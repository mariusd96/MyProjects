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
    /// Interaction logic for Obiecte_sanitare.xaml
    /// </summary>
    public partial class Obiecte_sanitare : Window
    {
        Controller c;

        public Obiecte_sanitare(Controller controlor)
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
            string sql = "SELECT id_obiect AS `Id`, nume_obiect AS `Nume obiect`, inventar AS `Inventar` FROM obiecte_igienico_sanitare";
            dataGrid1 = c.populeaza_datagrid(sql, "obiecte_igienico_sanitare", dataGrid1, 3);
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
            string sql = "SELECT id_obiect AS `Id`, nume_obiect AS `Nume obiect`, inventar AS `Inventar` FROM obiecte_igienico_sanitare WHERE nume_obiect LIKE '" + cautareBox.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "obiecte_igienico_sanitare", dataGrid1, 3);
        }

        private void cautareBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sql = "SELECT id_obiect AS `Id`, nume_obiect AS `Nume obiect`, inventar AS `Inventar` FROM obiecte_igienico_sanitare WHERE nume_obiect LIKE '" + cautareBox.Text + "%'";
            dataGrid1 = c.populeaza_datagrid(sql, "obiecte_igienico_sanitare", dataGrid1, 3);
        }
    }
}
