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
    public partial class TA_Oceania : Form
    {
        string[] v = new string[10];//vector de tari
        int[] r = new int[10];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public TA_Oceania()
        {
            InitializeComponent();
            v[1] = "Australia";
            v[2] = "Fiji";
            v[3] = "Insulele Solomon";
            v[4] = "Noua Zeelandă";
            v[5] = "Papua Noua Guinee";
            v[6] = "Samoa";
            v[7] = "Tonga";
            v[8] = "Vanuatu";
            amestecare();
        }

        private void amestecare()
        {
            n = 0;
            label1.Text = "";
            for (int i = 1; i <= 8; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 8; i++)
            {
                index = rand.Next(1,8);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//in ciclul for amestecam elementele din vectorul r
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n == 8)
            {
                amestecare();
            }
            else
            {
                n++;
                label1.Text = v[r[n]];
                label1.Location = new Point(this.ClientSize.Width / 2 - label1.Width / 2, this.ClientSize.Height / 2 - label1.Height / 2);
                //pozitionam eticheta pe centrul ecranului la apasarea butonul "next" din cauza lungimii textului din v[r[n]]
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            amestecare();
        }

        private void iesire_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(5);
            form.Show();
            this.Close();
        }
    }
}
