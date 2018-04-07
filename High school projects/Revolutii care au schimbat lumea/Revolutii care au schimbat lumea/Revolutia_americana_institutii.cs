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
    public partial class Revolutia_americana_institutii : Form
    {
        public Revolutia_americana_institutii()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "sua.cur");
        }

        private void text_Click(object sender, EventArgs e)
        {
            if (text.Text == "Arată text")
            {
                label1.Visible = true;
                text.Text = "Ascunde text";
            }
            else
            {
                label1.Visible = false;
                text.Text = "Arată text";
            }
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            SUA form = new SUA();
            form.Show();
            this.Hide();
        }
    }
}
