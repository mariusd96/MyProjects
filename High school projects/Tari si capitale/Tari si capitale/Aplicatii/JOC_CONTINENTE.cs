using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tari_si_capitale
{
    public partial class JOC_CONTINENTE : Form
    {
        Random rand = new Random();
        int nr, x, y, s, move, echipe, echipa_curenta = 1;
        int inceput, castig = 0;
        int[] xc = new int[50];
        int[] yc = new int[50];
        // xc si yc sunt vectori pt coordonatele imaginilor(cercuri si continente) de pe tabla de joc
        int[] sizexc = new int[50];
        int[] sizeyc = new int[50];
        // sizexc si sizeyc sunt vectori pt dimensiunile imaginilor(cercuri si continente) de pe tabla de joc
        int[] poz = new int[50];//vector pt pozitia pionilor

        string[] filename;

        Bitmap[] bp = new Bitmap[100001];//vector de pioni
        Bitmap[] picbox = new Bitmap[7];//vector pt pionii care ii folosim in joc

        PictureBox[] picture = new PictureBox[7];//vector pt pionii care ii folosim in joc

        int temp, aux;
        List<string> intrebari = new List<string>();//lista intrebari generale
        int[] ordine_intrebari;
        int nr_intrebari;

        List<string> intrebari_africa = new List<string>();
        List<string> intrebari_america_nord = new List<string>();
        List<string> intrebari_america_sud = new List<string>();
        List<string> intrebari_asia = new List<string>();
        List<string> intrebari_europa = new List<string>();
        List<string> intrebari_oceania = new List<string>();
        //liste cu intrebari speciale pt fiecare continent

        public JOC_CONTINENTE()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            panel3.Location = new Point(this.ClientSize.Width / 2 - panel3.Width / 2, this.ClientSize.Height / 2 - panel3.Height / 2);
            //pozitionam panoul1 si panoul3 pe centrul ecranului
            panel4.Location = new Point(this.ClientSize.Width - panel4.Width, this.ClientSize.Height / 2 - panel4.Height / 2);
            //pozitionam panoul4(cel cu valoarea zarului in cazul in care in realitate exista un zar pt acest joc)

            nr = rand.Next(1,7);
            if (nr == 1) zar.BackgroundImage = Properties.Resources.zar1;
            else if (nr == 2) zar.BackgroundImage = Properties.Resources.zar2;
            else if (nr == 3) zar.BackgroundImage = Properties.Resources.zar3;
            else if (nr == 4) zar.BackgroundImage = Properties.Resources.zar4;
            else if (nr == 5) zar.BackgroundImage = Properties.Resources.zar5;
            else if (nr == 6) zar.BackgroundImage = Properties.Resources.zar6;

            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width >= 1280)
            {
                zar.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - panel1.Width / 2 - 120, this.ClientSize.Height / 2 - zar.Height / 2);
                x = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - panel1.Width) / 2 - zar.Width;
                y = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - panel1.Height) / 2;
            }
            else
            {
                panel1.Controls.Add(zar);
                zar.Location = new Point(12, 600);
            }

            citire_img();
            citire_coordonate();

            for (int i = 1; i <= 42; i++)
            {
                foreach (Control c in panel1.Controls.OfType<PictureBox>())
                {
                    c.SendToBack();
                    if (c.Name == "pb" + i.ToString()) c.Visible = false;
                }
            }//toate imaginile de pe panoul1("tabla de joc") devin invizibile
            pictureBox1.Visible = pictureBox2.Visible = false;// imaginile cu liniile de start si de finish devin invizibile

            citire_intrebari();
            citire_intrebari_africa();
            citire_intrebari_americaN();
            citire_intrebari_americaS();
            citire_intrebari_asia();
            citire_intrebari_europa();
            citire_intrebari_oceania();
        }

        private void citire_img()
        {
            filename=Directory.GetFiles("Resurse/Joc/pioni");//aflam locatia imaginilor cu pioni
            foreach (string name in filename)
            {
                s++;
                bp[s] = new Bitmap(filename[s - 1]);//punem imaginile cu pioni intr-un vector
            }
            //s este numarul de pioni
        }

        private void citire_coordonate()
        {
            for (int i = 1; i <= 42; i++)
            {
                foreach (Control c in panel1.Controls.OfType<PictureBox>())
                {
                    if (c.Name == "pb" + i.ToString())
                    {
                        xc[i] = c.Location.X;
                        yc[i] = c.Location.Y;
                        sizexc[i] = c.Size.Width;
                        sizeyc[i] = c.Size.Height;
                    }
                }
            }
        }//preluam coordonatele imaginilor cu continente si cu cercuri

        private void citire_intrebari()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/intrebari.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari.Add(line);
            }//citim fisierul "intrebari.txt" linie cu linie
            sr.Close();
            ordine_intrebari = new int[intrebari.Count + 1];
            for (int i = 0; i < intrebari.Count; i++) ordine_intrebari[i] = i;
            for (int i = 0; i < intrebari.Count; i++)
            {
                temp = rand.Next(0, intrebari.Count + 1);
                aux = ordine_intrebari[i];
                ordine_intrebari[i] = ordine_intrebari[temp];
                ordine_intrebari[temp] = aux;  
            }//amestecam intrebarile

        }

        private void citire_intrebari_africa()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/africa.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari_africa.Add(line);
            }//citim fisierul "africa.txt" linie cu linie
            sr.Close();
        }

        private void citire_intrebari_americaN()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/americaN.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari_america_nord.Add(line);
            }//citim fisierul "americaN.txt" linie cu linie
            sr.Close();
        }

        private void citire_intrebari_americaS()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/americaS.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari_america_sud.Add(line);
            }//citim fisierul "americaS.txt" linie cu linie
            sr.Close();
        }

        private void citire_intrebari_asia()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/asia.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari_asia.Add(line);
            }//citim fisierul "asia.txt" linie cu linie
            sr.Close();
        }

        private void citire_intrebari_europa()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/europa.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari_europa.Add(line);
            }//citim fisierul "europa.txt" linie cu linie
            sr.Close();
        }

        private void citire_intrebari_oceania()
        {
            StreamReader sr = new StreamReader("Resurse/Joc/intrebari/oceania.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                intrebari_oceania.Add(line);
            }//citim fisierul "oceania.txt" linie cu linie
            sr.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panel1.ClientRectangle;
            Pen p = new Pen(Color.Red, 5);
            e.Graphics.DrawRectangle(p,rect);
            p.Dispose();
        }//facem contur de culoare rosie la panoul1(panoul1 este "tabla de joc")

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;//panoul2(cel cu alegerea pionilor) devine vizibil
            panel2.Location = new Point(this.ClientSize.Width / 2 - panel2.Width / 2, this.ClientSize.Height / 2 - panel2.Height / 2);
            //pozitionam panoul2 pe centrul ecranului
            move = 1;
            pictureBox3.Image = bp[1];

            label1.Visible = false;
            echipe = Convert.ToInt32(numericUpDown1.Value);//preluam numarul de echipe
            numericUpDown1.Visible = false;
            button2.Visible = false;
        }

        private void zar_Click(object sender, EventArgs e)
        {
            if (castig == 0)
            {
                if (panel3.Visible == false)
                {//operatiile care se executa la apasarea imaginii cu zarul au loc doar daca panoul cu intrebari este invizibil
                    //daca nu ar fi acest if echipa curenta poate avansa si poate primi alta intrebare
                    //sau s-ar trece imediat la echipa urmatoare, echipa precedenta castigand pozitia fara a raspunde la intrebarea ce i-a fost data

                    nr = rand.Next(1, 7);//alegem un numar intre 1 si 6 in cazul in care in realitate nu exista un zar
                    if (nr == 1) zar.BackgroundImage = Properties.Resources.zar1;
                    else if (nr == 2) zar.BackgroundImage = Properties.Resources.zar2;
                    else if (nr == 3) zar.BackgroundImage = Properties.Resources.zar3;
                    else if (nr == 4) zar.BackgroundImage = Properties.Resources.zar4;
                    else if (nr == 5) zar.BackgroundImage = Properties.Resources.zar5;
                    else if (nr == 6) zar.BackgroundImage = Properties.Resources.zar6;
                    //in if-uri vedem ce valoare are zarul si aratam imaginea cu aceasta valoare

                    if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width >= 1280) zar.Location = new Point(rand.Next(10, x - 10 + 1), rand.Next(y, panel1.Height - zar.Height + 1));

                    if (inceput == 0)
                    {
                        picture[echipa_curenta].Visible = true;
                    }
                    picture[echipa_curenta].BringToFront();
                    poz[echipa_curenta] += nr;
                    if (poz[echipa_curenta] > 42)
                    {
                        string mesaj;
                        mesaj = "Echipa ";
                        mesaj = mesaj + echipa_curenta.ToString();
                        mesaj = mesaj + " a câştigat !!! . Jocul s-a terminat.";
                        MessageBox.Show(mesaj.ToString());
                        picture[echipa_curenta].Location = new Point(930, 580);
                        castig = 1;
                    }//cand o echipa a terminat o anuntam si o pozitionam pe linia de finish
                    else
                    {
                        picture[echipa_curenta].Location = new Point(xc[poz[echipa_curenta]] + sizexc[poz[echipa_curenta]] / 2 - picture[echipa_curenta].Width / 2, yc[poz[echipa_curenta]] + sizeyc[poz[echipa_curenta]] / 2 - picture[echipa_curenta].Height / 2);
                        //pozitionam pionul
                        panel3.Visible = true;//panoul cu intrebari devine vizibil
                    }

                    if (poz[echipa_curenta] == 2 || poz[echipa_curenta] == 5 || poz[echipa_curenta] == 7)
                    {
                        richTextBox1.Text = intrebari_oceania[rand.Next(0, intrebari_oceania.Count)];
                    }
                    else if (poz[echipa_curenta] == 9 || poz[echipa_curenta] == 12 || poz[echipa_curenta] == 14)
                    {
                        richTextBox1.Text = intrebari_america_nord[rand.Next(0, intrebari_america_nord.Count)];
                    }
                    else if (poz[echipa_curenta] == 16 || poz[echipa_curenta] == 19 || poz[echipa_curenta] == 21)
                    {
                        richTextBox1.Text = intrebari_america_sud[rand.Next(0, intrebari_america_sud.Count)];
                    }
                    else if (poz[echipa_curenta] == 23 || poz[echipa_curenta] == 26 || poz[echipa_curenta] == 28)
                    {
                        richTextBox1.Text = intrebari_africa[rand.Next(0, intrebari_africa.Count)];
                    }
                    else if (poz[echipa_curenta] == 30 || poz[echipa_curenta] == 33 || poz[echipa_curenta] == 35)
                    {
                        richTextBox1.Text = intrebari_asia[rand.Next(0, intrebari_asia.Count)];
                    }
                    else if (poz[echipa_curenta] == 37 || poz[echipa_curenta] == 40 || poz[echipa_curenta] == 42)
                    {
                        richTextBox1.Text = intrebari_europa[rand.Next(0, intrebari_europa.Count)];
                    }//in if-urile de mai sus vedem daca pionul se afla pe o pozitie speciala, iar echipa cu acel pion va primi o intrebare din acel continent ilustrat
                    else
                    {
                        richTextBox1.Text = intrebari[ordine_intrebari[nr_intrebari]];
                        nr_intrebari++;
                    }//daca pionul nu se afla pe o pozitie speciala primeste intrebari din toate continentele
                }
            }
        }

        private void prev_img_Click(object sender, EventArgs e)
        {
            move--;
            if (move == 0) move = s;
            pictureBox3.Image = bp[move];
            //daca variabila move=1 si apasam pe butonul prev_img move devine 0 si nu avem imagine in bp[0] asa ca move va fi egal cu numarul pionilor
        }

        private void next_img_Click(object sender, EventArgs e)
        {
            move++;
            if (move > s) move = 1;
            pictureBox3.Image = bp[move];
            //daca variabila move=s si apasam pe butonul next_img move devine s+1 si nu avem imagine in bp[s+1] asa ca move va fi egal cu 1
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (next.Text == "Next")
            {
                picbox[echipa_curenta] = bp[move];
                for (int i = move; i < s; i++)
                {
                    bp[i] = bp[i + 1];
                }
                s--;
                //scoatem pionul ales din vectorul de pioni si scadem astfel numarul pionilor ramasi

                echipa_curenta++;//urmatoarea echipa isi alege pionul
                if (move <= s) pictureBox3.Image = bp[move];
                else
                {
                    move = 1;
                    pictureBox3.Image = bp[move];
                }
                if (echipa_curenta == echipe) next.Text = "Play";
                label2.Text = "Alege pionul pentru echipa " + echipa_curenta.ToString();
            }
            else
            {//daca toate echipele si-au ales cate un pion trecem mai departe
                picbox[echipa_curenta] = bp[move];
                panel1.Visible = true;
                zar.Visible = true;

                pioni_pe_tabla_de_joc();
            }
        }

        private void pioni_pe_tabla_de_joc()
        {
            echipa_curenta = 1;//incepem intotdeauna cu echipa nr.1
            for (int i = 1; i <= echipe; i++)
            {
                picture[i] = new PictureBox();
                panel1.Controls.Add(picture[i]);
                picture[i].Image = picbox[i];
                picture[i].SizeMode = PictureBoxSizeMode.CenterImage;
                picture[i].BackColor = Color.Transparent;
                picture[i].Visible = false;
                picture[i].Location = new Point(0, pictureBox1.Height / 2 - picture[i].Height / 2);
                picture[i].Width = 70;
                picture[i].Height = 100;
            }//in acest ciclu for punem pionii pe tabla noastra de joc

            picture[1].Visible = true;
        }

        private void da_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            echipa_curenta++;//trecem la urmatoarea echipa
            if (echipa_curenta == echipe + 1)
            {
                echipa_curenta = 1;
                inceput = 1;
            }//daca numarul echipei urmatoare este mai mare decat numarul de echipe trecem la prima echipa
            //de exemplu avem 5 echipe si suntem am evaluat raspunsul echipei nr.5 atunci trecem la echipa nr.1
            if (inceput == 0)
            {
                picture[echipa_curenta].Visible = true;
            }//daca echipa urmatoare este la start facem ca pionul sa fie vizibil pe linia de start
        }

        private void nu_Click(object sender, EventArgs e)
        {
            poz[echipa_curenta] -= nr;//in cazul in care echipa a raspuns gresit o trimitem inapoi cu nr pozitii,nr fiind valoarea zarului
            picture[echipa_curenta].Location = new Point(xc[poz[echipa_curenta]] + sizexc[poz[echipa_curenta]] / 2 - picture[echipa_curenta].Width / 2, yc[poz[echipa_curenta]] + sizeyc[poz[echipa_curenta]] / 2 - picture[echipa_curenta].Height / 2);
            //pozitionam pionul echipei care a gresit pe locul de unde a plecat ultima data
            panel3.Visible = false;

            echipa_curenta++;//trecem la urmatoarea echipa
            if (echipa_curenta == echipe + 1)
            {
                echipa_curenta = 1;
                inceput = 1;
            }//daca numarul echipei urmatoare este mai mare decat numarul de echipe trecem la prima echipa
            //de exemplu avem 5 echipe si suntem am evaluat raspunsul echipei nr.5 atunci trecem la echipa nr.1
            if (inceput == 0)
            {
                picture[echipa_curenta].Visible = true;
            }//daca echipa urmatoare este la start facem ca pionul sa fie vizibil pe linia de start
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (panel1.Visible == true && panel3.Visible == false)
            {
                if (e.Location.X >= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width-panel4.Width) panel4.Visible = true;
                else panel4.Visible = false;
            }//panoul cu valoarea zarului(cand avem zar in realitate) este vizbil doar cand tabla de joc este vizibila si panoul cu intrebari este invizibil
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (castig == 0)
            {
                if (panel3.Visible == false)
                {//operatiile care se executa la apasarea butonului cu textul "OK" au loc doar daca panoul cu intrebari este invizibil
                    //daca nu ar fi acest if echipa curenta poate avansa si poate primi alta intrebare
                    //sau s-ar trece imediat la echipa urmatoare, echipa precedenta castigand pozitia fara a raspunde la intrebarea ce i-a fost data

                    nr = Convert.ToInt32(numericUpDown2.Value);
                    if (nr == 1) zar.BackgroundImage = Properties.Resources.zar1;
                    else if (nr == 2) zar.BackgroundImage = Properties.Resources.zar2;
                    else if (nr == 3) zar.BackgroundImage = Properties.Resources.zar3;
                    else if (nr == 4) zar.BackgroundImage = Properties.Resources.zar4;
                    else if (nr == 5) zar.BackgroundImage = Properties.Resources.zar5;
                    else if (nr == 6) zar.BackgroundImage = Properties.Resources.zar6;
                    //in if-uri vedem ce valoare are zarul si aratam imaginea cu aceasta valoare

                    if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width >= 1280) zar.Location = new Point(rand.Next(10, x - 10 + 1), rand.Next(y, panel1.Height - zar.Height + 1));

                    if (inceput == 0)
                    {
                        picture[echipa_curenta].Visible = true;
                    }
                    picture[echipa_curenta].BringToFront();
                    poz[echipa_curenta] += nr;
                    if (poz[echipa_curenta] > 42)
                    {
                        string mesaj;
                        mesaj = "Echipa ";
                        mesaj = mesaj + echipa_curenta.ToString();
                        mesaj = mesaj + " a câştigat !!! . Jocul s-a terminat.";
                        MessageBox.Show(mesaj.ToString());
                        picture[echipa_curenta].Location = new Point(930, 580);
                        castig = 1;
                    }//cand o echipa a terminat o anuntam si o pozitionam pe linia de finish
                    else
                    {
                        picture[echipa_curenta].Location = new Point(xc[poz[echipa_curenta]] + sizexc[poz[echipa_curenta]] / 2 - picture[echipa_curenta].Width / 2, yc[poz[echipa_curenta]] + sizeyc[poz[echipa_curenta]] / 2 - picture[echipa_curenta].Height / 2);
                        //pozitionam pionul
                        panel3.Visible = true;//panoul cu intrebari devine vizibil
                    }

                    if (poz[echipa_curenta] == 2 || poz[echipa_curenta] == 5 || poz[echipa_curenta] == 7)
                    {
                        richTextBox1.Text = intrebari_oceania[rand.Next(0, intrebari_oceania.Count)];
                    }
                    else if (poz[echipa_curenta] == 9 || poz[echipa_curenta] == 12 || poz[echipa_curenta] == 14)
                    {
                        richTextBox1.Text = intrebari_america_nord[rand.Next(0, intrebari_america_nord.Count)];
                    }
                    else if (poz[echipa_curenta] == 16 || poz[echipa_curenta] == 19 || poz[echipa_curenta] == 21)
                    {
                        richTextBox1.Text = intrebari_america_sud[rand.Next(0, intrebari_america_sud.Count)];
                    }
                    else if (poz[echipa_curenta] == 23 || poz[echipa_curenta] == 26 || poz[echipa_curenta] == 28)
                    {
                        richTextBox1.Text = intrebari_africa[rand.Next(0, intrebari_africa.Count)];
                    }
                    else if (poz[echipa_curenta] == 30 || poz[echipa_curenta] == 33 || poz[echipa_curenta] == 35)
                    {
                        richTextBox1.Text = intrebari_asia[rand.Next(0, intrebari_asia.Count)];
                    }
                    else if (poz[echipa_curenta] == 37 || poz[echipa_curenta] == 40 || poz[echipa_curenta] == 42)
                    {
                        richTextBox1.Text = intrebari_europa[rand.Next(0, intrebari_europa.Count)];
                    }//in if-urile de mai sus vedem daca pionul se afla pe o pozitie speciala, iar echipa cu acel pion va primi o intrebare din acel continent ilustrat
                    else
                    {
                        richTextBox1.Text = intrebari[ordine_intrebari[nr_intrebari]];
                        nr_intrebari++;
                    }//daca pionul nu se afla pe o pozitie speciala primeste intrebari din toate continentele
                }
                panel4.Visible = false;
            }
        }
    }
}
