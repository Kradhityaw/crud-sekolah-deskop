using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SekolahApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void loadUC(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadUC(new StudentsUC());
        }

        private void dataPelajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUC(new StudentsUC());
        }

        private void dataSekolahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUC(new SekolahUC());
        }

        private void dataKotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUC(new KotaUC());
        }
    }
}
