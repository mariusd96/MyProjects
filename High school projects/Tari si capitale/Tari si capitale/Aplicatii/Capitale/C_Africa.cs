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
    public partial class C_Africa : Form
    {
        Bitmap[] bp = new Bitmap[60];
        string[] v = new string[60];
        int[] r = new int[60];
        int n = 1, index, temp, x = 1;
        int corect, gresit;
        public C_Africa()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //setam panoul1 pe centrul ecranului
            panel2.Location = new Point(panel1.Location.X - panel2.Width - 5, panel1.Location.Y);
            //setam panoul2 in stanga panoului1
            label4.Location = new Point(this.panel2.Width / 2 - label4.Width / 2, 31);//pozitionam eticheta4 pe centru-sus pe panoul2 
            v[1] = "Pretoria";
            v[2] = "Alger";
            v[3] = "Luanda";
            v[4] = "Porto Novo";
            v[5] = "Gaborone";
            v[6] = "Ouagadougou";
            v[7] = "Bujumbura";
            v[8] = "Yaounde";
            v[9] = "N'Djamena";
            v[10] = "Yamoussoukro";
            v[11] = "Moroni";
            v[12] = "Djibouti";
            v[13] = "Cairo";
            v[14] = "Asmara";
            v[15] = "Addis Abeba";
            v[16] = "Libreville";
            v[17] = "Banjul";
            v[18] = "Accra";
            v[19] = "Conakry";
            v[20] = "Bissau";
            v[21] = "Malabo";
            v[22] = "Praia";
            v[23] = "Nairobi";
            v[24] = "Maseru";
            v[25] = "Monrovia";
            v[26] = "Tripoli";
            v[27] = "Antananarivo";
            v[28] = "Lilongwe";
            v[29] = "Bamako";
            v[30] = "Rabat";
            v[31] = "Nouakchott";
            v[32] = "Port Louis";
            v[33] = "Maputo";
            v[34] = "Windhoek";
            v[35] = "Niamey";
            v[36] = "Abuja";
            v[37] = "Bangui";
            v[38] = "Brazzaville";
            v[39] = "Kinshasa";
            v[40] = "Kigali";
            v[41] = "Sao Tome";
            v[42] = "Dakar";
            v[43] = "Victoria";
            v[44] = "Freetown";
            v[45] = "Mogadishu";
            v[46] = "Khartoum";
            v[47] = "Juba";
            v[48] = "Mbabane";
            v[49] = "Dodoma";
            v[50] = "Lome";
            v[51] = "Tunis";
            v[52] = "Kampala";
            v[53] = "Lusaka";
            v[54] = "Harare";
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

            Biblioteca form = new Biblioteca(2);
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
                e.KeyChar = (char)537;
                e.Handled = false;
            }//ş
            if (e.KeyChar == (char)52)
            {
                e.KeyChar = (char)539;
                e.Handled = false;
            }//ţ
        }
    }
}
