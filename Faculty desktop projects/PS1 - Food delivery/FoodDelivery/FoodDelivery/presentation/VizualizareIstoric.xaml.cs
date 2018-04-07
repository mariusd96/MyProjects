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
    /// Interaction logic for VizualizareIstoric.xaml
    /// </summary>
    public partial class VizualizareIstoric : Window
    {
        private string userType;
        private ListaConturi listaConturiWindow;
        private Client clientOriginal;

        int id;
        string username;
        string nume;
        string prenume;
        string cnp;
        string adresa;
        string nrTelefon;
        string email;
        char eClientLoial;

        private List<Object> comenzi;
        private List<Object> detaliuComanda;

        string query1;
        string query2;

        public VizualizareIstoric(Client c, string userType)
        {
            InitializeComponent();
            if (userType == "client") canvas.Visibility = Visibility.Hidden;
            else
            {
                if (c.EClientLoial == 'Y') daRadioBtn.IsChecked = true;
                else nuRadioBtn.IsChecked = true;
            }

            clientOriginal = c;
            this.userType = userType;

            id = c.IdClient;
            username = c.Username;
            nume = c.Nume;
            prenume = c.Prenume;
            cnp = c.Cnp;
            adresa = c.AdresaLivrare;
            nrTelefon = c.NrTelefon;
            email = c.Email;
            eClientLoial = c.EClientLoial;

            deseneazaForme();
        }

        public void deseneazaForme()
        {
            stackPanel.Children.Clear();

            comenzi = ReflectionDAO.createListOfObjects("select * from Comanda where idClient = " + clientOriginal.IdClient, "Comanda");
            //MessageBox.Show(comenzi.Count.ToString());

            int height = 15;
            int nrComenzi = comenzi.Count;

            for (int i = 0; i < nrComenzi; i++)
            {
                Canvas canvas = new Canvas();
                stackPanel.Children.Add(canvas);
                canvas.Width = 800;
                canvas.Height = 35;
                canvas.Margin = new Thickness(15, height, 0, 0);
                //height += 100 + 15;
                //canvas.Background = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                canvas.Background = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                canvas.Visibility = Visibility.Visible;
                canvas.HorizontalAlignment = HorizontalAlignment.Left;
                canvas.VerticalAlignment = VerticalAlignment.Top;

                Label label = new Label();
                canvas.Children.Add(label);
                label.Content = "#" + ((Comanda)comenzi[i]).IdComanda;
                label.Height = 35;
                label.Margin = new Thickness(10, 0, 0, 0);
                label.Foreground = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                label.FontFamily = new FontFamily("Times New Roman");
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 14;

                Label data = new Label();
                canvas.Children.Add(data);
                data.Content = ((Comanda)comenzi[i]).DataComanda;
                data.Height = 35;
                data.Margin = new Thickness(200, 0, 0, 0);
                data.Foreground = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                data.FontFamily = new FontFamily("Times New Roman");
                data.HorizontalAlignment = HorizontalAlignment.Center;
                data.VerticalContentAlignment = VerticalAlignment.Center;
                data.FontSize = 14;

                Label pret = new Label();
                canvas.Children.Add(pret);
                pret.Content = ((Comanda)comenzi[i]).PretTotal + " lei";
                pret.Height = 35;
                pret.Margin = new Thickness(500, 0, 0, 0);
                pret.Foreground = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                pret.FontFamily = new FontFamily("Times New Roman");
                pret.HorizontalAlignment = HorizontalAlignment.Center;
                pret.VerticalContentAlignment = VerticalAlignment.Center;
                pret.FontSize = 14;

                Label plata = new Label();
                canvas.Children.Add(plata);
                plata.Content = ((Comanda)comenzi[i]).ModalitatePlata;
                plata.Height = 35;
                plata.Margin = new Thickness(700, 0, 0, 0);
                plata.Foreground = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                plata.FontFamily = new FontFamily("Times New Roman");
                plata.HorizontalAlignment = HorizontalAlignment.Center;
                plata.VerticalContentAlignment = VerticalAlignment.Center;
                plata.FontSize = 14;

                detaliuComanda = ReflectionDAO.createListOfObjects("select * from DetaliiComanda where idComanda = " + ((Comanda)comenzi[i]).IdComanda.ToString(), "DetaliiComanda");
                //MessageBox.Show(detaliuComanda.Count.ToString());
                int nrDetalii = detaliuComanda.Count;

                for (int j = 0; j < nrDetalii; j++)
                {
                    Canvas canvasDetaliu = new Canvas();
                    stackPanel.Children.Add(canvasDetaliu);
                    canvasDetaliu.Width = 800;
                    canvasDetaliu.Height = 35;
                    canvasDetaliu.Margin = new Thickness(15, height, 0, 0);
                    //height += 100 + 15;
                    canvasDetaliu.Background = new SolidColorBrush(Color.FromRgb(252, 228, 200));
                    canvasDetaliu.Visibility = Visibility.Visible;
                    canvasDetaliu.HorizontalAlignment = HorizontalAlignment.Left;
                    canvasDetaliu.VerticalAlignment = VerticalAlignment.Top;

                    Label labelProdus = new Label();
                    canvasDetaliu.Children.Add(labelProdus);
                    labelProdus.Content = ((DetaliiComanda)detaliuComanda[j]).NumeProdus;
                    labelProdus.Height = 35;
                    labelProdus.Margin = new Thickness(150, 0, 0, 0);
                    labelProdus.Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    labelProdus.FontFamily = new FontFamily("Times New Roman");
                    labelProdus.HorizontalAlignment = HorizontalAlignment.Center;
                    labelProdus.VerticalContentAlignment = VerticalAlignment.Center;
                    labelProdus.FontSize = 14;
                    labelProdus.FontWeight = FontWeights.Bold;

                    Label labelProdusCantitate = new Label();
                    canvasDetaliu.Children.Add(labelProdusCantitate);
                    labelProdusCantitate.Content = ((DetaliiComanda)detaliuComanda[j]).Pret + " x " + ((DetaliiComanda)detaliuComanda[j]).Cantitate + " = " + (((DetaliiComanda)detaliuComanda[j]).Pret * ((DetaliiComanda)detaliuComanda[j]).Cantitate).ToString() + " lei";
                    labelProdusCantitate.Height = 35;
                    labelProdusCantitate.Margin = new Thickness(550, 0, 0, 0);
                    labelProdusCantitate.Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                    labelProdusCantitate.FontFamily = new FontFamily("Times New Roman");
                    labelProdusCantitate.HorizontalAlignment = HorizontalAlignment.Center;
                    labelProdusCantitate.VerticalContentAlignment = VerticalAlignment.Center;
                    labelProdusCantitate.FontSize = 14;
                }
            }
        }

        public void setListaConturiWindow(ListaConturi lc)
        {
            this.listaConturiWindow = lc;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void salvareBtn_Click(object sender, RoutedEventArgs e)
        {
            if (daRadioBtn.IsChecked == true) eClientLoial = 'Y';
            else eClientLoial = 'N';

            Client clientModificat = new Client(id, username, nume, prenume, cnp, adresa, nrTelefon, email, eClientLoial);

            try
            {
                ClientBLL clientBLL = new ClientBLL();
                if (clientBLL.validareClient(clientModificat) == 1)
                {
                    ClientBLL.updateClient(clientModificat, clientOriginal);
                    listaConturiWindow.setClient(clientModificat);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void firstDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(firstDate.SelectedDate.Value.ToString("yyyy-MM-dd"));
        }

        private void secondDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(secondDate.SelectedDate.Value.ToString("yyyy-MM-dd"));
        }
    }
}
