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
using System.Windows.Resources;

namespace FoodDelivery.presentation
{
    /// <summary>
    /// Interaction logic for ListaConturi.xaml
    /// </summary>
    public partial class ListaConturi : Window
    {
        private List<Object> conturi;
        private List<Object> clienti;
        private AddModifyCont modificareCont;
        private VizualizareIstoric istoricClient;

        private Canvas[] canvas;
        private Image[] fidelitate;
        private Button[] btnCont;
        private Button[] btnCumparaturi;
        private Label[] dataUser;
        private Label[] adresaUser;
        private Label[] telefonEmailUser;

        private int nrConturi;
        private int index = 0;

        public ListaConturi()
        {
            InitializeComponent();

            deseneazaForme();
        }

        public void deseneazaForme()
        {
            stackPanel.Children.Clear();

            conturi = ReflectionDAO.createListOfObjects("select * from Cont where username not in ('admin')", "Cont");
            clienti = ReflectionDAO.createListOfObjects("select * from Client order by username", "Client");

            nrConturi = conturi.Count;
            canvas = new Canvas[nrConturi];
            fidelitate = new Image[nrConturi];
            btnCont = new Button[nrConturi];
            btnCumparaturi = new Button[nrConturi];
            dataUser = new Label[nrConturi];
            adresaUser = new Label[nrConturi];
            telefonEmailUser = new Label[nrConturi];

            index = 0;

            int height = 15;

            for (int i = 0; i < nrConturi; i++)
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

                //stea pentru fidelitate
                fidelitate[i] = new Image();
                if (((Client)clienti[i]).EClientLoial == 'Y') fidelitate[i].Source = new BitmapImage(new Uri("/Resources/star.png", UriKind.Relative));
                canvas[i].Children.Add(fidelitate[i]);
                fidelitate[i].Margin = new Thickness(25, 25, 0, 0);
                fidelitate[i].Width = fidelitate[i].Height = 50;

                //bara verticala
                Border b = new Border();
                canvas[i].Children.Add(b);
                b.Height = 80;
                b.Width = 3;
                b.BorderThickness = new Thickness(2);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                b.Margin = new Thickness(100, 10, 0, 0);

                //label-uri cu informatii
                dataUser[i] = new Label();
                canvas[i].Children.Add(dataUser[i]);
                dataUser[i].Content = ((Cont)conturi[i]).Username + ", " + ((Client)clienti[i]).Nume + " " + ((Client)clienti[i]).Prenume;
                dataUser[i].Margin = new Thickness(120, 10, 0, 0);
                dataUser[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                dataUser[i].FontFamily = new FontFamily("Times New Roman");
                dataUser[i].HorizontalAlignment = HorizontalAlignment.Center;
                dataUser[i].FontSize = 14;

                //adresa
                adresaUser[i] = new Label();
                canvas[i].Children.Add(adresaUser[i]);
                adresaUser[i].Content = ((Client)clienti[i]).AdresaLivrare;
                adresaUser[i].Margin = new Thickness(120, 36, 0, 0);
                adresaUser[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                adresaUser[i].FontFamily = new FontFamily("Times New Roman");
                adresaUser[i].HorizontalAlignment = HorizontalAlignment.Center;
                adresaUser[i].FontSize = 14;

                //telefon si email
                telefonEmailUser[i] = new Label();
                canvas[i].Children.Add(telefonEmailUser[i]);
                telefonEmailUser[i].Content = ((Client)clienti[i]).NrTelefon + ", " + ((Client)clienti[i]).Email;
                telefonEmailUser[i].Margin = new Thickness(120, 64, 0, 0);
                telefonEmailUser[i].Foreground = new SolidColorBrush(Color.FromRgb(179, 68, 38));
                telefonEmailUser[i].FontFamily = new FontFamily("Times New Roman");
                telefonEmailUser[i].HorizontalAlignment = HorizontalAlignment.Center;
                telefonEmailUser[i].FontSize = 14;

                //buton istoric cumparaturi
                btnCumparaturi[i] = new Button();
                canvas[i].Children.Add(btnCumparaturi[i]);
                btnCumparaturi[i].Margin = new Thickness(600, 10, 0, 0);
                btnCumparaturi[i].Width = btnCumparaturi[i].Height = 80;
                btnCumparaturi[i].Style = this.Resources["btnGlass"] as Style;
                btnCumparaturi[i].BorderThickness = new Thickness(4);
                btnCumparaturi[i].BorderBrush = new SolidColorBrush(Color.FromRgb(179, 68, 38));

                Uri resourceUri = new Uri("Resources/shoppingHistory.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                btnCumparaturi[i].Background = brush;
                btnCumparaturi[i].Cursor = Cursors.Hand;
                btnCumparaturi[i].ToolTip = "Istoric cumparaturi";
                btnCumparaturi[i].Name = "btnCumparaturi" + i.ToString();
                btnCumparaturi[i].Click += istoricCumparaturi_Click;

                //buton modificari cont
                btnCont[i] = new Button();
                canvas[i].Children.Add(btnCont[i]);
                btnCont[i].Margin = new Thickness(700, 10, 0, 0);
                btnCont[i].Width = btnCont[i].Height = 80;
                btnCont[i].Style = this.Resources["btnGlass"] as Style;
                btnCont[i].BorderThickness = new Thickness(4);
                btnCont[i].BorderBrush = new SolidColorBrush(Color.FromRgb(179, 68, 38));

                resourceUri = new Uri("Resources/settings.png", UriKind.Relative);
                streamInfo = Application.GetResourceStream(resourceUri);
                temp = BitmapFrame.Create(streamInfo.Stream);
                brush = new ImageBrush();
                brush.ImageSource = temp;
                btnCont[i].Background = brush;
                btnCont[i].Cursor = Cursors.Hand;
                btnCont[i].ToolTip = "Modificari cont";
                btnCont[i].Name = "btnCont" + i.ToString();
                btnCont[i].Click += modifConturi_Click;
                //MessageBox.Show(objects.ElementAt(i).ToString());
            }
        }

        public void setContClient(Cont cont, Client client)
        {
            conturi[index] = cont;
            clienti[index] = client;

            dataUser[index].Content = ((Cont)conturi[index]).Username + ", " + ((Client)clienti[index]).Nume + " " + ((Client)clienti[index]).Prenume;
            adresaUser[index].Content = ((Client)clienti[index]).AdresaLivrare;
            telefonEmailUser[index].Content = ((Client)clienti[index]).NrTelefon + ", " + ((Client)clienti[index]).Email;
        }

        public void setClient(Client client)
        {
            clienti[index] = client;

            dataUser[index].Content = ((Cont)conturi[index]).Username + ", " + ((Client)clienti[index]).Nume + " " + ((Client)clienti[index]).Prenume;
            adresaUser[index].Content = ((Client)clienti[index]).AdresaLivrare;
            telefonEmailUser[index].Content = ((Client)clienti[index]).NrTelefon + ", " + ((Client)clienti[index]).Email;

            if(((Client)clienti[index]).EClientLoial == 'Y') fidelitate[index].Source = new BitmapImage(new Uri("/Resources/star.png", UriKind.Relative));
            else fidelitate[index].Source = new BitmapImage();
        }

        private void istoricCumparaturi_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            index = 0;

            for (int i = 0; i < conturi.Count && index == 0; i++)
            {
                if (b.Name == "btnCumparaturi" + i.ToString()) index = i;
            }

            istoricClient = new VizualizareIstoric((Client)clienti[index], "admin");
            istoricClient.setListaConturiWindow(this);
            istoricClient.Show();
        }

        private void modifConturi_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            index = 0;

            for (int i = 0; i < conturi.Count && index == 0; i++)
            {
                if (b.Name == "btnCont" + i.ToString()) index = i;
            }

            modificareCont = new AddModifyCont((Cont)conturi[index], (Client)clienti[index], "admin");
            modificareCont.setListaConturiWindow(this);
            modificareCont.Show();
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
            if (modificareCont != null) modificareCont.Close();
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
    }
}
