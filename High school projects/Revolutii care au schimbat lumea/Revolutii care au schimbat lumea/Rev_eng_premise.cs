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
    public partial class Rev_eng_premise : Form
    {
        public Rev_eng_premise()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "anglia_cursor.cur");
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            Rev_eng form = new Rev_eng();
            form.Show();
            this.Hide();
        }
    }
}
