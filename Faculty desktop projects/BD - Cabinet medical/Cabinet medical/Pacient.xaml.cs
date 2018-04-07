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
using System.Data;
using MySql.Data.MySqlClient;

namespace Cabinet_medical
{
    /// <summary>
    /// Interaction logic for Pacient.xaml
    /// </summary>
    public partial class Pacient : Window
    {
        Controller c;

        public Pacient(Controller controlor)
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
            string sql = "SELECT Nume, Prenume, CNP, Adresa, Telefon, Sex, DATE_FORMAT(`data_nasterii`,'%d/%m/%Y') AS `Data nasterii` FROM Pacient WHERE id_medic = " + c.id_medic + " ORDER BY Nume";
            dataGrid1 = c.populeaza_datagrid(sql, "Pacient", dataGrid1, 7);
        }

        private void inserare_Click(object sender, RoutedEventArgs e)
        {
            c.inserare_pacient(nume_pacient.Text, prenume_pacient.Text, cnp_pacient.Text, adresa_pacient.Text, telefon_pacient.Text);
            if (inaltime_pacient.Text == "") inaltime_pacient.Text = "0";
            if (masa_corporala_pacient.Text == "") masa_corporala_pacient.Text = "0";
            if (grupa_sanguina_pacient.Text == "") grupa_sanguina_pacient.Text = "null";
            if (tensiune_arteriala_pacient.Text == "") tensiune_arteriala_pacient.Text = "null";
            if (glicemie_pacient.Text == "") glicemie_pacient.Text = "0";

            string sql = "INSERT INTO masuratori(id_pacient, inaltime, masa_corporala, grupa_sanguina, tensiune_cardiaca, glicemie) VALUES("+ c.idPacient() + "," + Convert.ToDouble(inaltime_pacient.Text) + "," + Convert.ToDouble(masa_corporala_pacient.Text) + "," + grupa_sanguina_pacient.Text + "," + tensiune_arteriala_pacient.Text + "," + Convert.ToInt32(glicemie_pacient.Text) + ")";
            c.insertOnDB(sql);
            nume_pacient.Text = prenume_pacient.Text = cnp_pacient.Text = adresa_pacient.Text = telefon_pacient.Text = null;
            inaltime_pacient.Text = masa_corporala_pacient.Text = grupa_sanguina_pacient.Text = tensiune_arteriala_pacient.Text = glicemie_pacient.Text = null;
            MessageBox.Show("Pacientul a fost inserat cu succes in baza de date!");
        }

        private void btn_meniu_Click(object sender, RoutedEventArgs e)
        {
            Meniu_medic window = new Meniu_medic(c);
            window.Show();
            this.Close();
        }
    }
}