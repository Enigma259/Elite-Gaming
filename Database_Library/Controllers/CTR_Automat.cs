using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;
using Database_Library.Views;

namespace Database_Library.Controllers
{
    public sealed class CTR_Automat
    {
        private DB_Automat db_automat;
        private V_Automat v_automat;
        private V_Kunde v_kunde;
        private V_AutomatData v_automat_data;
        private CTR_AutomatData ctr_automat_data;

        public CTR_Automat()
        {
            this.db_automat = DB_Automat.GetInstance();
            this.v_automat = V_Automat.GetInstance();
            this.v_kunde = V_Kunde.GetInstance();
            this.v_automat_data = V_AutomatData.GetInstance();
            this.ctr_automat_data = new CTR_AutomatData();
        }

        public string Create(int kunde_id, string serienummer, string spilnavn)
        {
            string result;
            Table_Kunde kunde = v_kunde.FindByKundeId(kunde_id);

            if (kunde.Equals(null) || kunde.navn.Equals(null))
            {
                result = "The Customer doesn't exist.";
            }

            else if (kunde.kunde_id.Equals(-1000))
            {
                result = kunde.navn;
            }

            else
            {
                result = db_automat.Create(kunde_id, serienummer, spilnavn);
            }

            return result;
        }

        public string Update(int automat_id, int kunde_id, string serienummer, string spilnavn)
        {
            string result;
            Table_Kunde kunde = v_kunde.FindByKundeId(kunde_id);
            Table_Automat automat = v_automat.FindByAutomatId(automat_id);

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
                result = db_automat.Update(automat_id, kunde_id, serienummer, spilnavn);
            }

            return result;
        }

        public string Delete(int automat_id)
        {
            string result = DeleteAutomatData(automat_id);

            if(result.Equals("Success"))
            {
                result = db_automat.Delete(automat_id);
            }

            return result;
        }

        private string DeleteAutomatData(int automat_id)
        {
            List<Table_AutomatData> automat_dataer = v_automat_data.FindByAutomatId(automat_id);
            int index = 0;
            string result = "Success";

            while(result.Equals("Success") && index < automat_dataer.Count)
            {
                Table_AutomatData automat_data = automat_dataer[index];

                ctr_automat_data.Delete(automat_data.data_id);

                index++;
            }

            return result;
        }
    }
}