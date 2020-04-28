using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Library.Database;
using Database_Library.Views;

namespace Database_Library.Controllers
{
    public sealed class CTR_AutomatData
    {
        private DB_AutomatData db_automat_data;
        private CTR_kunde ctr_kunde;
        private CTR_Automat ctr_automat;
        private V_AutomatData v_automat_data;

        public CTR_AutomatData()
        {
            this.db_automat_data = DB_AutomatData.GetInstance();
            this.ctr_kunde = new CTR_kunde();
            this.ctr_automat = new CTR_Automat();
            this.v_automat_data = V_AutomatData.GetInstance();
        }

        public string Create(int automat_id, int kunde_id, DateTime dato, int kr_ind, int kr_ud)
        {
            return db_automat_data.Create(automat_id, kunde_id, dato, kr_ind, kr_ud);
        }

        public string Update(int data_id, int automat_id, int kunde_id, DateTime dato, int kr_ind, int kr_ud)
        {
            return db_automat_data.Update(data_id, automat_id, kunde_id, dato, kr_ind, kr_ud);
        }

        public string Delete(int data_id)
        {
            return db_automat_data.Delete(data_id);
        }
    }
}
