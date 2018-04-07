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
    public partial class Rev_eng : Form
    {
        public Rev_eng()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "anglia_cursor.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void introducere_Click(object sender, EventArgs e)
        {
            Rev_eng_intr form = new Rev_eng_intr();
            form.Show();
            this.Hide();
        }

        private void premise_Click(object sender, EventArgs e)
        {
            Rev_eng_premise form = new Rev_eng_premise();
            form.Show();
            this.Hide();
        }

        private void desfasurare_Click(object sender, EventArgs e)
        {
            Rev_eng_desfasurare form = new Rev_eng_desfasurare();
            form.Show();
            this.Hide();
        }
    }
}
