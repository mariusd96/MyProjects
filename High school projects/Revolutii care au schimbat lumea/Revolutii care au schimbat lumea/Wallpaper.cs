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
    public partial class Wallpaper : Form
    {
        public Wallpaper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void da_Click(object sender, EventArgs e)
        {
            Wall form = new Wall();
            form.Show();
            this.Hide();
        }

        private void nu_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void iesire_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void bibliografie_Click(object sender, EventArgs e)
        {
            Bibliografie form = new Bibliografie();
            form.Show();
            this.Hide();
        }

        private void aplicatii_Click(object sender, EventArgs e)
        {
            Aplicatii form = new Aplicatii();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
        }

    }
}
