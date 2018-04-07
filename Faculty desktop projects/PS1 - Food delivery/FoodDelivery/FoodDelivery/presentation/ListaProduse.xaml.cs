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

using FoodDelivery.dao;
using FoodDelivery.models;
using FoodDelivery.presentation;
using System.Windows.Resources;

namespace FoodDelivery.presentation
{
    /// <summary>
    /// Interaction logic for ListaProduse.xaml
    /// </summary>
    public partial class ListaProduse : Window
    {
        private List<Object> categorii;
        private List<Object> produse;
        private AddModifyProdus modificareProdus;

        private Canvas[] canvas;
        private Label[] categorie;
        private Label[] dateProdus;
        private TextBox[] descriere;
        private Label[] detaliu;
        private Button[] btnProdus;

        private string categorieProdusValue = "Toate";
        private int nrProduse;
        private int index = 0;

        public ListaProduse()
        {
            InitializeComponent();

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
            btnProdus = new Button[nrProduse];

            index = 0;

            int height = 15;

            for (int i = 0; i < nrProduse; i++)
            {
                if (categorieProdusValue == "Toate" || ((Produs)produse[i]).Categorie == categorieProdusValue)
                {
                    canvas[i] = new Canvas();
                    stackPanel.Children.Add(canvas[i]);
                    canvas[i].Width = 800;
                    canvas[i].Height = 100;
                    canvas[i].Margin = new Thickness(15, height, 0, 0);
                    //height += 100 + 15;
                    canvas[i].Background = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                    canvas[i].Visibility = Visibility.Visible;
                    canvas[i].HorizontalAlignment = HorizontalAlignment.Left;
                    canvas[i].VerticalAlignment = VerticalAlignment.Top;

                    //label categorie
                    categorie[i] = new Label();
                    canvas[i].Children.Add(categorie[i]);
                    categorie[i].Width = 125;
                    categorie[i].Margin = new Thickness(20, 37, 0, 0);
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
                    b.Margin = new Thickness(150, 10, 0, 0);

                    //date produs
                    dateProdus[i] = new Label();
                    canvas[i].Children.Add(dateProdus[i]);
                    dateProdus[i].Margin = new Thickness(170, 10, 0, 0);
                    dateProdus[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    dateProdus[i].FontFamily = new FontFamily("Times New Roman");
                    dateProdus[i].FontSize = 14;
                    dateProdus[i].Content = ((Produs)produse[i]).Nume.ToString();
                    dateProdus[i].FontWeight = FontWeights.Bold;

                    //descriere produs
                    descriere[i] = new TextBox();
                    canvas[i].Children.Add(descriere[i]);
                    descriere[i].Margin = new Thickness(170, 35, 0, 0);
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
                    detaliu[i].Margin = new Thickness(500, 38, 0, 0);
                    detaliu[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    detaliu[i].FontFamily = new FontFamily("Times New Roman");
                    detaliu[i].FontSize = 14;
                    detaliu[i].Content = ((Produs)produse[i]).Gramaj.ToString() + " grame, " + ((Produs)produse[i]).Pret.ToString() + " lei";

                    //buton modificari cont
                    btnProdus[i] = new Button();
                    canvas[i].Children.Add(btnProdus[i]);
                    btnProdus[i].Margin = new Thickness(700, 10, 0, 0);
                    btnProdus[i].Width = btnProdus[i].Height = 80;
                    btnProdus[i].Style = this.Resources["btnGlass"] as Style;
                    btnProdus[i].BorderThickness = new Thickness(4);
                    btnProdus[i].BorderBrush = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    btnProdus[i].Name = "btnProdus" + i.ToString();
                    btnProdus[i].Click += produs_Click;

                    Uri resourceUri = new Uri("Resources/settings.png", UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    var brush = new ImageBrush();
                    brush.ImageSource = temp;
                    btnProdus[i].Background = brush;
                    btnProdus[i].Cursor = Cursors.Hand;
                    btnProdus[i].ToolTip = "Modificare date produs";
                    btnProdus[i].Name = "btnProdus" + i.ToString();
                    //btnCumparaturi[i].Click += istoricCumparaturi_Click;
                }
            }
        }

        private void produs_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            index = 0;

            for (int i = 0; i < produse.Count && index == 0; i++)
            {
                if (b.Name == "btnProdus" + i.ToString()) index = i;
            }

            modificareProdus = new AddModifyProdus((Produs)produse[index]);
            modificareProdus.setListaProduseWindow(this);
            modificareProdus.Show();
        }

        public void populateComboBox()
        {
            categorii = ReflectionDAO.createListOfObjects("select * from CategoriiProdus", "CategoriiProdus");
            comboBoxCategorie.Items.Add("Toate");
            for (int i = 0; i < categorii.Count; i++)
            {
                comboBoxCategorie.Items.Add(((CategoriiProdus)categorii[i]).Categorie.ToString());
            }
        }

        public void setProdus(Produs p)
        {
            produse[index] = p;

            categorie[index].Content = ((Produs)produse[index]).Categorie.ToString();
            dateProdus[index].Content = ((Produs)produse[index]).Nume.ToString();
            descriere[index].Text = "(" + ((Produs)produse[index]).Descriere.ToString() + ")";
            detaliu[index].Content = ((Produs)produse[index]).Gramaj.ToString() + " grame, " + ((Produs)produse[index]).Pret.ToString() + " lei";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            this.Hide();
        }

        private void userOptions_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            Login login = new Login();
            login.Show();
            if (modificareProdus != null) modificareProdus.Close();
            this.Hide();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void comboBoxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            categorieProdusValue = comboBoxCategorie.SelectedValue.ToString();
            deseneazaForme();
        }

        private void addCategorie_Click(object sender, RoutedEventArgs e)
        {
            AddCategory ac = new AddCategory();
            ac.Show();
        }

        private void addProdus_Click(object sender, RoutedEventArgs e)
        {
            modificareProdus = new AddModifyProdus();
            modificareProdus.setListaProduseWindow(this);
            modificareProdus.Show();
        }
    }
}
