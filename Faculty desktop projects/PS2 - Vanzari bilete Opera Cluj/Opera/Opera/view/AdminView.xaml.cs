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

using Opera.model;
using System.Windows.Resources;

namespace Opera.view
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        private List<Casier> listaCasieri;
        private Button[] modifCont;
        private int nrCasieri;

        private int nrSpectacole;
        private int indexSpectacol = -1;
        private List<Spectacol> listaSpectacole;
        private Button[] modifSpectacolBtn;
        private Button[] modifActorBtn;

        private Spectacol spectacolSelectat;
        private List<DistributieOp> listaOp;
        private List<DistributieBalet> listaBalet;
        int indexDistributie = -1;

        public AdminView()
        {
            InitializeComponent();
            listaCasieri = new List<Casier>();
            nrCasieri = 0;
        }

        public void logout(EventHandler Logout_Click)
        {
            logoutBtn.Click += new RoutedEventHandler(Logout_Click);
        }

        public void minimize(EventHandler Minimize_Click)
        {
            minimizeBtn.Click += new RoutedEventHandler(Minimize_Click);
        }

        public void addCasier(EventHandler InsertCasier_Click)
        {
            creareContBtn.Click += new RoutedEventHandler(InsertCasier_Click);
        }

        public void modificareCasier(EventHandler UpdateCasier_Click)
        {
            modificareContBtn.Click += new RoutedEventHandler(UpdateCasier_Click);
        }

        public void stergereCasier(EventHandler DeleteCasier_Click)
        {
            deleteContBtn.Click += new RoutedEventHandler(DeleteCasier_Click);
        }

        public void addSpectacol(EventHandler InsertSpectacol_Click)
        {
            creareSpectacolBtn.Click += new RoutedEventHandler(InsertSpectacol_Click);
        }

        public void modificareSpectacol(EventHandler UpdateSpectacol_Click)
        {
            modificareSpectacolBtn.Click += new RoutedEventHandler(UpdateSpectacol_Click);
        }

        public void stergereSpectacol(EventHandler DeleteSpectacol_Click)
        {
            deleteSpectacolBtn.Click += new RoutedEventHandler(DeleteSpectacol_Click);
        }

        /*--------------------------------------------casieri----------------------------------------------*/
        public void populateTable(List<Casier> casieri, EventHandler ModificareCont_Click)
        {
            nrCasieri = casieri.Count;
            listaCasieri = casieri;
            modifCont = new Button[nrCasieri];
            stackPanel.Children.Clear();

            for (int i = 0; i < nrCasieri; i++)
            {
                Border b = new Border();
                b.Width = 600;
                b.Height = 40;
                b.BorderThickness = new Thickness(4);
                b.CornerRadius = new CornerRadius(8);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                b.Background = new SolidColorBrush(Colors.White);
                b.Margin = new Thickness(0, 15, 0, 0);
                stackPanel.Children.Add(b);

                Canvas c = new Canvas();
                b.Child = c;

                Label nume = new Label();
                nume.Content = casieri[i].Nume;
                nume.Width = 175;
                nume.Height = 34;
                nume.Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                nume.Margin = new Thickness(3, 3, 0, 0);
                nume.FontWeight = FontWeights.Bold;
                c.Children.Add(nume);

                Label username = new Label();
                username.Content = "Username: " + casieri[i].Username;
                username.Width = 175;
                username.Height = 34;
                username.Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                username.Margin = new Thickness(180, 3, 0, 0);
                c.Children.Add(username);

                Label parola = new Label();
                parola.Content = "Parola: " + casieri[i].Password;
                parola.Width = 150;
                parola.Height = 34;
                parola.Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                parola.Margin = new Thickness(365, 3, 0, 0);
                c.Children.Add(parola);

                modifCont[i] = new Button();
                modifCont[i].Width = modifCont[i].Height = 30;
                modifCont[i].Style = this.Resources["btnGlass2"] as Style;
                modifCont[i].Margin = new Thickness(550, 2, 0, 0);
                modifCont[i].BorderThickness = new Thickness(0);
                Uri resourceUri = new Uri("Resources/settings.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                modifCont[i].Background = brush;
                modifCont[i].Cursor = Cursors.Hand;
                modifCont[i].Name = "modifCont" + i.ToString();
                modifCont[i].Click += new RoutedEventHandler(ModificareCont_Click);
                c.Children.Add(modifCont[i]);
            }
        }

        public Casier getCasier()
        {
            Casier c = new Casier();
            c.Nume = numeTextBox.Text;
            c.Username = userCasierTextBox.Text;
            c.Password = parolaCasierTextBox.Text;

            if(c.Nume != "" && c.Username!="" && c.Password != "") return c; 
            else return null;
        }

        public void setCasierTextboxes(int index)
        {
            numeTextBox.Text = listaCasieri[index].Nume;
            userCasierTextBox.Text = listaCasieri[index].Username;
            parolaCasierTextBox.Text = listaCasieri[index].Password;
            creareContBtn.Visibility = Visibility.Hidden;
            modificareContBtn.Visibility = deleteContBtn.Visibility = Visibility.Visible;
            userCasierTextBox.IsEnabled = false;
            labelAdaugare.FontWeight = FontWeights.Normal;
            labelModificare.FontWeight = FontWeights.Bold;
        }

        public void clearCasierTextboxes()
        {
            numeTextBox.Text = userCasierTextBox.Text = parolaCasierTextBox.Text = "";
        }

        public void showMessage(String message)
        {
            MessageBox.Show(message);
        }

        public void closeWindow()
        {
            this.Close();
        }

        public void minimizeWindow()
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void labelAdaugare_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(labelAdaugare.FontWeight != FontWeights.Bold)
            {
                labelAdaugare.FontWeight = FontWeights.Bold;
                labelModificare.FontWeight = FontWeights.Normal;
                creareContBtn.Visibility = Visibility.Visible;
                modificareContBtn.Visibility = deleteContBtn.Visibility = Visibility.Hidden;
                userCasierTextBox.IsEnabled = true;
                clearCasierTextboxes();
            }
        }


        /*--------------------------------------------spectacole----------------------------------------------*/
        public void populateTableSpectacole(List<Spectacol> spectacole, EventHandler ModificareSpectacol_Click)
        {
            nrSpectacole = spectacole.Count;
            listaSpectacole = spectacole;
            modifSpectacolBtn = new Button[nrSpectacole];
            stackPanelSpectacole.Children.Clear();

            for (int i = 0; i < nrSpectacole; i++)
            {
                Border b = new Border();
                b.Width = 375;
                b.Height = 40;
                b.BorderThickness = new Thickness(4);
                b.CornerRadius = new CornerRadius(8);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                b.Background = new SolidColorBrush(Colors.White);
                b.Margin = new Thickness(0, 15, 0, 0);
                stackPanelSpectacole.Children.Add(b);

                Canvas c = new Canvas();
                b.Child = c;

                Label nume = new Label();
                nume.Content = spectacole[i].Titlu;
                nume.Width = 250;
                nume.Height = 35;
                nume.Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                nume.Margin = new Thickness(3, 3, 0, 0);
                c.Children.Add(nume);

                modifSpectacolBtn[i] = new Button();
                modifSpectacolBtn[i].Width = modifSpectacolBtn[i].Height = 30;
                modifSpectacolBtn[i].Style = this.Resources["btnGlass2"] as Style;
                modifSpectacolBtn[i].Margin = new Thickness(320, 2, 0, 0);
                modifSpectacolBtn[i].BorderThickness = new Thickness(0);
                Uri resourceUri = new Uri("Resources/settings.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                modifSpectacolBtn[i].Background = brush;
                modifSpectacolBtn[i].Cursor = Cursors.Hand;
                modifSpectacolBtn[i].Name = "modifSpectacol" + i.ToString();
                modifSpectacolBtn[i].Click += new RoutedEventHandler(ModificareSpectacol_Click);
                c.Children.Add(modifSpectacolBtn[i]);
            }
        }

        public Spectacol getSpectacol()
        {
            bool ziOk = true, lunaOk = true, anOk = true, oraOk = true, minutOk = true, biletOk = true;
            for (int i = 0; i < ziSpectacol_TextBox.Text.Length && ziOk == true; i++)
            {
                if (!(ziSpectacol_TextBox.Text[i] >= '0' && ziSpectacol_TextBox.Text[i] <= '9')) ziOk = false;
            }

            for (int i = 0; i < lunaSpectacol_TextBox.Text.Length && lunaOk == true; i++)
            {
                if (!(lunaSpectacol_TextBox.Text[i] >= '0' && lunaSpectacol_TextBox.Text[i] <= '9')) lunaOk = false;
            }

            for (int i = 0; i < anSpectacol_TextBox.Text.Length && anOk == true; i++)
            {
                if (!(anSpectacol_TextBox.Text[i] >= '0' && anSpectacol_TextBox.Text[i] <= '9')) anOk = false;
            }

            for (int i = 0; i < oraSpectacol_TextBox.Text.Length && oraOk == true; i++)
            {
                if (!(oraSpectacol_TextBox.Text[i] >= '0' && oraSpectacol_TextBox.Text[i] <= '9')) oraOk = false;
            }

            for (int i = 0; i < minutSpectacol_TextBox.Text.Length && minutOk == true; i++)
            {
                if (!(minutSpectacol_TextBox.Text[i] >= '0' && minutSpectacol_TextBox.Text[i] <= '9')) minutOk = false;
            }

            for (int i = 0; i < nrBilete_TextBox.Text.Length && biletOk == true; i++)
            {
                if (!(nrBilete_TextBox.Text[i] >= '0' && nrBilete_TextBox.Text[i] <= '9')) biletOk = false;
            }

            if (ziOk == false || lunaOk == false || anOk == false || oraOk == false || minutOk == false)
            {
                showMessage("Zi/Luna/An/Ora/Minut incorect !");
                return null;
            }

            Spectacol s = new Spectacol();
            s.IdSpectacol = listaSpectacole[indexSpectacol].IdSpectacol;
            s.Titlu = numeSpectacol_TextBox.Text;
            s.Regia = regia_TextBox.Text;
            s.Gen = genSpectacol_comboBox.Text;
            s.NumarBilete = Convert.ToInt32(nrBilete_TextBox.Text);
            s.DataPremiere = anSpectacol_TextBox.Text + "-";

            if (lunaSpectacol_TextBox.Text.Length < 2) s.DataPremiere += "0" + lunaSpectacol_TextBox.Text + "-";
            else s.DataPremiere += "0" + lunaSpectacol_TextBox.Text + "-";

            if (ziSpectacol_TextBox.Text.Length < 2) s.DataPremiere += "0" + ziSpectacol_TextBox.Text + " ";
            else s.DataPremiere += ziSpectacol_TextBox.Text + " ";

            if (oraSpectacol_TextBox.Text.Length < 2) s.DataPremiere += "0" + oraSpectacol_TextBox.Text + ":";
            else s.DataPremiere += oraSpectacol_TextBox.Text + ":";

            if (minutSpectacol_TextBox.Text.Length < 2) s.DataPremiere += "0" + minutSpectacol_TextBox.Text + ":00";
            else s.DataPremiere += minutSpectacol_TextBox.Text + ":00";

            int zi = Convert.ToInt32(ziSpectacol_TextBox.Text);
            int luna = Convert.ToInt32(lunaSpectacol_TextBox.Text);
            int an = Convert.ToInt32(anSpectacol_TextBox.Text);
            int ora = Convert.ToInt32(oraSpectacol_TextBox.Text);
            int minut = Convert.ToInt32(minutSpectacol_TextBox.Text);
            int nrBilete = Convert.ToInt32(nrBilete_TextBox.Text);

            if (s.Titlu != "" && s.Regia != "" && s.Gen != "" && (zi >= 1 && zi <= 31) && (luna >= 1 && luna <= 12) && (an >= DateTime.Now.Year) && (ora >= 0 && ora <= 24) && (minut >= 0 && minut < 60) && (nrBilete > 0 && nrBilete <= 200)) return s;
            else
            {
                showMessage("Date incorecte");
                return null;
            }
        }

        public void setSpectacolTextboxes(int index)
        {
            indexSpectacol = index;
            numeSpectacol_TextBox.Text = listaSpectacole[index].Titlu;
            regia_TextBox.Text = listaSpectacole[index].Regia;
            genSpectacol_comboBox.Text = listaSpectacole[index].Gen;
            nrBilete_TextBox.Text = listaSpectacole[index].NumarBilete.ToString();

            string[] premiera = listaSpectacole[index].DataPremiere.Split(' ');
            string[] data = premiera[0].Split('.');
            //MessageBox.Show(premiera[0]);
            ziSpectacol_TextBox.Text = data[0];
            lunaSpectacol_TextBox.Text = data[1];
            anSpectacol_TextBox.Text = data[2];

            //MessageBox.Show(premiera[1]);
            string[] timp = premiera[1].Split(':');
            oraSpectacol_TextBox.Text = timp[0];
            minutSpectacol_TextBox.Text = timp[1];

            creareSpectacolBtn.Visibility = Visibility.Hidden;
            modificareSpectacolBtn.Visibility = deleteSpectacolBtn.Visibility = Visibility.Visible;
            //numeSpectacol_TextBox.IsEnabled = false;
            labelAdaugareSpectacol.FontWeight = FontWeights.Normal;
            labelModificareSpectacol.FontWeight = FontWeights.Bold;
        }

        public void clearSpectacolTextboxes()
        {
            numeSpectacol_TextBox.Text = regia_TextBox.Text = nrBilete_TextBox.Text = "";
            ziSpectacol_TextBox.Text = lunaSpectacol_TextBox.Text = anSpectacol_TextBox.Text = "";
            oraSpectacol_TextBox.Text = minutSpectacol_TextBox.Text = "";
            genSpectacol_comboBox.Text = "";

            creareSpectacolBtn.Visibility = Visibility.Visible;
            modificareSpectacolBtn.Visibility = deleteSpectacolBtn.Visibility = Visibility.Hidden;
        }

        private void labelAdaugareSpectacol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (labelAdaugareSpectacol.FontWeight != FontWeights.Bold)
            {
                labelAdaugareSpectacol.FontWeight = FontWeights.Bold;
                labelModificareSpectacol.FontWeight = FontWeights.Normal;
                creareSpectacolBtn.Visibility = Visibility.Visible;
                modificareSpectacolBtn.Visibility = deleteSpectacolBtn.Visibility = Visibility.Hidden;
                clearSpectacolTextboxes();
            }
        }

        /*--------------------------------------------actori----------------------------------------------*/
        public void populateComboBox()
        {
            comboBox.Items.Clear();
            foreach(Spectacol s in listaSpectacole)
            {
                comboBox.Items.Add(s.Titlu);
            }
        }

        public Spectacol getSpectacolByTitlu()
        {
            return listaSpectacole.Where(x => x.Titlu == comboBox.Text).SingleOrDefault();
        }

        public void populateTableDistributie(List<DistributieOp> dist_op, List<DistributieBalet> dist_balet, EventHandler ModificareActor_Click)
        {
            spectacolSelectat = getSpectacolByTitlu();
            listaOp = dist_op;
            listaBalet = dist_balet;

            modifActorBtn = dist_op.Count == 0 ? new Button[dist_balet.Count] : new Button[dist_op.Count];
            stackPanelActori.Children.Clear();

            int nrActori = spectacolSelectat.Gen == "Balet" ? dist_balet.Count : dist_op.Count;

            for (int i = 0; i < nrActori; i++)
            {
                Border b = new Border();
                b.Width = 375;
                b.Height = 40;
                b.BorderThickness = new Thickness(4);
                b.CornerRadius = new CornerRadius(8);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                b.Background = new SolidColorBrush(Colors.White);
                b.Margin = new Thickness(0, 15, 0, 0);
                stackPanelActori.Children.Add(b);

                Canvas c = new Canvas();
                b.Child = c;

                Label numeActor = new Label();
                numeActor.Content = spectacolSelectat.Gen == "Balet" ? dist_balet[i].NumeActor : dist_op[i].NumeActor ; 
                numeActor.Width = 150;
                numeActor.Height = 35;
                numeActor.Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                numeActor.Margin = new Thickness(3, 3, 0, 0);
                c.Children.Add(numeActor);

                if(spectacolSelectat.Gen != "Balet")
                {
                    Label rolActor = new Label();
                    rolActor.Content = dist_op[i].RolActor;
                    rolActor.Width = 150;
                    rolActor.Height = 35;
                    rolActor.Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                    rolActor.Margin = new Thickness(170, 3, 0, 0);
                    c.Children.Add(rolActor);
                }

                modifActorBtn[i] = new Button();
                modifActorBtn[i].Width = modifActorBtn[i].Height = 30;
                modifActorBtn[i].Style = this.Resources["btnGlass2"] as Style;
                modifActorBtn[i].Margin = new Thickness(320, 2, 0, 0);
                modifActorBtn[i].BorderThickness = new Thickness(0);
                Uri resourceUri = new Uri("Resources/settings.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                modifActorBtn[i].Background = brush;
                modifActorBtn[i].Cursor = Cursors.Hand;
                modifActorBtn[i].Name = "modifActor" + i.ToString();
                modifActorBtn[i].Click += new RoutedEventHandler(ModificareActor_Click);
                c.Children.Add(modifActorBtn[i]);
            }
        }

        public void cautareActoriSpectacol(EventHandler cautare_Click)
        {
            searchActori.Click += new RoutedEventHandler(cautare_Click);
        }

        public string getGenSpectacol()
        {
            return spectacolSelectat.Gen;
        }

        public Spectacol getSpectacolSelectat()
        {
            return spectacolSelectat;
        }

        public void showTextboxes()
        {
            if (spectacolSelectat.Gen == "Balet")
            {
                border_actor.Visibility = nume_prenume_actor.Visibility = Visibility.Visible;
                border_rol.Visibility = rol_actor.Visibility = Visibility.Hidden;
            }
            else
            {
                border_actor.Visibility = nume_prenume_actor.Visibility = Visibility.Visible;
                border_rol.Visibility = rol_actor.Visibility = Visibility.Visible;
            }
        }

        public void setIndexActor(int index)
        {
            indexDistributie = index;
        }

        public DistributieOp getActorOp()
        {
            DistributieOp actor = new DistributieOp();
            actor = listaOp[indexDistributie];
            actor.NumeActor = actorTextBox.Text;
            actor.RolActor = rolActor_TextBox.Text;

            return actor;
        }

        public DistributieBalet getActorBalet()
        {
            DistributieBalet actor = new DistributieBalet();
            actor = listaBalet[indexDistributie];
            actor.NumeActor = actorTextBox.Text;

            return actor;
        }

        public void setActorTextboxes(int index)
        {
            if(spectacolSelectat.Gen == "Balet")
            {
                actorTextBox.Text = listaBalet[index].NumeActor;
                border_actor.Visibility = nume_prenume_actor.Visibility = Visibility.Visible;
                border_rol.Visibility = rol_actor.Visibility = Visibility.Hidden;
            }
            else
            {
                actorTextBox.Text = listaOp[index].NumeActor;
                rolActor_TextBox.Text = listaOp[index].RolActor;
                border_actor.Visibility = nume_prenume_actor.Visibility = Visibility.Visible;
                border_rol.Visibility = rol_actor.Visibility = Visibility.Visible;
            }

            creareActorBtn.Visibility = Visibility.Hidden;
            modificareActorBtn.Visibility = deleteActorBtn.Visibility = Visibility.Visible;
            //numeSpectacol_TextBox.IsEnabled = false;
            labelAdaugareActor.FontWeight = FontWeights.Normal;
            labelModificareActor.FontWeight = FontWeights.Bold;
        }

        public void clearActorTextboxes()
        {
            actorTextBox.Text = rolActor_TextBox.Text = "";
            creareActorBtn.Visibility = Visibility.Visible;
            modificareActorBtn.Visibility = deleteActorBtn.Visibility = Visibility.Hidden;

            if (spectacolSelectat.Gen == "Balet") border_rol.Visibility = Visibility.Hidden;
        }

        public void addActor(EventHandler InsertActor_Click)
        {
            creareActorBtn.Click += new RoutedEventHandler(InsertActor_Click);
        }

        public void modificareActor(EventHandler UpdateActor_Click)
        {
            modificareActorBtn.Click += new RoutedEventHandler(UpdateActor_Click);
        }

        public void stergereActor(EventHandler DeleteActor_Click)
        {
            deleteActorBtn.Click += new RoutedEventHandler(DeleteActor_Click);
        }

        private void labelAdaugareActor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            labelAdaugareActor.FontWeight = FontWeights.Bold;
            labelModificareActor.FontWeight = FontWeights.Normal;
            clearActorTextboxes();
        }
    }
}
