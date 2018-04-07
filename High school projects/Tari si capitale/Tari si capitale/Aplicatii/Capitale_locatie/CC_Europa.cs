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
    public partial class CC_Europa : Form
    {
        string[] v = new string[50];//vectorul de tari
        string[] w = new string[50];//vector cu numele butoanelor
        int[] r = new int[50];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public CC_Europa()
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

            w[1] = "Tirana";
            w[2] = "Andorra_la_Vella";
            w[3] = "Viena";
            w[4] = "Minsk";
            w[5] = "Bruxelles";
            w[6] = "Sarajevo";
            w[7] = "Sofia";
            w[8] = "Praga";
            w[9] = "Nicosia";
            w[10] = "Zagreb";
            w[11] = "Copenhaga";
            w[12] = "Berna";
            w[13] = "Tallinn";
            w[14] = "Helsinki";
            w[15] = "Paris";
            w[16] = "Berlin";
            w[17] = "Atena";
            w[18] = "Dublin";
            w[19] = "Reykjavik";
            w[20] = "Roma";
            w[21] = "Priștina";
            w[22] = "Riga";
            w[23] = "Vaduz";
            w[24] = "Vilnius";
            w[25] = "Luxemburg";
            w[26] = "Skopje";
            w[27] = "Valletta";
            w[28] = "Monaco";
            w[29] = "Podgorica";
            w[30] = "Oslo";
            w[31] = "Amsterdam";
            w[32] = "Varșovia";
            w[33] = "Lisabona";
            w[34] = "Londra";
            w[35] = "Chișinău";
            w[36] = "București";
            w[37] = "Moscova";
            w[38] = "San_Marino";
            w[39] = "Belgrad";
            w[40] = "Bratislava";
            w[41] = "Ljubljana";
            w[42] = "Madrid";
            w[43] = "Stockholm";
            w[44] = "Ankara";
            w[45] = "Kiev";
            w[46] = "Budapesta";
            w[47] = "Vatican";

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

            Biblioteca form = new Biblioteca(7);
            form.Show();
            this.Hide();
        }

        private void amestecare()
        {
            corect = gresit = 0;
            n = 1;//n ne arata la ce buton suntem(ca numar)
            x = 1;//cand x este 1 primim numele unei tari si trebuie sa apasam pe butonul care reprezinta capitala sa
            label1.Text = corect.ToString();
            label2.Text = gresit.ToString();
            for (int i = 1; i <= 47; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 47; i++)
            {
                index = rand.Next(1, 47);
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
                if (n == 48)
                {//cand n este 48 inseamna ca am parcurs toate tarile
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
