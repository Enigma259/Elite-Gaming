using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;
using Database_Library.Views;

namespace Database_Library.Controllers
{
    /// <summary>
    /// This is the class CTR_AutomatData.
    /// </summary>
    public sealed class CTR_AutomatData
    {
        private DB_AutomatData db_automat_data;
        private V_AutomatData v_automat_data;
        private V_Automat v_automat;
        private V_Kunde v_kunde;

        /// <summary>
        /// This is the constructor for the class CTR_AutomatData.
        /// </summary>
        public CTR_AutomatData()
        {
            this.db_automat_data = DB_AutomatData.GetInstance();
            this.v_automat_data = V_AutomatData.GetInstance();
            this.v_automat = V_Automat.GetInstance();
            this.v_kunde = V_Kunde.GetInstance();
        }

        /// <summary>
        /// This method creates an automat data.
        /// </summary>
        /// <param name="automat_id"></param>
        /// <param name="kunde_id"></param>
        /// <param name="dato"></param>
        /// <param name="kr_ind"></param>
        /// <param name="kr_ud"></param>
        /// <returns>string</returns>
        public string Create(int automat_id, int kunde_id, DateTime dato, int kr_ind, int kr_ud)
        {
            string result;
            Table_Automat automat = v_automat.FindByAutomatId(automat_id);
            Table_Kunde kunde = v_kunde.FindByKundeId(kunde_id);

            if (kunde.Equals(null) || kunde.navn.Equals(null))
            {
                result = "The Customer doesn't exist.";
            }

            else if (kunde.kunde_id.Equals(-1000))
            {
                result = kunde.navn;
            }

            else if (automat.Equals(null) || automat.spilnavn.Equals(null))
            {
                result = "The automat doesn't exist.";
            }

            else if (automat.automat_id.Equals(-1000))
            {
                result = automat.spilnavn;
            }

            else
            {
                result = db_automat_data.Create(automat_id, kunde_id, dato, kr_ind, kr_ud);
            }

            return result;
        }

        /// <summary>
        /// This method updates an automat data.
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

            string result;
            Table_Automat automat = v_automat.FindByAutomatId(automat_id);
            Table_Kunde kunde = v_kunde.FindByKundeId(kunde_id);
            Table_AutomatData automat_data = v_automat_data.FindByDataId(data_id);

            if (kunde.Equals(null) || kunde.navn.Equals(null))
            {
                result = "The Customer doesn't exist.";
            }

            else if (kunde.kunde_id.Equals(-1000))
            {
                result = kunde.navn;
            }

            else if (automat.Equals(null) || automat.spilnavn.Equals(null))
            {
                result = "The automat doesn't exist.";
            }

            else if (automat.automat_id.Equals(-1000))
            {
                result = automat.spilnavn;
            }

            else if (automat_data.Equals(null) || automat_data.dato.Equals(null))
            {
                result = "The automat data doesn't exist.";
            }

            else if (automat.automat_id.Equals(-1000))
            {
                result = "something went wrong when retrieving the automat data.";
            }

            else
            {
                result = db_automat_data.Update(data_id, automat_id, kunde_id, dato, kr_ind, kr_ud);
            }

            return result;
        }

        /// <summary>
        /// This method deletes an automat data.
        /// </summary>
        /// <param name="data_id"></param>
        /// <returns>string</returns>
        public string Delete(int data_id)
        {
            return db_automat_data.Delete(data_id);
        }
    }
}
