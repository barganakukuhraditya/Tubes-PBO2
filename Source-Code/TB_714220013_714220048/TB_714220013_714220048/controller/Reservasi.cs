using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TB_714220013_714220048.model;

namespace TB_714220013_714220048.controller
{
    internal class Reservasi
    {
        Koneksi koneksi = new Koneksi();

        // Method Insert
        public bool Insert(M_reservasi reservasi)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("INSERT INTO t_reservasi (id_customer, nama, email, nohp, checkin, checkout, total) VALUES('" + reservasi.ID + "','" + reservasi.Nama + "','" + 
                    reservasi.Email + "','" + reservasi.Nohp + "','" + reservasi.Checkin + "','" + reservasi.Checkout + "','" + reservasi.Total + "')");
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        // Method Update
        public bool Update(M_reservasi reservasi, string id)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("UPDATE t_reservasi SET nama='" + reservasi.Nama + "'," + "email='" + reservasi.Email + "'," +
                    "nohp='" + reservasi.Nohp + "'," + reservasi.Checkin + "'," + reservasi.Checkout + "' WHERE id_customer= '" + id + "'");
                status = true;
                MessageBox.Show("Data Berhasil Diubah", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        // Method Delete
        public bool Delete(string id)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("DELETE FROM t_reservasi WHERE id_customer='" + id + "'");
                status = true;
                MessageBox.Show("Data Berhasil Dihapus", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
