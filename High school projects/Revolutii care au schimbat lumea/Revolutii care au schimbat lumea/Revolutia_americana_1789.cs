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
    public partial class Revolutia_americana_1789 : Form
    {
        public Revolutia_americana_1789()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "sua.cur");
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            SUA form = new SUA();
            form.Show();
            this.Hide();
        }

        private void text_Click(object sender, EventArgs e)
        {
            if (text.Text == "Arată text")
            {
                label1.Visible = true;
                pictureBox1.Image = null;
                text.Text = "Ascunde text";
            }
            else
            {
                label1.Visible = false;
                pictureBox1.Image = pictureBox1.Image = ((System.Drawing.Image)(Properties.Resources.US_Slave_Free_1789_1861));
                text.Text = "Arată text";
            }
        }
    }
}
