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
    public partial class Fisa : Form
    {
        public Fisa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aplicatii form = new Aplicatii();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "New Hampshire") textBox1.BackColor = Color.Green;
            else textBox1.BackColor = Color.Red;
            if (textBox2.Text == "Massachusetts") textBox2.BackColor = Color.Green;
            else textBox2.BackColor = Color.Red;
            if (textBox3.Text == "New York") textBox3.BackColor = Color.Green;
            else textBox3.BackColor = Color.Red;
            if (textBox4.Text == "Rhode Island") textBox4.BackColor = Color.Green;
            else textBox4.BackColor = Color.Red;
            if (textBox5.Text == "Connecticut") textBox5.BackColor = Color.Green;
            else textBox5.BackColor = Color.Red;
            if (textBox6.Text == "Pennsylvania") textBox6.BackColor = Color.Green;
            else textBox6.BackColor = Color.Red;
            if (textBox7.Text == "New Jersey") textBox7.BackColor = Color.Green;
            else textBox7.BackColor = Color.Red;
            if (textBox8.Text == "Delaware") textBox8.BackColor = Color.Green;
            else textBox8.BackColor = Color.Red;
            if (textBox9.Text == "Maryland") textBox9.BackColor = Color.Green;
            else textBox9.BackColor = Color.Red;
            if (textBox10.Text == "Virginia") textBox10.BackColor = Color.Green;
            else textBox10.BackColor = Color.Red;
            if (textBox11.Text == "Carolina de Nord") textBox11.BackColor = Color.Green;
            else textBox11.BackColor = Color.Red;
            if (textBox12.Text == "Carolina de Sud") textBox12.BackColor = Color.Green;
            else textBox12.BackColor = Color.Red;
            if (textBox13.Text == "Georgia") textBox13.BackColor = Color.Green;
            else textBox13.BackColor = Color.Red;
        }
    }
}
