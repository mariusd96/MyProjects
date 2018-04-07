﻿using System;
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
    public partial class Teste_de_inteligenta_sectiunea_industriala_testul_2 : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int minute = 60, secunde = 0;

        int n = 1, s = 0;
        int[] v = new int[20];
        string[,] variante = new string[,] { { "0", "0", "0", "0", "0", "0" },
                                             { "0", "Tetraedru", "Hexaedru", "Octoedru", "Dodecaedru", "Icosaedru" },//1
                                             { "0", "Eclipsa totală de Soare", "Eclipsă parţială de Soare", "Eclipsă inelară de Soare", "Eclipsă totală de Lună", "Eclipsa parţială de Lună" },//2
                                             { "0", "262 cm^2" , "286 cm^2", "312 cm^2", "328 cm^2", "352 cm^2" },//3
                                             { "0", "17.576", "675.324", "6.759.324", "17.558.424", "25.785.576" },//4
                                             { "0", "NV prin N", "NNE", "NE prin E", "ENE", "N prin E" },//5
                                             { "0", "2 ani", "3 ani", "4 ani", "6 ani", "8 ani" },//6
                                             { "0", "2", "3,5", "3,1415", "3,3927", "5,6" },//7
                                             { "0", "2-3-1", "4-3-2", "4-6-2", "4-6-1 ", "2-3-2" },//8
                                             { "0", "29", "30", "31", "32", "33" },//9
                                             { "0", "80", "120", "900", "200", "10.000" },//10
                                             { "0", "Cercul", "Elipsa", "Triunghiul", "Deptunghiul", "Pătratul" },//11
                                             { "0", "20°C", "22°C", "25°C", "28°C", "30°C" },//12
                                             { "0", "0,86", "0,7", "0,65", "0,6", "0,5" },//13
                                             { "0", "A", "B", "C", "D", "E" },//14
                                             { "0", "Dreptunghiului", "Trapezului", "Paralelogramului", "Cercului", "Triunghiului" },//15
                                             { "0", "20", "25", "30", "35", "40" },//16
                                             { "0", "1", "2", "3", "4", "5" }//17
                                           };
        int[] raspunsuri = new int[] { 0, 3, 4, 2, 4, 3, 5, 3, 3, 2, 1, 1, 3, 5, 5, 3, 4, 3 };

        SoundPlayer sound = new SoundPlayer("Sunete/beep.wav");
        int parametru;
        StreamResourceInfo cursor_soft;

        public Teste_de_inteligenta_sectiunea_industriala_testul_2(int nr)
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
            enunt.Source = new BitmapImage(new Uri("Teste/Sectiunea industriala/Testul 2/" + n.ToString() + ".png", UriKind.Relative));

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
            for (int i = 1; i <= 17; i++)
            {
                if (buton.Name == "button" + i.ToString())
                {
                    n = i;
                    label2.Content = n.ToString() + "/17";
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
                label2.Content = n.ToString() + "/17";
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
            if (n != 17)
            {
                n++;
                label2.Content = n.ToString() + "/17";
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
                    for (int i = 1; i <= 17; i++)
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
            for (int i = 1; i <= 17; i++) if (v[i] == raspunsuri[i]) s++;
            timer.Stop();
            next.Visibility = prev.Visibility = border1.Visibility = rectangle1.Visibility = label1.Visibility = Visibility.Hidden;
            border2.Visibility = Visibility.Visible;
            if (s < 5) calificativ_label.Content += "Sub nivelul mediu";
            else if (s >= 5 && s <= 7) calificativ_label.Content += "Nivel mediu";
            else if (s >= 8 && s <= 10) calificativ_label.Content += "Bine";
            else if (s >= 11 && s <= 13) calificativ_label.Content += "Foarte bine";
            else if (s >= 14 && s <= 17) calificativ_label.Content += "Excepţional";
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
