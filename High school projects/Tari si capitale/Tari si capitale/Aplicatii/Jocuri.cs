using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tari_si_capitale
{
    public partial class Jocuri : Form
    {
        public Jocuri()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            tari_steaguri.Parent = pictureBox1;
            tari_steaguri.BackColor = Color.Transparent;
            tari_aleatoare.Image = (System.Drawing.Image)(Properties.Resources.tari);
            capitale_aleatoare.Image = (System.Drawing.Image)(Properties.Resources.capitale);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Meniu form = new Meniu();
            form.Show();
            this.Hide();
        }

        private void tari_aleatoare_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(5);
            form.Show();
            this.Hide();
        }

        private void capitale_aleatoare_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(6);
            form.Show();
            this.Hide();
        }

        private void tari_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(1);
            form.Show();
            this.Hide();
        }

        private void capitale_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(2);
            form.Show();
            this.Hide();
        }

        private void steaguri_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(3);
            form.Show();
            this.Hide();
        }

        private void tari_steaguri_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(4);
            form.Show();
            this.Hide();
        }

        private void obiectiv_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Obiectiv_turistic form = new Obiectiv_turistic();
            form.Show();
            this.Hide();
        }

        private void localizare_capitale_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(8);
            form.Show();
            this.Hide();
        }

        private void capitale_colorate_Click(object sender, EventArgs e)
        {
            Biblioteca form = new Biblioteca(7);
            form.Show();
            this.Hide();
        }

        private void joc_continent_Click(object sender, EventArgs e)
        {
            JOC_CONTINENTE form = new JOC_CONTINENTE();
            form.Show();
            this.Hide();
        }
    }
}
