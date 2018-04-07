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
    public partial class LC_Asia : Form
    {
        string[] v = new string[50];//vectorul de capitale
        string[] w = new string[50];//vector cu numele butoanelor
        int[] r = new int[50];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public LC_Asia()
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
                    x = 2;//cand x este 2 orice buton am apasa nu mai are loc verificareas
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Restart") amestecare();
        }
    }
}
