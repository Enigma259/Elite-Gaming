﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Library.Database
{
    /// <summary>
    /// This is the class DB_Kunde.
    /// </summary>
    public sealed class DB_Kunde
    {
        private static volatile DB_Kunde _instance;
        private static readonly object syncRoot = new Object();
        private DatabaseDataContext db;

        /// <summary>
        /// This is the constructor for the class DB_Kunde.
        /// </summary>
        private DB_Kunde()
        {
            db = new DatabaseDataContext();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class DB_Kunde.
        /// </summary>
        /// <returns>_instance</returns>
        public static DB_Kunde GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new DB_Kunde();
                    }
                }
            }

            return _instance;
        }

        public string Create(string navn)
        {
            Table_Kunde kunde;
            string result;

            try
            {
                kunde = new Table_Kunde
                {
                    navn = navn
                };

                db.SubmitChanges();

                result = "Success";
            }

            catch (Exception exception)
            {
                result = exception.Message;
            }

            return result;
        }

        public List<Table_Kunde> ListAll()
        {
            List<Table_Kunde> kunder;

            try
            {
                kunder = (from k in db.Table_Kundes select k).ToList();
            }

            catch (Exception exception)
            {
                Table_Kunde kunde = new Table_Kunde
                {
                    navn = exception.Message
                };

                kunder = new List<Table_Kunde>
                {
                    kunde
                };
            }

            return kunder;
        }

        //
        public Table_Kunde FindByKundeId(int kundeId)
        {
            Table_Kunde kunde;

            try
            {
                kunde = db.Table_Kundes.First(k => k.kundeId.Equals(kundeId));
            }

            catch (Exception exception)
            {
                kunde = new Table_Kunde
                {
                    navn = exception.Message
                };

            }

            return kunde;
        }

        //
        public List<Table_Kunde> FindByNavn(string navn)
        {
            List<Table_Kunde> kunder;

            try
            {
                kunder = (from k in db.Table_Kundes where k.navn.Contains(navn) select k).ToList();
            }

            catch (Exception exception)
            {
                Table_Kunde kunde = new Table_Kunde
                {
                    navn = exception.Message
                };

                kunder = new List<Table_Kunde>
                {
                    kunde
                };
            }

            return kunder;
        }

        //
        public string Update(int kundeId, string navn)
        {
            string result = "";

            try
            {
                var kunde = from k in db.Table_Kundes where k.kundeId.Equals(kundeId) select k;

                foreach (Table_Kunde tmp_kunde in kunde)
                {
                    tmp_kunde.navn = navn;
                }

                db.SubmitChanges();
                result = "success";
            }

            catch (Exception exception)
            {
                result = exception.Message;
            }

            return result;
        }

        //
        public string Delete(int kundeId)
        {
            Table_Kunde kunde;
            string result;

            try
            {
                kunde = FindByKundeId(kundeId);
                db.Table_Kundes.DeleteOnSubmit(kunde);
                db.SubmitChanges();
                result = "success";
            }

            catch (Exception exception)
            {
                result = exception.Message;
            }

            return result;
        }
    }
}
