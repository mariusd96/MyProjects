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
    public partial class S_Africa : Form
    {
        Bitmap[] bp = new Bitmap[60];//vectorul de imagini cu steaguri
        string[] v = new string[60];//vectorul de tari
        string[] w = new string[60];//vectorul de capitale
        int[] r = new int[60];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public S_Africa()
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

            w[1] = "Pretoria";
            w[2] = "Alger";
            w[3] = "Luanda";
            w[4] = "Porto Novo";
            w[5] = "Gaborone";
            w[6] = "Ouagadougou";
            w[7] = "Bujumbura";
            w[8] = "Yaounde";
            w[9] = "N'Djamena";
            w[10] = "Yamoussoukro";
            w[11] = "Moroni";
            w[12] = "Djibouti";
            w[13] = "Cairo";
            w[14] = "Asmara";
            w[15] = "Addis Abeba";
            w[16] = "Libreville";
            w[17] = "Banjul";
            w[18] = "Accra";
            w[19] = "Conakry";
            w[20] = "Bissau";
            w[21] = "Malabo";
            w[22] = "Praia";
            w[23] = "Nairobi";
            w[24] = "Maseru";
            w[25] = "Monrovia";
            w[26] = "Tripoli";
            w[27] = "Antananarivo";
            w[28] = "Lilongwe";
            w[29] = "Bamako";
            w[30] = "Rabat";
            w[31] = "Nouakchott";
            w[32] = "Port Louis";
            w[33] = "Maputo";
            w[34] = "Windhoek";
            w[35] = "Niamey";
            w[36] = "Abuja";
            w[37] = "Bangui";
            w[38] = "Brazzaville";
            w[39] = "Kinshasa";
            w[40] = "Kigali";
            w[41] = "Sao Tome";
            w[42] = "Dakar";
            w[43] = "Victoria";
            w[44] = "Freetown";
            w[45] = "Mogadishu";
            w[46] = "Khartoum";
            w[47] = "Juba";
            w[48] = "Mbabane";
            w[49] = "Dodoma";
            w[50] = "Lome";
            w[51] = "Tunis";
            w[52] = "Kampala";
            w[53] = "Lusaka";
            w[54] = "Harare";
            for (int i = 1; i <= 54; i++)
            {
                bp[i] = new Bitmap("Resurse/Steaguri/Africa/imagine" + i.ToString() + ".png");
            }//obtinem imaginile cu tarile din Africa
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
            for (int i = 1; i <= 54; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 54; i++)
            {
                index = rand.Next(1, 54);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }//amestecam vectorul r pentru a avea imagini random la apasarea butonului "Next"
            steag.Image = bp[r[n]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 54; i++) bp[i] = null; 

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
                if (n == 55)
                {//cand n este 55 inseamna ca am parcurs toate tarile
                    x = 2; //cand x este 2 nu mai putem primi imagini la apasarea butonului "Next"
                    label3.Visible = true;//eticheta cu textul "Sfârşitul jocului. Doriţi să îl jucaţi de la început?" devine vizibila
                    da.Visible = true;//butonul cu textul "DA" devine vizibil
                    nu.Visible = true;//butonul cu textul "NU" devine vizibil
                    steag.Image = Properties.Resources.marakele_national_park_south_africa_wallpaper;//la final o imagine reprezentativa pt Africa
                }
            }
            if (x == 0)
            {//cand x este 0 avem interfata elev-profesor
                n++;
                steag.Image = bp[r[n]];
                if (n == 55)
                {//cand n este 55 inseamna ca am parcurs toate tarile si o luam de la inceput
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
            done.Location = new Point(12,415);
            done.Width = 550;
            done.Height = 100;
        }//nu mai avem scor, casete pt raspunsuri si ramane doar butonul cu textul "Next"
    }
}
