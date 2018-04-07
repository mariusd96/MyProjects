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
    /// Interaction logic for Teste_de_inteligenta_test_einstein.xaml
    /// </summary>
    public partial class Teste_de_inteligenta_test_einstein : Window
    {
        int parametru, ok, corect;
        string[] numar_casa = new string[6];
        string[] culoare_casa = new string[6];
        string[] tip_bautura = new string[6];
        string[] marca_tigari = new string[6];
        string[] animal_casa = new string[6];

        public Teste_de_inteligenta_test_einstein(int nr)
        {
            InitializeComponent();
            parametru = nr;

            foreach(ComboBox cb in tabel.Children.OfType<ComboBox>())
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (cb.Name == "casa" + i.ToString()) numar_casa[i] = cb.SelectedIndex.ToString();
                    if (cb.Name == "culoare" + i.ToString()) culoare_casa[i] = cb.SelectedIndex.ToString();
                    if (cb.Name == "bautura" + i.ToString()) tip_bautura[i] = cb.SelectedIndex.ToString();
                    if (cb.Name == "tigari" + i.ToString()) marca_tigari[i] = cb.SelectedIndex.ToString();
                    if (cb.Name == "animal" + i.ToString()) animal_casa[i] = cb.SelectedIndex.ToString();
                }

                cb.SelectionChanged += new SelectionChangedEventHandler(cb_SelectionChanged);
                cb.SelectedItem = null;
            }
        }

        private void cb_SelectionChanged(object sender, EventArgs e)
        {
            if (corect == 0)
            {
                verificare.Visibility = Visibility.Visible;
                border_verificare.Visibility = Visibility.Hidden;
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Teste_de_inteligenta_alte_teste form = new Teste_de_inteligenta_alte_teste(parametru);
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

        private void verificare_Click(object sender, RoutedEventArgs e)
        {
            ok = 1;
            foreach (ComboBox cb in tabel.Children.OfType<ComboBox>())
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (cb.Name == "casa" + i.ToString())
                    {
                        if (numar_casa[i] != cb.SelectedIndex.ToString())
                        {
                            ok = 0;
                            break;
                        }
                    }
                    if (cb.Name == "culoare" + i.ToString())
                    {
                        if (culoare_casa[i] != cb.SelectedIndex.ToString())
                        {
                            ok = 0;
                            break;
                        }
                    }
                    if (cb.Name == "bautura" + i.ToString()) 
                    {
                        if (tip_bautura[i] != cb.SelectedIndex.ToString())
                        {
                            ok = 0;
                            break;
                        }
                    }
                    if (cb.Name == "tigari" + i.ToString())
                    {
                        if (marca_tigari[i] != cb.SelectedIndex.ToString())
                        {
                            ok = 0;
                            break;
                        }
                    }
                    if (cb.Name == "animal" + i.ToString()) 
                    {
                        if (animal_casa[i] != cb.SelectedIndex.ToString())
                        {
                            ok = 0;
                            break;
                        }
                    }
                }
            }

            if (ok == 1)
            {
                corect = 1;
                verificare.Visibility = Visibility.Hidden;
                img_corect.Source = new BitmapImage(new Uri("Images/corect.png", UriKind.Relative));
                border_verificare.Visibility = Visibility.Visible;
            }
            else if (ok == 0)
            {
                verificare.Visibility = Visibility.Hidden;
                img_corect.Source = new BitmapImage(new Uri("Images/gresit.png", UriKind.Relative));
                border_verificare.Visibility = Visibility.Visible;
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
    }
}
