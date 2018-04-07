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
    public partial class LC_AmericaN : Form
    {
        string[] v = new string[30];//vectorul de capitale
        string[] w = new string[30];//vector cu numele butoanelor
        int[] r = new int[30];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public LC_AmericaN()
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

            v[1] = "Saint John's";
            v[2] = "Nassau";
            v[3] = "Bridgetown";
            v[4] = "Belmopan";
            v[5] = "Ottawa";
            v[6] = "San Jose";
            v[7] = "Havana";
            v[8] = "Roseau";
            v[9] = "San Salvador";
            v[10] = "Saint George's";
            v[11] = "Ciudad de Guatemala";
            v[12] = "Port au Prince";
            v[13] = "Tegucigalpa";
            v[14] = "Kingston";
            v[15] = "Ciudad de Mexico";
            v[16] = "Managua";
            v[17] = "Ciudad de Panama";
            v[18] = "Santo Domingo";
            v[19] = "Basseterre";
            v[20] = "Castries";
            v[21] = "Kingstown";
            v[22] = "Washington DC";
            v[23] = "Port of Spain";

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
