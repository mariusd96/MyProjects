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
    /// Interaction logic for Luminile_orasului_meniu.xaml
    /// </summary>
    public partial class Luminile_orasului_meniu : Window
    {
        StreamResourceInfo cursor_soft;
        int parametru, nr_nivel;

        public Luminile_orasului_meniu(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            nr_nivel = Convert.ToInt32(Properties.Settings.Default.nivel_luminile_orasului[Properties.Settings.Default.nr_user]);
            nivele();
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
                b.Click += new RoutedEventHandler(apas_buton);
                b.MouseEnter += new MouseEventHandler(b_MouseEnter);
                b.MouseLeave += new MouseEventHandler(b_MouseLeave);
            }
        }

        private void apas_buton(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            for (int i = 1; i <= 5; i++)
            {
                if (b.Name == "button" + i.ToString())
                {
                    if (i <= nr_nivel)
                    {
                        Luminile_orasului form = new Luminile_orasului(Convert.ToInt32(b.Content), parametru);
                        form.Show();
                        this.Hide();
                        break;
                    }
                }
            }
        }

        private void b_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.Foreground = new SolidColorBrush(Colors.White);

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

        private void b_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            buton.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            for (int i = 1; i <= 5; i++)
            {
                if (buton.Name == "button" + i.ToString())
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

            foreach (Image img in canvas1.Children.OfType<Image>())
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (buton.Name == "button" + i.ToString() && img.Name == "image" + i.ToString())
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
                }
            }
        }

        private void nivele()
        {
            foreach (Image img in canvas1.Children.OfType<Image>())
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

            foreach (Button buton in canvas1.Children.OfType<Button>())
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

            foreach (Button buton in canvas1.Children.OfType<Button>())
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
                    if (i % 2 == 0)
                    {
                        img.Source = new BitmapImage(new Uri("Images/lock.png", UriKind.Relative));
                    }
                    else
                    {
                        img.Source = new BitmapImage(new Uri("Images/lock_brown.png", UriKind.Relative));
                    }
                }
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
