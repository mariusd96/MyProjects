namespace Revolutii_care_au_schimbat_lumea
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.start = new System.Windows.Forms.Button();
            this.cuprins = new System.Windows.Forms.Button();
            this.iesire = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.start.BackColor = System.Drawing.Color.White;
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.FlatAppearance.BorderSize = 0;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start.Location = new System.Drawing.Point(269, 649);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(150, 40);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // cuprins
            // 
            this.cuprins.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cuprins.BackColor = System.Drawing.Color.White;
            this.cuprins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cuprins.FlatAppearance.BorderSize = 0;
            this.cuprins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuprins.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cuprins.Location = new System.Drawing.Point(424, 649);
            this.cuprins.Name = "cuprins";
            this.cuprins.Size = new System.Drawing.Size(150, 40);
            this.cuprins.TabIndex = 1;
            this.cuprins.Text = "Cuprins";
            this.cuprins.UseVisualStyleBackColor = false;
            this.cuprins.Click += new System.EventHandler(this.cuprins_Click);
            // 
            // iesire
            // 
            this.iesire.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.iesire.BackColor = System.Drawing.Color.Red;
            this.iesire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iesire.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.iesire.FlatAppearance.BorderSize = 0;
            this.iesire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iesire.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iesire.ForeColor = System.Drawing.Color.White;
            this.iesire.Location = new System.Drawing.Point(580, 649);
            this.iesire.Name = "iesire";
            this.iesire.Size = new System.Drawing.Size(150, 40);
            this.iesire.TabIndex = 2;
            this.iesire.Text = "Ieşire";
            this.iesire.UseVisualStyleBackColor = false;
            this.iesire.Click += new System.EventHandler(this.iesire_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Revolutii_care_au_schimbat_lumea.Properties.Resources.scris;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(121, 550);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(754, 80);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Revolutii_care_au_schimbat_lumea.Properties.Resources.revolutia_americana1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.iesire);
            this.Controls.Add(this.cuprins);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button cuprins;
        private System.Windows.Forms.Button iesire;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}