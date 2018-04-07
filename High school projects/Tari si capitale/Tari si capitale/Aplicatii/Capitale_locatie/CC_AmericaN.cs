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
    public partial class CC_AmericaN : Form
    {
        string[] v = new string[30];//vectorul de tari
        string[] w = new string[30];//vector cu numele butoanelor
        int[] r = new int[30];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public CC_AmericaN()
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

            v[1] = "Antigua şi Barbuda";
            v[2] = "Bahamas";
            v[3] = "Barbados";
            v[4] = "Belize";
            v[5] = "Canada";
            v[6] = "Costa Rica";
            v[7] = "Cuba";
            v[8] = "Dominica";
            v[9] = "El Salvador";
            v[10] = "Grenada";
            v[11] = "Guatemala";
            v[12] = "Haiti";
            v[13] = "Honduras";
            v[14] = "Jamaica";
            v[15] = "Mexic";
            v[16] = "Nicaragua";
            v[17] = "Panama";
            v[18] = "Republica Dominicană";
            v[19] = "Saint Kitts şi Nevis";
            v[20] = "Saint Lucia";
            v[21] = "Saint Vicent și Grenadine";
            v[22] = "Statele Unite ale Americii";
            v[23] = "Trinidad şi Tobago";

            w[1] = "Saint_John_s";
            w[2] = "Nassau";
            w[3] = "Bridgetown";
            w[4] = "Belmopan";
            w[5] = "Ottawa";
            w[6] = "San_Jose";
            w[7] = "Havana";
            w[8] = "Roseau";
            w[9] = "San_Salvador";
            w[10] = "Saint_George_s";
            w[11] = "Ciudad_de_Guatemala";
            w[12] = "Port_au_Prince";
            w[13] = "Tegucigalpa";
            w[14] = "Kingston";
            w[15] = "Ciudad_de_Mexico";
            w[16] = "Managua";
            w[17] = "Ciudad_de_Panama";
            w[18] = "Santo_Domingo";
            w[19] = "Basseterre";
            w[20] = "Castries";
            w[21] = "Kingstown";
            w[22] = "Washington_DC";
            w[23] = "Port_of_Spain";

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
            for (int i = 1; i <= 23; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 23; i++)
            {
                index = rand.Next(1, 23);
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
                if (n == 24)
                {//cand n este 24 inseamna ca am parcurs toate tarile
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
