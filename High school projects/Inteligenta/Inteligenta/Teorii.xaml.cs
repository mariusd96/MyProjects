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
    /// Interaction logic for Teorii.xaml
    /// </summary>
    public partial class Teorii : Window
    {
        int parametru;
        TextBlock text_block = new TextBlock();
        string text_label;
        StreamResourceInfo cursor_soft;

        public Teorii(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;

            foreach (Button b in canvas1.Children.OfType<Button>())
            {
                b.MouseEnter += new MouseEventHandler(b_MouseEnter);
                b.MouseLeave += new MouseEventHandler(b_MouseLeave);
            }

            foreach (Label l in canvas1.Children.OfType<Label>())
            {
                l.MouseEnter += new MouseEventHandler(l_MouseEnter);
                l.MouseLeave += new MouseEventHandler(l_MouseLeave);
            }
        }

        private void b_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
        }

        private void b_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button buton = (Button)sender;
            buton.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void l_MouseEnter(object sender, RoutedEventArgs e)
        {
            int ok = 1;
            Label lb = (Label)sender;
            text_label = text_block.Text = lb.Content.ToString();
            text_block.TextDecorations = TextDecorations.Underline;
            if (lb.Name == "label1".ToString() || lb.Name == "label2".ToString()) ok = 0;
            if (ok == 1) lb.Content = text_block;
        }

        private void l_MouseLeave(object sender, RoutedEventArgs e)
        {
            int ok = 1;
            Label lb = (Label)sender;
            if (lb.Name == "label1".ToString() || lb.Name == "label2".ToString()) ok = 0;
            if (ok == 1) lb.Content = text_label;
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            if (parametru == 0)
            {
                Studiaza form = new Studiaza();
                form.Show();
            }
            else if (parametru == 1)
            {
                Meniu form = new Meniu();
                form.Show();
            }
            this.Hide();
        }

        private void inapoi_MouseEnter(object sender, MouseEventArgs e)
        {
            inapoi.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            inapoi.BorderBrush = new SolidColorBrush(Colors.White);
            inapoi_img.Source = new BitmapImage(new Uri("Images/back_arrow.png", UriKind.Relative));
        }

        private void inapoi_MouseLeave(object sender, MouseEventArgs e)
        {
            inapoi.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            inapoi.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            inapoi_img.Source = new BitmapImage(new Uri("Images/back_arrow_brown.png", UriKind.Relative));
        }

        private void acasa_Click(object sender, RoutedEventArgs e)
        {
            Meniu form = new Meniu();
            form.Show();
            this.Hide();
        }

        private void acasa_MouseEnter(object sender, MouseEventArgs e)
        {
            acasa.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            acasa.BorderBrush = new SolidColorBrush(Colors.White);
            acasa_img.Source = new BitmapImage(new Uri("Images/home.png", UriKind.Relative));
        }

        private void acasa_MouseLeave(object sender, MouseEventArgs e)
        {
            acasa.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            acasa.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            acasa_img.Source = new BitmapImage(new Uri("Images/home_brown.png", UriKind.Relative));
        }

        private void nav_menu_Click(object sender, RoutedEventArgs e)
        {
            Studiaza form = new Studiaza();
            form.Show();
            this.Hide();
        }

        private void nav_menu_MouseEnter(object sender, MouseEventArgs e)
        {
            nav_menu.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            nav_menu.BorderBrush = new SolidColorBrush(Colors.White);
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu.png", UriKind.Relative));
        }

        private void nav_menu_MouseLeave(object sender, MouseEventArgs e)
        {
            nav_menu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            nav_menu.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu_brown.png", UriKind.Relative));
        }

        private void teoria_bifactoriala_Click(object sender, RoutedEventArgs e)
        {
            Teoria_bifactoriala form = new Teoria_bifactoriala(parametru);
            form.Show();
            this.Hide();
        }

        private void teoria_multifactoriala_Click(object sender, RoutedEventArgs e)
        {
            Teoria_multifactoriala form = new Teoria_multifactoriala(parametru);
            form.Show();
            this.Hide();
        }

        private void teoria_genetica_Click(object sender, RoutedEventArgs e)
        {
            Teoria_genetica form = new Teoria_genetica(parametru);
            form.Show();
            this.Hide();
        }

        private void teoria_inteligentelor_multiple_Click(object sender, RoutedEventArgs e)
        {
            Teoria_inteligentelor_multiple form = new Teoria_inteligentelor_multiple(parametru);
            form.Show();
            this.Hide();
        }

        private void t_bifactoriala_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teoria_bifactoriala form = new Teoria_bifactoriala(parametru);
            form.Show();
            this.Hide();
        }

        private void t_multifactoriala_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teoria_multifactoriala form = new Teoria_multifactoriala(parametru);
            form.Show();
            this.Hide();
        }

        private void t_genetica_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teoria_genetica form = new Teoria_genetica(parametru);
            form.Show();
            this.Hide();
        }

        private void t_inteligentelor_multiple_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teoria_inteligentelor_multiple form = new Teoria_inteligentelor_multiple(parametru);
            form.Show();
            this.Hide();
        }
    }
}
