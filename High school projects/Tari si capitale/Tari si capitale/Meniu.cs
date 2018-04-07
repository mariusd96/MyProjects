using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Tari_si_capitale;

namespace Tari_si_capitale
{
    public partial class Meniu : Form
    {
        int n = 5;
        public Meniu()
        {
            InitializeComponent();
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, label1.Location.Y); 
            // pozitionam eticheta(label-ul) cu textul "Tari si capitale" in partea de jos a ecranului
        }

        private void iesire_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            panel1.Visible = true;//facem vizibil panoul
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //pozitionam panoul pe centrul ecranului
            timer1.Enabled = true;//pornim cronometrul
        }

        private void invata_Click(object sender, EventArgs e)
        {
            Invata form = new Invata();
            form.Show();
            this.Hide();
        }

        private void jocuri_Click(object sender, EventArgs e)
        {
            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void test_Click(object sender, EventArgs e)
        {
            Test form = new Test();
            form.Show();
            this.Hide();
        }

        private void resurse_Click(object sender, EventArgs e)
        {
            Resurse form = new Resurse();
            form.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (n == 0)
            {
                Form1 form = new Form1(0);
                form.Show();
                this.Hide();
            }//cand n=0 mergem in prima fereastra pt a opri melodia si in foarte scurt timp programul se inchide complet
            n--;//scadem din n cate o unitate
            label3.Text = n.ToString();//eticheta arata valoarea lui n
        }
    }
}
