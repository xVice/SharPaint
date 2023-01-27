namespace SharPaint.Views
{
    partial class LayerView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.crownSectionPanel1 = new ReaLTaiizor.Controls.CrownSectionPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.airButton1 = new ReaLTaiizor.Controls.AirButton();
            this.moonLabel1 = new ReaLTaiizor.Controls.MoonLabel();
            this.crownSectionPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            this.crownSectionPanel1.Controls.Add(this.pictureBox2);
            this.crownSectionPanel1.Controls.Add(this.pictureBox1);
            this.crownSectionPanel1.Controls.Add(this.airButton1);
            this.crownSectionPanel1.Controls.Add(this.moonLabel1);
            this.crownSectionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crownSectionPanel1.Location = new System.Drawing.Point(0, 0);
            this.crownSectionPanel1.Name = "crownSectionPanel1";
            this.crownSectionPanel1.SectionHeader = null;
            this.crownSectionPanel1.Size = new System.Drawing.Size(177, 127);
            this.crownSectionPanel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SharPaint.Properties.Resources.icons8_eye_30px;
            this.pictureBox2.Location = new System.Drawing.Point(148, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(4, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // airButton1
            // 
            this.airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.airButton1.Image = null;
            this.airButton1.Location = new System.Drawing.Point(131, 100);
            this.airButton1.Name = "airButton1";
            this.airButton1.NoRounding = false;
            this.airButton1.Size = new System.Drawing.Size(41, 23);
            this.airButton1.TabIndex = 1;
            this.airButton1.Text = "Delete";
            this.airButton1.Transparent = false;
            this.airButton1.Click += new System.EventHandler(this.airButton1_Click);
            // 
            // moonLabel1
            // 
            this.moonLabel1.AutoSize = true;
            this.moonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel1.ForeColor = System.Drawing.Color.Gray;
            this.moonLabel1.Location = new System.Drawing.Point(4, 5);
            this.moonLabel1.Name = "moonLabel1";
            this.moonLabel1.Size = new System.Drawing.Size(35, 15);
            this.moonLabel1.TabIndex = 0;
            this.moonLabel1.Text = "Layer";
            // 
            // LayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crownSectionPanel1);
            this.Name = "LayerView";
            this.Size = new System.Drawing.Size(177, 127);
            this.Load += new System.EventHandler(this.LayerView_Load);
            this.crownSectionPanel1.ResumeLayout(false);
            this.crownSectionPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.MoonLabel moonLabel1;
        private ReaLTaiizor.Controls.AirButton airButton1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
