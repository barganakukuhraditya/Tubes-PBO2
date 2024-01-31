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

namespace TB_714220013_714220048.view
{
    public partial class FormDataKamar : Form
    {
        Koneksi koneksi = new Koneksi();
        M_kamar m_kamar = new M_kamar();
        string id_kamar;

        public void Tampil()
        {
            string query = "SELECT k.id_kamar, k.id_tipekamar, t.tipe_kamar, k.kamar, k.harga FROM kamar k JOIN tipe_kamar t ON (k.id_tipekamar = t.id_tipekamar)";
            DataKamar.DataSource = koneksi.ShowData(query);

            DataKamar.Columns[0].HeaderText = "ID";
            DataKamar.Columns[1].HeaderText = "ID Tipe Kamar";
            DataKamar.Columns[2].HeaderText = "Tipe Kamar";
            DataKamar.Columns[3].HeaderText = "Kamar";
            DataKamar.Columns[4].HeaderText = "Harga";
        }

        //ambil data tipe kamar dari table (tipe_kamar) untuk mengisi data pada combobox ID_tipeKamar
        public void GetDataKamar()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM tipe_kamar");
            while (reader.Read())
            {
                cbID.Items.Add(reader.GetString("id_tipekamar"));
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        public void GetTipeKamar()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT tipe_kamar FROM tipe_kamar WHERE id_tipekamar = '" + cbID.Text + "'");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbTipe.Text = reader.GetString(0);
                }
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        public FormDataKamar()
        {
            InitializeComponent();
            tbTipe.ReadOnly = true;
            tbTipe.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataKamar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_kamar = DataKamar.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbID.Text = DataKamar.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbTipe.Text = DataKamar.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbKamar.Text = DataKamar.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbHarga.Text = DataKamar.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            DataKamar.DataSource = koneksi.ShowData("SELECT k.id_kamar, k.id_tipekamar, t.tipe_kamar, k.kamar, k.harga " +
            "FROM kamar k JOIN tipe_kamar t ON k.id_tipekamar = t.id_tipekamar " +
            "WHERE k.kamar LIKE '%" + tbCari.Text + "%' " +
            "OR t.tipe_kamar LIKE '%" + tbCari.Text + "%'");
        }

        private void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTipeKamar();
        }

        public void resetForm()
        {
            cbID.SelectedIndex = -1;
            tbTipe.Text = "";
            tbKamar.Text = "";
            tbHarga.Text = "";
            tbCari.Text = "";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cbID.SelectedIndex == -1 || tbKamar.Text == "" || tbHarga.Text == "")
            {
               MessageBox.Show("Data tidak boleh kosong", "Peringatan",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Kamar kamar = new Kamar();
                m_kamar.ID = cbID.Text;
                m_kamar.Kamar = tbKamar.Text;
                m_kamar.Harga = tbHarga.Text;

                kamar.Insert(m_kamar);

                resetForm();
                Tampil();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (cbID.SelectedIndex == -1 || tbKamar.Text == "" || tbHarga.Text == "")
            {
               MessageBox.Show("Data tidak boleh kosong", "Peringatan",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Kamar kamar = new Kamar();
                m_kamar.Kamar = tbKamar.Text;
                m_kamar.Harga = tbHarga.Text;

                kamar.Update(m_kamar, id_kamar);
                resetForm();
                Tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah yakin akan menghapus data ini?",
            "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Kamar kamar = new Kamar();
                kamar.Delete(id_kamar);
                resetForm();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
            Tampil();
        }

        private void FormDataKamar_Load(object sender, EventArgs e)
        {
            Tampil();
            GetDataKamar();
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
 
        private void DataKamar_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)
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
