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
    public partial class Test : Form
    {
        int n, m, scor, nr, index, temp;
        int[] a_raspuns = new int[10];
        int[] raspuns = new int[10];
        int[] raspuns_user = new int[10];
        int[] raspunsuri_corecte = new int[100001];
        int[] r = new int[100001];

        List<string> lines = new List<string>();

        string[] intrebari = new string[100001];
        string[,] raspunsuri = new string[100001, 5];

        bool evaluat;

        Random rand = new Random();

        public Test()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //pozitionam panoul1 pe centrul ecranului
            label1.Location = new Point(panel1.Width / 2 - label1.Width / 2, label1.Location.Y);
            //pozitionam eticheta cu textul "Test" in partea centrala-sus a panoului

            citire();
            init();
        }

        private void citire()
        {
            StreamReader sr = new StreamReader("Resurse/Test/test.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }//citim linie cu linie fisierul "test.txt"
            sr.Close();

            for (int i = 0; i < lines.Count; i++)
            {
                if (String.ReferenceEquals(lines[i],""))
                {//la detectia unui rand gol crestem numarul de intrebari
                    n++;//n repr numarul de intrebari
                    intrebari[n] = lines[m];//punem intrebarea in vectorul de intrebari
                    raspunsuri_corecte[n] = Convert.ToInt32(lines[i - 1]);
                    //convertim numarul raspunsului corect(din cele 4 raspunsuri oferite) din fisierul citit in nr de tip int si il punem in vectorul de raspunsuri corecte
                    nr = 0;
                    for (int j = m+1; j <= i-2; j++)
                    {
                        nr++;
                        raspunsuri[n, nr] = lines[j].ToString();
                    }//in ciclul for punem in matricea de raspunsuri variantele de raspuns
                    m = i + 1;
                }
            }
        }

        private void init()
        {
            evaluare.BackColor = Color.Red;
            evaluare.Text = "Evaluare";
            //la inceput butonul de evaluare este rosu si are textul "Evaluare"
            nota.Visible = false;//la inceput nu afisam nota deoarece utilizatorul nu a apasat butonul de evaluare

            foreach (Control c in panel1.Controls.OfType<PictureBox>())
            {
                c.BackColor = Color.Gainsboro;//fiecare patrat repr o intrebare are culoarea gainsboro(gri deschis)
                //aceasta culoare repr faptul ca utilizatorul nu a raspuns la intrebare
            }
            foreach (Control c in panel1.Controls.OfType<RadioButton>())
            {
                c.BackColor = Color.White;//fiecare varianta de raspuns are fundalul alb
            }

            for (int i = 1; i <= n; i++) r[i] = i;
            for (int i = 1; i <= n; i++)
            {
                temp = rand.Next(1, n + 1);
                index = r[i];
                r[i] = r[temp];
                r[temp] = index;
            }//amestecam elementele vectorului r pt a avea intrebari amestecate 

            pictureBox1.BackColor = SystemColors.HotTrack;
            n = 1;

            label2.Text = intrebari[r[n]].ToString();//eticheta2 este cea pt afisarea intrebarilor
            // in acest moment afisam intrebarea nr 1
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
            //nicio varianta de raspuns nu este selectata
            for (int i = 1; i <= 9; i++) a_raspuns[i] = 0;
            //vectorul a_raspuns este vectorul care ne spune daca utilizatorul a raspuns sau nu la intrebare
            for (int i = 1; i <= 4; i++)
            {
                foreach (Control c in panel1.Controls.OfType<RadioButton>())
                {
                    if (c.Name == "radioButton" + i.ToString())
                    {
                        c.Text = raspunsuri[r[n], i];
                    }
                }
            }
            //in ciclu for de mai sus afisam variantele de raspuns pt prima intrebare
            scor = 1;//avem un punct din oficiu
            evaluat = false;//inca nu evaluam
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Meniu form = new Meniu();
            form.Show();
            this.Hide();
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (n > 1)
            {//deoarece la acest buton vedem intrebarile precedente scadem n
                //in cazul in care n=1 si mai apasam o data pe acest buton instructiunile de mai jos nu mai au loc
                if (evaluat == false)
                {//in cazul in care nu s-a realizat evaluarea raspunsurilor in cele 4 if-uri de mai jos preluam raspunsul utilizatorul la intrebarea curenta
                    //tot in cele 4 if-uri daca utilizatorul a raspuns in a_raspuns[n] ii dam valoarea 1
                    //1 inseamna ca utilizatorul a raspuns
                    if (radioButton1.Checked == true)
                    {
                        raspuns_user[n] = 1;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton2.Checked == true)
                    {
                        raspuns_user[n] = 2;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton3.Checked == true)
                    {
                        raspuns_user[n] = 3;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton4.Checked == true)
                    {
                        raspuns_user[n] = 4;
                        a_raspuns[n] = 1;
                    }
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            if (a_raspuns[n] == 0) c.BackColor = Color.Gainsboro;//daca utilizatorul nu a raspuns la intrebarea curenta patratul nr n va avea culoare gri deschis
                            if (a_raspuns[n] == 1) c.BackColor = Color.DimGray;//daca utilizatorul a raspuns la intrebarea curenta patratul nr n va avea culoare gri inchis
                        }
                    }
                    n--;//scadem din n o unitate pt ca dorim sa vedem inrebarea precedenta
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            c.BackColor = SystemColors.HotTrack;//patratul cu numarul n va avea culoarea albastru pt a ne indica la ce intrebare suntem
                        }
                    }

                    label2.Text = intrebari[r[n]].ToString();// in acest moment afisam intrebarea nr n
                    radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
                    //toate radiobutton-urile nu sunt selectate initial deoarece am trecut la alta intrebare
                    if (a_raspuns[n] == 1)
                    {
                        if (raspuns_user[n] == 1) radioButton1.Checked = true;
                        if (raspuns_user[n] == 2) radioButton2.Checked = true;
                        if (raspuns_user[n] == 3) radioButton3.Checked = true;
                        if (raspuns_user[n] == 4) radioButton4.Checked = true;
                    }//daca utilizatorul a raspuns la acesta intrebare vedem ce varianta de raspuns a ales
                    for (int i = 1; i <= 4; i++)
                    {
                        foreach (Control c in panel1.Controls.OfType<RadioButton>())
                        {
                            if (c.Name == "radioButton" + i.ToString())
                            {
                                c.Text = raspunsuri[r[n], i];
                            }
                        }
                    }//in acest ciclu for afisam variantele de raspuns pt intrebarea curenta
                }
                if (evaluat == true)
                {//in cazul in care s-a realizat evaluarea raspunsurilor
                    foreach (Control c in panel1.Controls.OfType<RadioButton>())
                    {
                        c.BackColor = Color.White;
                    }//fiecare varianta de raspuns are fundalul alb
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {//vom determina culoarea patratului cu numarul n dupa ce vom trece la intrebarea precedenta
                        //momentan acest patrat are culoarea albastru
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            if (raspuns[n] == 0) c.BackColor = Color.Red;//daca utilizatorul a raspuns gresit patratul va avea culoarea rosie(semn ca a gresit raspunsul)
                            if (raspuns[n] == 1) c.BackColor = Color.Green;//daca utilizatorul a raspuns corect patratul va avea culoarea verde(semn ca a raspuns corect)
                        }
                    }
                    n--;//scadem din n o unitate pt ca dorim sa vedem inrebarea precedenta
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            c.BackColor = SystemColors.HotTrack;//patratul cu numarul n va avea culoarea albastru pt a ne indica la ce intrebare suntem
                        }
                    }

                    label2.Text = intrebari[r[n]].ToString();// in acest moment afisam intrebarea nr n
                    radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
                    //toate radiobutton-urile nu sunt selectate initial deoarece am trecut la alta intrebare
                    if (a_raspuns[n] == 1)
                    {
                        if (raspuns_user[n] == 1) radioButton1.Checked = true;
                        if (raspuns_user[n] == 2) radioButton2.Checked = true;
                        if (raspuns_user[n] == 3) radioButton3.Checked = true;
                        if (raspuns_user[n] == 4) radioButton4.Checked = true;
                    }//daca utilizatorul a raspuns la acesta intrebare vedem ce varianta de raspuns a ales
                    for (int i = 1; i <= 4; i++)
                    {
                        foreach (Control c in panel1.Controls.OfType<RadioButton>())
                        {
                            if (c.Name == "radioButton" + i.ToString())
                            {
                                c.Text = raspunsuri[r[n], i];
                            }
                        }
                    }//in acest ciclu for afisam variantele de raspuns pt intrebarea curenta
                    if (raspuns[n] == 0)
                    {//raspuns[n] == 0 inseamna raspuns gresit
                        if (raspunsuri_corecte[r[n]] == 1) radioButton1.BackColor = Color.LawnGreen;
                        if (raspunsuri_corecte[r[n]] == 2) radioButton2.BackColor = Color.LawnGreen;
                        if (raspunsuri_corecte[r[n]] == 3) radioButton3.BackColor = Color.LawnGreen;
                        if (raspunsuri_corecte[r[n]] == 4) radioButton4.BackColor = Color.LawnGreen;
                    }//daca utilizatorul a raspuns gresit la intrebare ii aratam varianta corecta
                    //varianta corecta va avea fundalul verde
                }
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n < 9)
            {//deoarece la acest buton vedem intrebarile urmatoare crestem n
                //in cazul in care n=9 si mai apasam o data pe acest buton instructiunile de mai jos nu mai au loc
                if (evaluat == false)
                {//in cazul in care nu s-a realizat evaluarea raspunsurilor in cele 4 if-uri de mai jos preluam raspunsul utilizatorul la intrebarea curenta
                    //tot in cele 4 if-uri daca utilizatorul a raspuns in a_raspuns[n] ii dam valoarea 1
                    //1 inseamna ca utilizatorul a raspuns
                    if (radioButton1.Checked == true)
                    {
                        raspuns_user[n] = 1;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton2.Checked == true)
                    {
                        raspuns_user[n] = 2;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton3.Checked == true)
                    {
                        raspuns_user[n] = 3;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton4.Checked == true)
                    {
                        raspuns_user[n] = 4;
                        a_raspuns[n] = 1;
                    }
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            if (a_raspuns[n] == 0) c.BackColor = Color.Gainsboro;//daca utilizatorul nu a raspuns la intrebarea curenta patratul nr n va avea culoare gri deschis
                            if (a_raspuns[n] == 1) c.BackColor = Color.DimGray;//daca utilizatorul a raspuns la intrebarea curenta patratul nr n va avea culoare gri inchis
                        }
                    }
                    n++;//adunam o unitate la n pt ca dorim sa vedem inrebarea urmatoare
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            c.BackColor = SystemColors.HotTrack;//patratul cu numarul n va avea culoarea albastru pt a ne indica la ce intrebare suntem
                        }
                    }

                    label2.Text = intrebari[r[n]].ToString();// in acest moment afisam intrebarea nr n
                    radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
                    //toate radiobutton-urile nu sunt selectate initial deoarece am trecut la alta intrebare
                    if (a_raspuns[n] == 1)
                    {
                        if (raspuns_user[n] == 1) radioButton1.Checked = true;
                        if (raspuns_user[n] == 2) radioButton2.Checked = true;
                        if (raspuns_user[n] == 3) radioButton3.Checked = true;
                        if (raspuns_user[n] == 4) radioButton4.Checked = true;
                    }//daca utilizatorul a raspuns la acesta intrebare vedem ce varianta de raspuns a ales
                    for (int i = 1; i <= 4; i++)
                    {
                        foreach (Control c in panel1.Controls.OfType<RadioButton>())
                        {
                            if (c.Name == "radioButton" + i.ToString())
                            {
                                c.Text = raspunsuri[r[n], i];
                            }
                        }
                    }//in acest ciclu for afisam variantele de raspuns pt intrebarea curenta
                }
                if (evaluat == true)
                {//in cazul in care s-a realizat evaluarea raspunsurilor
                    foreach (Control c in panel1.Controls.OfType<RadioButton>())
                    {
                        c.BackColor = Color.White;
                    }//fiecare varianta de raspuns are fundalul alb
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {//vom determina culoarea patratului cu numarul n dupa ce vom trece la intrebarea precedenta
                        //momentan acest patrat are culoarea albastru
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            if (raspuns[n] == 0) c.BackColor = Color.Red;//daca utilizatorul a raspuns gresit patratul va avea culoarea rosie(semn ca a gresit raspunsul)
                            if (raspuns[n] == 1) c.BackColor = Color.Green;//daca utilizatorul a raspuns corect patratul va avea culoarea verde(semn ca a raspuns corect)
                        }
                    }
                    n++;//adunam o unitate la n pt ca dorim sa vedem inrebarea urmatoare
                    foreach (Control c in panel1.Controls.OfType<PictureBox>())
                    {
                        if (c.Name == "pictureBox" + n.ToString())
                        {
                            c.BackColor = SystemColors.HotTrack;//patratul cu numarul n va avea culoarea albastru pt a ne indica la ce intrebare suntem
                        }
                    }

                    label2.Text = intrebari[r[n]].ToString();// in acest moment afisam intrebarea nr n
                    radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
                    //toate radiobutton-urile nu sunt selectate initial deoarece am trecut la alta intrebare
                    if (a_raspuns[n] == 1)
                    {
                        if (raspuns_user[n] == 1) radioButton1.Checked = true;
                        if (raspuns_user[n] == 2) radioButton2.Checked = true;
                        if (raspuns_user[n] == 3) radioButton3.Checked = true;
                        if (raspuns_user[n] == 4) radioButton4.Checked = true;
                    }//daca utilizatorul a raspuns la acesta intrebare vedem ce varianta de raspuns a ales
                    for (int i = 1; i <= 4; i++)
                    {
                        foreach (Control c in panel1.Controls.OfType<RadioButton>())
                        {
                            if (c.Name == "radioButton" + i.ToString())
                            {
                                c.Text = raspunsuri[r[n], i];
                            }
                        }
                    }//in acest ciclu for afisam variantele de raspuns pt intrebarea curenta
                    if (raspuns[n] == 0)
                    {//raspuns[n] == 0 inseamna raspuns gresit
                        if (raspunsuri_corecte[r[n]] == 1) radioButton1.BackColor = Color.LawnGreen;
                        if (raspunsuri_corecte[r[n]] == 2) radioButton2.BackColor = Color.LawnGreen;
                        if (raspunsuri_corecte[r[n]] == 3) radioButton3.BackColor = Color.LawnGreen;
                        if (raspunsuri_corecte[r[n]] == 4) radioButton4.BackColor = Color.LawnGreen;
                    }//daca utilizatorul a raspuns gresit la intrebare ii aratam varianta corecta
                    //varianta corecta va avea fundalul verde
                }
            }
        }

        private void evaluare_Click(object sender, EventArgs e)
        {
            if (evaluare.Text == "Evaluare")
            {
                if (n!=0)
                {//preluam raspunsul pt intrebarea n deoarece in unele cazuri nu se poate prelua
                    /*de exemplu utilizatorul este la prima/ultima intrebare si chiar daca ar apasa butoanele de prev si next 
                      nu s-ar prelua din cauza numarului de patrate(daca n=0 sau n=10 nu arata nici un patrat colorat in albastru indicand numarul intrebarii,iar programul s-ar putea bloca)
                     */
                    //un alt exemplu este atunci cand utilizatorul nu stie raspunsul pt o intrebare si "sare peste ea", iar la sfarsit revine
                    if (radioButton1.Checked == true)
                    {
                        raspuns_user[n] = 1;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton2.Checked == true)
                    {
                        raspuns_user[n] = 2;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton3.Checked == true)
                    {
                        raspuns_user[n] = 3;
                        a_raspuns[n] = 1;
                    }
                    if (radioButton4.Checked == true)
                    {
                        raspuns_user[n] = 4;
                        a_raspuns[n] = 1;
                    }
                }

                int ok=1;
                for (int i = 1; i <= 9; i++)
                {
                    if (a_raspuns[i] == 0)
                    {
                        ok = 0;
                        break;
                    }
                }//in acest ciclu for vedem daca utilizatorul a raspuns la toate intrebarile
                if (ok == 0)
                {
                    MessageBox.Show("Nu aţi răspuns la toate întrebările !!!");
                }//daca utilizatorul nu a raspuns la toate intrebarile nu ii evaluam raspunsurile
                if (ok == 1)
                {//daca utilizatorul a raspuns la toate intrebarile ii evaluam raspunsurile
                    validare();
                    for (int i = 1; i <= 9; i++)
                    {
                        foreach (Control c in panel1.Controls.OfType<PictureBox>())
                        {
                            if (c.Name == "pictureBox" + i.ToString())
                            {
                                if (raspuns[i] == 0)
                                {
                                    c.BackColor = Color.Red;
                                }
                                if (raspuns[i] == 1)
                                {
                                    c.BackColor = Color.Green;
                                    scor++;
                                }
                            }
                        }
                    }/*in acest ciclu for coloram patratele
                       daca raspunsul este corect patratul i va avea culoarea verde
                       daca raspunsul este gresit patratul i va avea culoarea rosie
                      */

                    nota.Visible = true;
                    nota.Text = "Notă : " + scor.ToString();
                    //facem vizibila nota pe care o obtine utilizatorul

                    evaluare.BackColor = SystemColors.HotTrack;
                    evaluare.Text = "Restart";
                    //butonul de evaluare are textul "Restart" a nu ne mai complica cu alte butoane
                    //cand butonul de evaluare are textul "Restart" utilizatorul are dretul la sa mai dea testul, dar cu alte intrebari

                    evaluat = true;//am evaluat raspunsurile utilizatorului
                }
            }
            else
            {
                init();//restart
            }
        }

        private void validare()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (raspuns_user[i] == raspunsuri_corecte[r[i]]) raspuns[i] = 1;
                else raspuns[i] = 0;
            }
        }//vedem la ce intrebari a raspuns corect utilizatorul
    }
}
