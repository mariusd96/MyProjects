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
    public partial class Rev_am_razboaie : Form
    {
        int x;
        public Rev_am_razboaie()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "sua.cur");
        }

        private void inevitabil_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            inapoi.Visible = true;
            text.Visible = true;
            BackgroundImage = Properties.Resources.batalii;
            inevitabil.Visible = false;
            independenta.Visible = false;
            button1.Visible = false;
            x = 1;
        }

        private void independenta_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            inapoi.Visible = true;
            text.Visible = true;
            BackgroundImage = Properties.Resources.batalii;
            inevitabil.Visible = false;
            independenta.Visible = false;
            button1.Visible = false;
            x = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Revolutia_americana form = new Revolutia_americana();
            form.Show();
            this.Close();
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            inapoi.Visible = false;
            text.Visible = false;
            BackgroundImage = Properties.Resources.revolutia_americana;
            inevitabil.Visible = true;
            independenta.Visible = true;
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

        private void Rev_am_razboaie_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
