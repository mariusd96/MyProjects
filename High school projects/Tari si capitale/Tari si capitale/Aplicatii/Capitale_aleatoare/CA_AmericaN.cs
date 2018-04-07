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
    public partial class CA_AmericaN : Form
    {
        string[] v = new string[30];//vector de capitale
        int[] r = new int[30];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public CA_AmericaN()
        {
            InitializeComponent();
            v[1] = "Saint John's";
            v[2] = "Nassau";
            v[3] = "Bridgetown";
            v[4] = "Belmopan";
            v[5] = "Ottawa";
            v[6] = "San Jose";
            v[7] = "Havana";
            v[8] = "Roseau";
            v[9] = "San Salvador";
            v[10] = "Saint George's";
            v[11] = "Ciudad de Guatemala";
            v[12] = "Port-au-Prince";
            v[13] = "Tegucigalpa";
            v[14] = "Kingston";
            v[15] = "Ciudad de Mexico";
            v[16] = "Managua";
            v[17] = "Ciudad de Panama";
            v[18] = "Santo Domingo";
            v[19] = "Basseterre";
            v[20] = "Castries";
            v[21] = "Kingstown";
            v[22] = "Washington DC";
            v[23] = "Port of Spain";
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

            Biblioteca form = new Biblioteca(6);
            form.Show();
            this.Close();
        }
    }
}
