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
    /// Interaction logic for AddModifyCont.xaml
    /// </summary>
    public partial class AddModifyCont : Window
    {
        private char eClientLoial;
        private string mod;
        private Client clientOriginal;
        private Cont contOriginal;
        private string userType;

        private ClientWindow clientWindow;
        private ListaConturi listaConturiWindow;

        public AddModifyCont()
        {
            InitializeComponent();
            eClientLoial = 'N';
            mod = "creare";
        }

        public AddModifyCont(Cont cont, Client client, string userType)
        {
            InitializeComponent();

            contOriginal = cont;
            clientOriginal = client;

            userTextBox.Text = cont.Username;
            userTextBox.IsReadOnly = true;
            passwordBox.Password = cont.Pass;
            numeTextBox.Text = client.Nume;
            prenumeTextBox.Text = client.Prenume;
            cnpTextBox.Text = client.Cnp;
            cnpTextBox.IsReadOnly = true;
            adresaTextBox.Text = client.AdresaLivrare;
            nrTelefonTextBox.Text = client.NrTelefon;
            emailTextBox.Text = client.Email;
            eClientLoial = client.EClientLoial;

            mod = "modificare";
            label.Visibility = Visibility.Hidden;

            createCanvas.Visibility = Visibility.Hidden;
            updateCanvas.Visibility = Visibility.Visible;

            this.userType = userType;
        }

        public void setClientWindow(ClientWindow cw)
        {
            this.clientWindow = cw;
        }

        public void setListaConturiWindow(ListaConturi lc)
        {
            this.listaConturiWindow = lc;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
        }

        private Cont getCont()
        {
            string username = userTextBox.Text;
            string password = passwordBox.Password;

            return new Cont(username, password, 'C');
        }

        private Client getClient()
        {
            string username = userTextBox.Text;
            string nume = numeTextBox.Text;
            string prenume = prenumeTextBox.Text;
            string cnp = cnpTextBox.Text;
            string adresa = adresaTextBox.Text;
            string nrTelefon = nrTelefonTextBox.Text;
            string email = emailTextBox.Text;

            return new Client(0, username, nume, prenume, cnp, adresa, nrTelefon, email, eClientLoial);
        }

        private void btnCreareCont_Click(object sender, RoutedEventArgs e)
        {
            //string nume = numeTextBox.Text;
            //string prenume = prenumeTextBox.Text;
            //string cnp = cnpTextBox.Text;
            //string adresa = adresaTextBox.Text;
            //string nrTelefon = nrTelefonTextBox.Text;
            //string email = emailTextBox.Text;

            Cont contNou = getCont();
            Client clientNou = getClient();

            int iterator = 0;
            bool ok = true;
            foreach(Border b in formular.Children.OfType<Border>())
            {
                if (iterator == 1)
                {
                    PasswordBox pb = b.Child as PasswordBox;
                    //MessageBox.Show(pb.Password);
                    if (!(pb.Password.Length > 0))
                    {
                        ok = false;
                        MessageBox.Show("Parola necompletata");
                    }
                }
                else
                {
                    TextBox t = b.Child as TextBox;
                    //MessageBox.Show(t.Text);
                    if (t.Text.Length == 0)
                    {
                        ok = false;
                        MessageBox.Show("Camp(uri) necompletat(e)");
                    }
                }

                iterator++;
            }

            if (ok == true)
            {
                try
                {
                    if (ContBLL.findUser(contNou) == null)
                    {

                        ClientBLL clientBLL = new ClientBLL();
                        if (clientBLL.validareClient(clientNou) == 1)
                        {
                            ContBLL.insertUser(contNou);
                            //contNou = ContBLL.findUser(contNou);
                            ClientBLL.insertClient(clientNou);

                            MessageBox.Show("Contul a fost creat cu succes!");
                            this.Close();
                        }
                    }
                    else MessageBox.Show("Acest cont exista deja");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnActualizare_Click(object sender, RoutedEventArgs e)
        {
            Client clientModificat = getClient();
            clientModificat.IdClient = clientOriginal.IdClient;
            Cont contModificat = getCont();

            try
            {
                ClientBLL clientBLL = new ClientBLL();
                //ClientBLL.updateClient(clientModificat, clientOriginal);
                if (clientBLL.validareClient(clientModificat) == 1)
                {
                    ContBLL.updateClient(contModificat, contOriginal);
                    ClientBLL.updateClient(clientModificat, clientOriginal);

                    if (userType == "client") clientWindow.setContClient(contModificat, clientModificat);
                    else if (userType == "admin") listaConturiWindow.setContClient(contModificat, clientModificat);
                    MessageBox.Show("Contul a fost modificat cu succes");
                }

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStergereCont_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientBLL clientBLL = new ClientBLL();
                ClientBLL.deleteClient(clientOriginal);
                ContBLL.deleteClient(contOriginal);

                if (userType == "admin") listaConturiWindow.deseneazaForme();
                MessageBox.Show("Contul a fost sters cu succes");

                if (userType == "client") Application.Current.Shutdown();
                else if (userType == "admin") this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
