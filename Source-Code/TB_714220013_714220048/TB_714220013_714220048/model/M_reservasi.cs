using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TB_714220013_714220048.model
{
    class M_reservasi
    {
        string id_customer, nama, email, nohp, tipe_kamar, checkin, checkout, total;

        public M_reservasi()
        {
        }

        public M_reservasi(string id_customer, string nama, string email, string nohp, string tipe_kamar, string checkin, string checkout, string harga)
        {
            this.ID = id_customer;
            this.Nama = nama;
            this.Email = email;
            this.Nohp = nohp;
            this.Tipe = tipe_kamar;
            this.Checkin = checkin;
            this.Checkout = checkout;
            this.Total = total;
        }
            public string ID { get => id_customer; set => id_customer = value; }
            public string Nama { get => nama; set => nama = value; }
            public string Email { get => email; set => email = value; }
            public string Nohp { get => nohp; set => nohp = value; }
            public string Tipe { get => tipe_kamar; set => tipe_kamar = value; }
            public string Checkin { get => checkin; set => checkin = value; }
            public string Checkout { get => checkout; set => checkout = value; }
            public string Total { get => total; set => total = value; }
    }
}
