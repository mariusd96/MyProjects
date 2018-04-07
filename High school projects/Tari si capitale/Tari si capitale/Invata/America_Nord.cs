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
    public partial class America_Nord : Form
    {
        Bitmap[] bp = new Bitmap[30];//vector de imagini cu pozitia fiecarei tari
        Bitmap[] bp1 = new Bitmap[30];//vector de imagini cu steagul fiecarei tari
        string[] v = new string[30];//vector de capitale
        public America_Nord()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //setam panoul cu harta si etichetele cu tari pe centrul ecranului

            v[1] = "Saint John's";
            v[2] = "Nassau";
            v[3] = "Bridgetown";
            v[4] = "Belmopan";
            v[5] = "Ottawa";
            v[6] = "San Jose";
            v[7] = "Havana";
            v[8] = "Roseau";
            v[9] = "San Salvador";
            v[10] = "Saint George's";
            v[11] = "Ciudad de Guatemala";
            v[12] = "Port-au-Prince";
            v[13] = "Tegucigalpa";
            v[14] = "Kingston";
            v[15] = "Ciudad de Mexico";
            v[16] = "Managua";
            v[17] = "Ciudad de Panama";
            v[18] = "Santo Domingo";
            v[19] = "Basseterre";
            v[20] = "Castries";
            v[21] = "Kingstown";
            v[22] = "Washington DC";
            v[23] = "Port of Spain";
            //pt tara cu numarul i (in ordine alfabetica) punem in v[i] numele capitalei
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;//nu avem bordura la inceput la acest picturebox pt a nu se vedea un chenar negru pe panou
            for (int i = 1; i <= 23; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/AmericaN/imagine" + i.ToString() + ".png");
                bp1[i] = new Bitmap("Resurse/Steaguri/AmericaN/imagine" + i.ToString() + ".png");
            }//in acest ciclu for preluam imaginea pt pozitia unei tari, respectiv steagul ei
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.MouseEnter += new EventHandler(SchimbareImg);
                //atunci cand tinem cursorul pe o eticheta(label) cu numele unei tari aratam pozitia, numele capitalei si steagul acelei tari
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 23; i++)
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
            for (int i = 1; i <= 23; i++)
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
            harti.Image = Properties.Resources.america_de_nord1;
            steag.Image = null;
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;
        }//cand nu se atinge o eticheta(label) cu numele unei tari panoul devine ca la inceput inainte de a pune cursorul pe o eticheta
    }
}
