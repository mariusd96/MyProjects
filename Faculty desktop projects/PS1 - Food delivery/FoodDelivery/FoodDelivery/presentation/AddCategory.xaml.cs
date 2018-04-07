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

using FoodDelivery.models;
using FoodDelivery.bll;

namespace FoodDelivery.presentation
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private ListaProduse listaProduseWindow;

        public AddCategory()
        {
            InitializeComponent();
        }

        public void setListaProduseWindow(ListaProduse lp)
        {
            this.listaProduseWindow = lp;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnCreareCont_Click(object sender, RoutedEventArgs e)
        {
            CategoriiProdus cp = new CategoriiProdus(categorieTextBox.Text);

            try
            {
                if (CategoriiProdusBLL.findCategorie(cp) == null)
                {
                    if (cp.Categorie.ToString().Length > 0)
                    {
                        CategoriiProdusBLL.insertCategorie(cp);

                        listaProduseWindow.populateComboBox();
                        MessageBox.Show("Categoria a fost introdusa cu succes!");
                        this.Close();
                    }
                    else MessageBox.Show("Camp vid!");
                }
                else MessageBox.Show("Aceasta categorie exista deja!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
