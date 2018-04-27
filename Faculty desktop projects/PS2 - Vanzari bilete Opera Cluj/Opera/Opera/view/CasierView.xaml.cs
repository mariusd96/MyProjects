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

namespace Opera.view
{
    /// <summary>
    /// Interaction logic for CasierView.xaml
    /// </summary>
    public partial class CasierView : Window
    {
        private List<Spectacol> listaSpectacole;
        private List<Bilet> listaBilete;
        private Button[] spectacolBtn;
        private Button[,] locuriBtn;
        private int nrSpectacole;
        private int desenSala = 0;
        private int indexLinie = 0;
        private int indexColoana = 0;
        private int indexSpectacol = -1;
        private int nrBileteDisponibile = 0;

        public CasierView()
        {
            InitializeComponent();
        }

        public void logout(EventHandler Logout_Click)
        {
            logoutBtn.Click += new RoutedEventHandler(Logout_Click);
        }

        public void minimize(EventHandler Minimize_Click)
        {
            minimizeBtn.Click += new RoutedEventHandler(Minimize_Click);
        }

        public void buyTicket(EventHandler Buy_Click)
        {
            vindeBilet.Click += new RoutedEventHandler(Buy_Click);
        }

        public void exportBilet(EventHandler Export_Click)
        {
            exporterBtn.Click += new RoutedEventHandler(Export_Click);
        }

        public void showInfoSpectacol(MouseButtonEventHandler InfoSpectacol_Click)
        {
            numeSpectacol.MouseLeftButtonDown += new MouseButtonEventHandler(InfoSpectacol_Click);
        }

        public void populateTable(List<Spectacol> spectacole, EventHandler CreareMatriceLocuri_Click)
        {
            nrSpectacole = spectacole.Count;
            listaSpectacole = spectacole;
            spectacolBtn = new Button[nrSpectacole];
            stackPanel.Children.Clear();

            for (int i = 0; i < nrSpectacole; i++)
            {
                spectacolBtn[i] = new Button();
                spectacolBtn[i].Name = "spectacol" + i.ToString();
                spectacolBtn[i].Content = listaSpectacole[i].Titlu;
                spectacolBtn[i].Width = 250;
                spectacolBtn[i].Height = 35;
                spectacolBtn[i].FontSize = 14;
                spectacolBtn[i].Margin = new Thickness(10, 15, 0, 0);
                spectacolBtn[i].Style = this.Resources["btnGlass"] as Style;
                spectacolBtn[i].BorderThickness = new Thickness(4);
                spectacolBtn[i].BorderBrush = spectacolBtn[i].Foreground = new SolidColorBrush(Color.FromRgb(254, 94, 0));
                spectacolBtn[i].Background = new SolidColorBrush(Colors.White);
                spectacolBtn[i].Cursor = Cursors.Hand;
                spectacolBtn[i].Click += new RoutedEventHandler(CreareMatriceLocuri_Click);
                stackPanel.Children.Add(spectacolBtn[i]);
            }
        }

        public void setMatriceLocuri(int index, List<Bilet> listaBilete, MouseEventHandler MoveMatrice_Event, MouseEventHandler MatriceLeave_Event, EventHandler Matrice_Click)
        {
            numeSpectacol.Content = listaSpectacole[index].Titlu;
            nrBileteDisponibile = listaSpectacole[index].NumarBilete - listaBilete.Count;
            nrBilete.Content = "Nr. bilete disponibile: " + nrBileteDisponibile.ToString();
            indexSpectacol = index;
            this.listaBilete = listaBilete;
            indexLinie = indexColoana = 0;
            randColoanaLabel.Content = "Rand = 0, Coloana = 0";

            if (desenSala == 0)
            {
                locuriBtn = new Button[10, 20];
                int x = 0, y = 10;
                for (int i = 0; i < 10; i++)
                {
                    x = 0;
                    for (int j = 0; j < 20; j++)
                    {
                        locuriBtn[i, j] = new Button();
                        locuriBtn[i, j].Width = locuriBtn[i, j].Height = 20;
                        locuriBtn[i, j].Name = "btnLoc" + (20 * i + j).ToString();
                        locuriBtn[i, j].Style = this.Resources["btnGlass"] as Style;
                        locuriBtn[i, j].Background = new SolidColorBrush(Colors.LimeGreen);
                        locuriBtn[i, j].Margin = new Thickness(x, y, 0, 0);
                        locuriBtn[i, j].Visibility = Visibility.Visible;
                        locuriBtn[i, j].Cursor = Cursors.Hand;
                        locuriBtn[i, j].MouseMove += new MouseEventHandler(MoveMatrice_Event);
                        locuriBtn[i, j].MouseLeave += new MouseEventHandler(MatriceLeave_Event);
                        locuriBtn[i, j].Click += new RoutedEventHandler(Matrice_Click);
                        canvasLocuri.Children.Add(locuriBtn[i, j]);
                        if (j == 9) x += 60;
                        else x += 30;
                    }
                    y += 30;
                }

                desenSala = 1;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++) locuriBtn[i, j].Background = new SolidColorBrush(Colors.LimeGreen);
                }
            }

            for (int i = 0; i < listaBilete.Count; i++)
            {
                //MessageBox.Show(listaBilete[i].ToString());
                //if(listaBilete[i].IdSpectacol == index)
                locuriBtn[listaBilete[i].Rand - 1, listaBilete[i].Coloana - 1].Background = new SolidColorBrush(Colors.DarkRed);
            }
        }

        //setam in interfata grafica pe ce buton se afla cursorul
        public void setIndexLoc(int i, int j)
        {
            randColoanaLabel.Content = "Rand = " + (i + 1) + ", Coloana = " + (j + 1);
        }

        //setam in interfata grafica ce loc a fost selectat
        public void setIndexLoc()
        {
            randColoanaLabel.Content = "Rand = " + indexLinie + ", Coloana = " + indexColoana;
        }

        //din controller setam in interfata locul marcat pt a genera biletul
        public void setIndexLocClick(int a, int b)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    locuriBtn[i, j].Background = new SolidColorBrush(Colors.LimeGreen);
                }
            }

            for (int i = 0; i < listaBilete.Count; i++)
            {
                locuriBtn[listaBilete[i].Rand - 1, listaBilete[i].Coloana - 1].Background = new SolidColorBrush(Colors.DarkRed);
            }

            if (locuriBtn[a, b].Background.ToString() != Colors.DarkRed.ToString())
            {
                locuriBtn[a, b].Background = new SolidColorBrush(Colors.OrangeRed);
                indexLinie = a + 1;
                indexColoana = b + 1;
            }
            else
            {
                this.showMessage("Acest loc este ocupat");
                indexLinie = indexColoana = 0;
            }

            randColoanaLabel.Content = "Rand = " + indexLinie + ", Coloana = " + indexColoana;
        }

        //returnam varianta selectata
        public string getExportType()
        {
            return comboBox.Text;
        }

        public Bilet getBilet()
        {
            Bilet b = new Bilet(listaSpectacole[indexSpectacol].IdSpectacol, indexLinie, indexColoana);
            if (nrBileteDisponibile > 0) return b;
            else return null;
        }

        public string getSpectacolByTitlu()
        {
            if (indexSpectacol == -1) return "";
            return listaSpectacole[indexSpectacol].Titlu;
        }

        public Spectacol getSpectacol()
        {
            if (indexSpectacol == -1) return null;
            return listaSpectacole[indexSpectacol];
        }

        public List<Bilet> getListaBilete()
        {
            return listaBilete;
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
    }
}
