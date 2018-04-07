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
    public partial class Rev_garoafelor_rosii : Form
    {
        public Rev_garoafelor_rosii()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(),"garoafa.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void Rev_garoafelor_rosii_Load(object sender, EventArgs e)
        {

        }

        private void text_Click(object sender, EventArgs e)
        {
            if (text.Text == "Arată text")
            {
                label1.Visible = true;
                pictureBox1.Visible = true;
                text.Text = "Ascunde text";
            }
            else
            {
                label1.Visible = false;
                pictureBox1.Visible = false;
                text.Text = "Arată text";
            }
        }
    }
}
