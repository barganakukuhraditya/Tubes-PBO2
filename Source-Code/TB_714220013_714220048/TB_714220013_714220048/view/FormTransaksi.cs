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

namespace TB_714220013_714220048.view
{
    public partial class FormTransaksi : Form
    {
        Koneksi koneksi = new Koneksi();

        public void Tampil()
        {
            // Query
            DataTransaksi.DataSource = koneksi.ShowData("SELECT * FROM t_transaksi");

            // Mengubah nama kolom tabel
            DataTransaksi.Columns[0].HeaderText = "ID Customer";
            DataTransaksi.Columns[2].HeaderText = "Nama";
            DataTransaksi.Columns[1].HeaderText = "Tipe Kamar";
            DataTransaksi.Columns[3].HeaderText = "Check-in";
            DataTransaksi.Columns[4].HeaderText = "Check-out";
            DataTransaksi.Columns[5].HeaderText = "Qty";
            DataTransaksi.Columns[6].HeaderText = "Total Harga";
        }

        public void resetForm()
        {
            cbID.SelectedIndex = -1;
            tbNama.Text = "";
            tbTipe.Text = "";
            tbHarga.Text = "";
            tbQty.Text = "";
            tbTotal.Text = "";
        }

        public FormTransaksi()
        {
            InitializeComponent();
            tbNama.ReadOnly = true;
            tbNama.Enabled = false;
            tbTipe.ReadOnly = true;
            tbTipe.Enabled = false;
            tbHarga.ReadOnly = true;
            tbHarga.Enabled = false;
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void DataTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
