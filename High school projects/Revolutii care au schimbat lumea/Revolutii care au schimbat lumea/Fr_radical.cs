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
    public partial class Fr_radical : Form
    {
        int x;
        public Fr_radical()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "franta_cursor.cur");
        }

        private void introducere_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            introducere.Visible = false;
            robesppiere.Visible = false;
            thermidor.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 1;
        }

        private void robesppiere_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            introducere.Visible = false;
            robesppiere.Visible = false;
            thermidor.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 2;
        }

        private void thermidor_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            introducere.Visible = false;
            robesppiere.Visible = false;
            thermidor.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fr_desfasurare form = new Fr_desfasurare();
            form.Show();
            this.Hide();
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            introducere.Visible = true;
            robesppiere.Visible = true;
            thermidor.Visible = true;
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
            }
        }
    }
}
