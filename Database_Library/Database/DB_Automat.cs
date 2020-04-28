using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Library.Database
{
    /// <summary>
    /// This is the class DB_Automat.
    /// </summary>
    public sealed class DB_Automat
    {
        private static volatile DB_Automat _instance;
        private static readonly object syncRoot = new Object();
        private DatabaseDataContext db;

        /// <summary>
        /// This is the constructor for the class DB_Automat.
        /// </summary>
        private DB_Automat()
        {
            db = new DatabaseDataContext();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class DB_Automat.
        /// </summary>
        /// <returns>_instance</returns>
        public static DB_Automat GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new DB_Automat();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method creates an automat.
        /// </summary>
        /// <param name="kunde_id"></param>
        /// <param name="serienummer"></param>
        /// <param name="spilnavn"></param>
        /// <returns>string</returns>
        public string Create(int kunde_id, string serienummer, string spilnavn)
        {
            Table_Automat automat;
            string result;

            try
            {
                automat = new Table_Automat
                {
                    kunde_id = kunde_id,
                    serienummer = serienummer,
                    spilnavn = spilnavn
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

        /// <summary>
        /// This method lists all automats.
        /// </summary>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> ListAll()
        {
            List<Table_Automat> automater;

            try
            {
                automater = (from a in db.Table_Automats select a).ToList();
            }

            catch (Exception exception)
            {
                Table_Automat automat = new Table_Automat
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    serienummer = "ERROR",
                    spilnavn = exception.Message
                };

                automater = new List<Table_Automat>
                {
                    automat
                };
            }

            return automater;
        }

        /// <summary>
        /// This method finds an automat by their automat_id.
        /// </summary>
        /// <param name="automat_id"></param>
        /// <returns>Table_Automat</returns>
        public Table_Automat FindByAutomatId(int automat_id)
        {
            Table_Automat automat;

            try
            {
                automat = db.Table_Automats.First(a => a.automat_id.Equals(automat_id));
            }

            catch (Exception exception)
            {
                automat = new Table_Automat
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    serienummer = "ERROR",
                    spilnavn = exception.Message
                };

            }

            return automat;
        }

        /// <summary>
        /// This method finds a list of automates by their kunde_id.
        /// </summary>
        /// <param name="kunde_id"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindByKundeId(int kunde_id)
        {
            List<Table_Automat> automater;

            try
            {
                automater = (from a in db.Table_Automats where a.kunde_id.Equals(kunde_id) select a).ToList();
            }

            catch (Exception exception)
            {
                Table_Automat automat = new Table_Automat
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    serienummer = "ERROR",
                    spilnavn = exception.Message
                };

                automater = new List<Table_Automat>
                {
                    automat
                };
            }

            return automater;
        }

        /// <summary>
        /// This method finds a list of automates by their serienummer.
        /// </summary>
        /// <param name="serienummer"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindBySerienummer(string serienummer)
        {
            List<Table_Automat> automater;

            try
            {
                automater = (from a in db.Table_Automats where a.serienummer.Equals(serienummer) select a).ToList();
            }

            catch (Exception exception)
            {
                Table_Automat automat = new Table_Automat
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    serienummer = "ERROR",
                    spilnavn = exception.Message
                };

                automater = new List<Table_Automat>
                {
                    automat
                };
            }

            return automater;
        }

        /// <summary>
        /// This method finds a list of automates by their spilnavn.
        /// </summary>
        /// <param name="spilnavn"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindBySpilnavn(string spilnavn)
        {
            List<Table_Automat> automater;

            try
            {
                automater = (from a in db.Table_Automats where a.spilnavn.Contains(spilnavn) select a).ToList();
            }

            catch (Exception exception)
            {
                Table_Automat automat = new Table_Automat
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    serienummer = "ERROR",
                    spilnavn = exception.Message
                };

                automater = new List<Table_Automat>
                {
                    automat
                };
            }

            return automater;
        }

        /// <summary>
        /// This method updates an automat.
        /// </summary>
        /// <param name="automat_id"></param>
        /// <param name="kunde_id"></param>
        /// <param name="serienummer"></param>
        /// <param name="spilnavn"></param>
        /// <returns>string</returns>
        public string Update(int automatId, int kunde_id, string serienummer, string spilnavn)
        {
            string result = "";

            try
            {
                var automat = from a in db.Table_Automats where a.automat_id.Equals(automatId) select a;

                foreach (Table_Automat tmp_automat in automat)
                {
                    tmp_automat.kunde_id = kunde_id;
                    tmp_automat.serienummer = serienummer;
                    tmp_automat.spilnavn = spilnavn;
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

        /// <summary>
        /// This method deletes an automat.
        /// </summary>
        /// <param name="automatId"></param>
        /// <returns>string</returns>
        public string Delete(int automatId)
        {
            Table_Automat automat;
            string result;

            try
            {
                automat = FindByAutomatId(automatId);
                db.Table_Automats.DeleteOnSubmit(automat);
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
