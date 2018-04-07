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
using System.Windows.Media.Effects;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Inregistrare.xaml
    /// </summary>
    public partial class Inregistrare : Window
    {
        string cursor_selectat, user1, parola1, intrebare1, raspuns1;
        int ok;
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
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

        private void creeaza_cont_Click(object sender, RoutedEventArgs e)
        {
            ok = 1;
            if (user_textbox.Text != null && parola_textbox.Password != null && confirmare_parola_textbox.Password != null && intrebare_textbox.Text != null && raspuns_textbox.Text != null && cursor_selectat != null)
            {
                for (int i = 0; i < Properties.Settings.Default.user.Count; i++)
                {
                    if (string.Compare(Properties.Settings.Default.user[i], user_textbox.Text) == 0)
                    {
                        ok = 0;
                        break;
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

                        Properties.Settings.Default.user.Add(user1.ToString());
                        Properties.Settings.Default.parola.Add(parola1.ToString());
                        Properties.Settings.Default.intrebare.Add(intrebare1.ToString());
                        Properties.Settings.Default.raspuns.Add(raspuns1.ToString());
                        Properties.Settings.Default.cursor.Add(cursor_selectat.ToString());
                        Properties.Settings.Default.forma.Add("10");
                        Properties.Settings.Default.grosime_bordura.Add("2");
                        Properties.Settings.Default.culoare_butoane.Add("255,255,211");
                        Properties.Settings.Default.culoare_bordura.Add("120,32,15");
                        Properties.Settings.Default.nivel_puzzle_img.Add("1");
                        Properties.Settings.Default.nivel_puzzle_nr.Add("1");
                        Properties.Settings.Default.nivel_puzzle_regine.Add("1");
                        Properties.Settings.Default.nivel_luminile_orasului.Add("1");
                        Properties.Settings.Default.dificultate_gaseste_regula.Add("1");
                        Properties.Settings.Default.nivel_gaseste_regula.Add("1");

                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Upgrade();
                        Properties.Settings.Default.Save();

                        MainWindow form = new MainWindow();
                        form.Show();
                        this.Hide();
                        Mesaj msg = new Mesaj("Contul a fost creat cu succes !!!");
                        msg.Show();
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
    }
}
