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
    public partial class Rev_am_conflicte : Form
    {
        public Rev_am_conflicte()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "sua.cur");
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Revolutia_americana form = new Revolutia_americana();
            form.Show();
            this.Hide();
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
    }
}
