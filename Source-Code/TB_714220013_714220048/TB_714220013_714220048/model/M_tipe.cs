using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_714220013_714220048.model
{
    internal class M_tipe
    {
        string id_tipekamar, tipe_kamar;

        public M_tipe()
        {
        }

        public M_tipe(string id_tipekamar, string tipe_kamar)
        {
            this.ID = id_tipekamar;
            this.Tipe = tipe_kamar;
        }
        public string ID { get => id_tipekamar; set => id_tipekamar = value; }
        public string Tipe { get => tipe_kamar; set => tipe_kamar = value; }
    }
}
