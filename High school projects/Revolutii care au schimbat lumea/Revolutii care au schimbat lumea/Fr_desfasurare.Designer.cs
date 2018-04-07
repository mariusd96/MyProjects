namespace Revolutii_care_au_schimbat_lumea
{
    partial class Fr_desfasurare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fr_desfasurare));
            this.button1 = new System.Windows.Forms.Button();
            this.moderat = new System.Windows.Forms.Button();
            this.radical = new System.Windows.Forms.Button();
            this.directorat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(770, 713);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Înapoi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // moderat
            // 
            this.moderat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.moderat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.moderat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.moderat.FlatAppearance.BorderSize = 0;
            this.moderat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moderat.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.moderat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.moderat.Location = new System.Drawing.Point(11, 713);
            this.moderat.Name = "moderat";
            this.moderat.Size = new System.Drawing.Size(247, 43);
            this.moderat.TabIndex = 4;
            this.moderat.Text = "Revoluţia moderată";
            this.moderat.UseVisualStyleBackColor = false;
            this.moderat.Click += new System.EventHandler(this.moderat_Click);
            // 
            // radical
            // 
            this.radical.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radical.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radical.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.radical.FlatAppearance.BorderSize = 0;
            this.radical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radical.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radical.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radical.Location = new System.Drawing.Point(264, 713);
            this.radical.Name = "radical";
            this.radical.Size = new System.Drawing.Size(247, 43);
            this.radical.TabIndex = 5;
            this.radical.Text = "Revoluţia radicală";
            this.radical.UseVisualStyleBackColor = false;
            this.radical.Click += new System.EventHandler(this.radical_Click);
            // 
            // directorat
            // 
            this.directorat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.directorat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.directorat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.directorat.FlatAppearance.BorderSize = 0;
            this.directorat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.directorat.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.directorat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.directorat.Location = new System.Drawing.Point(517, 713);
            this.directorat.Name = "directorat";
            this.directorat.Size = new System.Drawing.Size(247, 43);
            this.directorat.TabIndex = 6;
            this.directorat.Text = "Directoratul";
            this.directorat.UseVisualStyleBackColor = false;
            this.directorat.Click += new System.EventHandler(this.directorat_Click);
            // 
            // Fr_desfasurare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::Revolutii_care_au_schimbat_lumea.Properties.Resources.rev_fr;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.directorat);
            this.Controls.Add(this.radical);
            this.Controls.Add(this.moderat);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fr_desfasurare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fr_desfasurare";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_desfasurare_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button moderat;
        private System.Windows.Forms.Button radical;
        private System.Windows.Forms.Button directorat;
    }
}