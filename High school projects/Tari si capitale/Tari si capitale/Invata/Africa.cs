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
    public partial class Africa : Form
    {
        Bitmap[] bp = new Bitmap[60];//vector de imagini cu pozitia fiecarei tari
        Bitmap[] bp1 = new Bitmap[60];//vector de imagini cu steagul fiecarei tari
        string[] v = new string[60];//vector de capitale
        public Africa()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //setam panoul cu harta si etichetele cu tari pe centrul ecranului
            
            v[1] = "Cape Town";
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
            //pt tara cu numarul i (in ordine alfabetica) punem in v[i] numele capitalei
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;//nu avem bordura la inceput la acest picturebox pt a nu se vedea un chenar negru pe panou
            for (int i = 1; i <= 54; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/Africa/imagine" + i.ToString() + ".png");
                bp1[i] = new Bitmap("Resurse/Steaguri/Africa/imagine" + i.ToString() + ".png");
            }//in acest ciclu for preluam imaginea pt pozitia unei tari, respectiv steagul ei
            foreach (Control c in panel1.Controls.OfType<Label>())
            {
                c.MouseEnter += new EventHandler(SchimbareImg);
                //atunci cand tinem cursorul pe o eticheta(label) cu numele unei tari aratam pozitia, numele capitalei si steagul acelei tari
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 54; i++)
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
            for (int i = 1; i <= 54; i++)
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
            harti.Image = Properties.Resources._0Africa;
            steag.Image = null;
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;
        }//cand nu se atinge o eticheta(label) cu numele unei tari panoul devine ca la inceput inainte de a pune cursorul pe o eticheta
    }
}
