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
    public partial class Rebus : Form
    {
        public Rebus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aplicatii form = new Aplicatii();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "E" && textBox2.Text == "D" && textBox3.Text == "I" && textBox6.Text == "S" && textBox5.Text == "O" && textBox4.Text == "N")
            {
                textBox1.BackColor = Color.Green;
                textBox2.BackColor = Color.Green;
                textBox3.BackColor = Color.Green;
                textBox4.BackColor = Color.Green;
                textBox5.BackColor = Color.Green;
                textBox6.BackColor = Color.Green;
            }
            else
            {
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
                textBox4.BackColor = Color.Red;
                textBox5.BackColor = Color.Red;
                textBox6.BackColor = Color.Red;
            }
            if (textBox12.Text == "D" && textBox11.Text == "I" && textBox10.Text == "N" && textBox9.Text == "A" && textBox8.Text == "M" && textBox7.Text == "I" && textBox13.Text == "T" && textBox63.Text == "A")
            {
                textBox12.BackColor = Color.Green;
                textBox11.BackColor = Color.Green;
                textBox10.BackColor = Color.Green;
                textBox9.BackColor = Color.Green;
                textBox8.BackColor = Color.Green;
                textBox7.BackColor = Color.Green;
                textBox13.BackColor = Color.Green;
                textBox63.BackColor = Color.Green;
            }
            else 
            {
                textBox12.BackColor = Color.Red;
                textBox11.BackColor = Color.Red;
                textBox10.BackColor = Color.Red;
                textBox9.BackColor = Color.Red;
                textBox8.BackColor = Color.Red;
                textBox7.BackColor = Color.Red;
                textBox13.BackColor = Color.Red;
                textBox63.BackColor = Color.Red;
            }
            if (textBox21.Text == "C" && textBox20.Text == "O" && textBox19.Text == "N" && textBox18.Text == "V" && textBox17.Text == "E" && textBox16.Text == "R" && textBox15.Text == "T" && textBox14.Text == "I" && textBox24.Text == "Z" && textBox23.Text == "O" && textBox22.Text == "R")
            {
                textBox21.BackColor = Color.Green;
                textBox20.BackColor = Color.Green;
                textBox19.BackColor = Color.Green;
                textBox18.BackColor = Color.Green;
                textBox17.BackColor = Color.Green;
                textBox16.BackColor = Color.Green;
                textBox15.BackColor = Color.Green;
                textBox14.BackColor = Color.Green;
                textBox24.BackColor = Color.Green;
                textBox23.BackColor = Color.Green;
                textBox22.BackColor = Color.Green;
            }
            else
            {
                textBox21.BackColor = Color.Red;
                textBox20.BackColor = Color.Red;
                textBox19.BackColor = Color.Red;
                textBox18.BackColor = Color.Red;
                textBox17.BackColor = Color.Red;
                textBox16.BackColor = Color.Red;
                textBox15.BackColor = Color.Red;
                textBox14.BackColor = Color.Red;
                textBox24.BackColor = Color.Red;
                textBox23.BackColor = Color.Red;
                textBox22.BackColor = Color.Red;
            }
            if (textBox31.Text == "M" && textBox30.Text == "O" && textBox29.Text == "R" && textBox28.Text == "S" && textBox27.Text == "E")
            {
                textBox31.BackColor = Color.Green;
                textBox30.BackColor = Color.Green;
                textBox29.BackColor = Color.Green;
                textBox28.BackColor = Color.Green;
                textBox27.BackColor = Color.Green;
            }
            else
            {
                textBox31.BackColor = Color.Red;
                textBox30.BackColor = Color.Red;
                textBox29.BackColor = Color.Red;
                textBox28.BackColor = Color.Red;
                textBox27.BackColor = Color.Red;
            }
            if (textBox32.Text == "N" && textBox33.Text == "O" && textBox34.Text == "B" && textBox26.Text == "E" && textBox25.Text == "L")
            {
                textBox32.BackColor = Color.Green;
                textBox33.BackColor = Color.Green;
                textBox34.BackColor = Color.Green;
                textBox26.BackColor = Color.Green;
                textBox25.BackColor = Color.Green;
            }
            else
            {
                textBox32.BackColor = Color.Red;
                textBox33.BackColor = Color.Red;
                textBox34.BackColor = Color.Red;
                textBox26.BackColor = Color.Red;
                textBox25.BackColor = Color.Red;
            }
            if (textBox44.Text == "I" && textBox41.Text == "Z" && textBox40.Text == "O" && textBox39.Text == "L" && textBox35.Text == "A" && textBox38.Text == "Ţ" && textBox37.Text == "I" && textBox36.Text == "E")
            {
                textBox44.BackColor = Color.Green;
                textBox41.BackColor = Color.Green;
                textBox40.BackColor = Color.Green;
                textBox39.BackColor = Color.Green;
                textBox35.BackColor = Color.Green;
                textBox35.BackColor = Color.Green;
                textBox38.BackColor = Color.Green;
                textBox37.BackColor = Color.Green;
                textBox36.BackColor = Color.Green;
            }
            else
            {
                textBox44.BackColor = Color.Red;
                textBox41.BackColor = Color.Red;
                textBox40.BackColor = Color.Red;
                textBox39.BackColor = Color.Red;
                textBox35.BackColor = Color.Red;
                textBox35.BackColor = Color.Red;
                textBox38.BackColor = Color.Red;
                textBox37.BackColor = Color.Red;
                textBox36.BackColor = Color.Red;
            }
            if (textBox47.Text == "C" && textBox43.Text == "I" && textBox42.Text == "N" && textBox48.Text == "E" && textBox49.Text == "M" && textBox50.Text == "A" && textBox51.Text == "T" && textBox52.Text == "O" && textBox53.Text == "G" && textBox54.Text == "R" && textBox55.Text == "A" && textBox56.Text == "F")
            {
                textBox47.BackColor = Color.Green;
                textBox43.BackColor = Color.Green;
                textBox42.BackColor = Color.Green;
                textBox48.BackColor = Color.Green;
                textBox49.BackColor = Color.Green;
                textBox50.BackColor = Color.Green;
                textBox51.BackColor = Color.Green;
                textBox52.BackColor = Color.Green;
                textBox53.BackColor = Color.Green;
                textBox54.BackColor = Color.Green;
                textBox55.BackColor = Color.Green;
                textBox56.BackColor = Color.Green;
            }
            else
            {
                textBox47.BackColor = Color.Red;
                textBox43.BackColor = Color.Red;
                textBox42.BackColor = Color.Red;
                textBox48.BackColor = Color.Red;
                textBox49.BackColor = Color.Red;
                textBox50.BackColor = Color.Red;
                textBox51.BackColor = Color.Red;
                textBox52.BackColor = Color.Red;
                textBox53.BackColor = Color.Red;
                textBox54.BackColor = Color.Red;
                textBox55.BackColor = Color.Red;
                textBox56.BackColor = Color.Red;
            }
            if (textBox62.Text == "D" && textBox61.Text == "A" && textBox60.Text == "I" && textBox59.Text == "M" && textBox58.Text == "L" && textBox46.Text == "E" && textBox57.Text == "R")
            {
                textBox62.BackColor = Color.Green;
                textBox61.BackColor = Color.Green;
                textBox60.BackColor = Color.Green;
                textBox59.BackColor = Color.Green;
                textBox58.BackColor = Color.Green;
                textBox46.BackColor = Color.Green;
                textBox57.BackColor = Color.Green;
            }
            else
            {
                textBox62.BackColor = Color.Red;
                textBox61.BackColor = Color.Red;
                textBox60.BackColor = Color.Red;
                textBox59.BackColor = Color.Red;
                textBox58.BackColor = Color.Red;
                textBox46.BackColor = Color.Red;
                textBox57.BackColor = Color.Red;
            }
        }
    }
}
