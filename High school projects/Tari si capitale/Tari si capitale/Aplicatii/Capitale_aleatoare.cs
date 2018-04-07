﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tari_si_capitale
{
    public partial class Capitale_aleatoare : Form
    {
        public Capitale_aleatoare()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            button2.Parent = pictureBox1;
            button2.BackColor = Color.Transparent;
            cAfrica.Parent = pictureBox1;
            cAfrica.BackColor = Color.Transparent;
            cAmericaN.Parent = pictureBox1;
            cAmericaN.BackColor = Color.Transparent;
            cAmericaS.Parent = pictureBox1;
            cAsia.Parent = pictureBox1;
            cAsia.BackColor = Color.Transparent;
            cAmericaS.BackColor = Color.Transparent;
            cEuropa.Parent = pictureBox1;
            cEuropa.BackColor = Color.Transparent;
            cOceania.Parent = pictureBox1;
            cOceania.BackColor = Color.Transparent;
            continente.Parent = pictureBox1;
            continente.BackColor = Color.Transparent;
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.Parent = pictureBox1;
                c.BackColor = Color.Transparent;
            }
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.Parent = pictureBox1;
                c.BackColor = Color.Transparent;
            }
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.Parent = pictureBox1;
                c.BackColor = Color.Transparent;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }
    }
}