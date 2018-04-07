using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revolutii_care_au_schimbat_lumea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = (System.Drawing.Image)(Properties.Resources.animatie2);
            timer1.Start();
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wallpaper form = new Wallpaper();
            form.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                pictureBox1.Image = (System.Drawing.Image)(Properties.Resources.wallpaper1);
                label1.Visible = true;
                label1.BackColor = Color.Transparent;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Wallpaper form = new Wallpaper();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Wallpaper form = new Wallpaper();
            form.Show();
            this.Hide();
        }
    }
}
