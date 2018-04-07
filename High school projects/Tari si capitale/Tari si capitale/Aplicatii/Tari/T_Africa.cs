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
    public partial class T_Africa : Form
    {
        Bitmap[] bp = new Bitmap[60];
        string[] v = new string[60];
        int[] r = new int[60];
        int n=1, index, temp,x=1;
        int corect, gresit;
        public T_Africa()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului
            panel2.Location = new Point(panel1.Location.X - panel2.Width - 5, panel1.Location.Y);
            //setam panoul2 in stanga panoului1
            label4.Location = new Point(this.panel2.Width / 2 - label4.Width / 2, 31);//pozitionam eticheta4 pe centru-sus pe panoul2 
            label1.Text = "0";
            label2.Text = "0";
            v[1] = "Africa de Sud";
            v[2] = "Algeria";
            v[3] = "Angola";
            v[4] = "Benin";
            v[5] = "Botswana";
            v[6] = "Burkina Faso";
            v[7] = "Burundi";
            v[8] = "Camerun";
            v[9] = "Ciad";
            v[10] = "Coasta de Fildeş";
            v[11] = "Comore";
            v[12] = "Djibouti";
            v[13] = "Egipt";
            v[14] = "Eritreea";
            v[15] = "Etiopia";
            v[16] = "Gabon";
            v[17] = "Gambia";
            v[18] = "Ghana";
            v[19] = "Guineea";
            v[20] = "Guineea-Bissau";
            v[21] = "Guineea-Ecuatorială";
            v[22] = "Insulele Capului Verde";
            v[23] = "Kenya";
            v[24] = "Lesotho";
            v[25] = "Liberia";
            v[26] = "Libia";
            v[27] = "Madagascar";
            v[28] = "Malawi";
            v[29] = "Mali";
            v[30] = "Maroc";
            v[31] = "Mauritania";
            v[32] = "Mauritius";
            v[33] = "Mozambic";
            v[34] = "Namibia";
            v[35] = "Niger";
            v[36] = "Nigeria";
            v[37] = "Republica Centrafricană";
            v[38] = "Republica Congo";
            v[39] = "Republica Democrată Congo";
            v[40] = "Rwanda";
            v[41] = "Sao Tome şi Principe";
            v[42] = "Senegal";
            v[43] = "Seychelles";
            v[44] = "Sierra Leone";
            v[45] = "Somalia";
            v[46] = "Sudan";
            v[47] = "Sudanul de Sud";
            v[48] = "Swaziland";
            v[49] = "Tanzania";
            v[50] = "Togo";
            v[51] = "Tunisia";
            v[52] = "Uganda";
            v[53] = "Zambia";
            v[54] = "Zimbabwe";
            for (int i = 1; i <= 54; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/Africa/imagine" + i.ToString() + ".png");
            }//obtinem imaginile cu tarile din Africa
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
            for (int i = 1; i <= 54; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 54; i++)
            {
                index = rand.Next(1, 54);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//amestecam vectorul r pentru a avea imagini random la apasarea butonului "Done"
            harti.Image = bp[r[n]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 54; i++) bp[i] = null;

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
                if (n == 55)
                {//cand n este 55 inseamna ca am parcurs toate tarile
                    harti.Image = Properties.Resources._0Africa;
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
