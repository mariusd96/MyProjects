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
    public partial class TA_Africa : Form
    {
        string[] v = new string[60];//vector de tari
        int[] r = new int[60];//vector in care elementele sale se vor amesteca
        int n;
        int index, temp;//variabile auxiliare
        public TA_Africa()
        {
            InitializeComponent();
            label1.Text = "";
            v[1] = "Africa de Sud";
            v[2] = "Algeria";
            v[3] = "Angola";
            v[4] = "Benin";
            v[5] = "Botswana";
            v[6] = "Burkina Faso";
            v[7] = "Burundi";
            v[8] = "Camerun";
            v[9] = "Ciad";
            v[10] = "Coasta de Fildeş";
            v[11] = "Comore";
            v[12] = "Djibouti";
            v[13] = "Egipt";
            v[14] = "Eritreea";
            v[15] = "Etiopia";
            v[16] = "Gabon";
            v[17] = "Gambia";
            v[18] = "Ghana";
            v[19] = "Guineea";
            v[20] = "Guineea-Bissau";
            v[21] = "Guineea-Ecuatorială";
            v[22] = "Insulele Capului Verde";
            v[23] = "Kenya";
            v[24] = "Lesotho";
            v[25] = "Liberia";
            v[26] = "Libia";
            v[27] = "Madagascar";
            v[28] = "Malawi";
            v[29] = "Mali";
            v[30] = "Maroc";
            v[31] = "Mauritania";
            v[32] = "Mauritius";
            v[33] = "Mozambic";
            v[34] = "Namibia";
            v[35] = "Niger";
            v[36] = "Nigeria";
            v[37] = "Republica Centrafricană";
            v[38] = "Republica Congo";
            v[39] = "Republica Democrată Congo";
            v[40] = "Rwanda";
            v[41] = "Sao Tome şi Principe";
            v[42] = "Senegal";
            v[43] = "Seychelles";
            v[44] = "Sierra Leone";
            v[45] = "Somalia";
            v[46] = "Sudan";
            v[47] = "Sudanul de Sud";
            v[48] = "Swaziland";
            v[49] = "Tanzania";
            v[50] = "Togo";
            v[51] = "Tunisia";
            v[52] = "Uganda";
            v[53] = "Zambia";
            v[54] = "Zimbabwe";
            amestecare();
        }

        private void amestecare()
        {
            n = 0;
            label1.Text = "";
            for (int i = 1; i <= 54; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 54; i++)
            {
                index = rand.Next(1, 54);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//in ciclul for amestecam elementele din vectorul r
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n == 54) 
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

        private void iesire_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(5);
            form.Show();
            this.Close();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            amestecare();
        }

        
    }
}
