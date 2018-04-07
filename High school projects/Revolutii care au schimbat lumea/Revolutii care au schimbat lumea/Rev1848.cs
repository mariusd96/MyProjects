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
    public partial class Rev1848 : Form
    {
        public Rev1848()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void italia_Click(object sender, EventArgs e)
        {
            Rev1848_italia form = new Rev1848_italia();
            form.Show();
            this.Hide();
        }

        private void franta_Click(object sender, EventArgs e)
        {
            Rev1848_franta form = new Rev1848_franta();
            form.Show();
            this.Hide();
        }

        private void germania_Click(object sender, EventArgs e)
        {
            Rev1848_germania form = new Rev1848_germania();
            form.Show();
            this.Hide();
        }

        private void imp_habs_Click(object sender, EventArgs e)
        {
            Rev1848_imp_habs form = new Rev1848_imp_habs();
            form.Show();
            this.Hide();
        }

        private void romania_Click(object sender, EventArgs e)
        {
            Rev1848_romania form= new Rev1848_romania();
            form.Show();
            this.Hide();
        }

        private void reflux_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = true;
            italia.Visible = false;
            franta.Visible = false;
            germania.Visible = false;
            imp_habs.Visible = false;
            romania.Visible = false;
            reflux.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            button2.Visible = true;
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label6.Visible = false;
            italia.Visible = true;
            franta.Visible = true;
            germania.Visible = true;
            imp_habs.Visible = true;
            romania.Visible = true;
            reflux.Visible = true;
            button1.Visible = true;
            inapoi.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Arată text")
            {
                label6.Visible = true;
                button2.Text = "Ascunde text";
            }
            else
            {
                label6.Visible = false;
                button2.Text = "Arată text";
            }
        }
    }
}
