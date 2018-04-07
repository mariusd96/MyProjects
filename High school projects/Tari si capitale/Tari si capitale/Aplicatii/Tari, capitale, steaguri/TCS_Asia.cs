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
    public partial class TCS_Asia : Form
    {
        Bitmap[] bp = new Bitmap[50];//vectorul de imagini
        string[] v = new string[50];//vectorul de tari
        string[] w = new string[50];//vectorul de capitale
        int[] r = new int[50];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public TCS_Asia()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului
            panel2.Location = new Point(panel1.Location.X - panel2.Width - 5, panel1.Location.Y);
            //setam panoul2 in stanga panoului1
            label4.Location = new Point(this.panel2.Width / 2 - label4.Width / 2, 31);//pozitionam eticheta4 pe centru-sus pe panoul2
            label1.Text = "0";
            label2.Text = "0";

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
            w[9] = "Bandar Seri Begawan";
            w[10] = "Phnom Penh";
            w[11] = "Beijing";
            w[12] = "Phenian";
            w[13] = "Seul";
            w[14] = "Abu Dhabi";
            w[15] = "Manila";
            w[16] = "Tbilisi";
            w[17] = "New Delhi";
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
            w[29] = "Kuala Lumpur";
            w[30] = "Ulan Bator";
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
            w[47] = "Sana'a";
            for (int i = 1; i <= 47; i++)
            {
                bp[i] = new Bitmap("Resurse/harti+steaguri/Asia/imagine" + i.ToString() + ".png");
            }//obtinem imaginile cu tarile din Asia
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
                    steag.BackgroundImage = Properties.Resources.Asia;//la final o imagine reprezentativa pt Asia
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
