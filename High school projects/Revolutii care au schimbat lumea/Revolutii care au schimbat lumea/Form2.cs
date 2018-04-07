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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       /* int x = SystemInformation.VirtualScreen.Width;
        int y = SystemInformation.VirtualScreen.Height;
        private void pozitieX(Control c)
        {
            int p1, procx;
            if (x > 1000) p1 = x / 10 - 100;
            else p1 = 100 - x / 10;
            procx = (c.Location.X * p1) / 100;
            if (x > 1000) c.Location = new Point(c.Location.X + procx, c.Location.Y);
            else c.Location = new Point(c.Location.X - procx, c.Location.Y);
        }
        private void pozitieY(Control c)
        {
            int p2, procy;
            if (y > 700) p2 = y/7-100;
            else p2 = 100 - y / 7;
            procy = (c.Location.Y * p2)/100;
            if (y > 700) c.Location = new Point(c.Location.X, c.Location.Y + procy);
            else c.Location = new Point(c.Location.X, c.Location.Y - procy);
        }*/

        private void start_Click(object sender, EventArgs e)
        {

            Form3 form = new Form3();
            form.Show();
            this.Hide();
        }

        private void cuprins_Click(object sender, EventArgs e)
        {

        }

        private void iesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
