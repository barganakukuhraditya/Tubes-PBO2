using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_714220013_714220048.model
{
    class M_transaksi
    {
        string id_customer, qty, total;

        public M_transaksi(string id_transaksi, string id_customer, string qty, string total)
        {
            this.Id_customer = id_customer;
            this.Qty = qty;
            this.Total = total;
        }

        public string Id_customer { get => id_customer; set => id_customer = value; }
        public string Qty { get => qty; set => qty = value; }
        public string Total { get => total; set => total = value; }
    }
}
