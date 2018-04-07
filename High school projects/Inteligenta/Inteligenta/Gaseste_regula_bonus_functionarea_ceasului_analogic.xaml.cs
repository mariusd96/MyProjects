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
using System.Windows.Resources;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Gaseste_regula_bonus_functionarea_ceasului_analogic.xaml
    /// </summary>
    public partial class Gaseste_regula_bonus_functionarea_ceasului_analogic : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int h, m, s;
        float unghi_h = 30, unghi_m = 6, unghi_s = 6;

        StreamResourceInfo cursor_soft;
        int parametru;
        int m2 = 4, n = 4, nr;
        int ecran_x, ecran_y;
        int nr_nivel, nr_dificultate;

        public Gaseste_regula_bonus_functionarea_ceasului_analogic(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            if (System.Windows.SystemParameters.PrimaryScreenWidth > 1024)
            {
                canvas_ceas.Margin = new Thickness(canvas_ceas.Margin.Left + 100, canvas_ceas.Margin.Top, canvas_ceas.Margin.Right, canvas_ceas.Margin.Bottom);
                canvas_reguli.Margin = new Thickness(canvas_reguli.Margin.Left - 100, canvas_reguli.Margin.Top, canvas_reguli.Margin.Right, canvas_reguli.Margin.Bottom);
            }

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);

            foreach (TextBox tb in canvas_reguli2.Children.OfType<TextBox>())
            {
                tb.TextChanged += new TextChangedEventHandler(schimbare_text);
            }

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

        private void timer_Tick(object sender, EventArgs e)
        {
            h = DateTime.Now.Hour;
            m = DateTime.Now.Minute;
            s = DateTime.Now.Second;
            if (h >= 12) h = h - 12;

            secundar.RenderTransformOrigin = new Point(0.5, 0.5);
            secundar.RenderTransform = new RotateTransform(s * unghi_s);

            minutar.RenderTransformOrigin = new Point(0.5, 0.5);
            minutar.RenderTransform = new RotateTransform(m * unghi_m);

            orar.RenderTransformOrigin = new Point(0.5, 0.5);
            orar.RenderTransform = new RotateTransform(h * unghi_h + m * 0.5F);
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
            }
        }

        private void buton_nivel_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name != "bonus1")
            {
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
        }

        private void buton_nivel_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name != "bonus1")
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
                            if (m2 < nr_dificultate)
                            {
                                nr = i;
                                Gaseste_regula form = new Gaseste_regula(m2, nr, parametru);
                                form.Show();
                                this.Hide();
                                break;
                            }
                            else if (m2 == nr_dificultate)
                            {
                                if (i <= nr_nivel)
                                {
                                    nr = i;
                                    Gaseste_regula form = new Gaseste_regula(m2, nr, parametru);
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
            border_instructiuni.Visibility = border_nivel.Visibility = canvas_reguli.Visibility = canvas_ceas.Visibility = Visibility.Hidden;
            border_instructiuni.Visibility = Visibility.Visible;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            border_instructiuni.Visibility = Visibility.Hidden;
            canvas_reguli.Visibility = canvas_ceas.Visibility = Visibility.Visible;
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

        private void verificare_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "6" && textBox2.Text == "6" && textBox3.Text == "30" && textBox4.Text == "0,5")
            {
                textBox1.Visibility = textBox2.Visibility = textBox3.Visibility = textBox4.Visibility = Visibility.Hidden;
                img_corect.Source = new BitmapImage(new Uri("Images/corect.png", UriKind.Relative));
                border_corect.Visibility = Visibility.Visible;
                timer.Start();
            }
            else
            {
                img_corect.Source = new BitmapImage(new Uri("Images/gresit.png", UriKind.Relative));
                border_corect.Visibility = Visibility.Visible;
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
            border_instructiuni.Visibility = border_nivel.Visibility = canvas_reguli.Visibility = canvas_ceas.Visibility = Visibility.Hidden;
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
            canvas_reguli.Visibility = canvas_ceas.Visibility = Visibility.Visible;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Gaseste_regula_bonus_functionarea_ceasului_analogic form = new Gaseste_regula_bonus_functionarea_ceasului_analogic(parametru);
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
            m2--;
            if (m2 == 0) m2 = 4;
            if (m2 == 1) label_dificultate.Content = "Dificultate uşoară";
            if (m2 == 2) label_dificultate.Content = "Dificultate medie";
            if (m2 == 3) label_dificultate.Content = "Dificultate grea";
            if (m2 == 4) label_dificultate.Content = "Bonus";

            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                if (n != m2)
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
            m2++;
            if (m2 == 5) m2 = 1;
            if (m2 == 1) label_dificultate.Content = "Dificultate uşoară";
            if (m2 == 2) label_dificultate.Content = "Dificultate medie";
            if (m2 == 3) label_dificultate.Content = "Dificultate grea";
            if (m2 == 4) label_dificultate.Content = "Bonus";

            foreach (Button buton_nivel in canvas_nivel.Children.OfType<Button>())
            {
                if (n != m2)
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
                if (c.Name == "button2" + m2)
                {
                    c.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
                    c.Foreground = c.BorderBrush = Brushes.White;
                }
            }
        }

        private void butoane()
        {
            if (m2 == 4)
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
                        if (m2 < nr_dificultate)
                        {
                            for (int i = 1; i <= 16; i++) img.Visibility = Visibility.Hidden;
                        }
                        else if (m2 == nr_dificultate)
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
                        else if (m2 > nr_dificultate)
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
                    if (m2 < nr_dificultate)
                    {
                        for (int i = 1; i <= 16; i++)
                        {
                            buton.Style = this.Resources["btnGlass3"] as Style;
                        }
                    }
                    else if (m2 == nr_dificultate)
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
                    else if (m2 > nr_dificultate)
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
