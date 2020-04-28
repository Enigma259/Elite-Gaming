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
        private CTR_kunde ctr_kunde;
        private V_Automat v_automat;

        public CTR_Automat()
        {
            this.db_automat = DB_Automat.GetInstance();
            this.ctr_kunde = new CTR_kunde();
            this.v_automat = V_Automat.GetInstance();
        }

        public string Create(int kunde_id, string serienummer, string spilnavn)
        {
            return db_automat.Create(kunde_id, serienummer, spilnavn);
        }

        public string Update(int automat_id, int kunde_id, string serienummer, string spilnavn)
        {
            return db_automat.Update(automat_id, kunde_id, serienummer, spilnavn);
        }

        public string Delete(int automat_id)
        {
            return db_automat.Delete(automat_id);
        }
    }
}
