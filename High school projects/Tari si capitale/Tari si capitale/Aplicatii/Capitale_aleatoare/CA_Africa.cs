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
    public partial class CA_Africa : Form
    {
        string[] v = new string[60];//vector de capitale
        int[] r = new int[60];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public CA_Africa()
        {
            InitializeComponent();
            v[1] = "Pretoria";
            v[2] = "Alger";
            v[3] = "Luanda";
            v[4] = "Porto Novo";
            v[5] = "Gaborone";
            v[6] = "Ouagadougou";
            v[7] = "Bujumbura";
            v[8] = "Yaounde";
            v[9] = "N'Djamena";
            v[10] = "Yamoussoukro";
            v[11] = "Moroni";
            v[12] = "Djibouti";
            v[13] = "Cairo";
            v[14] = "Asmara";
            v[15] = "Addis Abeba";
            v[16] = "Libreville";
            v[17] = "Banjul";
            v[18] = "Accra";
            v[19] = "Conakry";
            v[20] = "Bissau";
            v[21] = "Malabo";
            v[22] = "Praia";
            v[23] = "Nairobi";
            v[24] = "Maseru";
            v[25] = "Monrovia";
            v[26] = "Tripoli";
            v[27] = "Antananarivo";
            v[28] = "Lilongwe";
            v[29] = "Bamako";
            v[30] = "Rabat";
            v[31] = "Nouakchott";
            v[32] = "Port Louis";
            v[33] = "Maputo";
            v[34] = "Windhoek";
            v[35] = "Niamey";
            v[36] = "Abuja";
            v[37] = "Bangui";
            v[38] = "Brazzaville";
            v[39] = "Kinshasa";
            v[40] = "Kigali";
            v[41] = "Sao Tome";
            v[42] = "Dakar";
            v[43] = "Victoria";
            v[44] = "Freetown";
            v[45] = "Mogadishu";
            v[46] = "Khartoum";
            v[47] = "Juba";
            v[48] = "Mbabane";
            v[49] = "Dodoma";
            v[50] = "Lome";
            v[51] = "Tunis";
            v[52] = "Kampala";
            v[53] = "Lusaka";
            v[54] = "Harare";
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
