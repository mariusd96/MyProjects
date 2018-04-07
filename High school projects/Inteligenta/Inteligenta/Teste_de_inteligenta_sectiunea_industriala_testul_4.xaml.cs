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
    /// Interaction logic for Teste_de_inteligenta_sectiunea_industriala_testul_1.xaml
    /// </summary>
    public partial class Teste_de_inteligenta_sectiunea_industriala_testul_4 : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int minute = 60, secunde = 0;

        int n = 1, s = 0;
        int[] v = new int[21];
        string[,] variante = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                             { "0", "25°", "33°", "40°", "45°", "50°" },//1
                                             { "0", "1,81 kg", "2,26 kg", "2,72 kg", "3,17 kg", "3,62 kg" },//2
                                             { "0", "23 lire", "27 lire", "59 lire", "717 lire", "1023 lire" },//3
                                             { "0", "Biciul", "Roata", "Glontele", "Săgeata", "Avionul" },//4
                                             { "0", "4", "5", "6", "8", "Depinde" },//5
                                             { "0", "Hochei pe gheaţă", "Fotbal", "Baschet", "Cricket", "Volei" },//6
                                             { "0", "1/896", "1/1266", "1/1826", "1/2652", "1/3892" },//7
                                             { "0", "10/64", "12/64", "14/64", "16/24", "18/64" },//8
                                             { "0", "20-1", "25-1", "30-1", "40-1", "50-1" },//9
                                             { "0", "14/64", "15/64", "16/64", "17/64", "18/64" },//10
                                             { "0", "10 inch cubici", "12 inch cubici", "14 inch cubici", "16 inch cubici", "18 inch cubici" },//11
                                             { "0", "1/101 pinte mai mult vin", "100/101 pinte mai mult vin", "Cantităţile sunt egale", "1/101 pinte mai puţin vin", "100/101 pinte mai puţin vin" },//12
                                             { "0", "81", "91", "101", "111", "121" },//13
                                             { "0", "15", "16", "17", "18", "19" },//14
                                             { "0", "65 m", "66 m", "67 m", "68 m", "70 m" },//15
                                             { "0", "10", "11", "12", "13", "14" },//16
                                             { "0", "7.934", "8.216", "9.874", "11.236", "13.186" },//17
                                             { "0", "172 m", "173 m", "174 m", "175 m", "176 m" },//18
                                             { "0", "30 zile", "35 zile", "40 zile", "45 zile", "50 zile" },//19
                                             { "0", "35", "36", "37", "38", "39" }//20
                                           };
        int[] raspunsuri = new int[] { 0, 2, 3, 2, 1, 3, 4, 4, 2, 1, 2, 1, 3, 2, 4, 2, 5, 4, 1, 3, 5 };

        SoundPlayer sound = new SoundPlayer("Sunete/beep.wav");
        int parametru;
        StreamResourceInfo cursor_soft;

        public Teste_de_inteligenta_sectiunea_industriala_testul_4(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            setare_img();

            meniu_intrebari();
        }

        private void timer_Tick(object sender, EventArgs e)
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
            if (secunde == 0 && minute == 0)
            {
                timer.Stop();
                verificare_raspunsuri();
                verificare.Content = "Refă testul";
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            Teste_de_inteligenta_sectiunea_industriala form = new Teste_de_inteligenta_sectiunea_industriala(parametru);
            form.Show();
            this.Hide();
        }

        private void setare_img()
        {
            enunt.Source = new BitmapImage(new Uri("Teste/Sectiunea industriala/Testul 4/" + n.ToString() + ".png", UriKind.Relative));

            BitmapSource bs = (BitmapSource)enunt.Source;
            enunt.Height = bs.PixelHeight;
            Canvas.SetTop(canvas2, 50 + enunt.Height + 10);
            border1.Height = canvas1.Height = 50 + enunt.Height + 10 + canvas2.Height + 10;

            foreach (RadioButton rb in canvas2.Children.OfType<RadioButton>())
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (rb.Name == "radioButton" + i.ToString())
                    {
                        rb.Content = variante[n, i].ToString();
                    }
                }
            }
        }

        private void meniu_intrebari()
        {
            foreach (Button b in canvas_intrebari.Children.OfType<Button>())
            {
                b.Click += new RoutedEventHandler(b_Click);
            }
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            radiobutton_answer(n);
            for (int i = 1; i <= 20; i++)
            {
                if (buton.Name == "button" + i.ToString())
                {
                    n = i;
                    label2.Content = n.ToString() + "/20";
                    setare_img();
                    radiobutton_checked();
                    break;
                }
            }
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            radiobutton_answer(n);
            if (n != 1)
            {
                n--;
                label2.Content = n.ToString() + "/20";
                setare_img();
            }
            radiobutton_checked();
        }

        private void prev_MouseEnter(object sender, MouseEventArgs e)
        {
            prev.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            prev.Foreground = prev.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void prev_MouseLeave(object sender, MouseEventArgs e)
        {
            prev.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            prev.Foreground = prev.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            radiobutton_answer(n);
            if (n != 20)
            {
                n++;
                label2.Content = n.ToString() + "/20";
                setare_img();
            }
            radiobutton_checked();
        }

        private void next_MouseEnter(object sender, MouseEventArgs e)
        {
            next.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            next.Foreground = next.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void next_MouseLeave(object sender, MouseEventArgs e)
        {
            next.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            next.Foreground = next.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void radiobutton_checked()
        {
            if (v[n] == 0)
            {
                foreach (RadioButton rb in canvas2.Children.OfType<RadioButton>())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (rb.Name == "radioButton" + i.ToString()) rb.IsChecked = false;
                    }
                }
            }
            else
            {
                foreach (RadioButton rb in canvas2.Children.OfType<RadioButton>())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (rb.Name == "radioButton" + v[n].ToString()) rb.IsChecked = true;
                    }
                }
            }
        }

        private void radiobutton_answer(int n)
        {
            foreach (RadioButton rb in canvas2.Children.OfType<RadioButton>())
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (rb.Name == "radioButton" + i.ToString())
                    {
                        if (rb.IsChecked == true) v[n] = i;
                    }
                }
            }
            if (v[n] != 0)
            {
                foreach (Button b in canvas_intrebari.Children.OfType<Button>())
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        if (b.Name == "button" + n.ToString())
                        {
                            b.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                            b.Foreground = new SolidColorBrush(Colors.White);
                        }
                    }
                }
            }
        }

        private void verificare_Click(object sender, RoutedEventArgs e)
        {
            radiobutton_answer(n);
            border_intrebari.Visibility = Visibility.Hidden;
            if (verificare.Content.ToString() == "Am terminat")
            {
                verificare_raspunsuri();
                verificare.Content = "Refă testul";
            }
            else
            {
                Teste_de_inteligenta_sectiunea_industriala_testul_1 form = new Teste_de_inteligenta_sectiunea_industriala_testul_1(parametru);
                form.Show();
                this.Hide();
            }
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

        private void verificare_raspunsuri()
        {
            radiobutton_answer(n);
            for (int i = 1; i <= 20; i++) if (v[i] == raspunsuri[i]) s++;
            timer.Stop();
            next.Visibility = prev.Visibility = border1.Visibility = rectangle1.Visibility = label1.Visibility = Visibility.Hidden;
            border2.Visibility = Visibility.Visible;
            if (s < 8) calificativ_label.Content += "Sub nivelul mediu";
            else if (s >= 8 && s <= 10) calificativ_label.Content += "Nivel mediu";
            else if (s >= 11 && s <= 13) calificativ_label.Content += "Bine";
            else if (s >= 14 && s <= 16) calificativ_label.Content += "Foarte bine";
            else if (s >= 17 && s <= 20) calificativ_label.Content += "Excepţional";
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.T) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                minute = 0;
                secunde = 15;
            }
        }

        private void intrebari_Click(object sender, RoutedEventArgs e)
        {
            border_intrebari.Visibility = Visibility.Visible;
        }

        private void intrebari_MouseEnter(object sender, MouseEventArgs e)
        {
            intrebari.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            intrebari.Foreground = intrebari.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void intrebari_MouseLeave(object sender, MouseEventArgs e)
        {
            intrebari.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            intrebari.Foreground = intrebari.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void close_intrebari_Click(object sender, RoutedEventArgs e)
        {
            border_intrebari.Visibility = Visibility.Hidden;
        }

        private void close_intrebari_MouseEnter(object sender, MouseEventArgs e)
        {
            close_intrebari.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            close_intrebari.Foreground = new SolidColorBrush(Colors.White);
        }

        private void close_intrebari_MouseLeave(object sender, MouseEventArgs e)
        {
            close_intrebari.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            close_intrebari.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }
    }
}
