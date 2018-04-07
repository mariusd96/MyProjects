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
    public partial class CC_AmericaS : Form
    {
        string[] v = new string[20];//vectorul de tari
        string[] w = new string[20];//vector cu numele butoanelor
        int[] r = new int[20];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public CC_AmericaS()
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

            v[1] = "Argentina";
            v[2] = "Bolivia";
            v[3] = "Brazilia";
            v[4] = "Chile";
            v[5] = "Columbia";
            v[6] = "Ecuador";
            v[7] = "Guyana";
            v[8] = "Guyana Franceză";
            v[9] = "Paraguay";
            v[10] = "Peru";
            v[11] = "Surinam";
            v[12] = "Uruguay";
            v[13] = "Venezuela";

            w[1] = "Buenos_Aires";
            w[2] = "La_Paz";
            w[3] = "Brasilia";
            w[4] = "Santiago";
            w[5] = "Bogota";
            w[6] = "Quito";
            w[7] = "Georgetown";
            w[8] = "Cayenne";
            w[9] = "Asuncion";
            w[10] = "Lima";
            w[11] = "Paramaribo";
            w[12] = "Montevideo";
            w[13] = "Caracas";

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
            for (int i = 1; i <= 13; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 13; i++)
            {
                index = rand.Next(1, 13);
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
                if (n == 14)
                {//cand n este 14 inseamna ca am parcurs toate tarile
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
