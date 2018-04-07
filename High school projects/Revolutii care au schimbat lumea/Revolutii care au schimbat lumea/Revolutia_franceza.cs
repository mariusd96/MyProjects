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
    public partial class Revolutia_franceza : Form
    {
        public Revolutia_franceza()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "franta_cursor.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void origini_Click(object sender, EventArgs e)
        {
            Fr_origini form = new Fr_origini();
            form.Show();
            this.Hide();
        }

        private void cauze_Click(object sender, EventArgs e)
        {
            Fr_cauze form = new Fr_cauze();
            form.Show();
            this.Hide();
        }

        private void desfasurare_Click(object sender, EventArgs e)
        {
            Fr_desfasurare form = new Fr_desfasurare();
            form.Show();
            this.Hide();
        }
    }
}
