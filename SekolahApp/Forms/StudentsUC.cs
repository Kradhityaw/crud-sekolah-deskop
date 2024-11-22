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
    public partial class StudentsUC : UserControl
    {
        SekolahDBEntities db = new SekolahDBEntities();
        public StudentsUC()
        {
            InitializeComponent();
        }

        void resetState()
        {
            bindingSource1.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            OnLoad(EventArgs.Empty);
        }

        private void StudentsUC_Load(object sender, EventArgs e)
        {
            studentBindingSource.DataSource = db.Students.ToList();
            sekolahBindingSource.DataSource = db.Sekolahs.ToList();
            kotaBindingSource.DataSource = db.Kotas.ToList();
            bindingSource1.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void studentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (studentDataGridView.Rows[e.RowIndex].DataBoundItem is Student student)
                {
                    if (e.ColumnIndex == kotaCol.Index) e.Value = student.Kota.Nama;
                    if (e.ColumnIndex == sekolahCol.Index) e.Value = student.Sekolah.Nama;
                    if (e.ColumnIndex == delCol.Index) e.Value = "Hapus";
                    if (e.ColumnIndex == editCol.Index) e.Value = "Ubah";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var query = db.Students.AsQueryable();
            if (!string.IsNullOrEmpty(textBox1.Text)) query = db.Students.Where(f => f.Nama.Contains(textBox1.Text) || f.Sekolah.Nama.Contains(textBox1.Text) || f.Kota.Nama.Contains(textBox1.Text));
            studentBindingSource.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namaTextBox.Text))
            {
                Alerts.error("Pastikan semua data terisi!");
                return;
            }

            if (bindingSource1.Current is Student student)
            {
                student.SekolahID = (int)comboBox1.SelectedValue;
                student.KotaID = (int)comboBox2.SelectedValue;

                db.Students.AddOrUpdate(student);
                db.SaveChanges();

                Alerts.success("Berhasil Menyimpan!");
                resetState();
            }
        }

        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (studentDataGridView.Rows[e.RowIndex].DataBoundItem is Student student)
            {
                if (e.ColumnIndex == delCol.Index)
                {
                    if (Alerts.confirm($"Yakin Menghapus {student.Nama}?") == DialogResult.Yes)
                    {
                        db.Students.Remove(student);
                        db.SaveChanges();

                        Alerts.success("Berhasil Menghapus!");
                        resetState();
                    }
                }
                if (e.ColumnIndex == editCol.Index)
                {
                    var query = db.Students.AsNoTracking().FirstOrDefault(f => f.ID == student.ID);
                    bindingSource1.DataSource = query;
                    comboBox1.SelectedValue = query.SekolahID;
                    comboBox2.SelectedValue = query.KotaID;
                }
            }
        }

        //private void comboBox1_TextUpdate(object sender, EventArgs e)
        //{
        //    DataView dv = comboBox1.DataSource as DataView;
        //    //string filterText = comboBox1.Text.Replace("'", "''");
        //    dv.RowFilter = db.Sekolahs.Where(f => f.Nama.Contains(comboBox1.Text)).ToList().ToString();
        //}
    }
}
