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
    public partial class Revolutia_americana : Form
    {
        public Revolutia_americana()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(),"sua.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void introducere_Click(object sender, EventArgs e)
        {
            Rev_am_intr form = new Rev_am_intr();
            form.Show();
            this.Hide();
        }

        private void conflicte_Click(object sender, EventArgs e)
        {
            Rev_am_conflicte form = new Rev_am_conflicte();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rev_am_razboaie form = new Rev_am_razboaie();
            form.Show();
            this.Hide();
        }

        private void sua_Click(object sender, EventArgs e)
        {
            SUA form = new SUA();
            form.Show();
            this.Hide();
        }
    }
}
