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
    /// Interaction logic for Teste_de_inteligenta_sectiunea_verbala.xaml
    /// </summary>
    public partial class Teste_de_inteligenta_sectiunea_verbala : Window
    {
        int parametru;
        StreamResourceInfo cursor_soft;

        public Teste_de_inteligenta_sectiunea_verbala(int nr)
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
        }

        private void b_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void b_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name == "test2" || buton.Name == "test4")
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

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta form = new Teste_de_inteligenta(parametru);
            form.Show();
            this.Hide();
        }

        private void test1_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta_sectiunea_verbala_testul_1 form = new Teste_de_inteligenta_sectiunea_verbala_testul_1(parametru);
            form.Show();
            this.Hide();
        }

        private void test2_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta_sectiunea_verbala_testul_2 form = new Teste_de_inteligenta_sectiunea_verbala_testul_2(parametru);
            form.Show();
            this.Hide();
        }

        private void test3_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta_sectiunea_verbala_testul_3 form = new Teste_de_inteligenta_sectiunea_verbala_testul_3(parametru);
            form.Show();
            this.Hide();
        }

        private void test4_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta_sectiunea_verbala_testul_4 form = new Teste_de_inteligenta_sectiunea_verbala_testul_4(parametru);
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
    }
}
