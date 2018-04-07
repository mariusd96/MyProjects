using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tari_si_capitale
{
    public partial class Obiectiv_turistic : Form
    {
        PictureBox[,] pb = new PictureBox[100, 100];
        int n, m, p, r, q, s, t = 1;
        int[] v = new int[101];
        int[] imagine = new int[1000001];
        Bitmap[] bp=new Bitmap[1000001];
        public Obiectiv_turistic()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //pozitionam panoul pe centrul ecranului

            Random rand = new Random();
            int temp;
            for (int i = 1; i <= 100; i++) v[i] = i;
            for (int i = 1; i <= 100; i++)
            {
                r = rand.Next(1, 101);
                temp = v[i];
                v[i] = v[r];
                v[r] = temp;
            }//in acest ciclu for amestecam elementele vectorului v; acest vector se foloseste la alegerea "dreptunghiurilor" care vor deveni invizibile
            string[] filename = Directory.GetFiles("Resurse/Obiective turistice/");//obtinem locatiile imaginilor
            foreach (string name in filename)
            {
                s++;
                bp[s] = new Bitmap(filename[s - 1]);
            }//punem fiecare imagine in vector
            for (int i = 1; i <= s; i++) imagine[i] = i;
            for (int i = 1; i <= s; i++)
            {
                r = rand.Next(1, s);
                temp = imagine[i];
                imagine[i] = imagine[r];
                imagine[r] = temp;
            }//in acest ciclu for amestecam imaginile
            pictureBox1.BackgroundImage = bp[imagine[1]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void Obiectiv_turistic_Load(object sender, EventArgs e)
        {
            m = 0;
            for (int i = 1; i <= 10; i++)
            {
                n = 0;
                for (int j = 1; j <= 10; j++)
                {
                    p++;
                    pb[i, j] = new PictureBox();
                    pb[i, j].Name = "picbox" + p.ToString();
                    pb[i, j].Width = 80;
                    pb[i, j].Height = 60;
                    pb[i, j].Location = new Point(n, m);
                    n += 80;
                    pb[i, j].BackColor = Color.DimGray;
                    panel1.Controls.Add(pb[i, j]);
                    pb[i, j].BringToFront();
                    pb[i, j].Text=p.ToString();
                    pb[i, j].BorderStyle = BorderStyle.FixedSingle;
                }
                m += 60;
            }
            //cream "dreptunghiurile" care le punem peste imagine pt a nu se vedea ceva din imagine
            //avem initial 100 de "dreptunghiuri" care acopera imaginea
        }

        private void ajutor_Click(object sender, EventArgs e)
        {
            if (q <= 95)
            {
                for (int i = 1; i <= 5; i++)
                {
                    q++;
                    for (int j = 1; j <= 10; j++)
                    {
                        for (int k = 1; k <= 10; k++)
                        {
                            if (pb[j, k].Name == "picbox" + v[q].ToString())
                            {
                                pb[j, k].Visible = false;
                            }
                        }
                    }//in aceste 2 cicluri for gasim numele "dreptunghiurilor" pe care le facem invizibile pt a oferi indicii
                }//in acest ciclu for crestem q; folosim variabile q la vectorul v
            }//daca mai avem "dreptunghiuri" vizibile continuam; daca nu, nu mai continuam chiar daca apasam in continuu pe buton
        }

        private void img_Click(object sender, EventArgs e)
        {
            for (int j = 1; j <= 10; j++)
            {
                for (int k = 1; k <= 10; k++)
                {
                    pb[j, k].Visible = false;
                }
            }
        }//facem toate "dreptunghiurile" invizibile

        private void Next_Click(object sender, EventArgs e)
        {
            if (t < s)
            {//s este numarul de imagini, iar t cate imagini am parcurs
                q = 0;//q devine 0 pt a sti ca nu niciun "dreptunghi" nu e invizibil
                for (int j = 1; j <= 10; j++)
                {
                    for (int k = 1; k <= 10; k++)
                    {
                        pb[j, k].Visible = true;
                    }
                }//in aceste cicluri for facem toate "dreptunghiurile" vizibile
                t++;//crestem t pt ca vom avea o alta imagine in spatele "dreptunghiurilor"
                pictureBox1.BackgroundImage = bp[imagine[t]];
            }
        }
    }
}
