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
    public partial class America_Sud : Form
    {
        Bitmap[] bp = new Bitmap[20];//vector de imagini cu pozitia fiecarei tari
        Bitmap[] bp1 = new Bitmap[20];//vector de imagini cu steagul fiecarei tari
        string[] v = new string[20];//vector de capitale
        public America_Sud()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //setam panoul cu harta si etichetele cu tari pe centrul ecranului

            v[1] = "Buenos Aires";
            v[2] = "La Paz";
            v[3] = "Brasilia";
            v[4] = "Santiago";
            v[5] = "Bogota";
            v[6] = "Quito";
            v[7] = "Georgetown";
            v[8] = "Cayenne";
            v[9] = "Asuncion";
            v[10] = "Lima";
            v[11] = "Paramaribo";
            v[12] = "Montevideo";
            v[13] = "Caracas";
            //pt tara cu numarul i (in ordine alfabetica) punem in v[i] numele capitalei
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;
            for (int i = 1; i <= 13; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/AmericaS/imagine" + i.ToString() + ".png");
                bp1[i] = new Bitmap("Resurse/Steaguri/AmericaS/imagine" + i.ToString() + ".png");
            }//in acest ciclu for preluam imaginea pt pozitia unei tari, respectiv steagul ei
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.MouseEnter += new EventHandler(SchimbareImg);
                //atunci cand tinem cursorul pe o eticheta(label) cu numele unei tari aratam pozitia, numele capitalei si steagul acelei tari
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 13; i++)
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
            for (int i = 1; i <= 13; i++)
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
            harti.Image = Properties.Resources.America_de_S1;
            steag.Image = null;
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;
        }//cand nu se atinge o eticheta(label) cu numele unei tari panoul devine ca la inceput inainte de a pune cursorul pe o eticheta
    }
}
