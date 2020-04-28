using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Library.Database
{
    /// <summary>
    /// This is the class DB_AutomatData.
    /// </summary>
    public sealed class DB_AutomatData
    {
        private static volatile DB_AutomatData _instance;
        private static readonly object syncRoot = new Object();
        private DatabaseDataContext db;

        /// <summary>
        /// This is the constructor for the class DB_AutomatData.
        /// </summary>
        private DB_AutomatData()
        {
            db = new DatabaseDataContext();
        }

        /// <summary>
        /// This is a multi threaded singleton for the class DB_AutomatData.
        /// </summary>
        /// <returns>_instance</returns>
        public static DB_AutomatData GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new DB_AutomatData();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method creates an automat data
        /// </summary>
        /// <param name="automatId"></param>
        /// <param name="kunde_id"></param>
        /// <param name="dato"></param>
        /// <param name="kr_ind"></param>
        /// <param name="kr_ud"></param>
        /// <returns>string</returns>
        public string Create(int automatId, int kunde_id, DateTime dato, int kr_ind, int kr_ud)
        {
            Table_AutomatData automat_data;
            string result;

            try
            {
                automat_data = new Table_AutomatData
                {
                    automat_id = automatId,
                    kunde_id = kunde_id,
                    dato = dato,
                    kr_ind = kr_ind,
                    kr_ud = kr_ud,
                    bsi = CalculateBSI(kr_ind, kr_ud)
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
        /// This method lists all automate datas.
        /// </summary>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> ListAll()
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds an automate data by its data_id.
        /// </summary>
        /// <param name="data_id"></param>
        /// <returns>Table_AutomatData</returns>
        public Table_AutomatData FindByDataId(int data_id)
        {
            Table_AutomatData automat_data;

            try
            {
                automat_data = db.Table_AutomatDatas.First(ad => ad.data_id.Equals(data_id));
            }

            catch (Exception exception)
            {
                automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                    
                };

                Console.WriteLine(exception.Message);
            }

            return automat_data;
        }

        /// <summary>
        /// This method finds a list of automate datas by their automat_id.
        /// </summary>
        /// <param name="automat_id"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByAutomatId(int automat_id)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.automat_id.Equals(automat_id) select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas by their kunde_id.
        /// </summary>
        /// <param name="kunde_id"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKundeId(int kunde_id)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kunde_id.Equals(kunde_id) select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas by their dato.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByDato(DateTime dato)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.dato.Equals(dato) select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the dato is equal or later than the given dato.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByDatoLater(DateTime dato)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.dato >= dato select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the dato is equal or earlier than the given dato.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByDatoEarlier(DateTime dato)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.dato <= dato select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas by their kr_ind.
        /// </summary>
        /// <param name="kr_ind"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrInd(int kr_ind)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kr_ind.Equals(kr_ind) select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the kr_ind is equal or higher than the given kr_ind.
        /// </summary>
        /// <param name="kr_ind"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrIndHigher(int kr_ind)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kr_ind >= kr_ind select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the kr_ind is equal or lower than the given kr_ind.
        /// </summary>
        /// <param name="kr_ind"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrIndLower(int kr_ind)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kr_ind <= kr_ind select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas by their kr_ud.
        /// </summary>
        /// <param name="kr_ud"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrUd(int kr_ud)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kr_ud.Equals(kr_ud) select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the kr_ud is equal or higher than the given kr_ud.
        /// </summary>
        /// <param name="kr_ud"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrUdHigher(int kr_ud)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kr_ud >= kr_ud select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the kr_ud is equal or lower than the given kr_ud.
        /// </summary>
        /// <param name="kr_ud"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByKrUdLower(int kr_ud)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.kr_ud <= kr_ud select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas by their bsi.
        /// </summary>
        /// <param name="bsi"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByBsi(int bsi)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.bsi.Equals(bsi) select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the bsi is equal or higher than the given bsi.
        /// </summary>
        /// <param name="bsi"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByBsiHigher(int bsi)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.bsi >= bsi select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method finds a list of automate datas where value of the bsi is equal or lower than the given bsi.
        /// </summary>
        /// <param name="bsi"></param>
        /// <returns>List<Table_AutomatData></returns>
        public List<Table_AutomatData> FindByBsiLower(int bsi)
        {
            List<Table_AutomatData> automat_dataer;

            try
            {
                automat_dataer = (from ad in db.Table_AutomatDatas where ad.bsi <= bsi select ad).ToList();
            }

            catch (Exception exception)
            {
                Table_AutomatData automat_data = new Table_AutomatData
                {
                    automat_id = -1000,
                    kunde_id = -1000,
                    dato = new DateTime(0000, 01, 01, 00, 00, 00, 00),
                    kr_ind = -1000,
                    kr_ud = -1000,
                    bsi = -1000
                };

                automat_dataer = new List<Table_AutomatData>
                {
                    automat_data
                };

                Console.WriteLine(exception.Message);
            }

            return automat_dataer;
        }

        /// <summary>
        /// This method updates an automate data.
        /// </summary>
        /// <param name="data_id"></param>
        /// <param name="automat_id"></param>
        /// <param name="kunde_id"></param>
        /// <param name="dato"></param>
        /// <param name="kr_ind"></param>
        /// <param name="kr_ud"></param>
        /// <returns>string</returns>
        public string Update(int data_id, int automat_id, int kunde_id, DateTime dato, int kr_ind, int kr_ud)
        {
            string result = "";

            try
            {
                var automat_data = from ad in db.Table_AutomatDatas where ad.data_id.Equals(data_id) select ad;

                foreach (Table_AutomatData tmp_automat_data in automat_data)
                {
                    tmp_automat_data.automat_id = automat_id;
                    tmp_automat_data.kunde_id = kunde_id;
                    tmp_automat_data.dato = dato;
                    tmp_automat_data.kr_ind = kr_ind;
                    tmp_automat_data.kr_ud = kr_ud;
                    tmp_automat_data.bsi = CalculateBSI(kr_ind, kr_ud);
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
        /// This method deletes an automate data.
        /// </summary>
        /// <param name="dataId"></param>
        /// <returns>string</returns>
        public string Delete(int dataId)
        {
            Table_AutomatData automat_data;
            string result;

            try
            {
                automat_data = FindByDataId(dataId);
                db.Table_AutomatDatas.DeleteOnSubmit(automat_data);
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
        /// This method calculates the bsi.
        /// </summary>
        /// <param name="kr_ind"></param>
        /// <param name="kr_ud"></param>
        /// <returns>int</returns>
        private int CalculateBSI(int kr_ind, int kr_ud)
        {
            int result;

            result = kr_ind - kr_ud;

            return result;
        }
    }
}
