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
    public partial class LC_Oceania : Form
    {
        string[] v = new string[10];//vectorul de capitale
        string[] w = new string[10];//vector cu numele butoanelor
        int[] r = new int[10];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public LC_Oceania()
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

            v[1] = "Canberra";
            v[2] = "Suva";
            v[3] = "Honiara";
            v[4] = "Wellington";
            v[5] = "Port Moresby";
            v[6] = "Apia";
            v[7] = "Nuku'alofa";
            v[8] = "Port Vila";

            w[1] = "Canberra";
            w[2] = "Suva";
            w[3] = "Honiara";
            w[4] = "Wellington";
            w[5] = "Port_Moresby";
            w[6] = "Apia";
            w[7] = "Nuku_alofa";
            w[8] = "Port_Vila";

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
            for (int i = 1; i <= 8; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 8; i++)
            {
                index = rand.Next(1, 8);
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
                if (n == 9)
                {//cand n este 9 inseamna ca am parcurs toate tarile
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
