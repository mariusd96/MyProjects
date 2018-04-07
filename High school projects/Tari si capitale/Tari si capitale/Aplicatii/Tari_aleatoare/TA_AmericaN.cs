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
    public partial class TA_AmericaN : Form
    {
        string[] v = new string[30];//vector de tari
        int[] r = new int[30];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public TA_AmericaN()
        {
            InitializeComponent();
            v[1] = "Antigua şi Barbuda";
            v[2] = "Bahamas";
            v[3] = "Barbados";
            v[4] = "Belize";
            v[5] = "Canada";
            v[6] = "Costa Rica";
            v[7] = "Cuba";
            v[8] = "Dominica";
            v[9] = "El Salvador";
            v[10] = "Grenada";
            v[11] = "Guatemala";
            v[12] = "Haiti";
            v[13] = "Honduras";
            v[14] = "Jamaica";
            v[15] = "Mexic";
            v[16] = "Nicaragua";
            v[17] = "Panama";
            v[18] = "Republica Dominicană";
            v[19] = "Saint Kitts şi Nevis";
            v[20] = "Saint Lucia";
            v[21] = "Saint Vicent și Grenadine";
            v[22] = "Statele Unite ale Americii";
            v[23] = "Trinidad şi Tobago";
            amestecare();
        }

        private void amestecare()
        {
            n = 0;
            label1.Text = "";
            for (int i = 1; i <= 23; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 23; i++)
            {
                index = rand.Next(1, 23);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//in ciclul for amestecam elementele din vectorul r
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n == 23)
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
