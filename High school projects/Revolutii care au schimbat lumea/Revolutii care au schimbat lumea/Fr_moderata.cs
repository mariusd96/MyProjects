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
    public partial class Fr_moderata : Form
    {
        public Fr_moderata()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "franta_cursor.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fr_desfasurare form = new Fr_desfasurare();
            form.Show();
            this.Hide();
        }

        private void adunare_Click(object sender, EventArgs e)
        {
            Fr_mod_adunare form = new Fr_mod_adunare();
            form.Show();
            this.Hide();
        }

        private void adunare_const_Click(object sender, EventArgs e)
        {
            Fr_mod_adunare_const form = new Fr_mod_adunare_const();
            form.Show();
            this.Hide();
        }

        private void bastilia_Click(object sender, EventArgs e)
        {
            Fr_mod_bastilia form = new Fr_mod_bastilia();
            form.Show();
            this.Hide();
        }

        private void abolire_Click(object sender, EventArgs e)
        {
            Fr_mod_abolire form = new Fr_mod_abolire();
            form.Show();
            this.Hide();
        }

        private void constitutie_Click(object sender, EventArgs e)
        {
            Fr_mod_constitutie form = new Fr_mod_constitutie();
            form.Show();
            this.Hide();
        }

        private void monarhie_Click(object sender, EventArgs e)
        {
            Fr_mod_monarhie form = new Fr_mod_monarhie();
            form.Show();
            this.Hide();
        }

        private void monarhie_cadere_Click(object sender, EventArgs e)
        {
            Fr_mod_monarhie_cadere form = new Fr_mod_monarhie_cadere();
            form.Show();
            this.Hide();
        }

        private void girondin_Click(object sender, EventArgs e)
        {
            Fr_mod_girondin form = new Fr_mod_girondin();
            form.Show();
            this.Hide();
        }
    }
}
