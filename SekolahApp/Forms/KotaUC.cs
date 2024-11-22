using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SekolahApp.Forms
{
    public partial class KotaUC : UserControl
    {
        SekolahDBEntities db = new SekolahDBEntities();
        public KotaUC()
        {
            InitializeComponent();
        }

        void resetState()
        {
            bindingSource1.Clear();
            OnLoad(EventArgs.Empty);
        }

        private void KotaUC_Load(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            kotaBindingSource.DataSource = db.Kotas.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namaTextBox.Text))
            {
                Alerts.error("Pastikan semua data terisi!");
                return;
            }

            if (bindingSource1.Current is Kota kota)
            {
                db.Kotas.AddOrUpdate(kota);
                db.SaveChanges();

                Alerts.success("Berhasil menyimpan!");
                resetState();
            }
        }

        private void kotaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (kotaDataGridView.Rows[e.RowIndex].DataBoundItem is Kota kota)
            {
                if (e.ColumnIndex == delCol.Index) e.Value = "Hapus";
                if (e.ColumnIndex == editCol.Index) e.Value = "Ubah";
                if (e.ColumnIndex == sekolahCol.Index)
                {
                    var sekolah = db.Sekolahs.Where(f => f.KotaID == kota.ID).Count().ToString();
                    e.Value = $"{sekolah} Sekolah";
                }
                if (e.ColumnIndex == studentsCol.Index)
                {
                    var pelajar = db.Students.Where(f => f.KotaID == kota.ID).Count().ToString();
                    e.Value = $"{pelajar} Siswa";
                }
            }
        }

        private void kotaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (kotaDataGridView.Rows[e.RowIndex].DataBoundItem is Kota kota)
            {
                if (e.ColumnIndex == delCol.Index)
                {
                    if (Alerts.confirm($"Apakah kamu yakin menghapus {kota.Nama}?") == DialogResult.Yes)
                    {
                        try
                        {
                            db.Kotas.Remove(kota);
                            db.SaveChanges();

                            Alerts.success("Berhasil menghapus!");

                            resetState();
                        }
                        catch
                        {
                            Alerts.error("Gagal menghapus kota!");
                        }
                    }
                }
                if (e.ColumnIndex == editCol.Index)
                {
                    bindingSource1.DataSource = db.Kotas.AsNoTracking().FirstOrDefault(f => f.ID == kota.ID);
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var sql = db.Kotas.AsQueryable();
            if (!string.IsNullOrEmpty(textBox1.Text)) sql = db.Kotas.Where(f => f.Nama.Contains(textBox1.Text));
            kotaBindingSource.DataSource = sql.ToList();
        }
    }
}
