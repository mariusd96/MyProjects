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
    /// Interaction logic for MeniuClient.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        Cont cont;
        Client client;

        private List<Object> categorii;
        private List<Object> produse;

        private List<Produs> produseCos = new List<Produs>();
        private List<int> cantitateProdusCos = new List<int>();
        private double pretTotal = 0.0;
        //private AddModifyCont modificareCont;

        private Canvas[] canvas;
        private Label[] categorie;
        private Label[] dateProdus;
        private TextBox[] descriere;
        private Label[] detaliu;
        private TextBox[] cantitateProdus;
        private Button[] btnProdus;

        private RadioButton cash = new RadioButton();
        private RadioButton card = new RadioButton();

        private string categorieProdusValue = "Toate";
        private int nrProduse, index = 0;

        private AddModifyCont contWindow;
        private VizualizareIstoric istoricWindow;

        public ClientWindow(Cont c, Client cl)
        {
            InitializeComponent();
            cont = c;
            client = cl;

            populateComboBox();
            deseneazaForme();
        }

        public void deseneazaForme()
        {
            stackPanel.Children.Clear();

            categorii = ReflectionDAO.createListOfObjects("select * from CategoriiProdus", "CategoriiProdus");

            if (categorieProdusValue == "Toate") produse = ReflectionDAO.createListOfObjects("select * from Produs", "Produs");
            else produse = ReflectionDAO.createListOfObjects("select * from Produs where categorie = '" + categorieProdusValue + "'", "Produs");

            nrProduse = produse.Count();

            canvas = new Canvas[nrProduse];
            categorie = new Label[nrProduse];
            dateProdus = new Label[nrProduse];
            descriere = new TextBox[nrProduse];
            detaliu = new Label[nrProduse];
            cantitateProdus = new TextBox[nrProduse];
            btnProdus = new Button[nrProduse];

            index = 0;

            int height = 15;

            for (int i = 0; i < nrProduse; i++)
            {
                if (categorieProdusValue == "Toate" || ((Produs)produse[i]).Categorie == categorieProdusValue)
                {
                    canvas[i] = new Canvas();
                    stackPanel.Children.Add(canvas[i]);
                    canvas[i].Width = 650;
                    canvas[i].Height = 100;
                    canvas[i].Margin = new Thickness(0, height, 0, 0);
                    //height += 100 + 15;
                    canvas[i].Background = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                    canvas[i].Visibility = Visibility.Visible;
                    canvas[i].HorizontalAlignment = HorizontalAlignment.Left;
                    canvas[i].VerticalAlignment = VerticalAlignment.Top;

                    //label categorie
                    categorie[i] = new Label();
                    canvas[i].Children.Add(categorie[i]);
                    categorie[i].Width = 90;
                    categorie[i].Margin = new Thickness(5, 37, 0, 0);
                    categorie[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    categorie[i].FontFamily = new FontFamily("Times New Roman");
                    categorie[i].FontSize = 14;
                    categorie[i].Content = ((Produs)produse[i]).Categorie.ToString();
                    categorie[i].HorizontalContentAlignment = HorizontalAlignment.Center;

                    //bara verticala
                    Border b = new Border();
                    canvas[i].Children.Add(b);
                    b.Height = 80;
                    b.Width = 3;
                    b.BorderThickness = new Thickness(2);
                    b.BorderBrush = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    b.Margin = new Thickness(100, 10, 0, 0);

                    //date produs
                    dateProdus[i] = new Label();
                    canvas[i].Children.Add(dateProdus[i]);
                    dateProdus[i].Margin = new Thickness(120, 10, 0, 0);
                    dateProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    dateProdus[i].FontFamily = new FontFamily("Times New Roman");
                    dateProdus[i].FontSize = 14;
                    dateProdus[i].Content = ((Produs)produse[i]).Nume.ToString();
                    dateProdus[i].FontWeight = FontWeights.Bold;

                    //descriere produs
                    descriere[i] = new TextBox();
                    canvas[i].Children.Add(descriere[i]);
                    descriere[i].Margin = new Thickness(120, 35, 0, 0);
                    descriere[i].Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                    descriere[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    descriere[i].BorderThickness = new Thickness(0);
                    descriere[i].Width = 290;
                    descriere[i].Height = 55;
                    descriere[i].Text = "(" + ((Produs)produse[i]).Descriere.ToString() + ")";
                    descriere[i].HorizontalAlignment = HorizontalAlignment.Stretch;
                    descriere[i].VerticalAlignment = VerticalAlignment.Stretch;
                    descriere[i].TextWrapping = TextWrapping.Wrap;

                    //detaliu
                    detaliu[i] = new Label();
                    canvas[i].Children.Add(detaliu[i]);
                    detaliu[i].Width = 125;
                    detaliu[i].Margin = new Thickness(440, 28, 0, 0);
                    detaliu[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    detaliu[i].FontFamily = new FontFamily("Times New Roman");
                    detaliu[i].FontSize = 14;
                    detaliu[i].Content = ((Produs)produse[i]).Gramaj.ToString() + " grame \n" + ((Produs)produse[i]).Pret.ToString() + " lei";
                    //btnCumparaturi[i].Click += istoricCumparaturi_Click;

                    //caseta cantitate
                    Border b2 = new Border();
                    canvas[i].Children.Add(b2);
                    b2.Width = 60;
                    b2.Height = 30;
                    b2.BorderThickness = new Thickness(2);
                    b2.CornerRadius = new CornerRadius(15);
                    b2.BorderBrush = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    b2.Margin = new Thickness(560, 15, 0, 0);
                    b2.ToolTip = "Cantitate produs";
                    cantitateProdus[i] = new TextBox();
                    b2.Child = cantitateProdus[i];
                    cantitateProdus[i].Margin = new Thickness(10, 0, 10, 0);
                    cantitateProdus[i].Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                    cantitateProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    cantitateProdus[i].BorderThickness = new Thickness(0);
                    cantitateProdus[i].FontFamily = new FontFamily("Times New Roman");
                    cantitateProdus[i].FontSize = 14;
                    cantitateProdus[i].ToolTip = "Cantitate produs";
                    cantitateProdus[i].HorizontalContentAlignment = HorizontalAlignment.Center;
                    cantitateProdus[i].VerticalContentAlignment = VerticalAlignment.Center;

                    btnProdus[i] = new Button();
                    canvas[i].Children.Add(btnProdus[i]);
                    btnProdus[i].Width = 60;
                    btnProdus[i].Height = 30;
                    btnProdus[i].Style = this.Resources["btnGlass"] as Style;
                    //btnProdus[i].BorderThickness = new Thickness(4);
                    btnProdus[i].BorderBrush = btnProdus[i].Background = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    btnProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(255, 229, 195));
                    btnProdus[i].Name = "btnProdus" + i.ToString();
                    btnProdus[i].Content = "Add";
                    btnProdus[i].FontStyle = FontStyles.Italic;
                    btnProdus[i].Margin = new Thickness(560, 55, 0, 0);
                    btnProdus[i].Cursor = Cursors.Hand;
                    btnProdus[i].ToolTip = "Adaugă în coș";
                    btnProdus[i].Click += addToCart_Click;
                }
            }
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            index = 0;

            for (int i = 0; i < produse.Count && index == 0; i++)
            {
                if (b.Name == "btnProdus" + i.ToString()) index = i;
            }

            bool ok = true;

            for (int i = 0; i < cantitateProdus[index].Text.Length; i++)
            {
                if (!(cantitateProdus[index].Text.ElementAt(i) >= '0' && cantitateProdus[index].Text.ElementAt(i) <= '9')) ok = false;
            }

            if (ok == true && cantitateProdus[index].Text.Length > 0)
            {
                produseCos.Add(((Produs)produse[index]));
                cantitateProdusCos.Add(Convert.ToInt32(cantitateProdus[index].Text));
                cantitateProdus[index].Text = "";
                deseneazaCos();
            }
            else MessageBox.Show("Cantitate invalida!");
        }

        private void deseneazaCos()
        {
            int nrProduseCos = produseCos.Count;
            int height = 15;

            Canvas[] canvasProdus = new Canvas[nrProduseCos];
            Label[] numeProdus = new Label[nrProduseCos];
            Label[] pretCantitateProdus = new Label[nrProduseCos];
            Button[] deleteProdus = new Button[nrProduseCos];

            cosCumparaturiPanel.Children.Clear();
            pretTotal = 0.0;
            for (int i = 0; i < nrProduseCos; i++)
            {
                canvasProdus[i] = new Canvas();
                cosCumparaturiPanel.Children.Add(canvasProdus[i]);
                canvasProdus[i].Width = 375;
                canvasProdus[i].Height = 50;
                canvasProdus[i].Margin = new Thickness(0, height, 0, 0);
                //height += 100 + 15;
                canvasProdus[i].Background = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                canvasProdus[i].Visibility = Visibility.Visible;
                canvasProdus[i].HorizontalAlignment = HorizontalAlignment.Left;
                canvasProdus[i].VerticalAlignment = VerticalAlignment.Top;

                //nume produs
                numeProdus[i] = new Label();
                canvasProdus[i].Children.Add(numeProdus[i]);
                numeProdus[i].Margin = new Thickness(10, 10, 0, 0);
                numeProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                numeProdus[i].FontFamily = new FontFamily("Times New Roman");
                numeProdus[i].FontSize = 14;
                numeProdus[i].Content = produseCos[i].Nume.ToString();
                numeProdus[i].FontWeight = FontWeights.Bold;

                //calcul pret * cantitate
                pretCantitateProdus[i] = new Label();
                canvasProdus[i].Children.Add(pretCantitateProdus[i]);
                pretCantitateProdus[i].Margin = new Thickness(165, 10, 0, 0);
                pretCantitateProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                pretCantitateProdus[i].FontFamily = new FontFamily("Times New Roman");
                pretCantitateProdus[i].FontSize = 14;
                pretCantitateProdus[i].Content = produseCos[i].Pret + " X " + cantitateProdusCos[i] + " = " + (produseCos[i].Pret * cantitateProdusCos[i]).ToString() + " lei";

                pretTotal += produseCos[i].Pret * cantitateProdusCos[i];

                //sterge produs din cos
                deleteProdus[i] = new Button();
                canvasProdus[i].Children.Add(deleteProdus[i]);
                deleteProdus[i].Margin = new Thickness(300, 10, 0, 0);
                deleteProdus[i].Width = 50;
                deleteProdus[i].Height = 30;
                deleteProdus[i].Style = this.Resources["btnGlass"] as Style;
                deleteProdus[i].BorderBrush = deleteProdus[i].Background = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                deleteProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(255, 229, 195));
                deleteProdus[i].Content = "X";
                deleteProdus[i].FontStyle = FontStyles.Italic;
                deleteProdus[i].ToolTip = "Sterge produs din cos";
                deleteProdus[i].Name = "btnDeleteProdus" + i.ToString();
                deleteProdus[i].Click += deleteItemFromCart_Click;
                deleteProdus[i].Cursor = Cursors.Hand;
            }

            if (produseCos.Count > 0)
            {
                Canvas canvasPret = new Canvas();
                cosCumparaturiPanel.Children.Add(canvasPret);
                canvasPret.Width = 375;
                canvasPret.Height = 75;
                canvasPret.Margin = new Thickness(0, height, 0, 0);
                //height += 100 + 15;
                canvasPret.Background = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                canvasPret.Visibility = Visibility.Visible;
                canvasPret.HorizontalAlignment = HorizontalAlignment.Left;
                canvasPret.VerticalAlignment = VerticalAlignment.Top;

                Label labelTotal = new Label();
                canvasPret.Children.Add(labelTotal);
                labelTotal.Margin = new Thickness(10, 10, 0, 0);
                labelTotal.Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                labelTotal.FontFamily = new FontFamily("Times New Roman");
                labelTotal.FontSize = 14;
                if (client.EClientLoial == 'Y') labelTotal.Content = "Total cu discount";
                else labelTotal.Content = "Total";
                labelTotal.FontWeight = FontWeights.Bold;

                Label labelPret = new Label();
                canvasPret.Children.Add(labelPret);
                labelPret.Margin = new Thickness(165, 10, 0, 0);
                labelPret.Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                labelPret.FontFamily = new FontFamily("Times New Roman");
                labelPret.FontSize = 14;
                if (client.EClientLoial == 'Y') pretTotal = pretTotal - (0.05 * pretTotal);
                labelPret.Content = pretTotal.ToString() + " lei";

                Button comanda = new Button();
                canvasPret.Children.Add(comanda);
                comanda.Margin = new Thickness(270, 10, 0, 0);
                comanda.Width = 80;
                comanda.Height = 30;
                comanda.Style = this.Resources["btnGlass"] as Style;
                comanda.BorderBrush = comanda.Background = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                comanda.Foreground = new SolidColorBrush(Color.FromRgb(255, 229, 195));
                comanda.Content = "Comandă";
                comanda.FontStyle = FontStyles.Italic;
                comanda.Cursor = Cursors.Hand;
                comanda.Click += comanda_Click;

                cash = new RadioButton();
                canvasPret.Children.Add(cash);
                cash.Content = "Cash";
                cash.Margin = new Thickness(15, 50, 0, 0);
                cash.Foreground = new SolidColorBrush(Color.FromRgb(255, 229, 195));

                card = new RadioButton();
                canvasPret.Children.Add(card);
                card.Content = "Card";
                card.Margin = new Thickness(100, 50, 0, 0);
                card.Foreground = new SolidColorBrush(Color.FromRgb(255, 229, 195));
            }
        }

        private void comanda_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cash.IsChecked || (bool)card.IsChecked)
            {
                string modalitatePlata = ((bool)cash.IsChecked) == true ? "cash" : "card";
                string data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Comanda comanda = new Comanda(0, client.IdClient, data, pretTotal, modalitatePlata);

                try
                {
                    ComandaBLL.insertComanda(comanda);
                    comanda = (Comanda)ComandaBLL.selectComanda(comanda);
                    //MessageBox.Show(comanda.ToString());
                    DetaliiComandaBLL detaliiComandaBLL = new DetaliiComandaBLL();

                    for (int i = 0; i < produseCos.Count; i++)
                    {
                        DetaliiComanda dc = new DetaliiComanda(comanda.IdComanda, produseCos[i].Nume, produseCos[i].Pret, cantitateProdusCos[i]);
                        //MessageBox.Show(dc.ToString());
                        detaliiComandaBLL.insertDetaliiComanda(dc);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                produseCos.Clear();
                cantitateProdusCos.Clear();
                deseneazaCos();
                MessageBox.Show("Cosul de cumparaturi a fost inregistrat");
                //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else MessageBox.Show("Nu ati ales modalitatea de plata!"); 
        }

        private void deleteItemFromCart_Click(object sender, RoutedEventArgs e)
        {
            int indexStergere = 0;
            Button b = (Button)sender;

            for (int i = 0; i < produseCos.Count && indexStergere == 0; i++)
            {
                if (b.Name == "btnDeleteProdus" + i.ToString()) indexStergere = i;
            }

            produseCos.RemoveAt(indexStergere);
            cantitateProdusCos.RemoveAt(indexStergere);

            deseneazaCos();
        }

        private void populateComboBox()
        {
            categorii = ReflectionDAO.createListOfObjects("select * from CategoriiProdus", "CategoriiProdus");
            comboBoxCategorie.Items.Add("Toate");
            for (int i = 0; i < categorii.Count; i++)
            {
                comboBoxCategorie.Items.Add(((CategoriiProdus)categorii[i]).Categorie.ToString());
            }
        }

        private void comboBoxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            categorieProdusValue = comboBoxCategorie.SelectedValue.ToString();
            deseneazaForme();
        }

        public void setContClient(Cont cont, Client client)
        {
            this.cont = cont;
            this.client = client;
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void userOptions_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void UpdateProfil_Click(object sender, RoutedEventArgs e)
        {
            contWindow = new AddModifyCont(cont, client, "client");
            contWindow.setClientWindow(this);
            contWindow.Show();
        }

        private void IstoricCumparaturi_Click(object sender, RoutedEventArgs e)
        {
            istoricWindow = new VizualizareIstoric(client, "client");
            istoricWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            if (contWindow != null) contWindow.Close();
            if (istoricWindow != null) istoricWindow.Close();
            this.Hide();
        }
    }
}
