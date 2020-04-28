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

        public CTR_kunde()
        {
            this.db_kunde = DB_Kunde.GetInstance();
            this.v_kunde = V_Kunde.GetInstance();
        }

        public string Create(string navn)
        {
            return db_kunde.Create(navn);
        }

        public string Update(int kunde_id, string navn)
        {
            return db_kunde.Update(kunde_id, navn);
        }

        public string Delete(int kunde_id)
        {
            return db_kunde.Delete(kunde_id);
        }
    }
}
