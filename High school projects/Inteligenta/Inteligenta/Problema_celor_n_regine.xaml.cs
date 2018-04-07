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
    /// Interaction logic for Problema_celor_n_regine.xaml
    /// </summary>
    public partial class Problema_celor_n_regine : Window
    {
        int n, x, left, top, regine;
        int[] v;
        int[,] regine_pe_tabla_de_sah;
        Button[,] A;
        Canvas canvas1 = new Canvas();

        StreamResourceInfo cursor_soft;
        int parametru;
        int ecran_x, ecran_y;
        int nr_nivel;

        public Problema_celor_n_regine(int nr, int nr1)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr1;
            n = nr+3;
            regine = n;
            tabla_sah();
            label_nivel.Content = label_nivel.Content + nr.ToString();
            label1.Content = "Aranjaţi " + n.ToString() + " regine pe tabla de şah astfel încât să NU se atace între ele.";
            textBlock1.Text = regine.ToString();

            meniu();

            ecran_x = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            ecran_y = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            border_nivel.Margin = new Thickness((ecran_x - border_nivel.Width) / 2, (ecran_y - border_nivel.Height) / 2, 0, 0);
            border_instructiuni.Margin = new Thickness((ecran_x - border_instructiuni.Width) / 2, (ecran_y - border_instructiuni.Height) / 2, 0, 0);

            meniu_nivel();

            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_puzzle_regine[Properties.Settings.Default.nr_user]);
            nivele();
        }

        private void tabla_sah()
        {
            x = 560;
            x = x / n;
            x = x * n;

            canvas1.Visibility = Visibility.Visible;
            canvas1.Width = x;
            canvas1.Height = x;
            canvas1.HorizontalAlignment = HorizontalAlignment.Center;
            canvas1.VerticalAlignment = VerticalAlignment.Center;
            canvas1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            grid1.Children.Add(canvas1);

            regine_pe_tabla_de_sah = new int[n + 1, n + 1];
            A = new Button[n + 1, n + 1];
            for (int i = 1; i <= n; i++)
            {
                left = 0;
                for (int j = 1; j <= n; j++)
                {
                    A[i, j] = new Button();
                    A[i, j].Width = x / n;
                    A[i, j].Height = x / n;
                    A[i, j].Visibility = Visibility.Visible;
                    A[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;
                    A[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 1)
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                        else
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        }
                        else
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                    }
                    A[i, j].Margin = new Thickness(left, top, x - left, x - top);
                    A[i, j].Style = this.Resources["btnGlass"] as Style;
                    A[i, j].Click += new RoutedEventHandler(apas_buton);
                    canvas1.Children.Add(A[i, j]);
                    left = left + x / n;
                }
                top = top + x / n;
            }
        }

        private void apas_buton(object sender, RoutedEventArgs e)
        {
            if (regine > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (sender == A[i, j] && regine_pe_tabla_de_sah[i, j] != 1)
                        {
                            regine_pe_tabla_de_sah[i, j] = 1;
                            if (i % 2 == 1)
                            {
                                if (j % 2 == 1)
                                {
                                    Uri resourceUri = new Uri("Images/queen_black.png", UriKind.Relative);
                                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                                    var brush = new ImageBrush();
                                    brush.ImageSource = temp;

                                    A[i, j].Background = brush;

                                    regine--;
                                }
                                else
                                {
                                    Uri resourceUri = new Uri("Images/queen_white.png", UriKind.Relative);
                                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                                    var brush = new ImageBrush();
                                    brush.ImageSource = temp;

                                    A[i, j].Background = brush;

                                    regine--;
                                }
                            }
                            else
                            {
                                if (j % 2 == 1)
                                {
                                    Uri resourceUri = new Uri("Images/queen_white.png", UriKind.Relative);
                                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                                    var brush = new ImageBrush();
                                    brush.ImageSource = temp;

                                    A[i, j].Background = brush;

                                    regine--;
                                }
                                else
                                {
                                    Uri resourceUri = new Uri("Images/queen_black.png", UriKind.Relative);
                                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                                    var brush = new ImageBrush();
                                    brush.ImageSource = temp;

                                    A[i, j].Background = brush;

                                    regine--;
                                }
                            }
                        }
                    }
                }
                textBlock1.Text = regine.ToString();
            }
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

                for (int i = 1; i <= 5; i++)
                {
                    if (buton_nivel.Name == "button" + (n - 3).ToString())
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
            if (buton.Name != "button" + (n - 3).ToString())
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                buton.BorderBrush = buton.Foreground = new SolidColorBrush(Colors.White);

                foreach (Image img in canvas1.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock_white.png", UriKind.Relative));
                        }
                    }
                }
            }
        }

        private void buton_nivel_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name != "button" + (n - 3).ToString())
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                buton.BorderBrush = buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));

                foreach (Image img in canvas_nivel.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 5; i++)
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
            if (buton.Name != "nivel_close")
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (buton.Name == "button" + i.ToString())
                    {
                        if (i <= nr_nivel)
                        {
                            n = i;
                            Problema_celor_n_regine form = new Problema_celor_n_regine(n, parametru);
                            form.Show();
                            this.Hide();
                            break;
                        }
                    }
                }
            }
        }

        private void nivele()
        {
            foreach (Image img in canvas_nivel.Children.OfType<Image>())
            {
                for (int i = 1; i <= 5; i++)
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

            foreach (Button buton in canvas_nivel.Children.OfType<Button>())
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (buton.Name == "button" + i.ToString())
                    {
                        if (i <= nr_nivel) buton.Style = this.Resources["btnGlass4"] as Style;
                        else buton.Style = this.Resources["btnlock"] as Style;
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
                for (int i = 1; i <= 5; i++)
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
            for (int i = 1; i <= 5; i++)
            {
                if (img.Name == "image" + i.ToString())
                {
                    img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                }
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Problema_celor_n_regine_meniu form = new Problema_celor_n_regine_meniu(parametru);
            form.Show();
            this.Hide();
        }

        private void resetare_Click(object sender, RoutedEventArgs e)
        {
            regine = n;
            textBlock1.Text = regine.ToString();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 1)
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                        else
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        }
                        else
                        {
                            A[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                    }
                }
            }

            Array.Clear(regine_pe_tabla_de_sah, 0, regine_pe_tabla_de_sah.Length);
            border_verificare.Visibility = Visibility.Hidden;
            verificare.Visibility = Visibility.Visible;
        }

        private void resetare_MouseEnter(object sender, MouseEventArgs e)
        {
            resetare.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            resetare.Foreground = new SolidColorBrush(Colors.White);
        }

        private void resetare_MouseLeave(object sender, MouseEventArgs e)
        {
            resetare.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            resetare.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void verificare_Click(object sender, RoutedEventArgs e)
        {
            if (regine == 0)
            {
                int ok = 1;
                v = new int[n + 1];

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (regine_pe_tabla_de_sah[i, j] == 1) v[i] = j;
                    }
                }

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (j != i)
                        {
                            if (v[i] == 0 || v[j] == 0 || v[i] == v[j] || Math.Abs(v[i] - v[j]) == Math.Abs(i - j))
                            {
                                ok = 0;
                                break;
                            }
                        }
                    }
                }

                if (ok == 1)
                {
                    image_verificare.Source = new BitmapImage(new Uri("Images/corect.png", UriKind.Relative));

                    if (nr_nivel < 5)
                    {
                        if (nr_nivel == n - 3)
                        {
                            nr_nivel++;
                            Properties.Settings.Default.nivel_puzzle_regine[Properties.Settings.Default.nr_user] = nr_nivel.ToString();

                            foreach (Image img in canvas_nivel.Children.OfType<Image>())
                            {
                                for (int i = 1; i <= 5; i++)
                                {
                                    if (img.Name == "image" + nr_nivel.ToString())
                                    {
                                        img.Visibility = Visibility.Hidden;

                                        foreach (Button buton in canvas_nivel.Children.OfType<Button>())
                                        {
                                            for (int j = 1; j <= 5; j++)
                                            {
                                                if (buton.Name == "button" + nr_nivel.ToString())
                                                {
                                                    buton.Style = Resources["btnGlass4"] as Style;
                                                }
                                            }
                                        }

                                        break;
                                    }
                                }
                            }

                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Upgrade();
                            Properties.Settings.Default.Save();

                            Mesaj mesaj = new Mesaj("Nivelul " + nr_nivel.ToString() + " deblocat!");
                            mesaj.ShowDialog();
                        }
                    }
                }
                else image_verificare.Source = new BitmapImage(new Uri("Images/gresit.png", UriKind.Relative));
                
                border_verificare.Visibility = Visibility.Visible;
                verificare.Visibility = Visibility.Hidden;
            }
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

        private void instructiuni_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = border_nivel.Visibility = canvas1.Visibility = canvas_meniu_dreapta.Visibility = Visibility.Hidden;
            border_instructiuni.Visibility = Visibility.Visible;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Hidden;
            canvas1.Visibility = canvas_meniu_dreapta.Visibility = Visibility.Visible;
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
            border_instructiuni.Visibility = border_nivel.Visibility = canvas1.Visibility = canvas_meniu_dreapta.Visibility = Visibility.Hidden;
            border_nivel.Visibility = Visibility.Visible;
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
            canvas1.Visibility = canvas_meniu_dreapta.Visibility = Visibility.Visible;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Problema_celor_n_regine form = new Problema_celor_n_regine(n - 3, parametru);
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
    }
}
