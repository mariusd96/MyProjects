namespace Revolutii_care_au_schimbat_lumea
{
    partial class Fr_mod_abolire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fr_mod_abolire));
            this.text = new System.Windows.Forms.Button();
            this.inapoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.text.BackColor = System.Drawing.Color.White;
            this.text.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.text.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text.ForeColor = System.Drawing.Color.Black;
            this.text.Location = new System.Drawing.Point(883, 693);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(129, 31);
            this.text.TabIndex = 24;
            this.text.Text = "Ascunde text";
            this.text.UseVisualStyleBackColor = false;
            this.text.Click += new System.EventHandler(this.text_Click);
            // 
            // inapoi
            // 
            this.inapoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inapoi.BackColor = System.Drawing.Color.Red;
            this.inapoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inapoi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inapoi.ForeColor = System.Drawing.Color.White;
            this.inapoi.Location = new System.Drawing.Point(883, 725);
            this.inapoi.Name = "inapoi";
            this.inapoi.Size = new System.Drawing.Size(129, 31);
            this.inapoi.TabIndex = 23;
            this.inapoi.Text = "Înapoi";
            this.inapoi.UseVisualStyleBackColor = false;
            this.inapoi.Click += new System.EventHandler(this.inapoi_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(55, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(919, 189);
            this.label1.TabIndex = 25;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Fr_mod_abolire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Revolutii_care_au_schimbat_lumea.Properties.Resources.constitutie;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text);
            this.Controls.Add(this.inapoi);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fr_mod_abolire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fr_mod_abolire";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button text;
        private System.Windows.Forms.Button inapoi;
        private System.Windows.Forms.Label label1;
    }
}