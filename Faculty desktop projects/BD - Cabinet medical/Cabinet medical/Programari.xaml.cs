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
    /// Interaction logic for Programari.xaml
    /// </summary>
    public partial class Programari : Window
    {
        Controller c;

        public Programari(Controller controlor)
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

        private void btn_meniu_Click(object sender, RoutedEventArgs e)
        {
            Meniu_medic window = new Meniu_medic(c);
            window.Show();
            this.Close();
        }

        private void populeaza_datagrid()
        {
            string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, programari.data_programarii AS `Data programare` FROM Pacient JOIN Programari WHERE Pacient.id_pacient = Programari.id_pacient AND Programari.id_medic = " + c.id_medic + " HAVING yearweek(curdate())=yearweek(programari.data_programarii) ORDER BY `Data programare`";
            dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Programari", dataGrid1, 4);
        }

        private void cautareBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (numeBox.Text == "" && cnpBox.Text == "") populeaza_datagrid();
            else
            {
                string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, programari.data_programarii AS `Data programare` FROM Pacient JOIN Programari WHERE Pacient.id_pacient = Programari.id_pacient AND Programari.id_medic = " + c.id_medic + " AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' HAVING yearweek(curdate())=yearweek(programari.data_programarii) ORDER BY `Data programare`";
                dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Programari", dataGrid1, 4);
            }
        }

        private void cauta_Click(object sender, RoutedEventArgs e)
        {
            if (numeBox.Text == "" && cnpBox.Text == "") populeaza_datagrid();
            else
            {
                string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, programari.data_programarii AS `Data programare` FROM Pacient JOIN Programari WHERE Pacient.id_pacient = Programari.id_pacient AND Programari.id_medic = " + c.id_medic + " AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' HAVING yearweek(curdate())=yearweek(programari.data_programarii) ORDER BY `Data programare`";
                dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Pacient", dataGrid1, 4);
            }
        }
    }
}
