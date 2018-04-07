using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;
using System.Windows.Resources;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Teste_de_inteligenta_sectiunea_verbala_testul_1.xaml
    /// </summary>
    public partial class Teste_de_inteligenta_sectiunea_verbala_testul_1 : Window
    {
        int n = 1, s = 0, s1 = 0;
        int minute, secunde;
        Paragraph p1, p2, p3;
        Paragraph[] P = new Paragraph[22];

        Button[,] b = new Button[12, 7];
        TextBox[] tb = new TextBox[11];

        #region
        string[,] sinonime_1 = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                      { "FERMECĂTOR            ", "agreabil", "încântător", "ideal", "elegant", "virtuos" },//1
                                      { "COLINĂ	                       ", "zonă", "pământ", "spaţiu", "deal", "iarbă" },//2
                                      { "ŞTERGERE                  ", "amendare", "ajustare", "radiere", "lovire", "încrucişare" },//3
                                      { "RUMOARE                   ", "bârfă", "discuţie", "percepţie", "revizuire", "ascultare" },//4
                                      { "STRIDENT                   ", "ocupaţie", "auster", "precis", "ţipător", "rivalitate" },//5
                                      { "SAVOARE	       ", "mâncare", "aromă", "pregătire", "bucătar", "păstrător" },//6
                                      { "PUNGAŞ	       ", "criminal", "receptor", "hoţ", "ticălos", "informator" },//7
                                      { "GROPIŢĂ	       ", "bărbie", "punct", "obraz", "depresiune", "coş" },//8
                                      { "ASPRU	                       ", "sever", "nepoliticos", "diabolic", "milos", "gradient" },//9
                                      { "PELERINAJ                  ", "vizită", "odisee", "capsulă", "descoperire", "cunoaştere" }//10
                                    };
        int[] raspunsuri_sinonime_1 = new int[] { 0, 2, 4, 3, 1, 4, 2, 3, 4, 1, 2 };
        int[] raspunsuri_date_sinonime_1 = new int[11];
        #endregion
        //sinonime_1

        #region
        string[,] sinonime_2 = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                               { "1", "aspru", "tare", "bont", "dur", "greu", "furios" },//1
                                               { "2", "a amenda", "a influenţa", "a se justifica", "a merita", "a găsi", "a se scuza" },//2
                                               { "3", "de neegalat", "superficial", "ciudat", "îngâmfat", "eroic", "cu nasul pe sus" },//3
                                               { "4", "a învăţa", "elev", "profesor", "colegiu", "a căuta", "carte" },//4
                                               { "5", "a admite", "a saluta", "a prezida", "a respecta", "a întâmpina", "a intra" },//5
                                               { "6", "a motiva", "a insulta", "a calcula", "a estima", "a înşira", "a răspunde" },//6
                                               { "7", "a linguşi", "a falsifica", "sarcasm", "vanitate", "insipid", "a peria" },//7
                                               { "8", "carte", "motto", "discurs", "semn", "maximă", "memorandum" },//8
                                               { "9", "neînsemnat", "rânced", "vechi", "din belşug", "ieftin", "puţin" },//9
                                               { "10", "neted", "găunos", "plat", "solid", "rotund", "concav" }//10
                                            };
        int[,] raspunsuri_sinonime_2 = new int[,] { { 0, 0, 0},
                                                    { 0, 1, 4},//1
                                                    { 0, 3, 6},//2
                                                    { 0, 4, 6},//3
                                                    { 0, 1, 3},//4
                                                    { 0, 2, 5},//5
                                                    { 0, 3, 4},//6
                                                    { 0, 1, 6},//7
                                                    { 0, 2, 5},//8
                                                    { 0, 1, 5},//9
                                                    { 0, 2, 6}//10
                                                  };
        int[,] raspunsuri_date_sinonime_2 = new int[11, 3];
        int[] sinonime_2_selectate = new int[11];
        #endregion
        //sinonime_2

        #region
        string[,] antonime_1 = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                      { "TACIT		       ", "linişit", "vorbit", "conştient", "grăbit", "neregulat" },//1
                                      { "A ÎMPĂCA      	       ", "a schimba", "a calma", "a permite", "a incita", "a se amesteca" },//2
                                      { "A ASCUNDE                 ", "a păstra", "a expune", "a despuia", "a proteja", "a trece la" },//3
                                      { "UNIC		       ", "deosebit", "drept", "obişnuit", "diferit", "scump" },//4
                                      { "NEHOTĂRÂT               ", "demn de milă", "stabil", "şiret", "instabil", "regulat" },//5
                                      { "POSOMORÂT               ", "obişnuit", "fin", "senin", "departe", "vesel" },//6
                                      { "CERT	                       ", "manifest", "regulat", "obscur", "dificil", "merituos" },//7
                                      { "ILICIT	                       ", "greşit", "bun", "cinstit", "legal", "infam" },//8
                                      { "SIGUR	                       ", "incert", "alunecos", "slăbit", "intact", "liber" },//9
                                      { "PROASPĂT                   ", "crud", "târziu", "adormit", "învechit", "odihnă" }//10
                                    };
        int[] raspunsuri_antonime_1 = new int[] { 0, 2, 4, 2, 3, 2, 5, 3, 4, 1, 4 };
        int[] raspunsuri_date_antonime_1 = new int[11];
        #endregion
        //antonime_1

        #region
        string[,] antonime_2 = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                               { "1", "precis", "aproximativ", "apropiat", "neglijent", "neclar", "subiectiv" },//1
                                               { "2", "bolnav", "proaspăt", "sumbru", "nefericit", "sărac", "strălucitor" },//2
                                               { "3", "fără sens", "gol", "posomorât", "ocupat", "aglomerat", "retras" },//3
                                               { "4", "a polua", "a fierbe", "a purifica", "a spăla", "a curăţa", "a dizolva" },//4
                                               { "5", "blândeţe", "apatie", "tristeţe", "acţiune", "înţelepciune", "preocupare" },//5
                                               { "6", "calm", "îngrijorat", "furtunos", "egoist", "proaspăt", "săritor" },//6
                                               { "7", "prietenos", "nerăbdător", "timid", "nepăsător", "neînfricat", "entuziasmat" },//7
                                               { "8", "a opri", "a naşte", "a preveni", "a injecta", "a absolvi", "a extermina" },//8
                                               { "9", "fructuos", "prolific", "risipitor", "încântător", "concis", "tăcut" },//9
                                               { "10", "regulat", "înşirat", "necunoscut", "îngust", "încet", "variabil" }//10
                                            };
        int[,] raspunsuri_antonime_2 = new int[,] { { 0, 0, 0},
                                                    { 0, 1, 4},//1
                                                    { 0, 3, 6},//2
                                                    { 0, 2, 4},//3
                                                    { 0, 1, 3},//4
                                                    { 0, 2, 6},//5
                                                    { 0, 1, 3},//6
                                                    { 0, 3, 5},//7
                                                    { 0, 2, 6},//8
                                                    { 0, 2, 5},//9
                                                    { 0, 1, 6}//10
                                                  };
        int[,] raspunsuri_date_antonime_2 = new int[11, 7];
        int[] antonime_2_selectate = new int[11];
        #endregion
        //antonime_2

        #region
        string[,] comparatii = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                      { "UNDE este pentru SHEFFIELD aşa cum CÂND este pentru:", "tren", "curând", "cum", "poate", "timp" },//1
                                      { "STRUNG este pentru LEMN aşa cum RĂZBOIUL este pentru:", "materiale", "textile", "fir", "maşină", "aparat" },//2
                                      { "NEBUNATIC este pentru FERICIT aşa cum JUDECĂTOR este pentru:", "trist", "justiţie", "sobru", "serios", "perucă" },//3
                                      { "SFINŢIA SA este pentru ARHIEPISCOP aşa cum EXCELENŢĂ este pentru: ", "ambasador", "prinţ", "baron", "arhidiacon", "duce" },//4
                                      { "CUVÂNT ÎNAINTE este pentru CARTE aşa cum UVERTURĂ este pentru:", "muzică", "piesă", "orchestră", "compozitor", "operă" },//5
                                      { "A DECORTICA este pentru A COJI aşa cum A LUSTRUI este pentru:", "a tăia", "a freca", "a despica", "a face o incizie", "a diseca" },//6
                                      { "ÎNCUIAT este pentru ÎNCHIS aşa cum DESCHIS este pentru:", "descuiat", "concludent", "obscur", "ascuns", "fereastră" },//7
                                      { "SPANAC este pentru LEGUME aşa cum MUŞCHIUL DE TURBĂ este pentru:", "iarbă", "sol", "fructe", "ceapă", "muşchi" },//8
                                      { "NORD este pentru DIRECŢIE aşa cum ROŞU este pentru:", "stânjenit", "culoare", "copt", "portocaliu", "nuanţă" },//9
                                      { "MAHON este pentru LEMN aşa cum TUFIŞ este pentru:", "copac", "arbust", "plantă", "floare", "coloană vertebrală" }//10
                                    };
        int[] raspunsuri_comparatii = new int[] { 0, 2, 3, 3, 1, 5, 2, 1, 5, 2, 2 };
        int[] raspunsuri_date_comparatii = new int[11];
        #endregion
        //comparatii

        #region
        string[] succesiuni_de_numere = new string[]{ "0",
                                                      "1 1,5 2,5 4 ?                                     ",//1
                                                      "25, 23, 20, 16, ?                               ",//2
                                                      "5, 10, 10, 8, 15, 6, ?                         ",//3
                                                      "0, 1, 3, 4, 6, ?                                   ",//4
                                                      "2, 5, 10, 17, 26, ?                             ",//5
                                                      "0, 3, 3, 6, 9, 15, ?                             ",//6
                                                      "1, 8, 27, 64, ?                                   ",//7
                                                      "1, 1, 2, 6, 24, ?                                 ",//8
                                                      "0,5 0,55 0,65 0,8 ?                           ",//9
                                                      "1 0,5 0,333 0,25 0,2 ?                     "//10
                                                    };
        string[] raspunsuri_succesiuni_de_numere = new string[] { "0", "6", "11", "20", "7", "37", "24", "125", "120", "1", "0,16" };
        string[] raspunsuri_date_succesiuni_de_numere = new string[11];
        #endregion
        //succesiuni_de_numere

        #region
        string[,] clasificari = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                               { "1", "vâlvă", "comoţie", "zgomot", "urlet", "tulburare" },//1
                                               { "2", "matroană", "duce", "marchiză", "baroană", "prinţesă" },//2
                                               { "3", "manta", "mantie", "şal", "bluză", "învelitoare" },//3
                                               { "4", "absolut", "categoric", "sigur", "posibil", "explicit" },//4
                                               { "5", "râs", "glumă", "surâs", "chicotit", "ţâţâit" },//5
                                               { "6", "lojă", "cameră", "celulă", "teatru", "încăpere" },//6
                                               { "7", "acru", "orbită", "ridicare", "ascensiune", "urcuş" },//7
                                               { "8", "abrupt", "curând", "grăbit", "brusc", "impulsiv" },//8
                                               { "9", "a găuri", "a lustrui", "a pili", "a netezi", "a uniformiza" },//9
                                               { "10", "timorat", "uimit", "timid", "retras", "nehotărât" }//10
                                            };
        int[] raspunsuri_clasificari = new int[] { 0, 3, 2, 4, 4, 2, 4, 2, 2, 1, 2 };
        int[] raspunsuri_date_clasificari = new int[11];
        #endregion
        //clasificari

        string[] calificative = new string[9];
        int[] timp = new int[] { 0, 6, 8, 6, 8, 8, 12, 6 };

        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        SoundPlayer sound = new SoundPlayer("Sunete/beep.wav");
        int parametru;
        StreamResourceInfo cursor_soft;

        int canvas_label_top = 50, nr_ord;

        public Teste_de_inteligenta_sectiunea_verbala_testul_1(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            timer1.Interval = timer2.Interval = new TimeSpan(0, 0, 1);

            setare_timp();
            timer1.Start();

            flowdocument_cerinta();
        }

        private void setare_timp()
        {
            minute = timp[n];
            secunde = 0;
            if (minute < 10) label1.Content = "0" + minute.ToString();
            else label1.Content = minute.ToString();
            label1.Content = label1.Content + ":";
            if (secunde < 10) label1.Content = label1.Content + "0" + secunde.ToString();
            else label1.Content = label1.Content + secunde.ToString();

            rectangle1.Stroke = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            rectangle1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            label1.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (secunde == 0)
            {
                secunde = 60;
                minute--;
            }
            secunde--;

            if (minute < 10) label1.Content = "0" + minute.ToString();
            else label1.Content = minute.ToString();
            label1.Content = label1.Content + ":";
            if (secunde < 10) label1.Content = label1.Content + "0" + secunde.ToString();
            else label1.Content = label1.Content + secunde.ToString();

            if (secunde <= 10 && minute == 0)
            {
                rectangle1.Stroke = new SolidColorBrush(Colors.White);
                rectangle1.Fill = new SolidColorBrush(Colors.Red);
                label1.Foreground = new SolidColorBrush(Colors.White);

                sound.Play();
            }
            else
            {
                rectangle1.Stroke = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                rectangle1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                label1.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            }
            if (secunde == 0 && minute == 0)
            {
                if (n <= 6)
                {
                    timer1.Stop();
                    verificare_raspunsuri();
                    flowdoc1.Blocks.Clear();
                    n++;
                    setare_timp();
                    flowdocument_cerinta();
                    timer1.Start();
                }
                else if (n == 7)
                {
                    timer1.Stop();
                    verificare_raspunsuri();
                    rectangle1.Visibility = label1.Visibility = Visibility.Hidden;
                    border1.Visibility = Visibility.Hidden;
                    border2.Visibility = Visibility.Visible;
                    timer2.Start();
                    verificare.Content = "Refă testul";
                    verificare.Visibility = Visibility.Hidden;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            nr_ord++;
            if (nr_ord <= 7)
            {
                Label l = new Label();
                l.Width = 380;
                l.Height = 35;
                l.FontFamily = new FontFamily("Times New Roman");
                l.FontSize = 22;
                l.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                l.Content = "Partea ";
                if (nr_ord == 1) l.Content = l.Content + "I : " + calificative[nr_ord].ToString();
                if (nr_ord == 2) l.Content = l.Content + "a II-a : " + calificative[nr_ord].ToString();
                if (nr_ord == 3) l.Content = l.Content + "a III-a : " + calificative[nr_ord].ToString();
                if (nr_ord == 4) l.Content = l.Content + "a IV-a : " + calificative[nr_ord].ToString();
                if (nr_ord == 5) l.Content = l.Content + "a V-a : " + calificative[nr_ord].ToString();
                if (nr_ord == 6) l.Content = l.Content + "a VI-a : " + calificative[nr_ord].ToString();
                if (nr_ord == 7) l.Content = l.Content + "a VII-a : " + calificative[nr_ord].ToString();
                canvas2.Children.Add(l);
                Canvas.SetTop(l, canvas_label_top);
                Canvas.SetLeft(l, 10);
                canvas_label_top += Convert.ToInt32(l.Height) + 10;
            }
            if (nr_ord == 8)
            {
                Line linie = new Line();
                canvas2.Children.Add(linie);
                linie.X1 = 10;
                linie.X2 = 380;
                linie.Y1 = canvas_label_top;
                linie.Y2 = canvas_label_top;
                linie.Stroke = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                linie.StrokeThickness = 3;
                canvas_label_top += 5;
            }
            if (nr_ord == 9)
            {
                Label l = new Label();
                l.Width = 380;
                l.Height = 35;
                l.FontFamily = new FontFamily("Times New Roman");
                l.FontSize = 24;
                l.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                l.Content = "Total : " + calificative[8].ToString();
                l.FontWeight = FontWeights.Bold;
                canvas2.Children.Add(l);
                Canvas.SetTop(l, canvas_label_top);
                Canvas.SetLeft(l, 10);

                verificare.Visibility = Visibility.Visible;
                timer2.Stop();
            }
        }

        private void flowdocument_cerinta()
        {
            if (n == 1) p1 = new Paragraph(new Run("Partea I / VII"));
            if (n == 2) p1 = new Paragraph(new Run("Partea a II-a / VII"));
            if (n == 3) p1 = new Paragraph(new Run("Partea a III-a / VII"));
            if (n == 4) p1 = new Paragraph(new Run("Partea a IV-a / VII"));
            if (n == 5) p1 = new Paragraph(new Run("Partea a V-a / VII"));
            if (n == 6) p1 = new Paragraph(new Run("Partea a VI-a / VII"));
            if (n == 7) p1 = new Paragraph(new Run("Partea a VII-a / VII"));
            p1.TextAlignment = TextAlignment.Center;
            flowdoc1.Blocks.Add(p1);
            //primul paragraf

            p2 = new Paragraph();
            if (n == 1)
            {
                p2.Inlines.Add(new Bold(new Run("Sinonime(A)\n")));
                p2.Inlines.Add(new Run("Sinonimele sunt cuvinte care au acelaşi înţeles sau înţelesuri apropiate. Trebuie să găsiţi un cuvânt din cele cinci date, care să aibă acelaşi înţeles cu cuvântul-cheie şi să-l selectaţi.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu:")));
                p2.Inlines.Add(new Run("       Cuvânt cheie: ONCTUOS\n"));
                p2.Inlines.Add(new Run("Alegeţi din:    mlăştinos, spumos, uleios, umflat, ameţitor\n"));
                p2.Inlines.Add(new Run("Răspuns:        uleios\n"));
            }
            if (n == 2)
            {
                p2.Inlines.Add(new Bold(new Run("Sinonime(B)\n")));
                p2.Inlines.Add(new Run("Sinonimele sunt cuvinte cu înţelesuri identice sau asemănătoare. Din cele şase cuvinte date, găsiţi două care înseamnă acelaşi lucru şi selectaţi-le. \n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu\n")));
                p2.Inlines.Add(new Run("Alegeţi din:    fagure de miere, nişă, grotă, cavitate, crescătorie, copaie\n"));
                p2.Inlines.Add(new Run("Răspuns:        nişă, grotă\n"));
            }
            if (n == 3)
            {
                p2.Inlines.Add(new Bold(new Run("Antonime(A)\n")));
                p2.Inlines.Add(new Run("Antonimele sunt cuvinte care exprimă înţelesuri opuse sau aproximativ opuse. Trebuie să găsiţi un cuvânt din cele cinci date, care are un înţeles opus cuvântului-cheie şi să-l selectaţi.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu:")));
                p2.Inlines.Add(new Run("       Cuvânt-cheie: CORPOLENŢĂ\n"));
                p2.Inlines.Add(new Run("Alegeţi din:    măreţie, supleţe, obezitate, vastitate, voluminos\n"));
                p2.Inlines.Add(new Run("Răspuns:        supleţe\n"));
            }
            if (n == 4)
            {
                p2.Inlines.Add(new Bold(new Run("Antonime(B)\n")));
                p2.Inlines.Add(new Run("Antonimele sunt cuvinte care exprimă înţelesuri opuse sau aproximativ opuse. Din cele şase cuvinte date, trebuie să alegeţi două cuvinte cu înţelesuri opuse şi să le selectaţi.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu\n")));
                p2.Inlines.Add(new Run("Alegeţi din:    palpitant, nesuferit, impetuos, prudent, dominator, vesel\n"));
                p2.Inlines.Add(new Run("Răspuns:        impetuos, prudent\n"));
            }
            if (n == 5)
            {
                p2.Inlines.Add(new Bold(new Run("Comparaţii\n")));
                p2.Inlines.Add(new Run("Comparaţiile sunt clasificări în care un obiect sau o idee este comparată cu alt obiect sau idee. Trebuie să găsiţi aceeaşi legătură cu alt cuvânt sau idee. Aveţi la dispoziţie cinci răspunsuri. Selectaţi cuvântul ales.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu:")));
                p2.Inlines.Add(new Run("    TEREN este pentru TENIS aşa cum PISTĂ este pentru:\n"));
                p2.Inlines.Add(new Run("                    cricket, hochei, schi, golf, polo\n"));
                p2.Inlines.Add(new Run("Răspuns:     schi\n"));
            }
            if (n == 6)
            {
                p2.Inlines.Add(new Bold(new Run("Succesiuni de numere\n")));
                p2.Inlines.Add(new Run("Este dată o succesiune de numere. Trebuie să găsiţi numărul care continuă succesiunea. Dacă numărul este zecimal se acceptă maxim două zecimale.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu:")));
                p2.Inlines.Add(new Run("       2,4,6, 8, 10, ?\n"));
                p2.Inlines.Add(new Run("Răspuns:       12\n"));
            }
            if (n == 7)
            {
                p2.Inlines.Add(new Bold(new Run("Clasificări\n")));
                p2.Inlines.Add(new Run("Clasificarea constă într-un grup de obiecte sau idei care include un cuvânt ce nu aparţine acelui grup. Trebuie să selectaţi acel cuvânt din fiecare grup.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu:")));
                p2.Inlines.Add(new Run("       pin, brad, ulm, molid, brad de Canada\n"));
                p2.Inlines.Add(new Run("Răspuns:     ULMUL este lemn de esenţă tare, în timp ce copacii ceilalţi sunt de esenţă moale.\n"));
            }
            flowdoc1.Blocks.Add(p2);
            // al doilea paragraf

            p3 = new Paragraph();
            if (n == 1) p3.Inlines.Add(new Run("Aveţi la dispoziţie şase minute pentru a răspunde la cele zece întrebări."));
            if (n == 2) p3.Inlines.Add(new Run("Aveţi la dispoziţie opt minute pentru a răspunde la cele zece întrebări."));
            if (n == 3) p3.Inlines.Add(new Run("Aveţi la dispoziţie şase minute pentru a răspunde la cele zece întrebări."));
            if (n == 4) p3.Inlines.Add(new Run("Aveţi la dispoziţie opt minute pentru a răspunde la cele zece întrebări."));
            if (n == 5) p3.Inlines.Add(new Run("Aveţi la dispoziţie opt minute pentru a răspunde la cele zece întrebări."));
            if (n == 6) p3.Inlines.Add(new Run("Aveţi la dispoziţie douăsprezece minute în care să răspundeţi la cele zece întrebări."));
            if (n == 7) p3.Inlines.Add(new Run("Aveţi la dispoziţie şase minute în care să selectaţi cele zece cuvinte."));
            flowdoc1.Blocks.Add(p3);
            // al treilea paragraf

            if (n == 1) flowdocument_text_1();
            if (n == 2) flowdocument_text_2();
            if (n == 3) flowdocument_text_3();
            if (n == 4) flowdocument_text_4();
            if (n == 5) flowdocument_text_5();
            if (n == 6) flowdocument_text_6();
            if (n == 7) flowdocument_text_7();
        }

        #region
        private void flowdocument_text_1()
        {
            P[1] = new Paragraph();
            P[1].Inlines.Add(new Underline(new Run("Cuvânt-cheie")));
            P[1].Inlines.Add(new Run("                  "));
            P[1].Inlines.Add(new Underline(new Run("Alegeţi din")));
            flowdoc1.Blocks.Add(P[1]);

            for (int i = 1; i <= 10; i++)
            {
                P[i + 1] = new Paragraph();
                for (int j = 0; j <= 5; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = sinonime_1[i, j].ToString();
                    if (j == 0)
                    {
                        b[i, j].Width = 168;
                        b[i, j].Height = 30;
                        b[i, j].Style = Resources["btn"] as Style;
                        b[i, j].Background = new SolidColorBrush(Colors.Transparent);
                        b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    }
                    else
                    {
                        b[i, j].Width = 100;
                        b[i, j].Height = 30;
                        b[i, j].Style = Resources["btnGlass"] as Style;
                        b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        b[i, j].Click += new RoutedEventHandler(buton1_click);
                    }
                    ic.BaselineAlignment = BaselineAlignment.Center;
                    ic.Child = b[i, j];
                    P[i + 1].Inlines.Add(ic);
                    if (j != 5) P[i + 1].Inlines.Add(new Run(" "));
                }
                flowdoc1.Blocks.Add(P[i + 1]);
            }

            border1.Width = 800;
            canvas1.Width = 800;
            flowdoc_scroolview.Width = 770;
        }

        private void buton1_click(object sender, EventArgs e)
        {
            int i1 = 0, j1 = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (sender == b[i, j])
                    {
                        i1 = i;
                        j1 = j;
                        break;
                    }
                }
            }
            for (int j = 1; j <= 5; j++)
            {
                b[i1, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                b[i1, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            }
            b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            raspunsuri_date_sinonime_1[i1] = j1;
        }
        #endregion
        //flowdocument_text_1

        #region
        private void flowdocument_text_2()
        {
            P[1] = new Paragraph();
            P[1].Inlines.Add(new Underline(new Run("Alegeţi din")));
            flowdoc1.Blocks.Add(P[1]);

            for (int i = 1; i <= 10; i++)
            {
                P[i + 1] = new Paragraph();
                if (i < 10) P[i + 1].Inlines.Add(new Run(" "+i.ToString() + ") "));
                else P[i + 1].Inlines.Add(new Run(i.ToString() + ") "));
                for (int j = 1; j <= 6; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = sinonime_2[i, j].ToString();
                    b[i, j].Width = 125;
                    b[i, j].Height = 30;
                    b[i, j].Style = Resources["btnGlass"] as Style;
                    b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    b[i, j].Click += new RoutedEventHandler(buton2_click);
                    ic.Child = b[i, j];
                    ic.BaselineAlignment = BaselineAlignment.Center;
                    P[i + 1].Inlines.Add(ic);
                    if (j != 6) P[i + 1].Inlines.Add(new Run(" "));
                }
                flowdoc1.Blocks.Add(P[i + 1]);
            }

            border1.Width = 900;
            canvas1.Width = 900;
            flowdoc_scroolview.Width = 870;
        }

        private void buton2_click(object sender, EventArgs e)
        {
            int i1 = 0, j1 = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (sender == b[i, j])
                    {
                        i1 = i;
                        j1 = j;
                        break;
                    }
                }
            }
            sinonime_2_selectate[i1]++;
            if (sinonime_2_selectate[i1] == 1)
            {
                b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                raspunsuri_date_sinonime_2[i1, 1] = j1;
            }
            if (sinonime_2_selectate[i1] == 2)
            {
                b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                raspunsuri_date_sinonime_2[i1, 2] = j1;
                if (raspunsuri_date_sinonime_2[i1, 1] == raspunsuri_date_sinonime_2[i1, 2]) sinonime_2_selectate[i1] = 1;
            }
            if (sinonime_2_selectate[i1] == 3)
            {
                sinonime_2_selectate[i1] = 0;
                raspunsuri_date_sinonime_2[i1, 1] = 0;
                raspunsuri_date_sinonime_2[i1, 2] = 0;
                for (int j = 1; j <= 6; j++)
                {
                    b[i1, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i1, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                }
            }
        }
        #endregion
        //flowdocument_text_2

        #region
        private void flowdocument_text_3()
        {
            P[1] = new Paragraph();
            P[1].Inlines.Add(new Underline(new Run("Cuvânt-cheie")));
            P[1].Inlines.Add(new Run("                  "));
            P[1].Inlines.Add(new Underline(new Run("Alegeţi din")));
            flowdoc1.Blocks.Add(P[1]);

            for (int i = 1; i <= 10; i++)
            {
                P[i + 1] = new Paragraph();
                for (int j = 0; j <= 5; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = antonime_1[i, j].ToString();
                    if (j == 0)
                    {
                        b[i, j].Width = 168;
                        b[i, j].Height = 30;
                        b[i, j].Style = Resources["btn"] as Style;
                        b[i, j].Background = new SolidColorBrush(Colors.Transparent);
                        b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    }
                    else
                    {
                        b[i, j].Width = 110;
                        b[i, j].Height = 30;
                        b[i, j].Style = Resources["btnGlass"] as Style;
                        b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        b[i, j].Click += new RoutedEventHandler(buton3_click);
                    }
                    ic.Child = b[i, j];
                    ic.BaselineAlignment = BaselineAlignment.Center;
                    P[i + 1].Inlines.Add(ic);
                    if (j != 5) P[i + 1].Inlines.Add(new Run(" "));
                }
                flowdoc1.Blocks.Add(P[i + 1]);
            }

            border1.Width = 850;
            canvas1.Width = 850;
            flowdoc_scroolview.Width = 820;
        }

        private void buton3_click(object sender, EventArgs e)
        {
            int i1 = 0, j1 = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (sender == b[i, j])
                    {
                        i1 = i;
                        j1 = j;
                        break;
                    }
                }
            }
            for (int j = 1; j <= 5; j++)
            {
                b[i1, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                b[i1, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            }
            b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            raspunsuri_date_antonime_1[i1] = j1;
        }
        #endregion
        //flowdocument_text_3

        #region
        private void flowdocument_text_4()
        {
            P[1] = new Paragraph();
            P[1].Inlines.Add(new Underline(new Run("Alegeţi din")));
            flowdoc1.Blocks.Add(P[1]);

            for (int i = 1; i <= 10; i++)
            {
                P[i + 1] = new Paragraph();
                if (i < 10) P[i + 1].Inlines.Add(new Run(" " + i.ToString() + ") "));
                else P[i + 1].Inlines.Add(new Run(i.ToString() + ") "));
                for (int j = 1; j <= 6; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = antonime_2[i, j].ToString();
                    b[i, j].Width = 98;
                    b[i, j].Height = 30;
                    b[i, j].Style = Resources["btnGlass"] as Style;
                    b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    b[i, j].Click += new RoutedEventHandler(buton4_click);
                    ic.Child = b[i, j];
                    ic.BaselineAlignment = BaselineAlignment.Center;
                    P[i + 1].Inlines.Add(ic);
                    if (j != 6) P[i + 1].Inlines.Add(new Run(" "));
                }
                flowdoc1.Blocks.Add(P[i + 1]);
            }

            border1.Width = 740;
            canvas1.Width = 740;
            flowdoc_scroolview.Width = 710;
        }

        private void buton4_click(object sender, EventArgs e)
        {
            int i1 = 0, j1 = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (sender == b[i, j])
                    {
                        i1 = i;
                        j1 = j;
                        break;
                    }
                }
            }
            antonime_2_selectate[i1]++;
            if (antonime_2_selectate[i1] == 1)
            {
                b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                raspunsuri_date_antonime_2[i1, 1] = j1;
            }
            if (antonime_2_selectate[i1] == 2)
            {
                b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                raspunsuri_date_antonime_2[i1, 2] = j1;
                if (raspunsuri_date_antonime_2[i1, 1] == raspunsuri_date_antonime_2[i1, 2]) antonime_2_selectate[i1] = 1;
            }
            if (antonime_2_selectate[i1] == 3)
            {
                antonime_2_selectate[i1] = 0;
                raspunsuri_date_antonime_2[i1, 1] = 0;
                raspunsuri_date_antonime_2[i1, 2] = 0;
                for (int j = 1; j <= 6; j++)
                {
                    b[i1, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i1, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                }
            }
        }
        #endregion
        //flowdocument_text_4

        #region
        private void flowdocument_text_5()
        {
            int nr = 1;
            for (int i = 1; i <= 10; i++)
            {
                P[nr] = new Paragraph();
                if (i < 10) P[nr].Inlines.Add(new Run(" " + i.ToString() + ") "));
                else P[nr].Inlines.Add(new Run(i.ToString() + ") "));
                P[nr].Inlines.Add(new Run(comparatii[i, 0].ToString()));
                flowdoc1.Blocks.Add(P[nr]);

                nr++;
                P[nr] = new Paragraph();

                for (int j = 1; j <= 5; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = comparatii[i, j].ToString();
                    b[i, j].Width = 150;
                    b[i, j].Height = 30;
                    b[i, j].Style = Resources["btnGlass"] as Style;
                    b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    b[i, j].Click += new RoutedEventHandler(buton5_click);
                    ic.Child = b[i, j];
                    ic.BaselineAlignment = BaselineAlignment.Center;
                    P[nr].Inlines.Add(ic);
                    if (j != 5) P[nr].Inlines.Add(new Run(" "));
                }
                flowdoc1.Blocks.Add(P[nr]);
                nr++;
            }

            border1.Width = 870;
            canvas1.Width = 870;
            flowdoc_scroolview.Width = 840;
        }

        private void buton5_click(object sender, EventArgs e)
        {
            int i1 = 0, j1 = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (sender == b[i, j])
                    {
                        i1 = i;
                        j1 = j;
                        break;
                    }
                }
            }
            for (int j = 1; j <= 5; j++)
            {
                b[i1, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                b[i1, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            }
            b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            raspunsuri_date_comparatii[i1] = j1;
        }
        #endregion
        //flowdocument_text_5

        #region
        private void flowdocument_text_6()
        {

            for (int i = 1; i <= 10; i++)
            {
                P[i] = new Paragraph();
                if (i < 10) P[i].Inlines.Add(new Run(" " + i.ToString() + ") "));
                else P[i].Inlines.Add(new Run(i.ToString() + ") "));
                P[i].Inlines.Add(new Run(succesiuni_de_numere[i].ToString()));
                P[i].Inlines.Add(new Run("? = "));

                InlineUIContainer ic = new InlineUIContainer();
                tb[i] = new TextBox();
                tb[i].Width =40;
                tb[i].Height = 28;
                tb[i].FontFamily = new FontFamily("Times New Roman");
                tb[i].FontSize = 18;
                tb[i].TextAlignment = TextAlignment.Center;
                tb[i].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                tb[i].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                tb[i].TextChanged += new TextChangedEventHandler(buton6_click);
                ic.Child = tb[i];
                ic.BaselineAlignment = BaselineAlignment.Center;

                P[i].Inlines.Add(ic);
                flowdoc1.Blocks.Add(P[i]);
            }

            border1.Width = 700;
            canvas1.Width = 700;
            flowdoc_scroolview.Width = 670;
        }

        private void buton6_click(object sender, TextChangedEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (sender == tb[i])
                {
                    raspunsuri_date_succesiuni_de_numere[i] = tb[i].Text.ToString();
                }
            }
        }
        #endregion
        //flowdocument_text_6

        #region
        private void flowdocument_text_7()
        {
            for (int i = 1; i <= 10; i++)
            {
                P[i] = new Paragraph();
                if (i < 10) P[i].Inlines.Add(new Run(" " + i.ToString() + ") "));
                else P[i].Inlines.Add(new Run(i.ToString() + ") "));
                for (int j = 1; j <= 5; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = clasificari[i, j].ToString();
                    b[i, j].Width = 120;
                    b[i, j].Height = 30;
                    b[i, j].Style = Resources["btnGlass"] as Style;
                    b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    b[i, j].Click += new RoutedEventHandler(buton7_click);
                    ic.Child = b[i, j];
                    ic.BaselineAlignment = BaselineAlignment.Center;
                    P[i].Inlines.Add(ic);
                    if (j != 5) P[i].Inlines.Add(new Run(" "));
                }
                flowdoc1.Blocks.Add(P[i]);
            }

            border1.Width = 750;
            canvas1.Width = 750;
            flowdoc_scroolview.Width = 720;
        }

        private void buton7_click(object sender, EventArgs e)
        {
            int i1 = 0, j1 = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (sender == b[i, j])
                    {
                        i1 = i;
                        j1 = j;
                        break;
                    }
                }
            }
            for (int j = 1; j <= 5; j++)
            {
                b[i1, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                b[i1, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            }
            b[i1, j1].Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            b[i1, j1].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            raspunsuri_date_clasificari[i1] = j1;
        }
        #endregion
        //flowdocument_text_7

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            sound.Stop();

            Teste_de_inteligenta_sectiunea_verbala form = new Teste_de_inteligenta_sectiunea_verbala(parametru);
            form.Show();
            this.Hide();
        }

        private void verificare_Click(object sender, RoutedEventArgs e)
        {
            if (verificare.Content.ToString() == "Am terminat")
            {
                if (n <= 6)
                {
                    timer1.Stop();
                    verificare_raspunsuri();
                    flowdoc1.Blocks.Clear();
                    n++;
                    setare_timp();
                    flowdocument_cerinta();
                    timer1.Start();
                }
                else if (n == 7)
                {
                    timer1.Stop();
                    verificare_raspunsuri();
                    rectangle1.Visibility = label1.Visibility = Visibility.Hidden;
                    border1.Visibility = Visibility.Hidden;
                    border2.Visibility = Visibility.Visible;
                    timer2.Start();
                    verificare.Content = "Refă testul";
                    verificare.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Teste_de_inteligenta_sectiunea_verbala_testul_1 form = new Teste_de_inteligenta_sectiunea_verbala_testul_1(parametru);
                form.Show();
                this.Hide();
            }
        }

        private void verificare_raspunsuri()
        {
            s1 = 0;
            if (n == 1)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (raspunsuri_date_sinonime_1[i] == raspunsuri_sinonime_1[i]) s1++;
                }
                calificativ(s1,n);
                s += s1;
            }

            if (n == 2)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (raspunsuri_date_sinonime_2[i, 1] == raspunsuri_sinonime_2[i, 1] && raspunsuri_date_sinonime_2[i, 2] == raspunsuri_sinonime_2[i, 2]) s1++;
                    if (raspunsuri_date_sinonime_2[i, 1] == raspunsuri_sinonime_2[i, 2] && raspunsuri_date_sinonime_2[i, 2] == raspunsuri_sinonime_2[i, 1]) s1++;
                }
                calificativ(s1, n);
                s += s1;
            }

            if (n == 3)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (raspunsuri_date_antonime_1[i] == raspunsuri_antonime_1[i]) s1++;
                }
                calificativ(s1, n);
                s += s1;
            }

            if (n == 4)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (raspunsuri_date_antonime_2[i, 1] == raspunsuri_antonime_2[i, 1] && raspunsuri_date_antonime_2[i, 2] == raspunsuri_antonime_2[i, 2]) s1++;
                    if (raspunsuri_date_antonime_2[i, 1] == raspunsuri_antonime_2[i, 2] && raspunsuri_date_antonime_2[i, 2] == raspunsuri_antonime_2[i, 1]) s1++;
                }
                calificativ(s1, n);
                s += s1;
            }

            if (n == 5)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (raspunsuri_date_comparatii[i] == raspunsuri_comparatii[i]) s1++;
                }
                calificativ(s1, n);
                s += s1;
            }

            if (n == 6)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (String.Compare(raspunsuri_date_succesiuni_de_numere[i], raspunsuri_succesiuni_de_numere[i]) == 0) s1++;
                }
                calificativ(s1, n);
                s += s1;
            }

            if (n == 7)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (raspunsuri_date_clasificari[i] == raspunsuri_clasificari[i]) s1++;
                }
                calificativ(s1, n);
                s += s1;
                n++;
                calificativ_total();
            }
        }

        private void calificativ(int s1, int n)
        {
            if (s1 < 4) calificative[n] = "Sub nivelul mediu";
            if (s1 >= 4 && s1 <= 5) calificative[n] = "Mediu";
            if (s1 >= 6 && s1 <= 7) calificative[n] = "Bine";
            if (s1 >= 8 && s1 <= 9) calificative[n] = "Foarte bine";
            if (s1 == 10) calificative[n] = "Excepţional";
        }

        private void calificativ_total()
        {
            if (s < 28) calificative[n] = "Sub nivelul mediu";
            if (s >= 28 && s <= 35) calificative[n] = "Mediu";
            if (s >= 36 && s <= 49) calificative[n] = "Bine";
            if (s >= 50 && s <= 60) calificative[n] = "Foarte bine";
            if (s >= 61 && s <= 70) calificative[n] = "Excepţional";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.T) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                minute = 0;
                secunde = 15;
            }
        }

        private void inapoi_MouseEnter(object sender, MouseEventArgs e)
        {
            inapoi.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            inapoi.BorderBrush = new SolidColorBrush(Colors.White);
            inapoi_img.Source = new BitmapImage(new Uri("Images/back_arrow.png", UriKind.Relative));
        }

        private void inapoi_MouseLeave(object sender, MouseEventArgs e)
        {
            inapoi.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            inapoi.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            inapoi_img.Source = new BitmapImage(new Uri("Images/back_arrow_brown.png", UriKind.Relative));
        }

        private void acasa_Click(object sender, RoutedEventArgs e)
        {
            Meniu form = new Meniu();
            form.Show();
            this.Hide();
        }

        private void acasa_MouseEnter(object sender, MouseEventArgs e)
        {
            acasa.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            acasa.BorderBrush = new SolidColorBrush(Colors.White);
            acasa_img.Source = new BitmapImage(new Uri("Images/home.png", UriKind.Relative));
        }

        private void acasa_MouseLeave(object sender, MouseEventArgs e)
        {
            acasa.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            acasa.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            acasa_img.Source = new BitmapImage(new Uri("Images/home_brown.png", UriKind.Relative));
        }

        private void nav_menu_Click(object sender, RoutedEventArgs e)
        {
            Teste form = new Teste();
            form.Show();
            this.Hide();
        }

        private void nav_menu_MouseEnter(object sender, MouseEventArgs e)
        {
            nav_menu.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            nav_menu.BorderBrush = new SolidColorBrush(Colors.White);
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu.png", UriKind.Relative));
        }

        private void nav_menu_MouseLeave(object sender, MouseEventArgs e)
        {
            nav_menu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            nav_menu.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu_brown.png", UriKind.Relative));
        }

        private void verificare_MouseEnter(object sender, MouseEventArgs e)
        {
            verificare.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            verificare.Foreground = verificare.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void verificare_MouseLeave(object sender, MouseEventArgs e)
        {
            verificare.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            verificare.Foreground = verificare.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }
    }
}
