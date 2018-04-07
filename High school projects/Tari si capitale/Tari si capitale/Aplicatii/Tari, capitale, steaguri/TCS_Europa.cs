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
    public partial class TCS_Europa : Form
    {
        Bitmap[] bp = new Bitmap[50];//vectorul de imagini
        string[] v = new string[50];//vectorul de tari
        string[] w = new string[50];//vectorul de capitale
        int[] r = new int[50];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public TCS_Europa()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului
            panel2.Location = new Point(panel1.Location.X - panel2.Width - 5, panel1.Location.Y);
            //setam panoul2 in stanga panoului1
            label4.Location = new Point(this.panel2.Width / 2 - label4.Width / 2, 31);//pozitionam eticheta4 pe centru-sus pe panoul2 
            label1.Text = "0";
            label2.Text = "0";

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
            w[2] = "Andorra la Vella";
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
            w[35] = "Chişinău";
            w[36] = "București";
            w[37] = "Moscova";
            w[38] = "San Marino";
            w[39] = "Belgrad";
            w[40] = "Bratislava";
            w[41] = "Ljubljana";
            w[42] = "Madrid";
            w[43] = "Stockholm";
            w[44] = "Ankara";
            w[45] = "Kiev";
            w[46] = "Budapesta";
            w[47] = "Vatican";
            for (int i = 1; i <= 47; i++)
            {
                bp[i] = new Bitmap("Resurse/harti+steaguri/Europa/imagine" + i.ToString() + ".png");
            }//obtinem imaginile cu tarile din Europa
            amestecare();
        }

        private void amestecare()
        {
            steag.BackgroundImage = null;
            corect = gresit = 0;
            n = 1;//n ne arata la ce imagine suntem(ca numar)
            if (x != 0) x = 1;//cand x este 1 primim imagini cu tari la apasarea butonului "Next"
            //daca x este 0 avem interfata elev-profesor
            label1.Text = corect.ToString();
            label2.Text = gresit.ToString();
            label3.Visible = false;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine invizibila
            da.Visible = false;//butonul cu textul "DA" devine invizibil
            nu.Visible = false;//butonul cu textul "NU" devine invizibil
            for (int i = 1; i <= 47; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 47; i++)
            {
                index = rand.Next(1, 47);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//amestecam vectorul r pentru a avea imagini random la apasarea butonului "Next"
            steag.Image = bp[r[n]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 47; i++) bp[i] = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(4);
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
                if (n == 48)
                {//cand n este 48 inseamna ca am parcurs toate tarile
                    x = 2; //cand x este 2 nu mai putem primi imagini la apasarea butonului "Next"
                    label3.Visible = true;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine vizibila
                    da.Visible = true;//butonul cu textul "DA" devine vizibil
                    nu.Visible = true;//butonul cu textul "NU" devine vizibil
                    steag.BackgroundImage = Properties.Resources.Europa1;//la final o imagine reprezentativa pt Europa
                    steag.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            if (x == 0)
            {//cand x este 0 avem interfata elev-profesor
                n++;
                steag.Image = bp[r[n]];
                if (n == 48)
                {//cand n este 48 inseamna ca am parcurs toate tarile si o luam de la inceput
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
