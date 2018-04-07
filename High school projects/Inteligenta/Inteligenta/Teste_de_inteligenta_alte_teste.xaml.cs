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

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Teste_de_inteligenta_alte_teste.xaml
    /// </summary>
    public partial class Teste_de_inteligenta_alte_teste : Window
    {
        int parametru;
        public Teste_de_inteligenta_alte_teste(int nr)
        {
            InitializeComponent();
            parametru = nr;
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta form = new Teste_de_inteligenta(parametru);
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

        private void test_einstein_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta_test_einstein form = new Teste_de_inteligenta_test_einstein(parametru);
            form.Show();
            this.Hide();
        }

        private void test_einstein_MouseEnter(object sender, MouseEventArgs e)
        {
            test_einstein.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            test_einstein.Foreground = new SolidColorBrush(Colors.White);
        }

        private void test_einstein_MouseLeave(object sender, MouseEventArgs e)
        {
            test_einstein.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            test_einstein.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }
    }
}
