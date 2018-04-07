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
    public partial class Fr_origini : Form
    {
        int x;
        public Fr_origini()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "franta_cursor.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Revolutia_franceza form = new Revolutia_franceza();
            form.Show();
            this.Hide();
        }

        private void vechiul_regim_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            inapoi.Visible = true;
            text.Visible = true;
            vechiul_regim.Visible = false;
            societate.Visible = false;
            button1.Visible = false;
            x = 1;
        }

        private void societate_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            inapoi.Visible = true;
            text.Visible = true;
            vechiul_regim.Visible = false;
            societate.Visible = false;
            button1.Visible = false;
            x = 2;
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            inapoi.Visible = false;
            text.Visible = false;
            vechiul_regim.Visible = true;
            societate.Visible = true;
            button1.Visible = true;
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
            }
        }
    }
}
