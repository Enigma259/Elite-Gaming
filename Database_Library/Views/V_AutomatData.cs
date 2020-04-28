using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;

namespace Database_Library.Views
{
    public sealed class V_AutomatData
    {
        private static volatile V_AutomatData _instance;
        private static readonly object syncRoot = new Object();
        private DB_AutomatData db_automat_data;

        /// <summary>
        /// This is the constructor for the class V_AutomatData.
        /// </summary>
        private V_AutomatData()
        {
            this.db_automat_data = DB_AutomatData.GetInstance();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class V_AutomatData.
        /// </summary>
        /// <returns>_instance</returns>
        public static V_AutomatData GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new V_AutomatData();
                    }
                }
            }

            return _instance;
        }
        
        /// <summary>
        /// This method lists all automate datas.
        /// </summary>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> ListAll()
        {
            return db_automat_data.ListAll();
        }

        /// <summary>
        /// This method finds an automate data by its data_id.
        /// </summary>
        /// <param name="data_id"></param>
        /// <returns>Table_AutomatData</returns>
        public Table_AutomatData FindByDataId(int data_id)
        {
            return db_automat_data.FindByDataId(data_id);
        }

        /// <summary>
        /// This method finds a list of automate datas by their automat_id.
        /// </summary>
        /// <param name="automat_id"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByAutomatId(int automat_id)
        {
            return db_automat_data.FindByAutomatId(automat_id);
        }

        /// <summary>
        /// This method finds a list of automate datas by their kunde_id.
        /// </summary>
        /// <param name="kunde_id"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKundeId(int kunde_id)
        {
            return db_automat_data.FindByKundeId(kunde_id);
        }

        /// <summary>
        /// This method finds a list of automate datas by their dato.
        /// </summary>
        /// <param name="dato"></param>
        /// <param name="when"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByDato(DateTime dato, string when)
        {
            List<Table_AutomatData> result;

            switch(when)
            {
                case "Now":
                    result = db_automat_data.FindByDato(dato);
                    break;

                case "Later":
                    result = db_automat_data.FindByDatoLater(dato);
                    break;

                case "Earlier":
                    result = db_automat_data.FindByDatoEarlier(dato);
                    break;

                default:
                    result = new List<Table_AutomatData>();
                    break;
            }

            return result;
        }

        /// <summary>
        /// This method finds a list of automate datas by their kr_ind.
        /// </summary>
        /// <param name="kr_ind"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrInd(int kr_ind, string where)
        {
            List<Table_AutomatData> result;

            switch (where)
            {
                case "Specific":
                    result = db_automat_data.FindByKrInd(kr_ind);
                    break;

                case "Higher":
                    result = db_automat_data.FindByKrIndHigher(kr_ind);
                    break;

                case "Lower":
                    result = db_automat_data.FindByKrIndLower(kr_ind);
                    break;

                default:
                    result = new List<Table_AutomatData>();
                    break;
            }

            return result;
        }

        /// <summary>
        /// This method finds a list of automate datas by their kr_ud.
        /// </summary>
        /// <param name="kr_ud"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrUd(int kr_ud, string where)
        {
            List<Table_AutomatData> result;

            switch (where)
            {
                case "Specific":
                    result = db_automat_data.FindByKrUd(kr_ud);
                    break;

                case "Higher":
                    result = db_automat_data.FindByKrUdHigher(kr_ud);
                    break;

                case "Lower":
                    result = db_automat_data.FindByKrUdLower(kr_ud);
                    break;

                default:
                    result = new List<Table_AutomatData>();
                    break;
            }

            return result;
        }

        /// <summary>
        /// This method finds a list of automate datas by their bsi.
        /// </summary>
        /// <param name="bsi"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByBsi(int bsi, string where)
        {
            List<Table_AutomatData> result;

            switch (where)
            {
                case "Specific":
                    result = db_automat_data.FindByBsi(bsi);
                    break;

                case "Higher":
                    result = db_automat_data.FindByBsiHigher(bsi);
                    break;

                case "Lower":
                    result = db_automat_data.FindByBsiLower(bsi);
                    break;

                default:
                    result = new List<Table_AutomatData>();
                    break;
            }

            return result;
        }
    }
}
