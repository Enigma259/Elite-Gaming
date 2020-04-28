using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Library.Database
{
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
        /// <param name="kundeId"></param>
        /// <param name="serienummer"></param>
        /// <param name="spilnavn"></param>
        /// <returns>string</returns>
        public string Create(int kundeId, string serienummer, string spilnavn)
        {
            Table_Automat automat;
            string result;

            try
            {
                automat = new Table_Automat
                {
                    kundeId = kundeId,
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
        /// 
        /// </summary>
        /// <param name="automatId"></param>
        /// <param name="kundeId"></param>
        /// <param name="serienummer"></param>
        /// <param name="spilnavn"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> ListAll(int automatId, int kundeId, string serienummer, string spilnavn)
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
                    kundeId = -1000,
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
        /// This method finds an automat by their automatId.
        /// </summary>
        /// <param name="automatId"></param>
        /// <returns>Table_Automat</returns>
        public Table_Automat FindByAutomatId(int automatId)
        {
            Table_Automat automat;

            try
            {
                automat = db.Table_Automats.First(a => a.automatId.Equals(automatId));
            }

            catch (Exception exception)
            {
                automat = new Table_Automat
                {
                    kundeId = -1000,
                    serienummer = "ERROR",
                    spilnavn = exception.Message
                };

            }

            return automat;
        }

        /// <summary>
        /// This method finds a list of automates by their kundeId.
        /// </summary>
        /// <param name="kundeId"></param>
        /// <returns>List<Table_Automat></returns>
        public List<Table_Automat> FindByKundeId(int kundeId)
        {
            List<Table_Automat> automater;

            try
            {
                automater = (from a in db.Table_Automats where a.kundeId.Equals(kundeId) select a).ToList();
            }

            catch (Exception exception)
            {
                Table_Automat automat = new Table_Automat
                {
                    kundeId = -1000,
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
                    kundeId = -1000,
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
                    kundeId = -1000,
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
        /// <param name="automatId"></param>
        /// <param name="kundeId"></param>
        /// <param name="serienummer"></param>
        /// <param name="spilnavn"></param>
        /// <returns>string</returns>
        public string Update(int automatId, int kundeId, string serienummer, string spilnavn)
        {
            string result = "";

            try
            {
                var automat = from a in db.Table_Automats where a.automatId.Equals(automatId) select a;

                foreach (Table_Automat tmp_automat in automat)
                {
                    tmp_automat.kundeId = kundeId;
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
