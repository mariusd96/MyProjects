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
    public partial class Asia : Form
    {
        Bitmap[] bp = new Bitmap[50];//vector de imagini cu pozitia fiecarei tari
        Bitmap[] bp1 = new Bitmap[50];//vector de imagini cu steagul fiecarei tari
        string[] v = new string[50];//vector de capitale
        public Asia()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //setam panoul cu harta si etichetele cu tari pe centrul ecranului

            v[1] = "Kabul";
            v[2] = "Riyadh";
            v[3] = "Erevan";
            v[4] = "Baku";
            v[5] = "Manama";
            v[6] = "Dhaka";
            v[7] = "Thimphu";
            v[8] = "Naypyidaw";
            v[9] = "Bandar Seri Begawan";
            v[10] = "Phnom Penh";
            v[11] = "Beijing";
            v[12] = "Phenian";
            v[13] = "Seul";
            v[14] = "Abu Dhabi";
            v[15] = "Manila";
            v[16] = "Tbilisi";
            v[17] = "New Delhi";
            v[18] = "Jakarta";
            v[19] = "Amman";
            v[20] = "Bagdad";
            v[21] = "Teheran";
            v[22] = "Ierusalim";
            v[23] = "Tokyo";
            v[24] = "Astana";
            v[25] = "Bișkek";
            v[26] = "Kuweit";
            v[27] = "Vientiane";
            v[28] = "Beirut";
            v[29] = "Kuala Lumpur";
            v[30] = "Ulan Bator";
            v[31] = "Kathmandu";
            v[32] = "Muscat";
            v[33] = "Islamabad";
            v[34] = "Doha";
            v[35] = "Moscova";
            v[36] = "Singapore";
            v[37] = "Damasc";
            v[38] = "Colombo";
            v[39] = "Dușanbe";
            v[40] = "Taipei";
            v[41] = "Bangkok";
            v[42] = "Dili";
            v[43] = "Ankara";
            v[44] = "Așgabat";
            v[45] = "Tașkent";
            v[46] = "Hanoi";
            v[47] = "Sana'a";
            //pt tara cu numarul i (in ordine alfabetica) punem in v[i] numele capitalei
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;//nu avem bordura la inceput la acest picturebox pt a nu se vedea un chenar negru pe panou
            for (int i = 1; i <= 47; i++)
            {
                bp[i] = new Bitmap("Resurse/Harti/Asia/imagine" + i.ToString() + ".png");
                bp1[i] = new Bitmap("Resurse/Steaguri/Asia/imagine" + i.ToString() + ".png");
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
            harti.Image = Properties.Resources._0Asia;
            steag.Image = null;
            capitala.Text = null;
            steag.BorderStyle = BorderStyle.None;
        }//cand nu se atinge o eticheta(label) cu numele unei tari panoul devine ca la inceput inainte de a pune cursorul pe o eticheta
    }
}
