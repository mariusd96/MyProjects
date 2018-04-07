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
    /// Interaction logic for Mesaj.xaml
    /// </summary>
    public partial class Mesaj : Window
    {
        StreamResourceInfo cursor_soft;

        public Mesaj(string msg)
        {
            InitializeComponent();
            text.Content = msg.ToString();
            if (Properties.Settings.Default.nr_user < Properties.Settings.Default.user.Count)
            {
                if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
                else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
                this.Cursor = new Cursor(cursor_soft.Stream);
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            close.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            close.Background = new SolidColorBrush(Color.FromRgb(222, 9, 9));
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ok_MouseEnter(object sender, MouseEventArgs e)
        {
            ok.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            ok.Foreground = new SolidColorBrush(Colors.White);
        }

        private void ok_MouseLeave(object sender, MouseEventArgs e)
        {
            ok.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            ok.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }
    }
}
