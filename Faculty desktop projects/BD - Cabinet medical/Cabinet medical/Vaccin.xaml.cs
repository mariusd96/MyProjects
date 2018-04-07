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
    /// Interaction logic for Vaccin.xaml
    /// </summary>
    public partial class Vaccin : Window
    {
        Controller c;

        public Vaccin(Controller controlor)
        {
            InitializeComponent();
            c = controlor;
            populeaza_datagrid();
        }

        private void close_Click(object sender, RoutedEventArgs e)
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

        private void populeaza_datagrid()
        {
            string sql = "SELECT id_vaccin AS `Id`, nume_vaccin AS `Nume vaccin`, inventar AS `Inventar` FROM Vaccin";
            dataGrid1 = c.populeaza_datagrid(sql, "Vaccin", dataGrid1, 3);
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            c.updateDataGrid();
        }

        private void btn_meniu_Click(object sender, RoutedEventArgs e)
        {
            Meniu_medic window = new Meniu_medic(c);
            window.Show();
            this.Close();
        }

        private void cauta_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT id_vaccin AS `Id`, nume_vaccin AS `Nume vaccin`, inventar AS `Inventar` FROM Vaccin WHERE nume_vaccin LIKE '%" + cautareBox.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "Vaccin", dataGrid1, 3);
        }

        private void cautareBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sql = "SELECT id_vaccin AS `Id`, nume_vaccin AS `Nume vaccin`, inventar AS `Inventar` FROM Vaccin WHERE nume_vaccin LIKE '%" + cautareBox.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "Vaccin", dataGrid1, 3);
        }
    }
}
