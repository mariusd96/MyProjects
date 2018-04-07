using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cabinet_medical
{
    /// <summary>
    /// Interaction logic for Meniu_medic.xaml
    /// </summary>
    public partial class Meniu_medic : Window
    {
        Controller c;

        public Meniu_medic(Controller controlor)
        {
            InitializeComponent();
            c = controlor;
        }

        private void pacient_Click(object sender, RoutedEventArgs e)
        {
            Pacient window = new Pacient(c);
            window.Show();
            this.Close();
        }

        private void programari_Click(object sender, RoutedEventArgs e)
        {
            Programari window = new Programari(c);
            window.Show();
            this.Close();
        }

        private void consultatii_Click(object sender, RoutedEventArgs e)
        {
            Registru_consultatii window = new Registru_consultatii(c);
            window.Show();
            this.Close();
        }

        private void bebelusi_Click(object sender, RoutedEventArgs e)
        {
            Bebelusi window = new Bebelusi(c);
            window.Show();
            this.Close();
        }

        private void femei_insarcinate_Click(object sender, RoutedEventArgs e)
        {
            Femei_insarcinate window = new Femei_insarcinate(c);
            window.Show();
            this.Close();
        }

        private void bolnavi_cronici_Click(object sender, RoutedEventArgs e)
        {
            Bolnavi_cronici window = new Bolnavi_cronici(c);
            window.Show();
            this.Close();
        }

        private void chemari_domiciliu_Click(object sender, RoutedEventArgs e)
        {
            Chemari_domiciliu window = new Chemari_domiciliu(c);
            window.Show();
            this.Close();
        }

        private void tratamente_boli_Click(object sender, RoutedEventArgs e)
        {
            Tratamente_boli window = new Tratamente_boli(c);
            window.Show();
            this.Close();
        }

        private void vaccin_Click(object sender, RoutedEventArgs e)
        {
            Vaccin window = new Vaccin(c);
            window.Show();
            this.Close();
        }

        private void documente_Click(object sender, RoutedEventArgs e)
        {
            Documente window = new Documente(c);
            window.Show();
            this.Close();
        }

        private void medicamente_Click(object sender, RoutedEventArgs e)
        {
            Medicamente window = new Medicamente(c);
            window.Show();
            this.Close();
        }

        private void obiecte_sanitare_Click(object sender, RoutedEventArgs e)
        {
            Obiecte_sanitare window = new Obiecte_sanitare(c);
            window.Show();
            this.Close();
        }

        private void aparatura_medicala_Click(object sender, RoutedEventArgs e)
        {
            Aparatura_medicala window = new Aparatura_medicala(c);
            window.Show();
            this.Close();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void maximize_Click(object sender, RoutedEventArgs e)
        {
            windowStateMax();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                windowStateMax();
            }
            else
            {
                this.DragMove();
            }
        }

        private void windowStateMax()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                maximize_img.Source = new BitmapImage(new Uri("Resources2/maximize.png", UriKind.Relative));
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                maximize_img.Source = new BitmapImage(new Uri("Resources2/restore.png", UriKind.Relative));
            }
        }
    }
}
