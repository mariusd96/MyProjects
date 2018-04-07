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
    public partial class SUA : Form
    {
        public SUA()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "sua.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SUA_nastere form = new SUA_nastere();
            form.Show();
            this.Hide();
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Revolutia_americana form = new Revolutia_americana();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Revolutia_americana form = new Revolutia_americana();
            form.Show();
            this.Close();
        }

        private void philadelphia_Click(object sender, EventArgs e)
        {
            Revolutia_americana_philadelphia form = new Revolutia_americana_philadelphia();
            form.Show();
            this.Close();
        }

        private void state_Click(object sender, EventArgs e)
        {
            Revolutia_americana_1789 form = new Revolutia_americana_1789();
            form.Show();
            this.Close();
        }

        private void presedinte_Click(object sender, EventArgs e)
        {
            Revolutia_americana_presedinte form = new Revolutia_americana_presedinte();
            form.Show();
            this.Close();
        }

        private void institutii_Click(object sender, EventArgs e)
        {
            Revolutia_americana_institutii form = new Revolutia_americana_institutii();
            form.Show();
            this.Close();
        }
    }
}
