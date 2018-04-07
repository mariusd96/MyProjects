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
    /// Interaction logic for Reamintire_parola.xaml
    /// </summary>
    public partial class Reamintire_parola : Window
    {
        int ok, nr;
        public Reamintire_parola()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Close();
        }

        private void generare_intrebare_Click(object sender, RoutedEventArgs e)
        {
            ok = 0;
            for (int i = 0; i < Properties.Settings.Default.user.Count; i++)
            {
                if (String.Compare(Properties.Settings.Default.user[i], user_textBox.Text) == 0)
                {
                    intrebare_textBox.Text = Properties.Settings.Default.intrebare[i];
                    nr = i;
                    ok = 1;
                    break;
                }
            }
            if (ok == 0)
            {
                Mesaj form = new Mesaj("Utilizatorul nu există !!!");
                form.ShowDialog();
            }
        }

        private void verificare_raspuns_Click(object sender, RoutedEventArgs e)
        {
            if (ok == 0)
            {
                Mesaj form = new Mesaj("Întrebarea nu a fost generată !!!");
                form.ShowDialog();
            }
            else if (ok == 1)
            {
                if (String.Compare(Properties.Settings.Default.raspuns[nr], raspuns_textBox.Text) == 0)
                {
                    parola.Visibility = Visibility.Visible;
                    parola.Content += Properties.Settings.Default.parola[nr].ToString();
                }
                else
                {
                    Mesaj form = new Mesaj("Răspuns greşit !!!");
                    form.ShowDialog();
                }
            }
        }
    }
}
