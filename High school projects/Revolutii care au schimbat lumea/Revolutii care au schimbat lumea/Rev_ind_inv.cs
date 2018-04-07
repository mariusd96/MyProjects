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
    public partial class Rev_ind_inv : Form
    {
        public Rev_ind_inv()
        {
            InitializeComponent();
        }

        private void Rev_ind_inv_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rev_ind form = new Rev_ind();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                label1.Text = "";
                pictureBox1.Image = null;
            }
            if (trackBar1.Value == 1)
            {
                label1.Text = "Locomotiva-George Stephenson(1814)";
                pictureBox1.Image = Properties.Resources.locomotiva_cu_abur;
            }
            if (trackBar1.Value == 2)
            {
                label1.Text = "Fotografia-Nicephore Niepce (1816)";
                pictureBox1.Image = Properties.Resources.fotografia;
            }
            if (trackBar1.Value == 3)
            {
                label1.Text = "Telegraful prin fir-Samuel Morse (1840)";
                pictureBox1.Image = Properties.Resources.telegraf;
            }
            if (trackBar1.Value == 4)
            {
                label1.Text = "Convertizorul pentru producerea oțelului-Henry Bessemer (1856)";
                pictureBox1.Image = Properties.Resources.otel;
            }
            if (trackBar1.Value == 5)
            {
                label1.Text = "Pasteurizarea alimentelor-Louis Pasteur (1863)";
                pictureBox1.Image = Properties.Resources.pasteurizare;
            }
            if (trackBar1.Value == 6)
            {
                label1.Text = "Dinamita-Alfred Nobel (1867)";
                pictureBox1.Image = Properties.Resources.dinamita;
            }
            if (trackBar1.Value == 7)
            {
                label1.Text = "Telefonul-Alexander Graham Bell (1876)";
                pictureBox1.Image = Properties.Resources.telefon;
            }
            if (trackBar1.Value == 8)
            {
                label1.Text = "Bicicleta-H.G. Lawson (1876)";
                pictureBox1.Image = Properties.Resources.istoria_bicicletei;
            }
            if (trackBar1.Value == 9)
            {
                label1.Text = "Fonograful-Thomas Edison (1877)";
                pictureBox1.Image = Properties.Resources.Fonograf;
            }
            if (trackBar1.Value == 10)
            {
                label1.Text = "Becul-Thomas Edison (1879)";
                pictureBox1.Image = Properties.Resources.compunere_bec;
            }
            if (trackBar1.Value == 11)
            {
                label1.Text = "Automobilul-Gottlieb Daimler și Karl Benz (1885)";
                pictureBox1.Image = Properties.Resources.automobilul;
            }
            if (trackBar1.Value == 12)
            {
                label1.Text = "Cinematograful-Frații Lumiere (1895)";
                pictureBox1.Image = Properties.Resources.cinematograful;
            }
        }
    }
}
