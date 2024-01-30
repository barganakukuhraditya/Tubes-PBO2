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
    public partial class FormTipeKamar : Form
    {
        Koneksi koneksi = new Koneksi();
        M_tipe m_tipe = new M_tipe();
        string id_tipekamar;

        public void Tampil()
        {
            string query = "SELECT * FROM tipe_kamar";

            // Query
            DataTipeKamar.DataSource = koneksi.ShowData(query);

            // Mengubah nama kolom tabel
            DataTipeKamar.Columns[0].HeaderText = "ID Tipe Kamar";
            DataTipeKamar.Columns[1].HeaderText = "Tipe Kamar";
        }

        public void resetForm()
        {
            cbTipe.SelectedIndex = -1;
            tbCari.Text = "";
        }

        public FormTipeKamar()
        {
            InitializeComponent();
        }

        private void FormTipeKamar_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cbTipe.SelectedIndex == -1)
            {
                MessageBox.Show("Harap pilih tipe kamar dengan benar!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TipeKamar tipekamar = new TipeKamar();
                m_tipe.Tipe = cbTipe.Text;

                tipekamar.Insert(m_tipe);

                resetForm();
                Tampil();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (cbTipe.SelectedIndex == -1)
            {
                MessageBox.Show("Ubah data dengan benar!", "Peringatan!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TipeKamar tipekamar = new TipeKamar();
                m_tipe.Tipe = cbTipe.Text;

                tipekamar.Update(m_tipe,id_tipekamar);

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
                TipeKamar tipekamar = new TipeKamar();
                tipekamar.Delete(id_tipekamar);
                resetForm();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
            Tampil();
        }

        private void DataTipeKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_tipekamar = DataTipeKamar.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbTipe.Text = DataTipeKamar.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            // Query Search Data
            DataTipeKamar.DataSource = koneksi.ShowData("SELECT * FROM tipe_kamar WHERE id_tipekamar LIKE '%" + tbCari.Text + "%' OR tipe_kamar LIKE '%" + tbCari.Text + "%'");
        }
    }
}
