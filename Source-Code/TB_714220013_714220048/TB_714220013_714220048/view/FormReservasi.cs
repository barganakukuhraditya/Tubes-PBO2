using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TB_714220013_714220048.controller;
using TB_714220013_714220048.model;

namespace TB_714220013_714220048
{
    public partial class FormReservasi : Form
    {
        Koneksi koneksi = new Koneksi();
        M_reservasi m_rsv = new M_reservasi();

        public void Tampil()
        {
            string query = "SELECT t_reservasi.id_customer, t_reservasi.nama, t_reservasi.email, t_reservasi.nohp, tipe_kamar.tipe_kamar, kamar.kamar, kamar.harga, t_reservasi.checkin,  t_reservasi.checkout, t_reservasi.total FROM t_reservasi JOIN kamar ON t_reservasi.id_kamar = kamar.id_kamar JOIN tipe_kamar ON tipe_kamar.id_tipekamar = kamar.id_tipekamar";

            // Query
            DataReservasi.DataSource = koneksi.ShowData(query);

            // Mengubah nama kolom tabel
            DataReservasi.Columns[0].HeaderText = "ID Customer";
            DataReservasi.Columns[1].HeaderText = "Nama";
            DataReservasi.Columns[2].HeaderText = "Email";
            DataReservasi.Columns[3].HeaderText = "No HP";
            DataReservasi.Columns[4].HeaderText = "Tipe Kamar";
            DataReservasi.Columns[5].HeaderText = "Kamar";
            DataReservasi.Columns[6].HeaderText = "Harga";
            DataReservasi.Columns[7].HeaderText = "Check-in";
            DataReservasi.Columns[8].HeaderText = "Check-out";
            DataReservasi.Columns[9].HeaderText = "Total";
        }

        public void GetDataKamar()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM kamar");
            while (reader.Read())
            {
                cbKamar.Items.Add(reader.GetString("kamar"));
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        public void GetTipeKamar()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT tipe_kamar.tipe_kamar, kamar.harga FROM kamar JOIN tipe_kamar ON tipe_kamar.id_tipekamar = kamar.id_tipekamar WHERE kamar.kamar = '" + cbKamar.Text + "'");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbTipe.Text = reader.GetString(0);
                    tbHarga.Text = reader.GetString(1);
                }
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        public void resetForm()
        {
            tbNama.Text = "";
            tbEmail.Text = "";
            tbNOHP.Text = "";
            cbKamar.Text = "";
            tbTipe.Text = "";
            tbHarga.Text = "";
            dateCheckin.Value = DateTime.Today;
            dateCheckout.Value = DateTime.Today;
            tbTotal.Text = "";
            tbCari.Text = "";
        }

        public FormReservasi()
        {
            InitializeComponent();
        }

        private void FormReservasi_Load(object sender, EventArgs e)
        {
            Tampil();
            tbHarga.Enabled = false;
            tbHarga.ReadOnly = true;
            tbTotal.ReadOnly = true;
            tbTotal.Enabled = false;
            tbTipe.Enabled = false;
            tbTipe.ReadOnly = true;

            GetDataKamar();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (tbNama.Text == "" || tbEmail.Text == "" || tbNOHP.Text == "" || dateCheckin.Text == "" || dateCheckout.Text == "")
            {
                MessageBox.Show("Harap masukkan data dengan benar!", "Peringatan!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Reservasi reservasi = new Reservasi();
                m_rsv.Nama = tbNama.Text;
                m_rsv.Email = tbEmail.Text;
                m_rsv.Nohp = tbNOHP.Text;
                m_rsv.Checkin = dateCheckin.Text;
                m_rsv.Checkout = dateCheckout.Text;

                reservasi.Insert(m_rsv);

                resetForm();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
            Tampil();
        }

        private void DataReservasi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbNama.Text = DataReservasi.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbEmail.Text = DataReservasi.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbNOHP.Text = DataReservasi.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbTipe.Text = DataReservasi.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbKamar.Text = DataReservasi.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbHarga.Text = DataReservasi.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (DateTime.TryParse (DataReservasi.Rows[e.RowIndex].Cells[7].Value.ToString(), out DateTime checkinDate))
            {
                dateCheckin.Value = checkinDate;
            }
            else
            {
                dateCheckin.Value = DateTime.Now;
            }
            if (DateTime.TryParse (DataReservasi.Rows[e.RowIndex].Cells[8].Value.ToString(), out DateTime checkotDate))
            {
                dateCheckout.Value = checkotDate;
            }
            else
            {
                dateCheckout.Value = DateTime.Now;
            }
            tbTotal.Text = DataReservasi.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (tbNama.Text == "" || tbEmail.Text == "" || tbNOHP.Text == "" || dateCheckin.Text == "" || dateCheckout.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong!", "Peringatan!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Reservasi reservasi = new Reservasi();
                m_rsv.Nama = tbNama.Text;
                m_rsv.Email = tbEmail.Text;
                m_rsv.Nohp = tbNOHP.Text;
                m_rsv.Checkin = dateCheckin.Text;
                m_rsv.Checkout = dateCheckout.Text;

                string namaCustomer = tbNama.Text;
                reservasi.Update(m_rsv, namaCustomer);

                resetForm();
                Tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show(
                "Apakah yakin akan menghapus data ini?",
                "Perhatian",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (pesan == DialogResult.Yes)
            {
                Reservasi reservasi = new Reservasi();
                reservasi.Delete(tbNama.Text);
                resetForm();
                Tampil();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            DataReservasi.DataSource = koneksi.ShowData("SELECT t_reservasi.id_customer, t_reservasi.nama, t_reservasi.email, t_reservasi.nohp, t_reservasi.checkin, t_reservasi.checkout, t_reservasi.total, kamar.id_tipekamar, kamar.kamar, kamar.harga, kamar.status " +
                "FROM t_reservasi JOIN kamar ON t_reservasi.id_kamar = kamar.id_tipekamar " +
                "WHERE  t_reservasi.kamar LIKE '%" + tbCari.Text + "%' " +
                "OR kamar.kamar LIKE '%" + tbCari.Text + "%'");
        }

        private void cbKamar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTipeKamar();
        }

        private void dateCheckout_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkinDate = dateCheckin.Value;
            DateTime checkoutDate = dateCheckout.Value;

            TimeSpan selisih = checkoutDate.Subtract(checkinDate);
            int selisihHari = (int)selisih.TotalDays;

            if (int.TryParse(tbHarga.Text, out int harga))
            {
                int hasilPerhitungan = selisihHari * harga;
                tbTotal.Text = hasilPerhitungan.ToString();
            }
            else
            {
                MessageBox.Show("Format harga tidak valid.");
            }
        }

        private void FormatDigit(TextBox textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text) && textBox.Text.All(char.IsDigit))
            {
                string number = textBox.Text.Replace(".", "");

                number = string.Format("{0:#,##0}", double.Parse(number));

                textBox.Text = number;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private string FormatDigitAngka(int number)
        {
            return string.Format("Rp {0:N0}", number);
        }

        private void DataReservasi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int number))
                {
                    e.Value = FormatDigitAngka(number);
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == 9 && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int number))
                {
                    e.Value = FormatDigitAngka(number);
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
