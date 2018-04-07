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
    public partial class LC_Africa : Form
    {
        string[] v = new string[60];//vectorul de capitale
        string[] w = new string[60];//vector cu numele butoanelor
        int[] r = new int[60];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public LC_Africa()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;

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

            w[1] = "Pretoria";
            w[2] = "Alger";
            w[3] = "Luanda";
            w[4] = "Porto_Novo";
            w[5] = "Gaborone";
            w[6] = "Ouagadougou";
            w[7] = "Bujumbura";
            w[8] = "Yaounde";
            w[9] = "N_Djamena";
            w[10] = "Yamoussoukro";
            w[11] = "Moroni";
            w[12] = "Djibouti";
            w[13] = "Cairo";
            w[14] = "Asmara";
            w[15] = "Addis_Abeba";
            w[16] = "Libreville";
            w[17] = "Banjul";
            w[18] = "Accra";
            w[19] = "Conakry";
            w[20] = "Bissau";
            w[21] = "Malabo";
            w[22] = "Praia";
            w[23] = "Nairobi";
            w[24] = "Maseru";
            w[25] = "Monrovia";
            w[26] = "Tripoli";
            w[27] = "Antananarivo";
            w[28] = "Lilongwe";
            w[29] = "Bamako";
            w[30] = "Rabat";
            w[31] = "Nouakchott";
            w[32] = "Port_Louis";
            w[33] = "Maputo";
            w[34] = "Windhoek";
            w[35] = "Niamey";
            w[36] = "Abuja";
            w[37] = "Bangui";
            w[38] = "Brazzaville";
            w[39] = "Kinshasa";
            w[40] = "Kigali";
            w[41] = "Sao_Tome";
            w[42] = "Dakar";
            w[43] = "Victoria";
            w[44] = "Freetown";
            w[45] = "Mogadishu";
            w[46] = "Khartoum";
            w[47] = "Juba";
            w[48] = "Mbabane";
            w[49] = "Dodoma";
            w[50] = "Lome";
            w[51] = "Tunis";
            w[52] = "Kampala";
            w[53] = "Lusaka";
            w[54] = "Harare";

            amestecare();

            foreach (Control c in panel1.Controls.OfType<Button>())
            {
                if (c.Name != "button1")
                {
                    c.Click += new EventHandler(buton_Click);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(8);
            form.Show();
            this.Hide();
        }

        private void amestecare()
        {
            corect = gresit = 0;
            n = 1;//n ne arata la ce buton suntem(ca numar)
            x = 1;//cand x este 1 primim capitale si trebuie sa apasam pe butonul care reprezinta locatia acelei capitale
            label1.Text = corect.ToString();
            label2.Text = gresit.ToString();
            for (int i = 1; i <= 54; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 54; i++)
            {
                index = rand.Next(1, 54);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//amestecam elementele vectorului r pentru a avea tarile amestecate
            label3.Text = v[r[n]];
        }

        private void buton_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                Button b = (Button)sender;//vedem ce buton a apasat utilizatorul
                if (b.Name == w[r[n]])
                {
                    corect++;//daca a apasat butonul corect variabila 'corect' creste
                    label1.Text = corect.ToString();
                }
                else
                {
                    gresit++;//daca a apasat butonul gresit variabila 'gresit' creste
                    label2.Text = gresit.ToString();
                }
                n++;
                label3.Text = v[r[n]];
                if (n == 55)
                { //cand n este 55 inseamna ca am parcurs toate tarile
                    label3.Text = "Restart";
                    x = 2;//cand x este 2 orice buton am apasa nu mai are loc verificarea
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Restart") amestecare();
        }
    }
}
