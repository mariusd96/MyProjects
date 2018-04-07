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
    public partial class T_Asia : Form
    {
        Bitmap[] bp = new Bitmap[50];
        string[] v = new string[50];
        int[] r = new int[50];
        int n, index, temp, x = 1;
        int corect, gresit;
        public T_Asia()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului
            panel2.Location = new Point(panel1.Location.X - panel2.Width - 5, panel1.Location.Y);
            //setam panoul2 in stanga panoului1
            label4.Location = new Point(this.panel2.Width / 2 - label4.Width / 2, 31);//pozitionam eticheta4 pe centru-sus pe panoul2 
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
            for (int i = 1; i <= 47; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/Asia/imagine" + i.ToString() + ".png");
            }//obtinem imaginile cu tarile din Asia
            amestecare();
        }

        private void amestecare()
        {
            corect = gresit = 0;
            n = 1;//n ne arata la ce imagine suntem(ca numar)
            x = 1;//cand x este 1 primim imagini cu tari la apasarea butonului "Done"
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
            }//amestecam vectorul r pentru a avea imagini random la apasarea butonului "Done"
            harti.Image = bp[r[n]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 47; i++) bp[i] = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(1);
            form.Show();
            this.Close();
        }

        private void done_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                string raspuns;
                raspuns = richTextBox1.Text;//preluam raspunsul utilizatorului si il verificam
                if (raspuns == v[r[n]])
                {
                    corect++;//daca raspunsul este corect variabila 'corect' creste
                    label1.Text = corect.ToString();
                }
                else
                {
                    gresit++;//daca raspunsul este gresit variabila 'gresit' creste
                    label2.Text = gresit.ToString();
                }
                richTextBox1.Text = null;//caseta de text trebuie sa fie goala pt un nou raspuns
                n++;
                harti.Image = bp[r[n]];
                if (n == 48)
                {//cand n este 48 inseamna ca am parcurs toate tarile
                    harti.Image = Properties.Resources._0Asia;
                    x = 2;//cand x este 2 nu mai putem primi imagini la apasarea butonului "Done"
                    label3.Visible = true;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine vizibila
                    da.Visible = true;//butonul cu textul "DA" devine vizibil
                    nu.Visible = true;//butonul cu textul "NU" devine vizibil
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
            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width < 1280)
            {
                panel1.Location = new Point(202, this.ClientSize.Height / 2 - panel1.Height / 2);
                panel2.Location = new Point(1, this.ClientSize.Height / 2 - panel2.Height / 2);
            }//in cazul in care rezolutia pe orizontala este mai mica de 1280 pixeli repozitionam panourile
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width < 1280)
            {
                panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            }//pozitionam panoul pe centru, atunci cand panoul2 devine invizibil(in cazul in care rezolutia pe orizontala este mai mica de 1280 pixeli)
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
    }
}
