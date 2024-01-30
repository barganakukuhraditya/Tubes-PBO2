using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TB_714220013_714220048.view
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataReservasiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormReservasi frmReservasi = new FormReservasi();
            frmReservasi.MdiParent = this;
            frmReservasi.WindowState = FormWindowState.Maximized;
            frmReservasi.Show();
        }

        private void dataKamarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataKamar frmDataKamar = new FormDataKamar();
            frmDataKamar.MdiParent = this;
            frmDataKamar.WindowState = FormWindowState.Maximized;
            frmDataKamar.Show();
        }

        private void tipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTipeKamar frmTipeKamar = new FormTipeKamar();
            frmTipeKamar.MdiParent = this;
            frmTipeKamar.WindowState = FormWindowState.Maximized;
            frmTipeKamar.Show();
        }
    }
}
