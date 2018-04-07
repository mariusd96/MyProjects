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
    public partial class CA_AmericaS : Form
    {
        string[] v = new string[30];//vector de capitale
        int[] r = new int[30];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public CA_AmericaS()
        {
            InitializeComponent();
            v[1] = "Buenos Aires";
            v[2] = "La Paz";
            v[3] = "Brasilia";
            v[4] = "Santiago";
            v[5] = "Bogota";
            v[6] = "Quito";
            v[7] = "Georgetown";
            v[8] = "Cayenne";
            v[9] = "Asuncion";
            v[10] = "Lima";
            v[11] = "Paramaribo";
            v[12] = "Montevideo";
            v[13] = "Caracas";
            amestecare();
        }

        private void amestecare()
        {
            n = 0;
            label1.Text = "";
            for (int i = 1; i <= 13; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 13; i++)
            {
                index = rand.Next(1, 13);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//in ciclul for amestecam elementele din vectorul r
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n == 13)
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

            Biblioteca form = new Biblioteca(6);
            form.Show();
            this.Close();
        }
    }
}
