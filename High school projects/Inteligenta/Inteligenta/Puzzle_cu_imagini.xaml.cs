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
using System.IO;
using System.Windows.Media.Effects;
using System.Windows.Resources;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Puzzle_cu_imagini.xaml
    /// </summary>
    public partial class Puzzle_cu_imagini : Window
    {
        int n, a, b, x, y, x_img, y_img, top, left, top_img, left_img, count;
        Image[,] Imagini;
        BitmapImage[] img=new BitmapImage[10];
        int[,] A, B;
        int[] v;
        Random rand = new Random();
        int aux, r;
        Image imagine = new Image();
        int i1, i2, j1, j2;
        int nr_piese, corect, nr_img, nr_img_max;
        int z_index=1;
        int nr_nivel;

        DropShadowEffect no_select=new DropShadowEffect();
        DropShadowEffect select = new DropShadowEffect();
        StreamResourceInfo cursor_soft;
        int parametru;
        string activ="border_canvas1";
        int ecran_x, ecran_y;

        public Puzzle_cu_imagini(int nr, int nr1)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            n = nr;
            label_nivel.Content = label_nivel.Content + n.ToString();
            parametru = nr1;
            switch (n)
            {
                case 1: a = b = 2;
                        break;
                case 2: a = 2;
                        b = 3;
                        break;
                case 3: a = b = 3;
                        break;
                case 4: a = 4;
                        b = 5;
                        break;
                case 5: a = 5;
                        b = 7;
                        break;
                case 6: a = 8;
                        b = 6;
                        break;
                case 7: a = b = 9;
                        break;
                case 8: a = 10;
                        b = 12;
                        break;
                case 9: a = 11;
                        b = 13;
                        break;
                case 10: a = b = 15;
                         break;
            }

            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_puzzle_img[Properties.Settings.Default.nr_user]);
            nivele();

            x = (int)canvas2.Width / b;
            y = (int)canvas2.Height / a;

            canvas2.Width = x * b;
            canvas2.Height = y * a;
            border_corect.Margin = new Thickness(canvas2.Margin.Left + canvas2.Width - 25, canvas2.Margin.Top + canvas2.Height - 25, canvas2.Margin.Right + 25, canvas2.Margin.Bottom + 25);

            Imagini = new Image[a + 1, b + 1];
            A = new int[a + 1, b + 1];
            B = new int[a + 1, b + 1];
            
            img[1] = new BitmapImage(new Uri("Puzzle/brain-sides.jpg", UriKind.Relative));
            img[2] = new BitmapImage(new Uri("Puzzle/sistem_solar.png", UriKind.Relative));
            img[3] = new BitmapImage(new Uri("Puzzle/fizica.png", UriKind.Relative));
            image_puzzle.Source = img[1];
            nr_img = 1;
            nr_img_max = 3;

            Efecte();

            foreach (Button buton_meniu in canvas_meniu.Children.OfType<Button>())
            {
                buton_meniu.MouseEnter += new MouseEventHandler(buton_meniu_MouseEnter);
                buton_meniu.MouseLeave += new MouseEventHandler(buton_meniu_MouseLeave);
            }

            foreach (Button buton in canvas1.Children.OfType<Button>())
            {
                buton.MouseEnter += new MouseEventHandler(buton_MouseEnter);
                buton.MouseLeave += new MouseEventHandler(buton_MouseLeave);
            }

            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                buton_nivel.MouseEnter += new MouseEventHandler(buton_nivel_MouseEnter);
                buton_nivel.MouseLeave += new MouseEventHandler(buton_nivel_MouseLeave);
                buton_nivel.Click += new RoutedEventHandler(buton_nivel_Click);

                for (int i = 1; i <= 10; i++)
                {
                    if (buton_nivel.Name == "button" + n.ToString())
                    {
                        buton_nivel.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                        buton_nivel.BorderBrush = buton_nivel.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }

            ecran_x = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            ecran_y = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            border_nivel.Margin = new Thickness((ecran_x - border_nivel.Width) / 2, (ecran_y - border_nivel.Height) / 2, 0, 0);
            border_instructiuni.Margin = new Thickness((ecran_x - border_instructiuni.Width) / 2, (ecran_y - border_instructiuni.Height) / 2, 0, 0);

        }

        private void Efecte()
        {
            Color color_select = new Color();

            color_select.ScA = 255;
            color_select.ScR = 255;
            color_select.ScG = 255;
            color_select.ScB = 255;
            select.Color = color_select;
            select.ShadowDepth = 0;
            select.BlurRadius = 5;

            no_select.ShadowDepth = 0;
            no_select.BlurRadius = 0;
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

        private void buton_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void buton_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void buton_nivel_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name != "button" + n.ToString())
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                buton.BorderBrush = buton.Foreground = new SolidColorBrush(Colors.White);

                foreach (Image img in canvas1.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 10; i++)
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
            if (buton.Name != "button" + n.ToString())
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                buton.BorderBrush = buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));

                foreach (Image img in canvas_nivel.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 10; i++)
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
                for (int i = 1; i <= 10; i++)
                {
                    if (buton.Name == "button" + i.ToString())
                    {
                        if (i <= nr_nivel)
                        {
                            n = i;
                            Puzzle_cu_imagini form = new Puzzle_cu_imagini(n, parametru);
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
                for (int i = 1; i <= 10; i++)
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
                for (int i = 1; i <= 10; i++)
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
                for (int i = 1; i <= 10; i++)
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
            for (int i = 1; i <= 10; i++)
            {
                if (img.Name == "image" + i.ToString())
                {
                    img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                }
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Puzzle_cu_imagini_meniu form = new Puzzle_cu_imagini_meniu(parametru);
            form.Show();
            this.Hide();
        }

        private void prev_img_Click(object sender, RoutedEventArgs e)
        {
            if (nr_img == 1) nr_img = nr_img_max;
            else nr_img--;
            image_puzzle.Source = img[nr_img];
        }

        private void next_img_Click(object sender, RoutedEventArgs e)
        {
            if (nr_img == nr_img_max) nr_img = 1;
            else nr_img++;
            image_puzzle.Source = img[nr_img];
        }

        private void genereaza_puzzle_Click(object sender, RoutedEventArgs e)
        {
            activ = "canvas2";

            border_canvas1.Visibility = Visibility.Hidden;
            canvas2.Visibility = Visibility.Visible;

            count = 0;

            BitmapImage bit = new BitmapImage();
            bit = img[nr_img];
            CroppedBitmap cb;

            BitmapSource source = (BitmapSource)img[nr_img];
            x_img = source.PixelWidth / b;
            y_img = source.PixelHeight / a;

            for (int i = 1; i <= a; i++)
            {
                left = 0;
                left_img = 0;
                for (int j = 1; j <= b; j++)
                {
                    Imagini[i, j] = new Image();
                    Imagini[i, j].Width = x;
                    Imagini[i, j].Height = y;
                    cb = new CroppedBitmap(bit, new Int32Rect(left_img, top_img, x_img, y_img));
                    left_img += x_img;
                    Imagini[i, j].Margin = new Thickness(left, top, canvas2.Width - left, canvas2.Height - top);
                    left += x;
                    Imagini[i, j].Source = cb;
                    Imagini[i, j].Stretch = Stretch.Fill;
                    canvas2.Children.Add(Imagini[i, j]);

                    count++;
                    A[i, j] = count;
                    r = rand.Next(0, 3);
                    if (r == 0) B[i, j] = 0;
                    if (r == 1) B[i, j] = 90;
                    if (r == 2) B[i, j] = 180;
                    if (r == 3) B[i, j] = 270;
                    
                }
                top_img += y_img;
                top += y;
            }

            v = new int[count + 1];
            random();
            setari_img();
        }

        private void random()
        {
            for (int i = 1; i <= count; i++) v[i] = i;
            for (int i = 1; i <= count; i++)
            {
                r = rand.Next(1, count);
                if (v[r] % b == 0) i1 = v[r] / b;
                else i1 = v[r] / b + 1;
                j1 = v[r] % b;
                if (j1 == 0) j1 = b;

                if (v[i] % b == 0) i2 = v[i] / b;
                else i2 = v[i] / b + 1;
                j2 = v[i] % b;
                if (j2 == 0) j2 = b;

                aux = A[i1, j1];
                A[i1, j1] = A[i2, j2];
                A[i2, j2] = aux;

                aux = B[i1, j1];
                B[i1, j1] = B[i2, j2];
                B[i2, j2] = aux;

                imagine.Source = Imagini[i1, j1].Source;
                Imagini[i1, j1].Source = Imagini[i2, j2].Source;
                Imagini[i2, j2].Source = imagine.Source;

                aux = v[r];
                v[r] = v[i];
                v[i] = aux;
            }
        }

        private void setari_img()
        {
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    Imagini[i, j].Effect = no_select;

                    Imagini[i, j].RenderTransformOrigin = new Point(0.5, 0.5);
                    RotateTransform rotire = new RotateTransform(B[i, j]);
                    Imagini[i, j].RenderTransform = rotire;

                    Imagini[i, j].MouseLeftButtonUp += new MouseButtonEventHandler(click_stg);
                    Imagini[i, j].MouseRightButtonUp += new MouseButtonEventHandler(click_dr);
                }
            }
        }

        private void click_stg(object sender, MouseButtonEventArgs e)
        {
            if (corect == 0)
            {
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= b; j++)
                    {
                        if (Imagini[i, j] == sender)
                        {
                            nr_piese++;
                            if (nr_piese == 1)
                            {
                                i1 = i;
                                j1 = j;
                                Imagini[i1, j1].Effect = select;
                                Canvas.SetZIndex(Imagini[i1, j1], z_index++);
                            }
                            if (nr_piese == 2)
                            {
                                i2 = i;
                                j2 = j;
                                Imagini[i2, j2].Effect = select;
                                Canvas.SetZIndex(Imagini[i2, j2], z_index++);

                                aux = A[i1, j1];
                                A[i1, j1] = A[i2, j2];
                                A[i2, j2] = aux;

                                aux = B[i1, j1];
                                B[i1, j1] = B[i2, j2];
                                B[i2, j2] = aux;

                                imagine.Source = Imagini[i1, j1].Source;
                                Imagini[i1, j1].Source = Imagini[i2, j2].Source;
                                Imagini[i2, j2].Source = imagine.Source;
                                Imagini[i1, j1].RenderTransform = new RotateTransform(B[i1, j1]);
                                Imagini[i2, j2].RenderTransform = new RotateTransform(B[i2, j2]);
                                Imagini[i1, j1].Effect = Imagini[i2, j2].Effect = no_select;

                                nr_piese = 0;
                            }
                        }
                    }
                }
                verificare();
            }
        }
        
        private void click_dr(object sender, MouseButtonEventArgs e)
        {
            if (corect == 0)
            {
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= b; j++)
                    {
                        if (Imagini[i, j] == sender)
                        {
                            B[i, j] = (B[i, j] + 90) % 360;
                            Imagini[i, j].RenderTransform = new RotateTransform(B[i, j]);
                            Canvas.SetZIndex(Imagini[i, j], z_index++);
                        }
                    }
                }

                verificare();
            }
        }
        
        private void verificare()
        {
            count = 0;
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    count++;
                    if (A[i, j] == count && B[i, j] == 0) corect = 1;
                    else
                    {
                        corect = 0;
                        break;
                    }
                }
                if (corect == 0) break;
            }
            if (corect == 1)
            {
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= b; j++)
                    {
                        Imagini[i, j].Effect = no_select;
                    }
                }

                border_corect.Visibility = Visibility.Visible;
                border_corect.RenderTransform = new RotateTransform(rand.Next(0, 30));

                if (nr_nivel < 10)
                {
                    if (nr_nivel == n)
                    {
                        nr_nivel++;
                        Properties.Settings.Default.nivel_puzzle_img[Properties.Settings.Default.nr_user] = nr_nivel.ToString();

                        foreach (Image img in canvas_nivel.Children.OfType<Image>())
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                if (img.Name == "image" + nr_nivel.ToString())
                                {
                                    img.Visibility = Visibility.Hidden;
                                    
                                    foreach (Button buton in canvas_nivel.Children.OfType<Button>())
                                    {
                                        for (int j = 1; j <= 10; j++)
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

        private void instructiuni_Click(object sender, RoutedEventArgs e)
        {
            if (activ == "canvas2") canvas2.Visibility = Visibility.Hidden;
            else border_canvas1.Visibility = Visibility.Hidden;
            if (border_corect.Visibility == Visibility.Visible) border_corect.Visibility = Visibility.Hidden;

            border_instructiuni.Visibility = border_nivel.Visibility = Visibility.Hidden;
            border_instructiuni.Visibility = Visibility.Visible;
        }

        private void close_instructiuni_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Hidden;

            if (activ == "canvas2") canvas2.Visibility = Visibility.Visible;
            else border_canvas1.Visibility = Visibility.Visible;
            if (border_corect.Visibility == Visibility.Hidden && corect == 1) border_corect.Visibility = Visibility.Visible;
        }

        private void close_instructiuni_MouseEnter(object sender, MouseEventArgs e)
        {
            close_instructiuni.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            close_instructiuni.Foreground = new SolidColorBrush(Colors.White);
        }

        private void close_instructiuni_MouseLeave(object sender, MouseEventArgs e)
        {
            close_instructiuni.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            close_instructiuni.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
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
            if (activ == "canvas2") canvas2.Visibility = Visibility.Hidden;
            else border_canvas1.Visibility = Visibility.Hidden;
            if (border_corect.Visibility == Visibility.Visible) border_corect.Visibility = Visibility.Hidden;

            border_instructiuni.Visibility = border_nivel.Visibility = Visibility.Hidden;
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
            
            if (activ == "canvas2") canvas2.Visibility = Visibility.Visible;
            else border_canvas1.Visibility = Visibility.Visible;
            if (border_corect.Visibility == Visibility.Hidden && corect == 1) border_corect.Visibility = Visibility.Visible;
        } 

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Puzzle_cu_imagini form = new Puzzle_cu_imagini(n, parametru);
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
