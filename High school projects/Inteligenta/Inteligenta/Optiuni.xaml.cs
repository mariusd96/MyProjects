using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Resources;

namespace Inteligenta
{
    /// <summary>
    /// Interaction logic for Optiuni.xaml
    /// </summary>
    public partial class Optiuni : Window
    {
        StreamResourceInfo cursor_soft;

        public Optiuni()
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            foreach (Button b in canvas1.Children.OfType<Button>())
            {
                b.MouseEnter += new MouseEventHandler(b_MouseEnter);
                b.MouseLeave += new MouseEventHandler(b_MouseLeave);
            }
        }

        private void b_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            buton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void b_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            if (buton.Name == "setari" || buton.Name == "inapoi")
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
                buton.Foreground = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            }
            else
            {
                buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
                buton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            }
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            Meniu form = new Meniu();
            form.Show();
            this.Hide();
        }

        private void deconectare_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void setari_Click(object sender, RoutedEventArgs e)
        {
            Setari form = new Setari(0);
            form.Show();
            this.Hide();
        }

        private void despre_soft_Click(object sender, RoutedEventArgs e)
        {
            Despre_soft form = new Despre_soft(0);
            form.Show();
            this.Hide();
        }
    }
}
