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
    public partial class Fr_desfasurare : Form
    {
        public Fr_desfasurare()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "franta_cursor.cur");
        }

        private void Fr_desfasurare_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Revolutia_franceza form = new Revolutia_franceza();
            form.Show();
            this.Hide();
        }

        private void directorat_Click(object sender, EventArgs e)
        {
            Fr_directorat form = new Fr_directorat();
            form.Show();
            this.Hide();
        }

        private void radical_Click(object sender, EventArgs e)
        {
            Fr_radical form = new Fr_radical();
            form.Show();
            this.Hide();
        }

        private void moderat_Click(object sender, EventArgs e)
        {
            Fr_moderata form = new Fr_moderata();
            form.Show();
            this.Hide();
        }
    }
}
