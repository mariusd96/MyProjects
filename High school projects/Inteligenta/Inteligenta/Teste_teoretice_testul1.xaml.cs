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
using System.Windows.Threading;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Teste_teoretice_testul1.xaml
    /// </summary>
    public partial class Teste_teoretice_testul1 : Window
    {
        int parametru, s, nota = 1;
        int[] raspunsuri = new int[10];
        StreamResourceInfo cursor_soft;
        DispatcherTimer timer = new DispatcherTimer();

        public Teste_teoretice_testul1(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick+=new EventHandler(timer_Tick);
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Teste_teoretice form = new Teste_teoretice(parametru);
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

        private void rezultat_Click(object sender, RoutedEventArgs e)
        {
            s++;
            if (corect1.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect2.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect3.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect4.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect5.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect6.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect7.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect8.IsChecked == true) raspunsuri[s] = 1;
            s++;
            if (corect9.IsChecked == true) raspunsuri[s] = 1;

            for (int i = 1; i <= 9; i++) nota += raspunsuri[i];

            border1.Visibility = Visibility.Hidden;
            label10.Content += nota.ToString();
            s = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            s++;
            if (s <= 9)
            {
                foreach (Label lb in canvas1.Children.OfType<Label>())
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (lb.Name == "label" + s.ToString()) lb.Visibility = Visibility.Visible;
                    }
                }

                foreach (Image img in canvas1.Children.OfType<Image>())
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (img.Name == "image" + s.ToString())
                        {
                            img.Visibility = Visibility.Visible;
                            if (raspunsuri[s] == 1) img.Source = new BitmapImage(new Uri("Images/corect2.png", UriKind.Relative));
                            else img.Source = new BitmapImage(new Uri("Images/gresit2.png", UriKind.Relative));
                        }
                    }
                }
            }
            else if (s == 10) line1.Visibility = Visibility.Visible;
            else if (s == 11)
            {
                label10.Visibility = Visibility.Visible;
                refa_test.Visibility = Visibility.Visible;
                timer.Stop();
            }
        }

        private void refa_test_Click(object sender, RoutedEventArgs e)
        {
            Teste_teoretice_testul1 form = new Teste_teoretice_testul1(parametru);
            form.Show();
            this.Hide();
        }

        private void refa_test_MouseEnter(object sender, MouseEventArgs e)
        {
            refa_test.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            refa_test.Foreground = refa_test.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void refa_test_MouseLeave(object sender, MouseEventArgs e)
        {
            refa_test.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            refa_test.Foreground = refa_test.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
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

        private void rezultat_MouseEnter(object sender, MouseEventArgs e)
        {
            rezultat.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            rezultat.Foreground = new SolidColorBrush(Colors.White);
        }

        private void rezultat_MouseLeave(object sender, MouseEventArgs e)
        {
            rezultat.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            rezultat.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }
    }
}
