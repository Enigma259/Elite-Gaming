using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;

namespace Database_Library.Views
{
    public sealed class V_Kunde
    {
        private static volatile V_Kunde _instance;
        private static readonly object syncRoot = new Object();
        private DB_Kunde db_kunde;

        /// <summary>
        /// This is the constructor for the class V_Kunde.
        /// </summary>
        private V_Kunde()
        {
            this.db_kunde = DB_Kunde.GetInstance();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class V_Kunde.
        /// </summary>
        /// <returns>_instance</returns>
        public static V_Kunde GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new V_Kunde();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method lists all customers
        /// </summary>
        /// <returns>List<Table_Kunde></returns>
        public List<Table_Kunde> ListAll()
        {
            return db_kunde.ListAll();
        }

        /// <summary>
        /// This method finds a customer by its kunde_id.
        /// </summary>
        /// <param name="kundeId"></param>
        /// <returns>Table_Kunde</returns>
        public Table_Kunde FindByKundeId(int kunde_id)
        {
            return db_kunde.FindByKundeId(kunde_id);
        }

        /// <summary>
        /// This method finds a list of customers by their navn.
        /// </summary>
        /// <param name="navn"></param>
        /// <returns>List<Table_Kunde></returns>
        public List<Table_Kunde> FindByNavn(string navn)
        {
            return db_kunde.FindByNavn(navn);
        }
    }
}
