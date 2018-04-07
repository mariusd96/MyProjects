﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tari_si_capitale
{
    public partial class S_AmericaS : Form
    {
        Bitmap[] bp = new Bitmap[20];//vectorul de imagini cu steaguri
        string[] v = new string[20];//vectorul de tari
        string[] w = new string[20];//vectorul de capitale
        int[] r = new int[20];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public S_AmericaS()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului
            panel2.Location = new Point(panel1.Location.X - panel2.Width - 5, panel1.Location.Y);
            //setam panoul2 in stanga panoului1
            label4.Location = new Point(this.panel2.Width / 2 - label4.Width / 2, 31);//pozitionam eticheta4 pe centru-sus pe panoul2 
            label1.Text = "0";
            label2.Text = "0";

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

            w[1] = "Buenos Aires";
            w[2] = "La Paz";
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
            for (int i = 1; i <= 13; i++)
            {
                bp[i] = new Bitmap("Resurse/Steaguri/AmericaS/imagine" + i.ToString() + ".png");
            }//obtinem imaginile cu tarile din America de Sud
            amestecare();
        }

        private void amestecare()
        {
            corect = gresit = 0;
            n = 1;//n ne arata la ce imagine suntem(ca numar)
            if (x != 0) x = 1;//cand x este 1 primim imagini cu tari la apasarea butonului "Next"
            //daca x este 0 avem interfata elev-profesor
            label1.Text = corect.ToString();
            label2.Text = gresit.ToString();
            label3.Visible = false;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine invizibila
            da.Visible = false;//butonul cu textul "DA" devine invizibil
            nu.Visible = false;//butonul cu textul "NU" devine invizibil
            for (int i = 1; i <= 13; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 13; i++)
            {
                index = rand.Next(1, 13);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//amestecam vectorul r pentru a avea imagini random la apasarea butonului "Next"
            steag.Image = bp[r[n]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 13; i++) bp[i] = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(3);
            form.Show();
            this.Close();
        }

        private void done_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                string raspuns1;
                string raspuns2;
                raspuns1 = richTextBox1.Text;//preluam raspunsul utilizatorului si il verificam(verificam tara)
                raspuns2 = richTextBox2.Text;//preluam raspunsul utilizatorului si il verificam(verificam capitala)
                if (raspuns1 == v[r[n]] && raspuns2 == w[r[n]])
                {
                    corect++;//daca ambele raspunsuri sunt corecte variabila 'corect' creste
                    label1.Text = corect.ToString();
                }
                else
                {
                    gresit++;//daca unul dintre raspunsuri este gresit variabila 'gresit' creste
                    label2.Text = gresit.ToString();
                }
                richTextBox1.Text = null;
                richTextBox2.Text = null;
                //casetele de text trebuie sa fie goale pt raspunsuri noi
                n++;
                steag.Image = bp[r[n]];
                if (n == 14)
                {//cand n este 14 inseamna ca am parcurs toate tarile
                    x = 2; //cand x este 2 nu mai putem primi imagini la apasarea butonului "Next"
                    label3.Visible = true;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine vizibila
                    da.Visible = true;//butonul cu textul "DA" devine vizibil
                    nu.Visible = true;//butonul cu textul "NU" devine vizibil
                    steag.Image = Properties.Resources.machu_picchu1;//la final o imagine reprezentativa pt America de Sud
                }
            }
            if (x == 0)
            {//cand x este 0 avem interfata elev-profesor
                n++;
                steag.Image = bp[r[n]];
                if (n == 14)
                {//cand n este 14 inseamna ca am parcurs toate tarile si o luam de la inceput
                    amestecare();
                }
            }
        }

        private void da_Click(object sender, EventArgs e)
        {
            amestecare();
        }

        private void nu_Click(object sender, EventArgs e)
        {
            label3.Visible = false;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine invizibila
            da.Visible = false;//butonul cu textul "DA" devine invizibil
            nu.Visible = false;//butonul cu textul "NU" devine invizibil
        }

        private void instructiuni_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)49)
            {
                e.KeyChar = (char)259;
                e.Handled = false;
            }//ă
            if (e.KeyChar == (char)50)
            {
                e.KeyChar = (char)226;
                e.Handled = false;
            }//â
            if (e.KeyChar == (char)51)
            {
                e.KeyChar = (char)351;
                e.Handled = false;
            }//ş
            if (e.KeyChar == (char)52)
            {
                e.KeyChar = (char)355;
                e.Handled = false;
            }//ţ
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)49)
            {
                e.KeyChar = (char)259;
                e.Handled = false;
            }//ă
            if (e.KeyChar == (char)50)
            {
                e.KeyChar = (char)226;
                e.Handled = false;
            }//â
            if (e.KeyChar == (char)51)
            {
                e.KeyChar = (char)537;
                e.Handled = false;
            }//ş
            if (e.KeyChar == (char)52)
            {
                e.KeyChar = (char)539;
                e.Handled = false;
            }//ţ
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {//cand apasam pe imaginea cu semnul X interfata se schimba devenind una elev-profesor
            x = 0;//interfata elev-profesor
            da.Visible = nu.Visible = false;
            label1.Visible = label2.Visible = label3.Visible = label6.Visible = label7.Visible = false;
            richTextBox1.Visible = richTextBox2.Visible = false;
            pictureBox1.Visible = pictureBox2.Visible = false;
            panel2.Visible = false;
            instructiuni.Visible = false;
            done.Location = new Point(12, 415);
            done.Width = 550;
            done.Height = 100;
        }//nu mai avem scor, casete pt raspunsuri si ramane doar butonul cu textul "Next"
    }
}