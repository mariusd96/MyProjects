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
    /// Interaction logic for Gaseste_regula_meniu.xaml
    /// </summary>
    public partial class Gaseste_regula_meniu : Window
    {
        int n = 1, parametru;
        StreamResourceInfo cursor_soft;
        int nr_nivel, nr_dificultate;

        public Gaseste_regula_meniu(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            foreach (Button b in canvas1.Children.OfType<Button>())
            {
                b.MouseEnter += new MouseEventHandler(b_MouseEnter);
                b.MouseLeave += new MouseEventHandler(b_MouseLeave);
            }

            nr_dificultate = Convert.ToInt32(Properties.Settings.Default.dificultate_gaseste_regula[Properties.Settings.Default.nr_user]);
            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_gaseste_regula[Properties.Settings.Default.nr_user]);
            nivele();
            butoane();
        }

        private void b_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.Foreground = new SolidColorBrush(Colors.White);

            foreach (Image img in canvas1.Children.OfType<Image>())
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

        private void b_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (n >= 1 && n <= 3)
            {
                for (int i = 1; i <= 16; i++)
                {
                    if (buton.Name == "button" + i.ToString())
                    {
                        if (i <= 8)
                        {
                            if (i % 2 == 0)
                            {
                                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                                buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                            }
                            else
                            {
                                buton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                                buton.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                            }
                        }
                        else if (i > 8)
                        {
                            if (i % 2 == 0)
                            {
                                buton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                                buton.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                            }
                            else
                            {
                                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                                buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                            }
                        }
                    }
                }

                foreach (Image img in canvas1.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 16; i++)
                    {
                        if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
                        {
                            if (i <= 8)
                            {
                                if (i % 2 == 0)
                                {
                                    img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                                }
                                else
                                {
                                    img.Source = new BitmapImage(new Uri("Images/lock_brown.png", UriKind.Relative));
                                }
                            }
                            else if (i > 8)
                            {
                                if (i % 2 == 0)
                                {
                                    img.Source = new BitmapImage(new Uri("Images/lock_brown.png", UriKind.Relative));
                                }
                                else
                                {
                                    img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                                }
                            }
                        }
                    }
                }
            }
            else if (n == 4)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (buton.Name == "bonus" + i.ToString())
                    {
                        if (i % 2 == 0)
                        {
                            buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                            buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        }
                        else
                        {
                            buton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                            buton.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                        }
                    }
                }
            }
        }

        private void nivele()
        {
            foreach (Image img in canvas1.Children.OfType<Image>())
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

            foreach (Button buton in canvas1.Children.OfType<Button>())
            {
                for (int i = 1; i <= 16; i++)
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

            foreach (Button buton in canvas1.Children.OfType<Button>())
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
                    if (i <= 8)
                    {
                        if (i % 2 == 0)
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                        }
                        else
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock_brown.png", UriKind.Relative));
                        }
                    }
                    else if (i > 8)
                    {
                        if (i % 2 == 0)
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock_brown.png", UriKind.Relative));
                        }
                        else
                        {
                            img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                        }
                    }
                }
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            if (parametru == 0)
            {
                Jocuri form = new Jocuri();
                form.Show();
            }
            else if (parametru == 1)
            {
                Meniu form = new Meniu();
                form.Show();
            }
            this.Hide();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Button b in canvas1.Children.OfType<Button>())
            {
                for (int i = 1; i <= 16; i++)
                {
                    if (b.Name == "button" + i.ToString()) b.Click += new RoutedEventHandler(apas_buton);
                }
            }
        }

        private void apas_buton(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            for (int i = 1; i <= 16; i++)
            {
                if (b.Name == "button" + i.ToString())
                {
                    if (n < nr_dificultate)
                    {
                        Gaseste_regula form = new Gaseste_regula(n, Convert.ToInt32(b.Content), parametru);
                        form.Show();
                        this.Hide();
                        break;
                    }
                    else if (n == nr_dificultate)
                    {
                        if (i <= nr_nivel)
                        {
                            Gaseste_regula form = new Gaseste_regula(n, Convert.ToInt32(b.Content), parametru);
                            form.Show();
                            this.Hide();
                            break;
                        }
                    }
                }
            }
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            n--;
            if (n == 0) n = 4;
            if (n == 1) label1.Content = "Dificultate uşoară";
            if (n == 2) label1.Content = "Dificultate medie";
            if (n == 3) label1.Content = "Dificultate grea";
            if (n == 4) label1.Content = "Bonus";
            buton_rosu();
            butoane();
        }

        private void prev_MouseEnter(object sender, MouseEventArgs e)
        {
            prev.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            prev.Foreground = prev.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void prev_MouseLeave(object sender, MouseEventArgs e)
        {
            prev.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            prev.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            n++;
            if (n == 5) n = 1;
            if (n == 1) label1.Content = "Dificultate uşoară";
            if (n == 2) label1.Content = "Dificultate medie";
            if (n == 3) label1.Content = "Dificultate grea";
            if (n == 4) label1.Content = "Bonus";
            buton_rosu();
            butoane();
        }

        private void next_MouseEnter(object sender, MouseEventArgs e)
        {
            next.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            next.Foreground = next.BorderBrush = new SolidColorBrush(Colors.White);
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
                        c.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                        c.Foreground = c.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                    }
                }
                if (c.Name == "button2" + n)
                {
                    c.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                    c.Foreground = c.BorderBrush = Brushes.White;
                }
            }
        }

        private void butoane()
        {
            if (n == 4)
            {
                foreach (Button b in canvas1.Children.OfType<Button>())
                {
                    for (int i = 1; i <= 16; i++) b.Visibility = Visibility.Hidden;
                    foreach (Image img in canvas1.Children.OfType<Image>())
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
                foreach (Button b in canvas1.Children.OfType<Button>())
                {
                    for (int i = 1; i <= 16; i++) b.Visibility = Visibility.Visible;
                    foreach (Image img in canvas1.Children.OfType<Image>())
                    {
                        if (n < nr_dificultate)
                        {
                            for (int i = 1; i <= 16; i++) img.Visibility = Visibility.Hidden;
                        }
                        else if (n == nr_dificultate)
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
                        else if (n > nr_dificultate)
                        {
                            for (int i = 1; i <= 16; i++) img.Visibility = Visibility.Visible;
                        }
                    }

                    for (int i = 1; i <= 4; i++)
                    {
                        if (b.Name == "bonus" + i.ToString()) b.Visibility = Visibility.Hidden;
                    }
                }

                foreach (Button buton in canvas1.Children.OfType<Button>())
                {
                    if (n < nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++)
                        {
                            buton.Style = this.Resources["btnGlass"] as Style;
                        }
                    }
                    else if (n == nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++)
                        {
                            if (buton.Name == "button" + i.ToString())
                            {
                                if (i <= nr_nivel) buton.Style = this.Resources["btnGlass"] as Style;
                                else buton.Style = this.Resources["btnlock"] as Style;
                            }
                        }
                    }
                    else if (n > nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++) buton.Style = this.Resources["btnlock"] as Style;
                    }
                }
            }
        }

        private void bonus1_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_bonus_functionarea_ceasului_analogic form=new Gaseste_regula_bonus_functionarea_ceasului_analogic(parametru);
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
            Jocuri form = new Jocuri();
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
    }
}
