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
    /// Interaction logic for Luminile_orasului.xaml
    /// </summary>
    public partial class Luminile_orasului : Window
    {
        int n, x, left, top, corect;
        Border[,] A;
        int[,] B;
        Random rand = new Random();
        Canvas canvas1 = new Canvas();

        StreamResourceInfo cursor_soft;
        int parametru;
        int ecran_x, ecran_y;
        int nr_nivel;

        public Luminile_orasului(int nr, int nr1)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr1;
            n = nr + 4;
            label_nivel.Content = label_nivel.Content + nr.ToString();
            border_corect.Margin = new Thickness(border_tabla_joc.Margin.Left + border_tabla_joc.Width + 10, border_tabla_joc.Margin.Top + border_tabla_joc.Height + 10, border_tabla_joc.Margin.Right - 10, border_tabla_joc.Margin.Bottom - 10);
            tabla_joc();

            meniu();
            meniu_nivel();
            ecran_x = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            ecran_y = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            border_nivel.Margin = new Thickness((ecran_x - border_nivel.Width) / 2, (ecran_y - border_nivel.Height) / 2, 0, 0);
            border_instructiuni.Margin = new Thickness((ecran_x - border_instructiuni.Width) / 2, (ecran_y - border_instructiuni.Height) / 2, 0, 0);

            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_luminile_orasului[Properties.Settings.Default.nr_user]);
            nivele();
        }

        private void tabla_joc()
        {
            x = 500;
            x = x / n;
            x = x * n;

            canvas1.Width = canvas1.Height = x + 5 * (n + 1);
            canvas1.HorizontalAlignment = HorizontalAlignment.Center;
            canvas1.VerticalAlignment = VerticalAlignment.Center;
            //canvas1.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            canvas1.Visibility = Visibility.Visible;
            border_tabla_joc.Child = canvas1;
            //border3.Children.Add(canvas1);

            A = new Border[n + 2, n + 2];
            B = new int[n + 2, n + 2];
            top = 5;
            for (int i = 1; i <= n; i++)
            {
                left = 5;
                for (int j = 1; j <= n; j++)
                {
                    A[i, j] = new Border();
                    A[i, j].Width = A[i, j].Height = x / n;
                    A[i, j].CornerRadius = new CornerRadius(100);
                    A[i, j].Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                    A[i, j].Margin = new Thickness(left, top, canvas1.Width - left, canvas1.Height - top);
                    A[i, j].MouseDown += new MouseButtonEventHandler(click);
                    canvas1.Children.Add(A[i, j]);
                    left = left + x / n + 5;
                }
                top = top + x / n + 5;
            }
            for (int i = 1; i <= n; i++) A[0, i] = A[n + 1, i] = A[i, 0] = A[i, n + 1] = new Border();
        }

        private void click(object sender, RoutedEventArgs e)
        {
            if (corect == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (A[i, j] == sender)
                        {
                            if (B[i, j] == 0)
                            {
                                B[i, j] = 1;
                                A[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                            }
                            else
                            {
                                B[i, j] = 0;
                                A[i, j].Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                            }

                            if (B[i, j - 1] == 0)
                            {
                                B[i, j - 1] = 1;
                                A[i, j - 1].Background = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                            }
                            else
                            {
                                B[i, j - 1] = 0;
                                A[i, j - 1].Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                            }//i, j - 1

                            if (B[i, j + 1] == 0)
                            {
                                B[i, j + 1] = 1;
                                A[i, j + 1].Background = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                            }
                            else
                            {
                                B[i, j + 1] = 0;
                                A[i, j + 1].Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                            }//i, j + 1

                            if (B[i - 1, j] == 0)
                            {
                                B[i - 1, j] = 1;
                                A[i - 1, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                            }
                            else
                            {
                                B[i - 1, j] = 0;
                                A[i - 1, j].Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                            }//i - 1, j

                            if (B[i + 1, j] == 0)
                            {
                                B[i + 1, j] = 1;
                                A[i + 1, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                            }
                            else
                            {
                                B[i + 1, j] = 0;
                                A[i + 1, j].Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                            }//i + 1, j
                        }
                    }
                }
                final();
            }
        }

        private void final()
        {
            corect = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (B[i, j] == 0)
                    {
                        corect = 0;
                        break;
                    }
                }
                if (corect == 0) break;
            }
            if (corect == 1)
            {
                border_corect.Visibility = Visibility.Visible;
                border_corect.RenderTransform = new RotateTransform(rand.Next(0, 30));

                if (nr_nivel < 5)
                {
                    if (nr_nivel == n - 4)
                    {
                        nr_nivel++;
                        Properties.Settings.Default.nivel_luminile_orasului[Properties.Settings.Default.nr_user] = nr_nivel.ToString();

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
                                                buton.Style = Resources["btnGlass"] as Style;
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
                    if (buton_nivel.Name == "button" + (n - 4).ToString())
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
            if (buton.Name != "button" + (n - 4).ToString())
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
            if (buton.Name != "button" + (n - 4).ToString())
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
                            Luminile_orasului form = new Luminile_orasului(n, parametru);
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
                        if (i <= nr_nivel) buton.Style = this.Resources["btnGlass"] as Style;
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
            Luminile_orasului_meniu form = new Luminile_orasului_meniu(parametru);
            form.Show();
            this.Hide();
        }

        private void instructiuni_Click(object sender, RoutedEventArgs e)
        {
            if (border_corect.Visibility == Visibility.Visible) border_corect.Visibility = Visibility.Hidden;

            border_instructiuni.Visibility = border_nivel.Visibility = border_tabla_joc.Visibility = Visibility.Hidden;
            border_instructiuni.Visibility = Visibility.Visible;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Hidden;
            border_tabla_joc.Visibility = Visibility.Visible;

            if (border_corect.Visibility == Visibility.Hidden && corect == 1) border_corect.Visibility = Visibility.Visible;
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
            border_instructiuni.Visibility = border_nivel.Visibility = border_tabla_joc.Visibility = Visibility.Hidden;
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
            border_tabla_joc.Visibility = Visibility.Visible;

            if (border_corect.Visibility == Visibility.Hidden && corect == 1) border_corect.Visibility = Visibility.Visible;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Luminile_orasului form = new Luminile_orasului(n - 4, parametru);
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
