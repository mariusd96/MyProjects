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
    /// Interaction logic for Femei_insarcinate.xaml
    /// </summary>
    public partial class Femei_insarcinate : Window
    {
        Controller c;

        public Femei_insarcinate(Controller controlor)
        {
            InitializeComponent();
            c = controlor;
            populeaza_datagrid();
            DatePicker1.Text = DateTime.Now.Date.ToString();
            populeaza_combobox();
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
            string sql = "SELECT Nume, Prenume, CNP, DATE_FORMAT(`Data examinare`,'%d.%m.%Y') AS `Data examinare`, Observatii FROM RegistruMame WHERE CNP IN (SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ")";
            dataGrid1 = c.populeaza_datagrid(sql, "RegistruMame", dataGrid1, 5);
        }

        private void cautareBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sql = "SELECT Nume, Prenume, CNP, DATE_FORMAT(`Data examinare`, '%d.%m.%Y') AS `Data examinare`, Observatii FROM RegistruMame WHERE CNP IN(SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ") AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' AND DATE_FORMAT(`Data examinare`, '%d.%m.%Y') LIKE '" + dataCalendaristica.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "RegistruMame", dataGrid1, 5);
        }

        private void dataCalendaristica_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string sql = "SELECT Nume, Prenume, CNP, DATE_FORMAT(`Data examinare`, '%d.%m.%Y') AS `Data examinare`, Observatii FROM RegistruMame WHERE CNP IN(SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ") AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' AND DATE_FORMAT(`Data examinare`, '%d.%m.%Y') LIKE '" + dataCalendaristica.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "RegistruMame", dataGrid1, 5);
        }

        private void cauta_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT Nume, Prenume, CNP, DATE_FORMAT(`Data examinare`, '%d.%m.%Y') AS `Data examinare`, Observatii FROM RegistruMame WHERE CNP IN(SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ") AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' AND DATE_FORMAT(`Data examinare`, '%d.%m.%Y') LIKE '" + dataCalendaristica.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "RegistruMame", dataGrid1, 5);
        }

        private void populeaza_combobox()
        {
            string sql = "SELECT cnp FROM Pacient WHERE sex = 'F' AND datediff(curdate(), data_nasterii)/365 >= 18 AND id_medic = " + c.id_medic;
            cnpCB = c.populeazaComboBox(sql, "cnp", cnpCB);
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string sql = "INSERT INTO Registru_femei_insarcinate(id_pacient, data_examinare, observatii) VALUES((SELECT id_pacient from pacient where cnp = '" + cnpCB.Text + "'), curdate(),'" + observatiiBox.Text + "')";
            c.insertOnDB(sql);
            populeaza_datagrid();
        }
    }
}
