using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_714220013_714220048.model
{
    internal class M_kamar
    {
        string id_tipekamar, kamar, harga, status;

        public M_kamar()
        {
        }

        public M_kamar(string kamar, string harga)
        {
            this.ID = id_tipekamar;
            this.Kamar = kamar;
            this.Harga = harga;
            this.Status = status;
        }
        public string ID { get => id_tipekamar; set => id_tipekamar = value; }
        public string Kamar { get => kamar; set => kamar = value; }
        public string Harga { get => harga; set => harga = value; }
        public string Status { get => status; set => status = value; }
    }
}
