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
    public partial class CA_Asia : Form
    {
        string[] v = new string[50];//vector de capitale
        int[] r = new int[50];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public CA_Asia()
        {
            InitializeComponent();
            v[1] = "Kabul";
            v[2] = "Riyadh";
            v[3] = "Erevan";
            v[4] = "Baku";
            v[5] = "Manama";
            v[6] = "Dhaka";
            v[7] = "Thimphu";
            v[8] = "Naypyidaw";
            v[9] = "Bandar Seri Begawan";
            v[10] = "Phnom Penh";
            v[11] = "Beijing";
            v[12] = "Phenian";
            v[13] = "Seul";
            v[14] = "Abu Dhabi";
            v[15] = "Manila";
            v[16] = "Tbilisi";
            v[17] = "New Delhi";
            v[18] = "Jakarta";
            v[19] = "Amman";
            v[20] = "Bagdad";
            v[21] = "Teheran";
            v[22] = "Ierusalim";
            v[23] = "Tokyo";
            v[24] = "Astana";
            v[25] = "Bișkek";
            v[26] = "Kuweit";
            v[27] = "Vientiane";
            v[28] = "Beirut";
            v[29] = "Kuala Lumpur";
            v[30] = "Ulan Bator";
            v[31] = "Kathmandu";
            v[32] = "Muscat";
            v[33] = "Islamabad";
            v[34] = "Doha";
            v[35] = "Moscova";
            v[36] = "Singapore";
            v[37] = "Damasc";
            v[38] = "Colombo";
            v[39] = "Dușanbe";
            v[40] = "Taipei";
            v[41] = "Bangkok";
            v[42] = "Dili";
            v[43] = "Ankara";
            v[44] = "Așgabat";
            v[45] = "Tașkent";
            v[46] = "Hanoi";
            v[47] = "Sana'a";
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
