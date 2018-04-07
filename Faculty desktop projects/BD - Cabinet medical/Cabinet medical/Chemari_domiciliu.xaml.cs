﻿using System;
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
    /// Interaction logic for Chemari_domiciliu.xaml
    /// </summary>
    public partial class Chemari_domiciliu : Window
    {
        Controller c;

        public Chemari_domiciliu(Controller controlor)
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
            string sql = "SELECT Pacient.nume AS Nume, Pacient.prenume AS Prenume, Pacient.cnp AS CNP, DATE_FORMAT(Registru_chemari_domiciliu.data_chemare, '%d.%m.%Y') AS `Data consult`, registru_chemari_domiciliu.scop AS Scop FROM Pacient JOIN registru_chemari_domiciliu WHERE Pacient.id_pacient = registru_chemari_domiciliu.id_pacient HAVING CNP IN(SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ") AND yearweek(STR_TO_DATE(`Data consult`, '%d.%m.%Y')) = yearweek(curdate())";
            dataGrid1 = c.populeaza_datagrid(sql, "Registru_chemari_domiciliu", dataGrid1, 5);
        }

        private void cautareBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (numeBox.Text == "" && cnpBox.Text == "") populeaza_datagrid();
            else
            {
                string sql = "SELECT Pacient.nume AS Nume, Pacient.prenume AS Prenume, Pacient.cnp AS CNP, DATE_FORMAT(Registru_chemari_domiciliu.data_chemare, '%d.%m.%Y') AS `Data consult`, registru_chemari_domiciliu.scop AS Scop FROM Pacient JOIN registru_chemari_domiciliu WHERE Pacient.id_pacient = registru_chemari_domiciliu.id_pacient HAVING CNP IN(SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ") AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%'";
                dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Registru_chemari_domiciliu", dataGrid1, 5);
            }
        }

        private void cauta_Click(object sender, RoutedEventArgs e)
        {
            if (numeBox.Text == "" && cnpBox.Text == "") populeaza_datagrid();
            else
            {
                string sql = "SELECT Pacient.nume AS Nume, Pacient.prenume AS Prenume, Pacient.cnp AS CNP, DATE_FORMAT(Registru_chemari_domiciliu.data_chemare, '%d.%m.%Y') AS `Data consult`, registru_chemari_domiciliu.scop AS Scop FROM Pacient JOIN registru_chemari_domiciliu WHERE Pacient.id_pacient = registru_chemari_domiciliu.id_pacient HAVING CNP IN(SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic + ") AND Nume LIKE '" + numeBox.Text + "%' AND CNP LIKE '" + cnpBox.Text + "%'";
                dataGrid1 = c.populeaza_datagrid(sql, "Pacient JOIN Registru_chemari_domiciliu", dataGrid1, 5);
            }
        }

        private void populeaza_combobox()
        {
            string sql = "SELECT cnp FROM Pacient WHERE id_medic = " + c.id_medic;
            cnpCB = c.populeazaComboBox(sql, "cnp", cnpCB);
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string sql = "INSERT INTO Registru_chemari_domiciliu(id_pacient, data_chemare, scop) VALUES((SELECT id_pacient from pacient where cnp = '" + cnpCB.Text + "'), STR_TO_DATE('" + DatePicker1.Text + "','%d.%m.%Y'),'" + scopBox.Text + "')";
            //MessageBox.Show(sql);
            c.insertOnDB(sql);
            populeaza_datagrid();
        }
    }
}