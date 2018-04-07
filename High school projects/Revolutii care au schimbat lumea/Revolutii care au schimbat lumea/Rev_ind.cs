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
    public partial class Rev_ind : Form
    {
        public Rev_ind()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(),"rev_ind_cursor_copy.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void epoca_Click(object sender, EventArgs e)
        {
            Rev_ind_epoca form = new Rev_ind_epoca();
            form.Show();
            this.Hide();
        }

        private void europa_Click(object sender, EventArgs e)
        {
            Rev_ind_europa form = new Rev_ind_europa();
            form.Show();
            this.Hide();
        }

        private void factori_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            pictureBox1.Visible = false;
            epoca.Visible = false;
            europa.Visible = false;
            factori.Visible = false;
            pr_inv.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            button2.Visible = true;
        }

        private void pr_inv_Click(object sender, EventArgs e)
        {
            Rev_ind_inv form = new Rev_ind_inv();
            form.Show();
            this.Hide();
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            pictureBox1.Visible = true;
            epoca.Visible = true;
            europa.Visible = true;
            factori.Visible = true;
            pr_inv.Visible = true;
            button1.Visible = true;
            inapoi.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Arată text")
            {
                label3.Visible = true;
                button2.Text = "Ascunde text";
            }
            else
            {
                label3.Visible = false;
                button2.Text = "Arată text";
            }
        }
    }
}
