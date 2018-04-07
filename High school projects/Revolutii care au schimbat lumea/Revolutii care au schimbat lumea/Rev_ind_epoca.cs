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
    public partial class Rev_ind_epoca : Form
    {
        public Rev_ind_epoca()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "rev_ind_cursor_copy.cur");
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Rev_ind form = new Rev_ind();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Arată text")
            {
                label1.Visible = true;
                button1.Text = "Ascunde text";
            }
            else
            {
                label1.Visible = false;
                button1.Text = "Arată text";
            }
        }
    }
}
