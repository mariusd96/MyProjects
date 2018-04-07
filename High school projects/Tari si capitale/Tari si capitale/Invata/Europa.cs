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
    public partial class Europa : Form
    {
        Bitmap[] bp = new Bitmap[50];//vector de imagini cu pozitia fiecarei tari
        Bitmap[] bp1 = new Bitmap[50];//vector de imagini cu steagul fiecarei tari
        string[] v = new string[50];//vector de capitale
        public Europa()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //setam panoul cu harta si etichetele cu tari pe centrul ecranului

            v[1] = "Tirana";
            v[2] = "Andorra la Vella";
            v[3] = "Viena";
            v[4] = "Minsk";
            v[5] = "Bruxelles";
            v[6] = "Sarajevo";
            v[7] = "Sofia";
            v[8] = "Praga";
            v[9] = "Nicosia";
            v[10] = "Zagreb";
            v[11] = "Copenhaga";
            v[12] = "Berna";
            v[13] = "Tallinn";
            v[14] = "Helsinki";
            v[15] = "Paris";
            v[16] = "Berlin";
            v[17] = "Atena";
            v[18] = "Dublin";
            v[19] = "Reykjavik";
            v[20] = "Roma";
            v[21] = "Priștina";
            v[22] = "Riga";
            v[23] = "Vaduz";
            v[24] = "Vilnius";
            v[25] = "Luxemburg";
            v[26] = "Skopje";
            v[27] = "Valletta";
            v[28] = "Monaco";
            v[29] = "Podgorica";
            v[30] = "Oslo";
            v[31] = "Amsterdam";
            v[32] = "Varșovia";
            v[33] = "Lisabona";
            v[34] = "Londra";
            v[35] = "Chișinău";
            v[36] = "București";
            v[37] = "Moscova";
            v[38] = "San Marino";
            v[39] = "Belgrad";
            v[40] = "Bratislava";
            v[41] = "Ljubljana";
            v[42] = "Madrid";
            v[43] = "Stockholm";
            v[44] = "Ankara";
            v[45] = "Kiev";
            v[46] = "Budapesta";
            v[47] = "Vatican";
            //pt tara cu numarul i (in ordine alfabetica) punem in v[i] numele capitalei
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;//nu avem bordura la inceput la acest picturebox pt a nu se vedea un chenar negru pe panou
            for (int i = 1; i <= 47; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/Europa/imagine" + i.ToString() + ".png");
                bp1[i] = new Bitmap("Resurse/Steaguri/Europa/imagine" + i.ToString() + ".png");
            }//in acest ciclu for preluam imaginea pt pozitia unei tari, respectiv steagul ei
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.MouseEnter += new EventHandler(SchimbareImg);
                //atunci cand tinem cursorul pe o eticheta(label) cu numele unei tari aratam pozitia, numele capitalei si steagul acelei tari
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 47; i++)
            {
                bp[i] = null;
                bp1[i] = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Invata form = new Invata();
            form.Show();
            this.Hide();
        }

        private void SchimbareImg(object sender, EventArgs e)
        {
            steag.BorderStyle = BorderStyle.FixedSingle;//punem bordura la picturebox-ul unde avem imaginea unui steag in caz ca un steag ar avea fundal alb
            Label l = (Label)sender;//avem informatiile etichetei pe care tinem cursorul
            for (int i = 1; i <= 47; i++)
            {
                if (l.Name == "label" + i.ToString())
                {
                    harti.Image = bp[i];
                    steag.Image = bp1[i];
                    capitala.Text = "Capitală : " + v[i];
                }
            }// in ciclul for aflam care este numele etichetei pe care tinem cursorul;  cand am gasit numele care ne trebuie aratam pozitia, numele capitalei si steagul acelei tari
        }//functia care atunci cand tinem cursorul pe o eticheta(label) cu numele unei tari ne arata pozitia, numele capitalei si steagul acelei tari

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            harti.Image = Properties.Resources._1Europa;
            steag.Image = null;
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;
        }//cand nu se atinge o eticheta(label) cu numele unei tari panoul devine ca la inceput inainte de a pune cursorul pe o eticheta
    }
}
