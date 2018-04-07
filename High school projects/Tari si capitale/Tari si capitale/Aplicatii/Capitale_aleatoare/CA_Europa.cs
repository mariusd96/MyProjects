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
    public partial class CA_Europa : Form
    {
        string[] v = new string[50];//vector de capitale
        int[] r = new int[50];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public CA_Europa()
        {
            InitializeComponent();
            v[1] = "Tirana";
            v[2] = "Andorra la Vella";
            v[3] = "Viena";
            v[4] = "Minsk";
            v[5] = "Bruxelles";
            v[6] = "Sarajevo";
            v[7] = "Sofia";
            v[8] = "Praga";
            v[9] = "Nicosia";
            v[10] = "Zagreb";
            v[11] = "Copenhaga";
            v[12] = "Berna";
            v[13] = "Tallinn";
            v[14] = "Helsinki";
            v[15] = "Paris";
            v[16] = "Berlin";
            v[17] = "Atena";
            v[18] = "Dublin";
            v[19] = "Reykjavik";
            v[20] = "Roma";
            v[21] = "Priștina";
            v[22] = "Riga";
            v[23] = "Vaduz";
            v[24] = "Vilnius";
            v[25] = "Luxemburg";
            v[26] = "Skopje";
            v[27] = "Valletta";
            v[28] = "Monaco";
            v[29] = "Podgorica";
            v[30] = "Oslo";
            v[31] = "Amsterdam";
            v[32] = "Varșovia";
            v[33] = "Lisabona";
            v[34] = "Londra";
            v[35] = "Chișinău";
            v[36] = "București";
            v[37] = "Moscova";
            v[38] = "San Marino";
            v[39] = "Belgrad";
            v[40] = "Bratislava";
            v[41] = "Ljubljana";
            v[42] = "Madrid";
            v[43] = "Stockholm";
            v[44] = "Ankara";
            v[45] = "Kiev";
            v[46] = "Budapesta";
            v[47] = "Vatican";
            amestecare();
        }

        private void amestecare()
        {
            n = 0;
            label1.Text = "";
            for (int i = 1; i <= 47; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 47; i++)
            {
                index = rand.Next(1, 47);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//in ciclul for amestecam elementele din vectorul r
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n == 47)
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
