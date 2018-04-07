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
using System.Windows.Resources;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Gaseste_regula.xaml
    /// </summary>
    public partial class Gaseste_regula : Window
    {
        string[,] A, B, C, location_and_width;
        string[] lungime_label;
        int[,] numere_de_verificat;
        TextBox[] txtbox = new TextBox[4];
        int n, nr, parametru;

        StreamResourceInfo cursor_soft;
        int corect;
        int m;
        int ecran_x, ecran_y;
        int nr_nivel, nr_dificultate;

        public Gaseste_regula(int a, int b, int nr1)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr1;
            n = m = a;
            nr = b;
            if (n == 1)
            {
                matriceA();
                label_dificultate_nivel.Content = label_dificultate_nivel.Content + "mică, nivelul " + nr.ToString();
                label_dificultate.Content = label_dificultate.Content + "mică";
                button21.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                button21.Foreground = new SolidColorBrush(Colors.White);
            }
            if (n == 2)
            {
                matriceB();
                label_dificultate_nivel.Content = label_dificultate_nivel.Content + "medie, nivelul " + nr.ToString();
                label_dificultate.Content = label_dificultate.Content + "medie";
                button22.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                button22.Foreground = new SolidColorBrush(Colors.White);
            }
            if (n == 3)
            {
                matriceC();
                label_dificultate_nivel.Content = label_dificultate_nivel.Content + "mare, nivelul " + nr.ToString();
                label_dificultate.Content = label_dificultate.Content + "mare";
                button23.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                button23.Foreground = new SolidColorBrush(Colors.White);
            }
            casete_text();

            meniu();
            meniu_nivel();
            ecran_x = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            ecran_y = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            border_nivel.Margin = new Thickness((ecran_x - border_nivel.Width) / 2, (ecran_y - border_nivel.Height) / 2, 0, 0);
            border_instructiuni.Margin = new Thickness((ecran_x - border_instructiuni.Width) / 2, (ecran_y - border_instructiuni.Height) / 2, 0, 0);

            nr_dificultate = Convert.ToInt32(Properties.Settings.Default.dificultate_gaseste_regula[Properties.Settings.Default.nr_user]);
            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_gaseste_regula[Properties.Settings.Default.nr_user]);
            nivele();
            butoane();
        }

        private void matriceA()
        {
            A = new string[,] { { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                { "0", "1", "1", "1", "1", "1", "1", "1", "1", "1" },//1
                                { "0", "1", "-1", "1", "-1", "1", "-1", "1", "-1", "1" },//2
                                { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },//3
                                { "0", "0", "2", "4", "6", "8", "10", "12", "14", "16" },//4
                                { "0", "25", "22", "19", "16", "13", "10", "7", "4", "1" },//5
                                { "0", "35", "34", "32", "29", "25", "20", "14", "7", "0" },//6
                                { "0", "1", "a", "2" ,"b", "3", "c", "4", "d", "5" },//7
                                { "0", "256", "128" ,"64", "32", "16", "8", "4", "2", "1" },//8
                                { "0", "1", "3", "6", "10", "15", "21", "28", "36", "45" },//9
                                { "0", "100", "98", "94", "88", "80", "70", "58", "44", "28" },//10
                                { "0", "3", "6", "11", "18", "27", "38", "51", "66", "83" },//11
                                { "0", "1", "4", "9", "16", "25", "36", "49", "64", "81" },//12
                                { "0", "91/81", "92/72", "93/63", "94/54", "95/45", "96/36", "97/27", "98/18", "99/9" },//13
                                { "0", "1/6", "2/12", "3/20", "4/30", "5/42", "6/56", "7/72", "8/90", "9/110" },//14
                                { "0", "1", "1/2", "3", "1/4", "5", "1/6", "7", "1/8", "9" },//15
                                { "0", "0", "1", "1", "2", "3", "5", "8", "13", "21" }//16
                              };
            lungime_label = new string[] { "0", "390", "435", "390", "460", "500", "520", "390", "515",
                                            "500", "570", "520", "500", "950", "810", "505", "430" };

            location_and_width = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                                 { "0", "270", "28", "315", "28", "360", "28" },//1
                                                 { "0", "306", "28", "351", "38", "408", "28" },//2
                                                 { "0", "270", "28", "315", "28", "360", "28" },//3
                                                 { "0", "288", "46", "351", "46", "414", "46" },//4
                                                 { "0", "378", "28", "423", "28", "468", "28" },//5
                                                 { "0", "378", "46", "441", "28", "486", "28" },//6
                                                 { "0", "266", "28", "311", "28", "356", "28" },//7
                                                 { "0", "396", "28", "441", "28", "486", "28" },//8
                                                 { "0", "324", "46", "387", "46", "450", "46" },//9
                                                 { "0", "396", "46", "459", "46", "522", "46" },//10
                                                 { "0", "342", "46", "405", "46", "468", "46" },//11
                                                 { "0", "324", "46", "387", "46", "450", "46" },//12
                                                 { "0", "654", "90", "763", "90", "872", "75" },//13
                                                 { "0", "528", "75", "619", "75", "710", "90" },//14
                                                 { "0", "354", "28", "399", "55", "472", "28" },//15
                                                 { "0", "270", "28", "315", "46", "378", "46" }//16
                                               };

            numere_de_verificat = new int[,] { { 0, 0, 0, 0 },
                                               { 0, 7, 8, 9 },//1
                                               { 0, 7, 8, 9 },//2
                                               { 0, 7, 8, 9 },//3
                                               { 0, 7, 8, 9 },//4
                                               { 0, 7, 8, 9 },//5
                                               { 0, 7, 8, 9 },//6
                                               { 0, 7, 8, 9 },//7
                                               { 0, 7, 8, 9 },//8
                                               { 0, 7, 6, 9 },//9
                                               { 0, 7, 8, 9 },//10
                                               { 0, 7, 8, 9 },//11
                                               { 0, 7, 8, 9 },//12
                                               { 0, 7, 8, 9 },//13
                                               { 0, 7, 8, 9 },//14
                                               { 0, 7, 8, 9 },//15
                                               { 0, 7, 8, 9 },//16
                                             };

            label1.Content = A[nr, 1].ToString() + " , ";
            for (int i = 2; i <= 8; i++)
            {
                label1.Content = label1.Content + A[nr, i].ToString() + " , ";
            }
            label1.Content = label1.Content + A[nr, 9].ToString() + " ";
            label1.Width = canvas1.Width = Convert.ToInt32(lungime_label[nr]);
            border_regula.Width = canvas1.Width + 60;
        }

        private void matriceB()
        {
            B = new string[,] { { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                { "0", "1/2", "4/3", "9/4", "16/5", "25/6", "36/7", "49/8", "64/9", "81/10" },//1
                                { "0", "5", "10", "7", "14", "11", "22", "19", "38", "35" },//2
                                { "0", "7", "8", "16", "17", "34", "35", "70", "71", "142" },//3
                                { "0", "100", "96,75", "93,5", "90,25", "87", "83,75", "80,5", "77,25", "74" },//4
                                { "0", "1", "2", "6", "12", "36", "72", "216", "432", "1296" },//5
                                { "0", "2", "3", "5", "7", "11", "13", "17", "19", "23" },//6
                                { "0", "1", "2", "6", "24", "120", "720", "5040", "40320", "362880" },//7
                                { "0", "100", "50", "200", "25", "400", "12,5", "800", "6,25", "1600" },//8
                                { "0", "0", "100", "6", "94", "12", "88", "18", "82", "24" },//9
                                { "0", "1000", "971,4", "942,8", "914,2", "885,6", "857", "828,4", "799,8", "771,2" },//10
                                { "0", "0", "1", "1", "2", "4", "7", "13", "24", "44" },//11
                                { "0", "100", "1", "97,5", "3,5", "92,5", "8,5", "85", "16", "75" },//12
                                { "0", "1", "8", "27", "64", "125", "216", "343", "512", "729" },//13
                                { "0", "1", "-3", "9", "-27", "81", "-243", "729", "-2187", "6561"},//14
                                { "0", "5", "26", "131", "656", "3281", "16406", "82031", "410156", "2050781" },//15
                                { "0", "1", "3", "15", "105", "945", "10395", "135135", "2027025", "34459425" }//16
                                
                              };

            lungime_label = new string[] { "0", "775", "520", "540", "805", "580", "485", "700", "715",
                                            "535", "920", "450", "625", "610", "650", "875", "875" };

            location_and_width = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                                 { "0", "492", "75", "583", "75", "673", "95" },//1
                                                 { "0", "342", "46", "405", "46", "468", "46" },//2
                                                 { "0", "342", "46", "405", "46", "468", "65" },//3
                                                 { "0", "450", "90", "558", "72", "648", "90" },//4
                                                 { "0", "261", "46", "405", "65", "486", "85" },//5
                                                 { "0", "306", "46", "369", "46", "432", "46" },//6
                                                 { "0", "198", "65", "360", "80", "459", "100" },//7
                                                 { "0", "288", "65", "369", "70", "540", "70" },//8
                                                 { "0", "234", "46", "297", "46", "360", "46" },//9
                                                 { "0", "207", "90", "315", "90", "612", "90" },//10
                                                 { "0", "270", "46", "333", "46", "396", "46" },//11
                                                 { "0", "288", "70", "378", "55", "450", "46" },//12
                                                 { "0", "153", "46", "297", "65", "539", "65" },//13
                                                 { "0", "45", "40", "102", "28", "147", "60" },//14
                                                 { "0", "189", "65", "369", "100", "603", "115" },//15
                                                 { "0", "234", "65", "315", "100", "720", "155" },//16
                                               };

            numere_de_verificat = new int[,] { { 0, 0, 0, 0 },
                                               { 0, 7, 8, 9 },//1
                                               { 0, 7, 8, 9 },//2
                                               { 0, 7, 8, 9 },//3
                                               { 0, 6, 7, 8 },//4
                                               { 0, 6, 8, 9 },//5
                                               { 0, 7, 8, 9 },//6
                                               { 0, 5, 7, 8 },//7
                                               { 0, 5, 6, 8 },//8
                                               { 0, 5, 6, 7 },//9
                                               { 0, 3, 4, 7 },//10
                                               { 0, 7, 8, 9 },//11
                                               { 0, 5, 6, 7 },//12
                                               { 0, 4, 6, 9 },//13
                                               { 0, 2, 3, 4 },//14
                                               { 0, 4, 6, 8 },//15
                                               { 0, 5, 6, 9 },//16
                                             };

            label1.Content = B[nr, 1].ToString() + " , ";
            for (int i = 2; i <= 8; i++)
            {
                label1.Content = label1.Content + B[nr, i].ToString() + " , ";
            }
            label1.Content = label1.Content + B[nr, 9].ToString() + " ";
            label1.Width = canvas1.Width = Convert.ToInt32(lungime_label[nr]);
            border_regula.Width = canvas1.Width + 60;
        }

        private void matriceC()
        {
            C = new string[,] { { "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                { "0", "2", "3", "6", "18", "108", "1944", "209952", "408146688" },//1
                                { "0", "1", "5", "14", "30", "55", "91", "140", "204" },//2
                                { "0", "1", "1,41", "1,73", "2", "2,23",  "2,44", "2,64", "2,82" },//3
                                { "0", "1", "1", "2,5", "3,5", "4", "6", "5,5", "8,5" },//4
                                { "0", "1", "-1", "3", "-5", "11", "-21", "43", "-85" },//5
                                { "0", "1", "5", "12", "22", "35", "51", "70", "92" },//6
                                { "0", "1", "6", "15", "28", "45", "66", "91", "120" },//7
                                { "0", "3", "14", "39", "84", "155", "258", "399", "584" },//8
                                { "0", "-1", "3", "15", "44", "95", "174", "287", "440" },//9
                                { "0", "4", "8", "32", "128", "2048", "8192", "131072", "524288" },//10
                                { "0", "4", "8", "16", "77", "145", "668", "1345", "6677" },//11
                                { "0", "1", "9", "9", "18", "18", "27", "18", "45" },//12
                                { "0", "1", "10", "11", "100", "101", "110", "111", "1000" },//13
                                { "0", "1", "1", "10", "11", "101", "1000", "1101", "10101" },//14
                                { "0", "1", "11", "21", "1211", "111221", "312211", "13112221", "1113213211" },//15
                                { "0", "1", "1", "2", "5", "14", "42", "132", "429" }//16
                              };

            lungime_label = new string[] { "0", "685", "490", "615", "455", "465", "455", "475", "550",
                                            "525", "690", "565", "440", "580", "600", "910", "460" };

            location_and_width = new string[,] { { "0", "0", "0", "0", "0", "0", "0" },
                                                 { "0", "90", "28", "198", "65", "279", "80" },//1
                                                 { "0", "153", "46", "279", "46", "423", "65" },//2
                                                 { "0", "45", "70", "135", "70", "270", "70" },//3
                                                 { "0", "279", "28", "324", "55", "396", "55" },//4
                                                 { "0", "147", "38", "342", "46", "405", "55" },//5
                                                 { "0", "279", "46", "342", "46", "405", "46" },//6
                                                 { "0", "279", "46", "342", "46", "405", "65" },//7
                                                 { "0", "108", "46", "234", "65", "477", "65" },//8
                                                 { "0", "165", "46", "291", "65", "453", "65" },//9
                                                 { "0", "153", "65", "234", "80", "432", "115" },//10
                                                 { "0", "297", "65", "378", "80", "477", "80" },//11
                                                 { "0", "198", "46", "261", "46", "387", "46" },//12
                                                 { "0", "252", "65", "333", "65", "414", "65" },//13
                                                 { "0", "45", "28", "396", "80", "495", "95" },//14
                                                 { "0", "405", "115", "540", "150", "711", "190" },//15
                                                 { "0", "243", "46", "306", "65", "387", "65" },//16
                                               };

            numere_de_verificat = new int[,] { { 0, 0, 0, 0 },
                                               { 0, 3, 5, 6 },//1
                                               { 0, 4, 6, 8 },//2
                                               { 0, 2, 3, 5 },//3
                                               { 0, 6, 7, 8 },//4
                                               { 0, 4, 7, 8 },//5
                                               { 0, 6, 7, 8 },//6
                                               { 0, 6, 7, 8 },//7
                                               { 0, 3, 5, 8 },//8
                                               { 0, 4, 6, 8 },//9
                                               { 0, 4, 5, 7 },//10
                                               { 0, 6, 7, 8 },//11
                                               { 0, 5, 6, 8 },//12
                                               { 0, 5, 6, 7 },//13
                                               { 0, 2, 7, 8 },//14
                                               { 0, 6, 7, 8 },//15
                                               { 0, 6, 7, 8 },//16
                                             };

            label1.Content = C[nr, 1].ToString() + " , ";
            for (int i = 2; i <= 7; i++)
            {
                label1.Content = label1.Content + C[nr, i].ToString() + " , ";
            }
            label1.Content = label1.Content + C[nr, 8].ToString() + " ";
            label1.Width = canvas1.Width = Convert.ToInt32(lungime_label[nr]);
            border_regula.Width = canvas1.Width + 60;
        }

        private void casete_text()
        {
            for (int i = 1; i <= 3; i++)
            {
                txtbox[i] = new TextBox();
                canvas1.Children.Add(txtbox[i]);
                txtbox[i].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                txtbox[i].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                Canvas.SetTop(txtbox[i], 9);
                Canvas.SetLeft(txtbox[i], Convert.ToInt32(location_and_width[nr, 2 * i - 1]));
                txtbox[i].Width = Convert.ToInt32(location_and_width[nr, 2 * i]);
                txtbox[i].Height = 46;
                txtbox[i].FontFamily = new FontFamily("Times New Roman");
                txtbox[i].FontSize = 36;
                txtbox[i].TextChanged += new TextChangedEventHandler(schimbare_text);
            }
        }

        private void schimbare_text(object sender, TextChangedEventArgs e)
        {
            border_corect.Visibility = Visibility.Hidden;
        }

        private void meniu()
        {
            foreach (Button buton_meniu in canvas_meniu.Children.OfType<Button>())
            {
                buton_meniu.MouseEnter += new MouseEventHandler(buton_meniu_MouseEnter);
                buton_meniu.MouseLeave += new MouseEventHandler(buton_meniu_MouseLeave);
            }
        }

        private void buton_meniu_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.BorderBrush = buton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void buton_meniu_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            buton.BorderBrush = buton.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void meniu_nivel()
        {
            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                buton_nivel.MouseEnter += new MouseEventHandler(buton_nivel_MouseEnter);
                buton_nivel.MouseLeave += new MouseEventHandler(buton_nivel_MouseLeave);
                buton_nivel.Click += new RoutedEventHandler(buton_nivel_Click);

                for (int i = 1; i <= 16; i++)
                {
                    if (buton_nivel.Name == "button" + nr.ToString())
                    {
                        buton_nivel.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                        buton_nivel.BorderBrush = buton_nivel.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private void buton_nivel_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;

            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.BorderBrush = buton.Foreground = new SolidColorBrush(Colors.White);

            foreach (Image img in canvas_nivel.Children.OfType<Image>())
            {
                for (int i = 1; i <= 16; i++)
                {
                    if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
                    {
                        img.Source = new BitmapImage(new Uri("Images/lock_white.png", UriKind.Relative));
                    }
                }
            }

        }

        private void buton_nivel_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name != "button" + nr.ToString())
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                buton.BorderBrush = buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));

                foreach (Image img in canvas_nivel.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                        }
                    }
                }
            }

            if (buton.Name == "button" + nr.ToString() && m != n)
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                buton.BorderBrush = buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));

                foreach (Image img in canvas_nivel.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                        }
                    }
                }
            }
        }

        private void buton_nivel_Click(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            int ok = 1;
            if (buton.Name != "nivel_close")
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (buton.Name == "bonus" + i.ToString())
                    {
                        ok = 0;
                        break;
                    }
                }
                if (ok == 1)
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton.Name == "button" + i.ToString())
                        {
                            if (m < nr_dificultate)
                            {
                                nr = i;
                                Gaseste_regula form = new Gaseste_regula(m, nr, parametru);
                                form.Show();
                                this.Hide();
                                break;
                            }
                            else if (m == nr_dificultate)
                            {
                                if (i <= nr_nivel)
                                {
                                    nr = i;
                                    Gaseste_regula form = new Gaseste_regula(m, nr, parametru);
                                    form.Show();
                                    this.Hide();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void nivele()
        {
            foreach (Image img in canvas_nivel.Children.OfType<Image>())
            {
                for (int i = 1; i <= 16; i++)
                {
                    if (img.Name == "image" + i.ToString())
                    {
                        if (i <= nr_nivel) img.Visibility = Visibility.Hidden;
                        else
                        {
                            img.MouseEnter += new MouseEventHandler(img_MouseEnter);
                            img.MouseLeave += new MouseEventHandler(img_MouseLeave);
                        }
                    }
                }
            }
        }

        private void img_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            img.Source = new BitmapImage(new Uri("Images/lock_white.png", UriKind.Relative));

            foreach (Button buton in canvas_nivel.Children.OfType<Button>())
            {
                for (int i = 1; i <= 16; i++)
                {
                    if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
                    {
                        buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                        buton.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private void img_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            for (int i = 1; i <= 16; i++)
            {
                if (img.Name == "image" + i.ToString())
                {
                    img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                }
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_meniu form = new Gaseste_regula_meniu(parametru);
            form.Show();
            this.Hide();
        }

        private void instructiuni_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = border_nivel.Visibility = border_regula.Visibility = verificare.Visibility = Visibility.Hidden;
            border_instructiuni.Visibility = Visibility.Visible;
        }

        private void verificare_Click(object sender, RoutedEventArgs e)
        {
            corect = 0;

            if (n == 1)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (String.Compare(txtbox[i].Text, A[nr, numere_de_verificat[nr, i]]) == 0) corect++;
                }
            }
            if (n == 2)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (String.Compare(txtbox[i].Text, B[nr, numere_de_verificat[nr, i]]) == 0) corect++;
                }
            }
            if (n == 3)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (String.Compare(txtbox[i].Text, C[nr, numere_de_verificat[nr, i]]) == 0) corect++;
                }
            }

            border_corect.Visibility = Visibility.Visible;
            if (corect == 3)
            {
                for (int i = 1; i <= 3; i++) txtbox[i].Visibility = Visibility.Hidden;
                img_corect.Source = new BitmapImage(new Uri("/Images/corect.png", UriKind.Relative));

                if (m == nr_dificultate)
                {
                    if (nr == nr_nivel)
                    {
                        nr_nivel++;
                        if (nr_nivel != 17) Properties.Settings.Default.nivel_gaseste_regula[Properties.Settings.Default.nr_user] = nr_nivel.ToString();
                        else
                        {
                            nr_nivel = 1;
                            Properties.Settings.Default.nivel_gaseste_regula[Properties.Settings.Default.nr_user] = nr_nivel.ToString();
                            nr_dificultate++;
                            Properties.Settings.Default.dificultate_gaseste_regula[Properties.Settings.Default.nr_user] = nr_dificultate.ToString();
                        }

                        foreach (Image img in canvas_nivel.Children.OfType<Image>())
                        {
                            if (nr_nivel != 1)
                            {
                                for (int i = 1; i <= 16; i++)
                                {
                                    if (img.Name == "image" + nr_nivel.ToString())
                                    {
                                        img.Visibility = Visibility.Hidden;

                                        foreach (Button buton in canvas_nivel.Children.OfType<Button>())
                                        {
                                            for (int j = 1; j <= 16; j++)
                                            {
                                                if (buton.Name == "button" + nr_nivel.ToString())
                                                {
                                                    buton.Style = Resources["btnGlass"] as Style;
                                                }
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                butoane();
                            }
                        }

                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Upgrade();
                        Properties.Settings.Default.Save();

                        if (nr_dificultate != 4)
                        {
                            string msg;
                            msg = "Nivelul " + nr_nivel.ToString() + " de dificultate ";
                            if (nr_dificultate == 1) msg = msg + "mică";
                            if (nr_dificultate == 2) msg = msg + "medie";
                            if (nr_dificultate == 3) msg = msg + "mare";
                            msg = msg + " deblocat!";

                            Mesaj mesaj = new Mesaj(msg);
                            mesaj.ShowDialog();
                        }
                    }
                }
            }
            else img_corect.Source = new BitmapImage(new Uri("/Images/gresit.png", UriKind.Relative));
        }

        private void verificare_MouseEnter(object sender, MouseEventArgs e)
        {
            verificare.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            verificare.Foreground = new SolidColorBrush(Colors.White);
        }

        private void verificare_MouseLeave(object sender, MouseEventArgs e)
        {
            verificare.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            verificare.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Hidden;
            border_regula.Visibility = Visibility.Visible;
            if (border_corect.Visibility == Visibility.Hidden && corect == 3) border_corect.Visibility = Visibility.Visible;
            else verificare.Visibility = Visibility.Visible;
        }

        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            close.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            close.Foreground = new SolidColorBrush(Colors.White);
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            close.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            close.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void inapoi_MouseEnter(object sender, MouseEventArgs e)
        {
            inapoi_img.Source = new BitmapImage(new Uri("Images/back_arrow.png", UriKind.Relative));
        }

        private void inapoi_MouseLeave(object sender, MouseEventArgs e)
        {
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
            acasa_img.Source = new BitmapImage(new Uri("Images/home.png", UriKind.Relative));
        }

        private void acasa_MouseLeave(object sender, MouseEventArgs e)
        {
            acasa_img.Source = new BitmapImage(new Uri("Images/home_brown.png", UriKind.Relative));
        }

        private void nav_menu_Click(object sender, RoutedEventArgs e)
        {
            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void nav_menu_MouseEnter(object sender, MouseEventArgs e)
        {
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu.png", UriKind.Relative));
        }

        private void nav_menu_MouseLeave(object sender, MouseEventArgs e)
        {
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu_brown.png", UriKind.Relative));
        }

        private void nivel_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = border_nivel.Visibility = border_regula.Visibility = verificare.Visibility = Visibility.Hidden;
            border_nivel.Visibility = Visibility.Visible;

            if (border_corect.Visibility == Visibility.Visible) border_corect.Visibility = Visibility.Hidden;
        }

        private void nivel_MouseEnter(object sender, MouseEventArgs e)
        {
            nivel_img.Source = new BitmapImage(new Uri("Images/level.png", UriKind.Relative));
        }

        private void nivel_MouseLeave(object sender, MouseEventArgs e)
        {
            nivel_img.Source = new BitmapImage(new Uri("Images/level_brown.png", UriKind.Relative));
        }

        private void nivel_close_Click(object sender, RoutedEventArgs e)
        {
            border_nivel.Visibility = Visibility.Hidden;
            border_regula.Visibility = Visibility.Visible;

            if (border_corect.Visibility == Visibility.Hidden && corect == 3) border_corect.Visibility = Visibility.Visible;
            else verificare.Visibility = Visibility.Visible;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula form = new Gaseste_regula(n, nr, parametru);
            form.Show();
            this.Hide();
        }

        private void restart_MouseEnter(object sender, MouseEventArgs e)
        {
            restart_img.Source = new BitmapImage(new Uri("Images/restart.png", UriKind.Relative));
        }

        private void restart_MouseLeave(object sender, MouseEventArgs e)
        {
            restart_img.Source = new BitmapImage(new Uri("Images/restart_brown.png", UriKind.Relative));
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            m--;
            if (m == 0) m = 4;
            if (m == 1) label_dificultate.Content = "Dificultate uşoară";
            if (m == 2) label_dificultate.Content = "Dificultate medie";
            if (m == 3) label_dificultate.Content = "Dificultate grea";
            if (m == 4) label_dificultate.Content = "Bonus";

            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                if (n != m)
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton_nivel.Name == "button" + nr.ToString())
                        {
                            buton_nivel.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                            buton_nivel.BorderBrush = buton_nivel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton_nivel.Name == "button" + nr.ToString())
                        {
                            buton_nivel.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                            buton_nivel.BorderBrush = buton_nivel.Foreground = new SolidColorBrush(Colors.White);
                        }
                    }
                }
            }

            buton_rosu();
            butoane();
        }

        private void prev_MouseEnter(object sender, MouseEventArgs e)
        {
            prev.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            prev.Foreground = new SolidColorBrush(Colors.White);
        }

        private void prev_MouseLeave(object sender, MouseEventArgs e)
        {
            prev.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            prev.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            m++;
            if (m == 5) m = 1;
            if (m == 1) label_dificultate.Content = "Dificultate uşoară";
            if (m == 2) label_dificultate.Content = "Dificultate medie";
            if (m == 3) label_dificultate.Content = "Dificultate grea";
            if (m == 4) label_dificultate.Content = "Bonus";

            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                if (n != m)
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton_nivel.Name == "button" + nr.ToString())
                        {
                            buton_nivel.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                            buton_nivel.BorderBrush = buton_nivel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton_nivel.Name == "button" + nr.ToString())
                        {
                            buton_nivel.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                            buton_nivel.BorderBrush = buton_nivel.Foreground = new SolidColorBrush(Colors.White);
                        }
                    }
                }
            }

            buton_rosu();
            butoane();
        }

        private void next_MouseEnter(object sender, MouseEventArgs e)
        {
            next.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            next.Foreground = new SolidColorBrush(Colors.White);
        }

        private void next_MouseLeave(object sender, MouseEventArgs e)
        {
            next.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            next.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void buton_rosu()
        {
            foreach (Control c in canvas2.Children.OfType<Button>())
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (c.Name == "button2" + i)
                    {
                        c.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        c.Foreground = c.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    }
                }
                if (c.Name == "button2" + m)
                {
                    c.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                    c.Foreground = c.BorderBrush = Brushes.White;
                }
            }
        }

        private void butoane()
        {
            if (m == 4)
            {
                foreach (Button b in canvas_nivel.Children.OfType<Button>())
                {
                    for (int i = 1; i <= 16; i++) if (b.Name != "nivel_close") b.Visibility = Visibility.Hidden;

                    foreach (Image img in canvas_nivel.Children.OfType<Image>())
                    {
                        for (int i = 1; i <= 16; i++) img.Visibility = Visibility.Hidden;
                    }

                    for (int i = 1; i <= 4; i++)
                    {
                        if (b.Name == "bonus" + i.ToString()) b.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                foreach (Button b in canvas_nivel.Children.OfType<Button>())
                {
                    for (int i = 1; i <= 16; i++) if (b.Name != "nivel_close") b.Visibility = Visibility.Visible;
                    foreach (Image img in canvas_nivel.Children.OfType<Image>())
                    {
                        if (m < nr_dificultate)
                        {
                            for (int i = 1; i <= 16; i++) img.Visibility = Visibility.Hidden;
                        }
                        else if (m == nr_dificultate)
                        {
                            for (int i = 1; i <= 16; i++)
                            {
                                if (img.Name == "image" + i.ToString())
                                {
                                    if (i <= nr_nivel) img.Visibility = Visibility.Hidden;
                                    else img.Visibility = Visibility.Visible;
                                }
                            }
                        }
                        else if (m > nr_dificultate)
                        {
                            for (int i = 1; i <= 16; i++) img.Visibility = Visibility.Visible;
                        }
                    }

                    for (int i = 1; i <= 4; i++)
                    {
                        if (b.Name == "bonus" + i.ToString()) b.Visibility = Visibility.Hidden;
                    }
                }

                foreach (Button buton in canvas_nivel.Children.OfType<Button>())
                {
                    if (m < nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++)
                        {
                            buton.Style = this.Resources["btnGlass3"] as Style;
                        }
                    }
                    else if (m == nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++)
                        {
                            if (buton.Name == "button" + i.ToString())
                            {
                                if (i <= nr_nivel) buton.Style = this.Resources["btnGlass3"] as Style;
                                else buton.Style = this.Resources["btnlock"] as Style;
                            }
                        }
                    }
                    else if (m > nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++) buton.Style = this.Resources["btnlock"] as Style;
                    }
                }
            }
        }

        private void bonus1_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_bonus_functionarea_ceasului_analogic form = new Gaseste_regula_bonus_functionarea_ceasului_analogic(parametru);
            form.Show();
            this.Hide();
        }

        private void bonus2_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_bonus_patrate_perfecte form = new Gaseste_regula_bonus_patrate_perfecte(parametru);
            form.Show();
            this.Hide();
        }

        private void bonus3_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_bonus_codul_culorilor form = new Gaseste_regula_bonus_codul_culorilor(parametru);
            form.Show();
            this.Hide();
        }

        private void bonus4_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_bonus_regele_si_regina form = new Gaseste_regula_bonus_regele_si_regina(parametru);
            form.Show();
            this.Hide();
        }
    }
}
