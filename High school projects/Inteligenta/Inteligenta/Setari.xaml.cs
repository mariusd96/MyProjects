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
    /// Interaction logic for Setari.xaml
    /// </summary>
    public partial class Setari : Window
    {
        int parametru, ok;
        StreamResourceInfo cursor_soft;
        string cursor_selectat, user1, parola1, intrebare1, raspuns1;

        public Setari(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0)
            {
                cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
                radioButton1.IsChecked = true;
                cursor_selectat = "1";
            }
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0)
            {
                cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
                radioButton2.IsChecked = true;
                cursor_selectat = "2";
            }
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            user_textbox.Text = Properties.Settings.Default.user[Properties.Settings.Default.nr_user].ToString();
            parola_textbox.Password = Properties.Settings.Default.parola[Properties.Settings.Default.nr_user].ToString();
            confirmare_parola_textbox.Password = Properties.Settings.Default.parola[Properties.Settings.Default.nr_user].ToString();
            intrebare_textbox.Text = Properties.Settings.Default.intrebare[Properties.Settings.Default.nr_user].ToString();
            raspuns_textbox.Text = Properties.Settings.Default.raspuns[Properties.Settings.Default.nr_user];
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            if (parametru == 0)
            {
                Optiuni form = new Optiuni();
                form.Show();
            }
            else if (parametru == 1)
            {
                Meniu form = new Meniu();
                form.Show();
            }
            this.Hide();
        }

        private void cursor1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            cursor_selectat = "1";
        }

        private void cursor2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            cursor_selectat = "2";
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            cursor_selectat = "1";
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            cursor_selectat = "2";
        }

        private void salveaza_Click(object sender, RoutedEventArgs e)
        {
            ok = 1;
            if (user_textbox.Text != null && parola_textbox.Password != null && confirmare_parola_textbox.Password != null && intrebare_textbox.Text != null && raspuns_textbox.Text != null && cursor_selectat != null)
            {
                for (int i = 0; i < Properties.Settings.Default.user.Count; i++)
                {
                    if (i != Properties.Settings.Default.nr_user)
                    {
                        if (string.Compare(Properties.Settings.Default.user[i], user_textbox.Text) == 0)
                        {
                            ok = 0;
                            break;
                        }
                    }
                }
                if (ok == 1)
                {
                    if (string.Compare(parola_textbox.Password, confirmare_parola_textbox.Password) == 0)
                    {
                        user1 = user_textbox.Text.ToString();
                        parola1 = parola_textbox.Password.ToString();
                        intrebare1 = intrebare_textbox.Text.ToString();
                        raspuns1 = raspuns_textbox.Text.ToString();

                        Properties.Settings.Default.user[Properties.Settings.Default.nr_user] = user_textbox.Text.ToString();
                        Properties.Settings.Default.parola[Properties.Settings.Default.nr_user] = parola_textbox.Password.ToString();
                        Properties.Settings.Default.intrebare[Properties.Settings.Default.nr_user] = intrebare_textbox.Text.ToString();
                        Properties.Settings.Default.raspuns[Properties.Settings.Default.nr_user] = raspuns_textbox.Text.ToString();
                        Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user] = cursor_selectat.ToString();

                        Properties.Settings.Default.Save();

                        Setari form = new Setari(parametru);
                        form.Show();
                        this.Hide();
                        Mesaj msg = new Mesaj("Modificările au fost salvate cu succes !!!");
                        msg.ShowDialog();
                    }
                    else
                    {
                        Mesaj msg = new Mesaj("Confirmarea parolei greşită !");
                        msg.Show();
                    }
                }
                else
                {
                    Mesaj form = new Mesaj("Acest utilizator există deja !");
                    form.Show();
                }
            }
            else
            {
                Mesaj form = new Mesaj("Nu aţi completat toate câmpurile !!!");
                form.Show();
            }
        }

        private void sterge_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.user.Remove(Properties.Settings.Default.user[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.parola.Remove(Properties.Settings.Default.parola[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.intrebare.Remove(Properties.Settings.Default.intrebare[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.raspuns.Remove(Properties.Settings.Default.raspuns[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.cursor.Remove(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.forma.Remove(Properties.Settings.Default.forma[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.grosime_bordura.Remove(Properties.Settings.Default.grosime_bordura[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.culoare_butoane.Remove(Properties.Settings.Default.culoare_butoane[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.culoare_bordura.Remove(Properties.Settings.Default.culoare_bordura[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.nivel_puzzle_img.Remove(Properties.Settings.Default.nivel_puzzle_img[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.nivel_puzzle_nr.Remove(Properties.Settings.Default.nivel_puzzle_nr[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.nivel_puzzle_regine.Remove(Properties.Settings.Default.nivel_puzzle_regine[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.nivel_luminile_orasului.Remove(Properties.Settings.Default.nivel_luminile_orasului[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.dificultate_gaseste_regula.Remove(Properties.Settings.Default.dificultate_gaseste_regula[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.nivel_gaseste_regula.Remove(Properties.Settings.Default.nivel_gaseste_regula[Properties.Settings.Default.nr_user].ToString());
            Properties.Settings.Default.Save();

            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
            Mesaj msg = new Mesaj("Contul a fost şters cu succes !!!");
            msg.ShowDialog();
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
            Optiuni form = new Optiuni();
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

        private void salveaza_MouseEnter(object sender, MouseEventArgs e)
        {
            salveaza.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            salveaza.Foreground = new SolidColorBrush(Colors.White);
        }

        private void salveaza_MouseLeave(object sender, MouseEventArgs e)
        {
            salveaza.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            salveaza.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void sterge_MouseEnter(object sender, MouseEventArgs e)
        {
            sterge.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            sterge.Foreground = new SolidColorBrush(Colors.White);
        }

        private void sterge_MouseLeave(object sender, MouseEventArgs e)
        {
            sterge.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            sterge.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }
    }
}
