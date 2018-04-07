namespace Tari_si_capitale
{
    partial class TA_Asia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TA_Asia));
            this.label1 = new System.Windows.Forms.Label();
            this.iesire = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(146, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 90);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // iesire
            // 
            this.iesire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iesire.BackColor = System.Drawing.Color.Red;
            this.iesire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iesire.FlatAppearance.BorderSize = 0;
            this.iesire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iesire.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iesire.ForeColor = System.Drawing.Color.White;
            this.iesire.Location = new System.Drawing.Point(916, 721);
            this.iesire.Margin = new System.Windows.Forms.Padding(0);
            this.iesire.Name = "iesire";
            this.iesire.Size = new System.Drawing.Size(99, 38);
            this.iesire.TabIndex = 14;
            this.iesire.TabStop = false;
            this.iesire.Text = "Ieşire";
            this.iesire.UseVisualStyleBackColor = false;
            this.iesire.Click += new System.EventHandler(this.iesire_Click);
            // 
            // restart
            // 
            this.restart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restart.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restart.Location = new System.Drawing.Point(916, 677);
            this.restart.Margin = new System.Windows.Forms.Padding(0);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(99, 38);
            this.restart.TabIndex = 13;
            this.restart.TabStop = false;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // next
            // 
            this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.next.Location = new System.Drawing.Point(916, 633);
            this.next.Margin = new System.Windows.Forms.Padding(0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(99, 38);
            this.next.TabIndex = 12;
            this.next.TabStop = false;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // TA_Asia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tari_si_capitale.Properties.Resources.fuji2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iesire);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.next);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TA_Asia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TA_Asia";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button iesire;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button next;
    }
}