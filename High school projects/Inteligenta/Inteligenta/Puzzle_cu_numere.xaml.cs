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
using System.IO;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Puzzle_cu_numere.xaml
    /// </summary>
    public partial class Puzzle_cu_numere : Window
    {
        int n, m, left, top, x, nivel, corect;
        int[] v, w, e;
        Canvas figura = new Canvas();
        Border[,] A, fig;
        Label[,] l;
        Label[,] lb;
        int[,] B, C;
        Random rand = new Random();
        int nr_nivel;

        StreamResourceInfo cursor_soft;
        int parametru;
        int ecran_x, ecran_y;

        public Puzzle_cu_numere(int nr, int nr1)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            nivel = nr;
            label_nivel.Content = label_nivel.Content + nivel.ToString();
            parametru = nr1;
            if (nr == 1) 
            {
                n = 3;
                C = new int[n + 1, n + 1];
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        m++;
                        C[i, j] = m;
                        if (m == n * n) C[i, j] = 0;
                    }
                }
            }
            if (nr == 2) 
            {   
                n = 3;
                C = new int[n + 1, n + 1];
                m = 9;
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        C[i, j] = m;
                        if (m == n * n) C[i, j] = 0;
                        m--;
                    }
                }
            }
            if (nr == 3) 
            {
                n = 4;
                C = new int[n + 1, n + 1];
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        m++;
                        C[j, i] = m;
                        if (m == n * n) C[i, j] = 0;
                    }
                }
            }
            if (nr == 4)
            {
                n = 4;
                C = new int[n + 1, n + 1];
                int k;
                k = m = 1;
                while (k != n)
                {
                    for (int i = k; i <= n - k; i++)
                    {
                        C[k, i] = m;
                        if (m == n * n) C[k, i] = 0;
                        m++;
                    }
                    for (int i = k; i <= n - k; i++)
                    {
                        C[i, n - k + 1] = m;
                        if (m == n * n) C[i, n - k + 1] = 0;
                        m++;
                    }
                    for (int i = n - k + 1; i >= k + 1; i--)
                    {
                        C[n - k + 1, i] = m;
                        if (m == n * n) C[n - k + 1, i] = 0;
                        m++;
                    }
                    for (int i = n - k + 1; i >= k + 1; i--)
                    {
                        C[i, k] = m;
                        if (m == n * n) C[i, k] = 0;
                        m++;
                    }
                    k++;
                }
            }
            if (nr == 5) 
            {
                n = 5;
                C = new int[n + 1, n + 1];
                int k;
                k = n;
                m = n * n - 1;
                while (k != 1)
                {
                    for (int i = n - k + 1; i <= k; i++)
                    {
                        C[k, i] = m;
                        m--;
                    }
                    for (int i = k - 1; i >= n - k + 1; i--)
                    {
                        C[i, k] = m;
                        m--;
                    }
                    for (int i = k - 1; i >= n - k + 1; i--)
                    {
                        C[n - k + 1, i] = m;
                        m--;
                    }
                    for (int i = n - k + 2; i <= k - 1; i++)
                    {
                        C[i, n - k + 1] = m;
                        m--;
                    }
                    k--;
                }
            }

            v = new int[n * n + 2];
            w = new int[n * n + 2];
            e = new int[n * n + 1];

            tabla_joc_instructiuni();
            random();
            tabla_joc();
            setari_vizual();
            butoane_meniu();
            nivel_meniu();

            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_puzzle_nr[Properties.Settings.Default.nr_user]);
            nivele();
        }

        private void setari_vizual()
        {
            forma.Value = Convert.ToInt32(Properties.Settings.Default.forma[Properties.Settings.Default.nr_user]);
            bordura.Value = Convert.ToInt32(Properties.Settings.Default.grosime_bordura[Properties.Settings.Default.nr_user]);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].CornerRadius = new CornerRadius(Convert.ToInt32(Properties.Settings.Default.forma[Properties.Settings.Default.nr_user]));
                    fig[i, j].CornerRadius = new CornerRadius(Convert.ToInt32(Properties.Settings.Default.forma[Properties.Settings.Default.nr_user]) / 2);

                    A[i, j].BorderThickness = new Thickness(Convert.ToInt32(Properties.Settings.Default.grosime_bordura[Properties.Settings.Default.nr_user]));
                    fig[i, j].BorderThickness = new Thickness(Convert.ToInt32(Properties.Settings.Default.grosime_bordura[Properties.Settings.Default.nr_user]) / 2);
                }
            }

            string cod_culoare_buton = Properties.Settings.Default.culoare_butoane[Properties.Settings.Default.nr_user].ToString();
            char[] separator = { ',' };
            string[] numere = cod_culoare_buton.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            red_slider.Value = Convert.ToInt32(numere[0]);
            red_box.Text = numere[0].ToString();
            green_slider.Value = Convert.ToInt32(numere[1]);
            green_box.Text = numere[1].ToString();
            blue_slider.Value = Convert.ToInt32(numere[2]);
            blue_box.Text = numere[2].ToString();

            byte red = Convert.ToByte(red_slider.Value);
            byte green = Convert.ToByte(green_slider.Value);
            byte blue = Convert.ToByte(blue_slider.Value);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
                    fig[i, j].Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
                }
            }

            string cod_culoare_bordura = Properties.Settings.Default.culoare_bordura[Properties.Settings.Default.nr_user].ToString();
            char[] separator2 = { ',' };
            string[] numere2 = cod_culoare_bordura.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
            
            red_border_slider.Value = Convert.ToInt32(numere2[0]);
            red_border_box.Text = numere2[0].ToString();
            green_border_slider.Value = Convert.ToInt32(numere2[1]);
            green_border_box.Text = numere2[1].ToString();
            blue_border_slider.Value = Convert.ToInt32(numere2[2]);
            blue_border_box.Text = numere2[2].ToString();

            red = Convert.ToByte(red_border_slider.Value);
            green = Convert.ToByte(green_border_slider.Value);
            blue = Convert.ToByte(blue_border_slider.Value);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].BorderBrush = new SolidColorBrush(Color.FromRgb(red, green, blue));
                    l[i, j].Foreground = new SolidColorBrush(Color.FromRgb(red, green, blue));

                    fig[i, j].BorderBrush = new SolidColorBrush(Color.FromRgb(red, green, blue));
                    lb[i, j].Foreground = new SolidColorBrush(Color.FromRgb(red, green, blue));
                }
            }
        }

        private void tabla_joc_instructiuni()
        {
            figura.Visibility = Visibility.Visible;
            figura.Width = 50 * n + 3 * (n - 1);
            figura.Height = 50 * n + 3 * (n - 1);
            figura.Margin = new Thickness((panou_instructiuni.Width-10) / 2 - figura.Width / 2, 105, (panou_instructiuni.Width-10 ) / 2 - figura.Width / 2, 40);

            border_instructiuni.Height = panou_instructiuni.Height = close1.Width + label7.Height + figura.Height + 30;
            panou_instructiuni.Children.Add(figura);

            fig = new Border[n + 1, n + 1];
            lb = new Label[n + 1, n + 1];
            top = 0;
            for (int i = 1; i <= n; i++)
            {
                left = 0;
                for (int j = 1; j <= n; j++)
                {
                    fig[i, j] = new Border();
                    fig[i, j].Width = 50;
                    fig[i, j].Height = 50;
                    fig[i, j].Visibility = Visibility.Visible;
                    fig[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;
                    fig[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                    fig[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    fig[i, j].CornerRadius = new CornerRadius(5);
                    fig[i, j].BorderThickness = new Thickness(1);
                    fig[i, j].BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    fig[i, j].Margin = new Thickness(left, top, figura.Width - left, figura.Height - top);

                    lb[i, j] = new Label();
                    lb[i, j].Content = C[i, j].ToString();
                    lb[i, j].VerticalAlignment = VerticalAlignment.Center;
                    lb[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    lb[i, j].FontSize = 22;
                    lb[i, j].Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    lb[i, j].FontFamily = new System.Windows.Media.FontFamily("Times New Roman");

                    figura.Children.Add(fig[i, j]);
                    fig[i, j].Child = lb[i, j];

                    if (C[i, j] == 0)
                    {
                        fig[i, j].Visibility = Visibility.Hidden;
                    }

                    left = left + 50 + 3;
                }
                top = top + 50 + 3;
            }

        }

        private void random()
        {
            Random rand = new Random();
            int aux, numar;
            for (int i = 1; i <= n*n; i++) w[i] = i;
            for (int i = 1; i <= n*n; i++)
            {
                numar = rand.Next(1, n * n + 1);
                aux = w[i];
                w[i] = w[numar];
                w[numar] = aux;
            }

            inversa();
        }

        private void inversa()
        {
            for (int i = 1; i <= n * n; i++) e[i] = w[i];
            for (int i = 1; i <= n * n; i++) w[e[i]] = i;
            permutare();
        }

        private void permutare()
        {
            int numar = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    numar++;
                    if (C[i, j] == 0) e[numar] = n * n;
                    else e[numar] = C[i, j];
                }
            }

            solutie();
        }

        private void solutie()
        {
            for (int i = 1; i <= n * n; i++)
            {
                v[i] = e[w[i]];
            }

            for (int i = 1; i < n * n - 1; i++)
            {
                for (int j = i + 1; j < n * n; j++)
                {
                    if (v[i] > v[j]) x++;
                }
            }
            if (x % 2 == 1) random();
        }

        private void tabla_joc()
        {
            int numar=1;

            canvas1.Width = 100 * n + (n - 1) * 5;
            canvas1.Height = 100 * n + (n - 1) * 5;
            border_corect.Margin = new Thickness(canvas1.Margin.Left + canvas1.Width + 25, canvas1.Margin.Top + canvas1.Height + 25, canvas1.Margin.Right - 25, canvas1.Margin.Bottom - 25);

            A = new Border[n + 1, n + 1];
            B = new int[n + 2, n + 2];
            l = new Label[n + 1, n + 1];
            top = 0;
            for (int i = 1; i <= n; i++)
            {
                left = 0;
                for (int j = 1; j <= n; j++)
                {
                    A[i, j] = new Border();
                    A[i, j].Width = 100;
                    A[i, j].Height = 100;
                    A[i, j].Visibility = Visibility.Visible;
                    A[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;
                    A[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                    A[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                    A[i, j].CornerRadius = new CornerRadius(10);
                    A[i, j].BorderThickness = new Thickness(2);
                    A[i, j].BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    A[i, j].Margin = new Thickness(left, top, canvas1.Width - left, canvas1.Height - top);
                    A[i, j].MouseDown += new MouseButtonEventHandler(click);

                    l[i, j] = new Label();
                    l[i, j].Content = v[numar].ToString();
                    B[i, j] = v[numar];
                    l[i, j].VerticalAlignment = VerticalAlignment.Center;
                    l[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    l[i, j].FontSize = 45;
                    l[i, j].Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    l[i, j].FontFamily = new System.Windows.Media.FontFamily("Times New Roman");

                    canvas1.Children.Add(A[i, j]);
                    A[i, j].Child = l[i, j];
                    left = left + 100 + 5;

                    if (v[numar] == n * n)
                    {
                        A[i, j].Visibility = Visibility.Hidden;
                        B[i, j] = 0;
                    }

                    numar++;
                }
                top = top + 100 + 5;
            }

            for (int i = 1; i <= n; i++) B[0, i] = B[n + 1, i] = -1;
            for (int i = 1; i <= n; i++) B[i, 0] = B[i, n + 1] = -1;
        }

        private void butoane_meniu()
        {
            foreach (Button buton_meniu in meniu.Children.OfType<Button>())
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

        private void nivel_meniu()
        {
            ecran_x = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            ecran_y = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            border_nivel.Margin = new Thickness((ecran_x - border_nivel.Width) / 2, (ecran_y - border_nivel.Height) / 2, 0, 0);
            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                buton_nivel.MouseEnter += new MouseEventHandler(buton_nivel_MouseEnter);
                buton_nivel.MouseLeave += new MouseEventHandler(buton_nivel_MouseLeave);
                buton_nivel.Click += new RoutedEventHandler(buton_nivel_Click);

                for (int i = 1; i <= 5; i++)
                {
                    if (buton_nivel.Name == "button" + nivel.ToString())
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
            if (buton.Name != "button" + nivel.ToString())
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
            if (buton.Name != "button" + nivel.ToString())
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
                            nivel = i;
                            Puzzle_cu_numere form = new Puzzle_cu_numere(nivel, parametru);
                            form.Show();
                            this.Hide();
                            break;
                        }
                    }
                }
            }
        }

        private void click(object sender, RoutedEventArgs e)
        {
            int aux;
            string cuv; 
            if (corect == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (A[i, j] == sender)
                        {
                            aux = B[i, j];
                            cuv = l[i, j].Content.ToString();

                            if (B[i - 1, j] == 0)
                            {
                                B[i, j] = B[i - 1, j];
                                B[i - 1, j] = aux;

                                l[i, j].Content = "0";
                                l[i - 1, j].Content = cuv.ToString();

                                A[i - 1, j].Visibility = Visibility.Visible;
                                A[i, j].Visibility = Visibility.Hidden;

                                break;
                            }

                            if (B[i + 1, j] == 0)
                            {
                                B[i, j] = B[i + 1, j];
                                B[i + 1, j] = aux;

                                l[i, j].Content = "0";
                                l[i + 1, j].Content = cuv.ToString();

                                A[i + 1, j].Visibility = Visibility.Visible;
                                A[i, j].Visibility = Visibility.Hidden;

                                break;
                            }

                            if (B[i, j - 1] == 0)
                            {
                                B[i, j] = B[i, j - 1];
                                B[i, j - 1] = aux;

                                l[i, j].Content = "0";
                                l[i, j - 1].Content = cuv.ToString();

                                A[i, j - 1].Visibility = Visibility.Visible;
                                A[i, j].Visibility = Visibility.Hidden;

                                break;
                            }

                            if (B[i, j + 1] == 0)
                            {
                                B[i, j] = B[i, j + 1];
                                B[i, j + 1] = aux;

                                l[i, j].Content = "0";
                                l[i, j + 1].Content = cuv.ToString();

                                A[i, j + 1].Visibility = Visibility.Visible;
                                A[i, j].Visibility = Visibility.Hidden;

                                break;
                            }
                        }
                    }
                }
                final();
            }
        }

        private void final()
        {
            corect=1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (B[i, j] != C[i, j])
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
                    if (nr_nivel == nivel)
                    {
                        nr_nivel++;
                        Properties.Settings.Default.nivel_puzzle_nr[Properties.Settings.Default.nr_user] = nr_nivel.ToString();

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
            Puzzle_cu_numere_meniu form = new Puzzle_cu_numere_meniu(parametru);
            form.Show();
            this.Hide();
        }

        private void forma_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].CornerRadius = new CornerRadius(forma.Value);
                    fig[i, j].CornerRadius = new CornerRadius(forma.Value / 2);
                }
            }
        }

        private void bordura_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].BorderThickness = new Thickness(bordura.Value);
                    fig[i, j].BorderThickness = new Thickness(bordura.Value / 2);
                }
            }
        }

        private void red_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            red_box.Text = red_slider.Value.ToString();
            colorare_butoane();
        }

        private void green_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            green_box.Text = green_slider.Value.ToString();
            colorare_butoane();
        }

        private void blue_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blue_box.Text = blue_slider.Value.ToString();
            colorare_butoane();
        }

        private void red_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (red_box.Text.Length == 0) red_box.Text = "0";
            red_slider.Value = Convert.ToInt32(red_box.Text);
        }

        private void green_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (green_box.Text.Length == 0) green_box.Text = "0";
            green_slider.Value = Convert.ToInt32(green_box.Text);
        }

        private void blue_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (blue_box.Text.Length == 0) blue_box.Text = "0";
            blue_slider.Value = Convert.ToInt32(blue_box.Text);
        }

        private void colorare_butoane()
        {
            byte red = Convert.ToByte(red_slider.Value);
            byte green = Convert.ToByte(green_slider.Value);
            byte blue = Convert.ToByte(blue_slider.Value);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
                    fig[i, j].Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
                }
            }
        }

        private void red_border_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            red_border_box.Text = red_border_slider.Value.ToString();
            colorare_borduri_si_text();
        }

        private void green_border_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            green_border_box.Text = green_border_slider.Value.ToString();
            colorare_borduri_si_text();
        }

        private void blue_border_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blue_border_box.Text = blue_border_slider.Value.ToString();
            colorare_borduri_si_text();
        }

        private void red_border_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (red_border_box.Text.Length == 0) red_border_box.Text = "0";
            red_border_slider.Value = Convert.ToInt32(red_border_box.Text);
        }

        private void green_border_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (green_border_box.Text.Length == 0) green_border_box.Text = "0";
            green_border_slider.Value = Convert.ToInt32(green_border_box.Text);
        }

        private void blue_border_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (blue_border_box.Text.Length == 0) blue_border_box.Text = "0";
            blue_border_slider.Value = Convert.ToInt32(blue_border_box.Text);
        }

        private void colorare_borduri_si_text()
        {
            byte red = Convert.ToByte(red_border_slider.Value);
            byte green = Convert.ToByte(green_border_slider.Value);
            byte blue = Convert.ToByte(blue_border_slider.Value);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[i, j].BorderBrush = new SolidColorBrush(Color.FromRgb(red, green, blue));
                    l[i, j].Foreground = new SolidColorBrush(Color.FromRgb(red, green, blue));

                    fig[i, j].BorderBrush = new SolidColorBrush(Color.FromRgb(red, green, blue));
                    lb[i, j].Foreground = new SolidColorBrush(Color.FromRgb(red, green, blue));
                }
            }
        }

        private void setari_Click(object sender, RoutedEventArgs e)
        {
            panou_setari.Visibility = Visibility.Visible;
        }

        private void configurare_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.forma[Properties.Settings.Default.nr_user] = forma.Value.ToString();
            Properties.Settings.Default.grosime_bordura[Properties.Settings.Default.nr_user] = bordura.Value.ToString();
            string cod_culoare_buton = red_slider.Value.ToString() + "," + green_slider.Value.ToString() + "," + blue_slider.Value.ToString();
            Properties.Settings.Default.culoare_butoane[Properties.Settings.Default.nr_user] = cod_culoare_buton.ToString();
            string cod_culoare_bordura = red_border_slider.Value.ToString() + "," + green_border_slider.Value.ToString() + "," + blue_border_slider.Value.ToString();
            Properties.Settings.Default.culoare_bordura[Properties.Settings.Default.nr_user] = cod_culoare_bordura.ToString();
            Properties.Settings.Default.Save();

            Puzzle_cu_numere form = new Puzzle_cu_numere(nivel, parametru);
            form.Show();
            this.Hide();
            Mesaj msg = new Mesaj("Modificările au fost salvate cu succes !!!");
            msg.ShowDialog();
        }

        private void configurare_MouseEnter(object sender, MouseEventArgs e)
        {
            configurare.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            configurare.Foreground = new SolidColorBrush(Colors.White);
        }

        private void configurare_MouseLeave(object sender, MouseEventArgs e)
        {
            configurare.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            configurare.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void resetare_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.forma[Properties.Settings.Default.nr_user] = "10";
            Properties.Settings.Default.grosime_bordura[Properties.Settings.Default.nr_user] = "2";
            string cod_culoare_buton = "255,255,211";
            Properties.Settings.Default.culoare_butoane[Properties.Settings.Default.nr_user] = cod_culoare_buton;
            string cod_culoare_bordura = "120,32,15";
            Properties.Settings.Default.culoare_bordura[Properties.Settings.Default.nr_user] = cod_culoare_bordura;
            Properties.Settings.Default.Save();

            Puzzle_cu_numere form = new Puzzle_cu_numere(nivel, parametru);
            form.Show();
            this.Hide();
            Mesaj msg = new Mesaj("Resetarea s-a efectuat cu succes !!!");
            msg.ShowDialog();
        }

        private void resetare_MouseEnter(object sender, MouseEventArgs e)
        {
            resetare.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            resetare.Foreground = new SolidColorBrush(Colors.White);
        }

        private void resetare_MouseLeave(object sender, MouseEventArgs e)
        {
            resetare.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            resetare.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void instructiuni_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Visible;
        }

        private void close1_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Hidden;
        }

        private void close1_MouseEnter(object sender, MouseEventArgs e)
        {
            close1.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            close1.Foreground = new SolidColorBrush(Colors.White);
        }

        private void close1_MouseLeave(object sender, MouseEventArgs e)
        {
            close1.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            close1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        } 

        private void close2_Click(object sender, RoutedEventArgs e)
        {
            panou_setari.Visibility = Visibility.Hidden;
        }

        private void close2_MouseEnter(object sender, MouseEventArgs e)
        {
            close2.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            close2.Foreground = new SolidColorBrush(Colors.White);
        }

        private void close2_MouseLeave(object sender, MouseEventArgs e)
        {
            close2.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            close2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
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

        private void setari_MouseEnter(object sender, MouseEventArgs e)
        {
            setari_img.Source = new BitmapImage(new Uri("Images/setting2.png", UriKind.Relative));
        }

        private void setari_MouseLeave(object sender, MouseEventArgs e)
        {
            setari_img.Source = new BitmapImage(new Uri("Images/setting2_brown.png", UriKind.Relative));
        }

        private void nivel_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Visibility = Visibility.Hidden;
            if (border_corect.Visibility == Visibility.Visible) border_corect.Visibility = Visibility.Hidden;

            border_instructiuni.Visibility = border_nivel.Visibility = Visibility.Hidden;
            border_nivel.Visibility = Visibility.Visible;
        }

        private void nivel_buton_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Visibility = Visibility.Hidden;
            if (border_corect.Visibility == Visibility.Visible) border_corect.Visibility = Visibility.Hidden;

            border_nivel.Visibility = Visibility.Visible;
        } 

        private void nivel_buton_MouseEnter(object sender, MouseEventArgs e)
        {
            nivel_img.Source = new BitmapImage(new Uri("Images/level.png", UriKind.Relative));
        }

        private void nivel_buton_MouseLeave(object sender, MouseEventArgs e)
        {
            nivel_img.Source = new BitmapImage(new Uri("Images/level_brown.png", UriKind.Relative));
        }

        private void nivel_close_Click(object sender, RoutedEventArgs e)
        {
            border_nivel.Visibility = Visibility.Hidden;

            canvas1.Visibility = Visibility.Visible;
            if (border_corect.Visibility == Visibility.Hidden && corect == 1) border_corect.Visibility = Visibility.Visible;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Puzzle_cu_numere form = new Puzzle_cu_numere(nivel, parametru);
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
