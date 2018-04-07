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
    /// Interaction logic for Teste_de_inteligenta_sectiunea_verbala_testul_3.xaml
    /// </summary>
    public partial class Teste_de_inteligenta_sectiunea_verbala_testul_3 : Window
    {
        int n = 1, s = 0, s1 = 0;
        int minute, secunde;
        Paragraph p1, p2, p3;
        Paragraph[] P = new Paragraph[22];

        Button[,] b = new Button[12, 7];
        TextBox[] tb = new TextBox[11];

        #region
        string[,] sinonime_1 = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                      { "OBSCUR                       ", "fălţuit", "abscons", "rupt", "sigur", "respins" },//1
                                      { "ÎNŢEPĂTOR	       ", "rezonabil", "gătit", "scorojit", "somnoros", "acrişor" },//2
                                      { "A COMANDA               ", "a sufoca", "a tăia", "a descinde", "a asculta", "a angaja" },//3
                                      { "INTRIGĂ                       ", "complot", "alee", "joc", "aruncare", "spaţiu" },//4
                                      { "BĂŢ                               ", "lustru", "nivel", "baston", "stăpân", "ajutor" },//5
                                      { "LEGE	                       ", "statut", "rachetă", "putere", "urmare", "artistic" },//6
                                      { "BLÂND	                       ", "prostesc", "crescător", "sigur", "suav", "inteligent" },//7
                                      { "FRĂGEZIME	       ", "neînsemnat", "aristocratic", "formă", "prospeţime", "uimire" },//8
                                      { "NESOCIABIL	       ", "negru", "veştejit", "sălbatic", "umflat", "temător" },//9
                                      { "ÎN PUTERE                   ", "servitor", "palid", "sărac", "deschis", "sănătos" }//10
                                    };
        int[] raspunsuri_sinonime_1 = new int[] { 0, 2, 5, 5, 1, 3, 1, 4, 4, 3, 5 };
        int[] raspunsuri_date_sinonime_1 = new int[11];
        #endregion
        //sinonime_1

        #region
        string[,] sinonime_2 = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                               { "1", "primăvăratic", "colorat", "acoperit", "primăvară", "prezent", "coborât" },//1
                                               { "2", "agitat", "peşte", "furios", "tulbure", "ciudat", "rece" },//2
                                               { "3", "icoană", "zenit", "vârf", "străin", "pronunţie", "viespar" },//3
                                               { "4", "muncă", "tabără", "a zăbovi", "a rătăci", "răcoros", "a trudi" },//4
                                               { "5", "a sugera", "a stăpâni", "a tempera", "a lovi", "obicei", "uzaj" },//5
                                               { "6", "linişte", "strănut", "a trâmbiţa", "mască", "a anunţa", "a raporta" },//6
                                               { "7", "vocal", "scriere", "disc", "verbal", "a o tuli", "frică" },//7
                                               { "8", "costum", "păsăresc", "a redresa", "a îndrepta", "miniatură", "obicei" },//8
                                               { "9", "fel", "familie", "a da foc", "a înflăcăra", "umbră", "copac" },//9
                                               { "10", "jubileu", "ospăţ", "tron", "bijuterie", "regal", "regesc" }//10
                                            };
        int[,] raspunsuri_sinonime_2 = new int[,] { { 0, 0, 0},
                                                    { 0, 1, 4},//1
                                                    { 0, 1, 4},//2
                                                    { 0, 2, 3},//3
                                                    { 0, 1, 6},//4
                                                    { 0, 5, 6},//5
                                                    { 0, 3, 5},//6
                                                    { 0, 1, 4},//7
                                                    { 0, 3, 4},//8
                                                    { 0, 3, 4},//9
                                                    { 0, 5, 6}//10
                                                  };
        int[,] raspunsuri_date_sinonime_2 = new int[11, 3];
        int[] sinonime_2_selectate = new int[11];
        #endregion
        //sinonime_2

        #region
        string[,] antonime_1 = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                      { "DIABOLIC	       ", "drept", "tensiune", "bas", "recapitulare", "noros" },//1
                                      { "FIDELITATE    	       ", "trădare", "luminos", "faimos", "muzical", "mobilitate" },//2
                                      { "OBTUZ                          ", "modificat", "acut", "radical", "condiţie", "instabil" },//3
                                      { "A DISTRUGE                ", "a construi", "a face reclamă", "a pufăi", "molimă", "ferocitate" },//4
                                      { "ÎNFLORIRE                  ", "susţinere", "amorţire", "testare", "echilibrare", "descreştere" },//5
                                      { "URSUZ                          ", "prins", "părăsit", "cordial", "pedepsit", "îngrijit" },//6
                                      { "RAPACE                        ", "frugal", "preţios", "exersat", "calm", "calificat" },//7
                                      { "STOIC                            ", "medicinal", "entuziast", "variabil", "metodic", "magic" },//8
                                      { "AGITAT                         ", "tren", "exact", "convenţie", "stăpânit", "pulsatoriu" },//9
                                      { "JUG                                ", "divorţ", "ovoid", "administrare", "chimie", "a suporta" }//10
                                    };
        int[] raspunsuri_antonime_1 = new int[] { 0, 1, 1, 2, 1, 5, 3, 1, 2, 4, 1 };
        int[] raspunsuri_date_antonime_1 = new int[11];
        #endregion
        //antonime_1

        #region
        string[,] antonime_2 = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                               { "1", "a despuia", "a cădea", "a umili", "a dispreţui", "a relata", "a îmbrăca" },//1
                                               { "2", "vină", "inactivitate", "vestit", "pustiu", "acţiune", "susţinere" },//2
                                               { "3", "a reaminti", "a se certa", "sigur", "echivoc", "delicat", "sentimental" },//3
                                               { "4", "motiv", "apărare", "timp liber", "duşmănie", "perdiţie", "eternitate" },//4
                                               { "5", "familiar", "ridicol", "caraghios", "decorativ", "merituos", "plăcut" },//5
                                               { "6", "neînsemnat", "dulce", "intern", "comoară", "important", "globular" },//6
                                               { "7", "a iriga", "a satisface", "a promulga", "special", "masaj", "a suprima" },//7
                                               { "8", "echilibru", "necredinţă", "grandoare", "dogmă", "încăpăţânat", "grăbit" },//8
                                               { "9", "domestic", "parfum", "mizer", "rătăcitor", "mămos", "ofiţer" },//9
                                               { "10", "om serios", "port", "haimana", "document", "încordare", "respect" }//10
                                            };
        int[,] raspunsuri_antonime_2 = new int[,] { { 0, 0, 0},
                                                    { 0, 1, 6},//1
                                                    { 0, 2, 5},//2
                                                    { 0, 3, 4},//3
                                                    { 0, 5, 6},//4
                                                    { 0, 3, 5},//5
                                                    { 0, 1, 5},//6
                                                    { 0, 3, 6},//7
                                                    { 0, 2, 4},//8
                                                    { 0, 1, 4},//9
                                                    { 0, 1, 3}//10
                                                  };
        int[,] raspunsuri_date_antonime_2 = new int[11, 7];
        int[] antonime_2_selectate = new int[11];
        #endregion
        //antonime_2

        #region
        string[,] comparatii = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                      { "SLAB este pentru PUTERNIC aşa cum FIERBINTE este pentru:", "tropical", "apă", "călduţ", "rece", "încins" },//1
                                      { "CARTE este pentru BIBLIOTECĂ, aşa cum COMOARĂ este pentru:", "oraş", "muzeu", "insulă", "urmă", "pirat" },//2
                                      { "PANDA este pentru BAMBUS, aşa cum VIERMELE DE MĂTASE este pentru:", "dud", "stejar", "brad", "salcie", "cedru" },//3
                                      { "SFERĂ este pentru MINGE, aşa cum ROTUNJIME este pentru:", "nuntă", "gogoaşă", "box", "zână", "toreador" },//4
                                      { "MĂNĂ este pentru MAGICIAN aşa cum BAGHETĂ este pentru:", "dirijor", "dansator", "grevist", "marinar", "iluzionist" },//5
                                      { "ANIMAL SĂLBATIC este pentru GNU aşa cum CAMILOPARD este pentru:", "cămilă", "leopard", "girafă", "zebră", "dromader" },//6
                                      { "CÂRNATUL este pentru TERCI aşa cum FOILE sunt pentru:", "morcovi", "fasole", "cartofi prăjiţi", "ceapă", "varză" },//7
                                      { "ARCUŞUL este pentru VIOARĂ aşa cum FLUIERUL este pentru:", "lac", "carte", "film", "clarinet", "chitară" },//8
                                      { "PULOVERUL este pentru LÂNĂ aşa cum ŞAGR1NUL este pentru:", "catifeaua reiată", "mătase", "piele", "bumbac", "tul" },//9
                                      { "TIBIA este pentru PICIOR aşa cum METACARPUL este pentru:", "mână", "cap", "laba piciorului", "gleznă", "umăr" }//10
                                    };
        int[] raspunsuri_comparatii = new int[] { 0, 4, 2, 1, 2, 1, 3, 4, 4, 3, 1 };
        int[] raspunsuri_date_comparatii = new int[11];
        #endregion
        //comparatii

        #region
        string[,] succesiuni = new string[,]{ { "0", "0", "0", "0", "0", "0" },
                                               { "briză, vânt, mistral, sirocco, zefir, ? \n     Alegeţi din:", "cutremur", "tunet", "uragan", "tornadă", "potop" },//1
                                               { "C, O, S, U, P, ? \n     Alegeţi din:", "L", "Z", "T", "R", "X" },//2
                                               { "prismă, cub, con, sferă, cilindru, ? \n     Alegeţi din:", "dodecaedru", "trapezoid", "cerc", "triunghi", "nonagon" },//3
                                               { "ceţos, pâclă, neclar, apăsător, fumuriu, ? \n     Alegeţi din:", "lucios", "şchiop", "tulbure", "bombastic", "diafan" },//4
                                               { "coupe, sedan, combi, limuzină, maşină de teren ? \n     Alegeţi din:", "rablă", "vas comercial", "caravelă", "a face curte", "feribot" },//5
                                               { "pârâu, estuar, şanţ, rigolă, canal, ? \n     Alegeţi din:", "pampas", "tundră", "atol", "arhipelag", "scurgere" },//6
                                               { "octogon, dreptunghi, pătrat, prelung, pentagon, ? \n     Alegeţi din:", "trapez", "cub", "sigma", "nodal", "logaritm" },//7
                                               { "a lătra, a hămăi, a schelălăi, a muşca, a mârâi ? \n     Alegeţi din:", "a cârâi", "a scânci", "a cârâi", "a ciripi", "a cloncăni" },//8
                                               { "piquet, poker, euchre, wist, canastă, ? \n     Alegeţi din:", "nod", "covrig", "bezique", "squash", "speologie" },//9
                                               { "adunare, greblă, lăţime, ambarcaţiune pe pernă de aer, plutire, ? \n     Alegeţi din:", "a se strădui", "a aluneca", "plutaş", "naştere", "liman" }//10
                                            };
        int[] raspunsuri_succesiuni = new int[] { 0, 3, 4, 1, 3, 1, 5, 1, 2, 3, 3 };
        int[] raspunsuri_date_succesiuni = new int[11];
        #endregion
        //succesiuni

        #region
        string[,] clasificari = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                               { "1", "Luca", "Marcu", "Oliver", "Matei", "loan" },//1
                                               { "2", "homar", "creveţi", "crabi", "languste", "fructe de mare" },//2
                                               { "3", "siameză", "birmaneză", "chinchilla", "abisiniană", "persană" },//3
                                               { "4", "dorsal", "pelvian", "caudal", "lateral", "pectoral" },//4
                                               { "5", "corb", "cioară", "mierlă", "gaiţă", "stăncuţă" },//5
                                               { "6", "Suzana", "Hilary", "Muriel", "Shelagh", "Lidia" },//6
                                               { "7", "Londra", "Washington", "Manchester", "Melbourne", "Viena" },//7
                                               { "8", "zmeură", "căpşuni", "coacăze", "agrişe", "pomuşoare" },//8
                                               { "9", "ciută", "melc", "scroată", "căţea", "iapă" },//9
                                               { "10", "sfert de galon", "galon", "baniţă", "butoi", "poloboc" }//10
                                            };
        int[] raspunsuri_clasificari = new int[] { 0, 3, 3, 3, 4, 3, 3, 4, 2, 2, 3 };
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

        public Teste_de_inteligenta_sectiunea_verbala_testul_3(int nr)
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
                p2.Inlines.Add(new Bold(new Run("Succesiuni\n")));
                p2.Inlines.Add(new Run("Este dată o succesiune şi cinci alternative, dintre care trebuie să alegeţi una, pentru a continua succesiunea respectivă, conform regulii sau principiului pe care se bazează.\n"));
                p2.Inlines.Add(new Underline(new Run("Exemplu:")));
                p2.Inlines.Add(new Run("        LT      FA     E \n"));
                p2.Inlines.Add(new Run("Alegeţi din:    N, W, H, I, K \n"));
                p2.Inlines.Add(new Run("Răspuns:        W\n"));
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
                if (i < 10) P[i + 1].Inlines.Add(new Run(" " + i.ToString() + ") "));
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
            int nr = 1;
            for (int i = 1; i <= 10; i++)
            {
                P[nr] = new Paragraph();
                if (i < 10) P[nr].Inlines.Add(new Run(" " + i.ToString() + ") "));
                else P[nr].Inlines.Add(new Run(i.ToString() + ") "));
                P[nr].Inlines.Add(new Run(succesiuni[i, 0].ToString()));
                flowdoc1.Blocks.Add(P[nr]);

                nr++;
                P[nr] = new Paragraph();

                for (int j = 1; j <= 5; j++)
                {
                    InlineUIContainer ic = new InlineUIContainer();
                    b[i, j] = new Button();
                    b[i, j].Content = succesiuni[i, j].ToString();
                    b[i, j].Width = 150;
                    b[i, j].Height = 30;
                    b[i, j].Style = Resources["btnGlass"] as Style;
                    b[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    b[i, j].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    b[i, j].Click += new RoutedEventHandler(buton6_click);
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

        private void buton6_click(object sender, EventArgs e)
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
            raspunsuri_date_succesiuni[i1] = j1;
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
                calificativ(s1, n);
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
                    if (raspunsuri_date_succesiuni[i] == raspunsuri_succesiuni[i]) s1++;
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
