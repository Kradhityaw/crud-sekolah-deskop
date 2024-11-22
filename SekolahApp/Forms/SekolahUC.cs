using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SekolahApp.Forms
{
    public partial class SekolahUC : UserControl
    {
        SekolahDBEntities db = new SekolahDBEntities();
        public SekolahUC()
        {
            InitializeComponent();
        }

        void resetState()
        {
            bindingSource1.Clear();
            comboBox1.SelectedIndex = 0;
            OnLoad(EventArgs.Empty);
        }

        private void sekolahDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (sekolahDataGridView.Rows[e.RowIndex].DataBoundItem is Sekolah sekolah)
                {
                    if (e.ColumnIndex == delCol.Index) e.Value = "Hapus";
                    if (e.ColumnIndex == editCol.Index) e.Value = "Ubah";
                    if (e.ColumnIndex == kotaCol.Index) e.Value = sekolah.Kota?.Nama;
                    if (e.ColumnIndex == studentsCol.Index)
                    {
                        var data = db.Students.Where(f => f.SekolahID == sekolah.ID).Count().ToString();
                        e.Value = $"{data} Siswa";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SekolahUC_Load(object sender, EventArgs e)
        {
            sekolahBindingSource.DataSource = db.Sekolahs.ToList();
            comboBox1.DataSource = db.Kotas.ToList();
            bindingSource1.AddNew();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var sql = db.Sekolahs.AsQueryable();
            if (!string.IsNullOrEmpty(textBox1.Text)) sql = db.Sekolahs.Where(f => f.Nama.Contains(textBox1.Text) || f.Kota.Nama.Contains(textBox1.Text));
            sekolahBindingSource.DataSource = sql.ToList();
        }

        private void sekolahDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sekolahDataGridView.Rows[e.RowIndex].DataBoundItem is Sekolah sekolah)
            {
                if (e.ColumnIndex == delCol.Index)
                {
                    if (Alerts.confirm($"Apakah kamu yakin menghapus {sekolah.Nama}?") == DialogResult.Yes)
                    {
                        try
                        {
                            db.Sekolahs.Remove(sekolah);
                            db.SaveChanges();

                            Alerts.success("Berhasil Menghapus!");
                            resetState();
                        }
                        catch
                        {
                            Alerts.error("Gagal Menghapus Sekolah!");
                        }
                    }
                }
                if (e.ColumnIndex == editCol.Index)
                {
                    var sql = db.Sekolahs.AsNoTracking().FirstOrDefault(f => f.ID == sekolah.ID);
                    bindingSource1.DataSource = sql;
                    comboBox1.SelectedValue = sql.KotaID;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namaTextBox.Text))
            {
                Alerts.error("Pastikan semua data terisi!");
                return;
            }

            if (bindingSource1.Current is Sekolah sekolah)
            {
                sekolah.KotaID = (int)comboBox1.SelectedValue;

                db.Sekolahs.AddOrUpdate(sekolah);
                db.SaveChanges();

                Alerts.success("Berhasil Menyimpan Data!");
                resetState();
            }
        }
    }
}
