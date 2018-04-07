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

namespace FoodDelivery.presentation
{
    /// <summary>
    /// Interaction logic for MeniuAdmin.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private AddModifyCont cont;
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void createCont_Click(object sender, RoutedEventArgs e)
        {
            cont = new AddModifyCont();
            cont.Show();
        }

        private void updateCont_Click(object sender, RoutedEventArgs e)
        {
            ListaConturi conturi = new ListaConturi();
            conturi.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            if(cont != null) cont.Close();
            this.Hide();
        }

        private void userOptions_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void updateMenu_Click(object sender, RoutedEventArgs e)
        {
            ListaProduse produse = new ListaProduse();
            produse.Show();
            this.Close();
        }
    }
}
