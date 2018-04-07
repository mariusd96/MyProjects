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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ok;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            verificare_date();
        }

        private void verificare_date()
        {
            //Properties.Settings.Default.Reset();
            //Properties.Settings.Default.Save();
            for (int i = 0; i < Properties.Settings.Default.user.Count; i++)
            {
                if (String.Compare(Properties.Settings.Default.user[i], textBox1.Text) == 0)
                {
                    if (String.Compare(Properties.Settings.Default.parola[i], passwordBox1.Password) == 0)
                    {
                        ok = 1;
                        Properties.Settings.Default.nr_user = i;
                        Properties.Settings.Default.Save();
                        break;
                    }
                    else ok = 0;
                }
            }
            if (ok == 0)
            {
                Mesaj form = new Mesaj("Utilizatorul nu există sau parolă greşită.");
                form.ShowDialog();
            }
            else
            {
                Meniu form = new Meniu();
                form.Show();
                this.Hide();
            }
        }

        private void inregistrare_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Inregistrare form = new Inregistrare();
            form.Show();
            this.Hide();
        }

        private void reamintire_parola_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Reamintire_parola form = new Reamintire_parola();
            form.Show();
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                verificare_date();
            }
        }

        private void passwordBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                verificare_date();
            }
        }
    }
}
