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
    public partial class TA_Europa : Form
    {
        string[] v = new string[50];//vector de tari
        int[] r = new int[50];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public TA_Europa()
        {
            InitializeComponent();
            v[1] = "Albania";
            v[2] = "Andorra";
            v[3] = "Austria";
            v[4] = "Belarus";
            v[5] = "Belgia";
            v[6] = "Bosnia şi Herţegovina";
            v[7] = "Bulgaria";
            v[8] = "Cehia";
            v[9] = "Cipru";
            v[10] = "Croaţia";
            v[11] = "Danemarca";
            v[12] = "Elveţia";
            v[13] = "Estonia";
            v[14] = "Finlanda";
            v[15] = "Franţa";
            v[16] = "Germania";
            v[17] = "Grecia";
            v[18] = "Irlanda";
            v[19] = "Islanda";
            v[20] = "Italia";
            v[21] = "Kosovo";
            v[22] = "Letonia";
            v[23] = "Lichtenstein";
            v[24] = "Lituania";
            v[25] = "Luxemburg";
            v[26] = "Macedonia";
            v[27] = "Malta";
            v[28] = "Monaco";
            v[29] = "Muntenegru";
            v[30] = "Norvegia";
            v[31] = "Olanda";
            v[32] = "Polonia";
            v[33] = "Portugalia";
            v[34] = "Regatul Unit";
            v[35] = "Republica Moldova";
            v[36] = "România";
            v[37] = "Rusia";
            v[38] = "San Marino";
            v[39] = "Serbia";
            v[40] = "Slovacia";
            v[41] = "Slovenia";
            v[42] = "Spania";
            v[43] = "Suedia";
            v[44] = "Turcia";
            v[45] = "Ucraina";
            v[46] = "Ungaria";
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

            Biblioteca form = new Biblioteca(5);
            form.Show();
            this.Close();
        }
    }
}
