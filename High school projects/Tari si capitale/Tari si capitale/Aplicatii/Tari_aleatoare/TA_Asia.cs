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
    public partial class TA_Asia : Form
    {
        string[] v = new string[50];//vector de tari
        int[] r = new int[50];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public TA_Asia()
        {
            InitializeComponent();
            v[1] = "Afganistan";
            v[2] = "Arabia Saudită";
            v[3] = "Armenia";
            v[4] = "Azerbaidjan";
            v[5] = "Bahrain";
            v[6] = "Bangladesh";
            v[7] = "Bhutan";
            v[8] = "Birmania";
            v[9] = "Brunei";
            v[10] = "Cambodgia";
            v[11] = "China";
            v[12] = "Coreea de Nord";
            v[13] = "Coreea de Sud";
            v[14] = "Emiratele Arabe Unite";
            v[15] = "Filipine";
            v[16] = "Georgia";
            v[17] = "India";
            v[18] = "Indonezia";
            v[19] = "Iordania";
            v[20] = "Irak";
            v[21] = "Iran";
            v[22] = "Israel";
            v[23] = "Japonia";
            v[24] = "Kazahstan";
            v[25] = "Kârgâzstan";
            v[26] = "Kuweit";
            v[27] = "Laos";
            v[28] = "Liban";
            v[29] = "Malaezia";
            v[30] = "Mongolia";
            v[31] = "Nepal";
            v[32] = "Oman";
            v[33] = "Pakistan";
            v[34] = "Qatar";
            v[35] = "Rusia";
            v[36] = "Singapore";
            v[37] = "Siria";
            v[38] = "Sri Lanka";
            v[39] = "Tadjikistan";
            v[40] = "Taiwan";
            v[41] = "Thailanda";
            v[42] = "Timorul de Est";
            v[43] = "Turcia";
            v[44] = "Turkmenistan";
            v[45] = "Uzbekistan";
            v[46] = "Vietnam";
            v[47] = "Yemen";
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

            Biblioteca form = new Biblioteca(5);
            form.Show();
            this.Close();
        }
    }
}
