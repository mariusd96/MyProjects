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
    public partial class Rev1848_italia : Form
    {
        public Rev1848_italia()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "italia.cur");
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Rev1848 form = new Rev1848();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Arată text")
            {
                pictureBox1.Visible = true;
                label3.Visible = true;
                button1.Text = "Ascunde text";
            }
            else
            {
                pictureBox1.Visible=false;
                label3.Visible = false;
                button1.Text = "Arată text";
            }
        }
    }
}
