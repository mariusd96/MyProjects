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
using FoodDelivery.dao;

namespace FoodDelivery.presentation
{
    /// <summary>
    /// Interaction logic for AddModifyProdus.xaml
    /// </summary>
    public partial class AddModifyProdus : Window
    {
        private string mod;
        private Produs produsOriginal;
        private ListaProduse listaProduseWindow;
        private List<Object> categorii;

        public AddModifyProdus()
        {
            InitializeComponent();
            populateComboBox();
            mod = "creare";
        }

        public AddModifyProdus(Produs p)
        {
            InitializeComponent();
            mod = "creare";

            produsOriginal = p;

            populateComboBox();

            comboBoxCategorie.SelectedValue = p.Categorie;
            numeProdusTextBox.Text = p.Nume;
            descriereTextBox.Text = p.Descriere;
            gramajTextBox.Text = p.Gramaj.ToString();
            pretTextBox.Text = p.Pret.ToString();

            label.Visibility = Visibility.Hidden;

            createCanvas.Visibility = Visibility.Hidden;
            updateCanvas.Visibility = Visibility.Visible;
        }

        private void populateComboBox()
        {
            categorii = ReflectionDAO.createListOfObjects("select * from CategoriiProdus", "CategoriiProdus");
            
            for (int i = 0; i < categorii.Count; i++)
            {
                comboBoxCategorie.Items.Add(((CategoriiProdus)categorii[i]).Categorie.ToString());
            }
        }

        public void setListaProduseWindow(ListaProduse lp)
        {
            this.listaProduseWindow = lp;
        }

        private Produs getProdus()
        {
            string categorie = comboBoxCategorie.SelectedValue.ToString();
            string nume = numeProdusTextBox.Text;
            string descriere = descriereTextBox.Text;
            int gramaj = 0;
            double pret = 0.0;

            bool ok = true;
            for (int i = 0; i < gramajTextBox.Text.Length; i++)
            {
                if (!(gramajTextBox.Text.ElementAt(i) >= '0' && gramajTextBox.Text.ElementAt(i) <= '9')) ok = false;
            }
            if(ok == true && gramajTextBox.Text.Length > 0) gramaj = Convert.ToInt32(gramajTextBox.Text);

            ok = true;
            int nrPunct = 0;
            for (int i = 0; i < pretTextBox.Text.Length; i++)
            {
                if (!(pretTextBox.Text.ElementAt(i) >= '0' && pretTextBox.Text.ElementAt(i) <= '9')) ok = false;
                if (pretTextBox.Text.ElementAt(i) == '.') nrPunct++;
            }
            if (ok == true && nrPunct <= 1 && pretTextBox.Text.Length > 0) pret = Convert.ToDouble(pretTextBox.Text);

            return new Produs(0, categorie, nume, descriere, gramaj, pret);
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

        private void btnCreareProdus_Click(object sender, RoutedEventArgs e)
        {
            Produs produsNou = getProdus();

            try
            {
                ProdusBLL produstBLL = new ProdusBLL();
                if (produstBLL.validareProdus(produsNou) == 1)
                {
                    if (ProdusDAO.getProdus(produsNou) == null)
                    {
                        ProdusBLL.insertProdus(produsNou);

                        listaProduseWindow.deseneazaForme();
                        MessageBox.Show("Produsul a fost inserat cu succes!");
                        this.Close();
                    }
                    else MessageBox.Show("Acest produs exista deja!");
                }
                else MessageBox.Show("Produs invalid!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnActualizare_Click(object sender, RoutedEventArgs e)
        {
            Produs produsModificat = getProdus();
            produsModificat.IdProdus = produsOriginal.IdProdus;

            try
            {
                ProdusBLL produstBLL = new ProdusBLL();
                if (produstBLL.validareProdus(produsModificat) == 1)
                {
                    ProdusBLL.updateProdus(produsModificat, produsOriginal);

                    listaProduseWindow.setProdus(produsModificat);
                    MessageBox.Show("Produsul a fost modificat cu succes");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStergereProdus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProdusBLL.deleteProdus(produsOriginal);

                listaProduseWindow.deseneazaForme();
                MessageBox.Show("Produsul a fost sters cu succes");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
