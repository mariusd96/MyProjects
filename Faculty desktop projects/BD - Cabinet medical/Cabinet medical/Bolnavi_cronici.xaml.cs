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
    /// Interaction logic for Bolnavi_cronici.xaml
    /// </summary>
    public partial class Bolnavi_cronici : Window
    {
        Controller c;
        public Bolnavi_cronici(Controller controlor)
        {
            InitializeComponent();
            c = controlor;
            DatePicker1.Text = DateTime.Now.Date.ToString();
            populeaza_datagrid();
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
            this.Hide();
        }

        private void populeaza_datagrid()
        {
            string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, registru_bolnavi_cronici.boala AS Boala, DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') AS `Data examinare`, registru_bolnavi_cronici.observatii AS Observatii FROM Pacient JOIN registru_bolnavi_cronici WHERE Pacient.id_pacient = registru_bolnavi_cronici.id_pacient AND Pacient.id_medic = " + c.id_medic;
            dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Registru_bolnavi_cronici", dataGrid1, 6);
        }

        private void cautareBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, registru_bolnavi_cronici.boala AS Boala, DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') AS `Data examinare`, registru_bolnavi_cronici.observatii AS Observatii FROM Pacient JOIN registru_bolnavi_cronici WHERE Pacient.id_pacient = registru_bolnavi_cronici.id_pacient AND Pacient.id_medic =" + c.id_medic + " AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' AND Boala LIKE '" + boalaBox.Text + "%' AND DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') LIKE '" + dataCalendaristica.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Registru_bolnavi_cronici", dataGrid1, 6);
        }

        private void dataCalendaristica_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, registru_bolnavi_cronici.boala AS Boala, DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') AS `Data examinare`, registru_bolnavi_cronici.observatii AS Observatii FROM Pacient JOIN registru_bolnavi_cronici WHERE Pacient.id_pacient = registru_bolnavi_cronici.id_pacient AND Pacient.id_medic =" + c.id_medic + " AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' AND Boala LIKE '" + boalaBox.Text + "%' AND DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') LIKE '" + dataCalendaristica.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Registru_bolnavi_cronici", dataGrid1, 6);
        }

        private void cauta_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT Pacient.nume AS Nume, pacient.prenume AS Prenume, pacient.cnp AS CNP, registru_bolnavi_cronici.boala AS Boala, DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') AS `Data examinare`, registru_bolnavi_cronici.observatii AS Observatii FROM Pacient JOIN registru_bolnavi_cronici WHERE Pacient.id_pacient = registru_bolnavi_cronici.id_pacient AND Pacient.id_medic =" + c.id_medic + " AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%' AND Boala LIKE '" + boalaBox.Text + "%' AND DATE_FORMAT(registru_bolnavi_cronici.data_examinare, '%d.%m.%Y') LIKE '" + dataCalendaristica.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Registru_bolnavi_cronici", dataGrid1, 6);
        }

        private void populeaza_combobox()
        {
            string sql = "SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic;
            cnpCB = c.populeazaComboBox(sql, "cnp", cnpCB);
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string sql = "INSERT INTO registru_bolnavi_cronici(id_pacient, boala, data_examinare, observatii) VALUES((SELECT id_pacient from pacient where cnp = '" + cnpCB.Text + "'),'" + boliBox.Text+ "',curdate(),'"+ observatiiBox.Text + "')";
            c.insertOnDB(sql);
            populeaza_datagrid();
        }
    }
}
