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
    public partial class Rev1917 : Form
    {
        int x;
        public Rev1917()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(),"rusia_cursor.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void introducere_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            pictureBox1.Visible = false;
            introducere.Visible = false;
            cauze.Visible = false;
            evenimente.Visible = false;
            consecinte.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 1;
        }

        private void cauze_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            pictureBox1.Visible = false;
            introducere.Visible = false;
            cauze.Visible = false;
            evenimente.Visible = false;
            consecinte.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 2;
        }

        private void evenimente_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            pictureBox1.Visible = false;
            introducere.Visible = false;
            cauze.Visible = false;
            evenimente.Visible = false;
            consecinte.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 3;
        }

        private void consecinte_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            pictureBox1.Visible = false;
            introducere.Visible = false;
            cauze.Visible = false;
            evenimente.Visible = false;
            consecinte.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 4;
        }

        private void introducere_Click_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            pictureBox1.Visible = false;
            introducere.Visible = false;
            cauze.Visible = false;
            evenimente.Visible = false;
            consecinte.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 1;
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            pictureBox1.Visible = true;
            introducere.Visible = true;
            cauze.Visible = true;
            evenimente.Visible = true;
            consecinte.Visible = true;
            button1.Visible = true;
            inapoi.Visible = false;
            text.Visible = false;
        }

        private void text_Click(object sender, EventArgs e)
        {
            if (text.Text == "Arată text")
            {
                if (x == 1)
                {
                    label1.Visible = true;
                    text.Text = "Ascunde text";
                }
                if (x == 2)
                {
                    label2.Visible = true;
                    text.Text = "Ascunde text";
                }
                if (x == 3)
                {
                    label3.Visible = true;
                    text.Text = "Ascunde text";
                }
                if (x == 4)
                {
                    label4.Visible = true;
                    text.Text = "Ascunde text";
                }
            }
            else
            {
                if (x == 1)
                {
                    label1.Visible = false;
                    text.Text = "Arată text";
                }
                if (x == 2)
                {
                    label2.Visible = false;
                    text.Text = "Arată text";
                }
                if (x == 3)
                {
                    label3.Visible = false;
                    text.Text = "Arată text";
                }
                if (x == 4)
                {
                    label4.Visible = false;
                    text.Text = "Arată text";
                }
            }
        }
    }
}
