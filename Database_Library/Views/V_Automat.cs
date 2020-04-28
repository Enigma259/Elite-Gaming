using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;

namespace Database_Library.Views
{
    /// <summary>
    /// This is the class V_Automat.
    /// </summary>
    public sealed class V_Automat
    {
        private static volatile V_Automat _instance;
        private static readonly object syncRoot = new Object();
        private DB_Automat db_automat;

        /// <summary>
        /// This is the constructor for the class V_Automat.
        /// </summary>
        private V_Automat()
        {
            this.db_automat = DB_Automat.GetInstance();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class V_Automat.
        /// </summary>
        /// <returns>_instance</returns>
        public static V_Automat GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new V_Automat();
                    }
                }
            }

            return _instance;
        }
        
        /// <summary>
        /// This method lists all automats.
        /// </summary>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> ListAll()
        {
            return db_automat.ListAll();
        }

        /// <summary>
        /// This method finds an automat by their automat_id.
        /// </summary>
        /// <param name="automat_id"></param>
        /// <returns>Table_Automat</returns>
        public Table_Automat FindByAutomatId(int automat_id)
        {
            return db_automat.FindByAutomatId(automat_id);
        }

        /// <summary>
        /// This method finds a list of automates by their kunde_id.
        /// </summary>
        /// <param name="kunde_id"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindByKundeId(int kunde_id)
        {
            return db_automat.FindByKundeId(kunde_id);
        }

        /// <summary>
        /// This method finds a list of automates by their serienummer.
        /// </summary>
        /// <param name="serienummer"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindBySerienummer(string serienummer)
        {
            return db_automat.FindBySerienummer(serienummer);
        }

        /// <summary>
        /// This method finds a list of automates by their spilnavn.
        /// </summary>
        /// <param name="spilnavn"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindBySpilnavn(string spilnavn)
        {
            return db_automat.FindBySpilnavn(spilnavn);
        }
    }
}
