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
    public partial class CC_Asia : Form
    {
        string[] v = new string[50];//vectorul de tari
        string[] w = new string[50];//vector cu numele butoanelor
        int[] r = new int[50];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public CC_Asia()
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

            w[1] = "Kabul";
            w[2] = "Riyadh";
            w[3] = "Erevan";
            w[4] = "Baku";
            w[5] = "Manama";
            w[6] = "Dhaka";
            w[7] = "Thimphu";
            w[8] = "Naypyidaw";
            w[9] = "Bandar_Seri_Begawan";
            w[10] = "Phnom_Penh";
            w[11] = "Beijing";
            w[12] = "Phenian";
            w[13] = "Seul";
            w[14] = "Abu_Dhabi";
            w[15] = "Manila";
            w[16] = "Tbilisi";
            w[17] = "New_Delhi";
            w[18] = "Jakarta";
            w[19] = "Amman";
            w[20] = "Bagdad";
            w[21] = "Teheran";
            w[22] = "Ierusalim";
            w[23] = "Tokyo";
            w[24] = "Astana";
            w[25] = "Bișkek";
            w[26] = "Kuweit";
            w[27] = "Vientiane";
            w[28] = "Beirut";
            w[29] = "Kuala_Lumpur";
            w[30] = "Ulan_Bator";
            w[31] = "Kathmandu";
            w[32] = "Muscat";
            w[33] = "Islamabad";
            w[34] = "Doha";
            w[35] = "Moscova";
            w[36] = "Singapore";
            w[37] = "Damasc";
            w[38] = "Colombo";
            w[39] = "Dușanbe";
            w[40] = "Taipei";
            w[41] = "Bangkok";
            w[42] = "Dili";
            w[43] = "Ankara";
            w[44] = "Așgabat";
            w[45] = "Tașkent";
            w[46] = "Hanoi";
            w[47] = "Sana_a";

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
