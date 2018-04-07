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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Franta;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.map;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Revolutia_franceza form = new Revolutia_franceza();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Revolutia_americana form = new Revolutia_americana();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Wallpaper form = new Wallpaper();
            form.Show();
            this.Hide();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Anglia;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Portugalia;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rev_garoafelor_rosii form = new Rev_garoafelor_rosii();
            form.Show();
            this.Hide();
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Turcia;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rev_ind form = new Rev_ind();
            form.Show();
            this.Hide();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.harta_rev_ind;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources._1848_map;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.rev_1917_oct;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rev_glrioasa form = new Rev_glrioasa();
            form.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Rev1848 form = new Rev1848();
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Rev1917 form = new Rev1917();
            form.Show();
            this.Hide();
        }

        private void button7_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Anglia;
        }

        private void button7_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rev_eng form = new Rev_eng();
            form.Show();
            this.Hide();
        }
    }
}
