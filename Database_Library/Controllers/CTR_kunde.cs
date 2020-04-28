using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;
using Database_Library.Views;

namespace Database_Library.Controllers
{
    public sealed class CTR_kunde
    {
        private DB_Kunde db_kunde;
        private V_Kunde v_kunde;
        private V_Automat v_automat;
        private CTR_Automat ctr_automat;

        public CTR_kunde()
        {
            this.db_kunde = DB_Kunde.GetInstance();
            this.v_kunde = V_Kunde.GetInstance();
            this.v_automat = V_Automat.GetInstance();
            this.ctr_automat = new CTR_Automat();
        }

        public string Create(string navn)
        {
            return db_kunde.Create(navn);
        }

        public string Update(int kunde_id, string navn)
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
                result = db_kunde.Update(kunde_id, navn);
            }

            return result;
        }

        public string Delete(int kunde_id)
        {
            string result = DeleteAutomater(kunde_id);

            if (result.Equals("Success"));
            {
                result = db_kunde.Delete(kunde_id);
            }

            return result;
        }

        private string DeleteAutomater(int kunde_id)
        {
            List<Table_Automat> automater = v_automat.FindByKundeId(kunde_id);
            int index = 0;
            string result = "Success";

            while (result.Equals("Success") && index < automater.Count)
            {
                Table_Automat automat = automater[index];

                ctr_automat.Delete(automat.automat_id);

                index++;
            }

            return result;
        }
    }
}
