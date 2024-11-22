using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SekolahApp
{
    internal class Alerts
    {
        public static DialogResult success(string message)
        {
            return MessageBox.Show(message, "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult error(string message)
        {
            return MessageBox.Show(message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult confirm(string message)
        {
            return MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
