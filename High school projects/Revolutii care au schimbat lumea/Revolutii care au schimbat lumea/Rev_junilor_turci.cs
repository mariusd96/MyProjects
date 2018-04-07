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
    public partial class Rev_junilor_turci : Form
    {
        public Rev_junilor_turci()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(),"turcia.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            this.Hide();
        }

        private void Rev_junilor_turci_Load(object sender, EventArgs e)
        {

        }
    }
}
