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
    public partial class Bibliografie : Form
    {
        public Bibliografie()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Wallpaper form = new Wallpaper();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {
            int x = SystemInformation.VirtualScreen.Width;
            int y = SystemInformation.VirtualScreen.Height;
            pictureBox1.Location = new Point(91 * x / 1024, 654 * y / 768);
            pictureBox1.Width = 117 * x / 1024;
        }
    }
}
