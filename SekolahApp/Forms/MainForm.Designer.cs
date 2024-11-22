namespace SekolahApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataPelajarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSekolahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataKotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataPelajarToolStripMenuItem,
            this.dataSekolahToolStripMenuItem,
            this.dataKotaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataPelajarToolStripMenuItem
            // 
            this.dataPelajarToolStripMenuItem.Name = "dataPelajarToolStripMenuItem";
            this.dataPelajarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.dataPelajarToolStripMenuItem.Text = "Data Pelajar";
            this.dataPelajarToolStripMenuItem.Click += new System.EventHandler(this.dataPelajarToolStripMenuItem_Click);
            // 
            // dataSekolahToolStripMenuItem
            // 
            this.dataSekolahToolStripMenuItem.Name = "dataSekolahToolStripMenuItem";
            this.dataSekolahToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.dataSekolahToolStripMenuItem.Text = "Data Sekolah";
            this.dataSekolahToolStripMenuItem.Click += new System.EventHandler(this.dataSekolahToolStripMenuItem_Click);
            // 
            // dataKotaToolStripMenuItem
            // 
            this.dataKotaToolStripMenuItem.Name = "dataKotaToolStripMenuItem";
            this.dataKotaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.dataKotaToolStripMenuItem.Text = "Data Kota";
            this.dataKotaToolStripMenuItem.Click += new System.EventHandler(this.dataKotaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataPelajarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSekolahToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataKotaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}