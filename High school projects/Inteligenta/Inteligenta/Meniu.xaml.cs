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
    /// Interaction logic for Meniu.xaml
    /// </summary>
    public partial class Meniu : Window
    {
        StreamResourceInfo cursor_soft;
        TextBlock text_block = new TextBlock();
        string text_label;

        public Meniu()
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            foreach (Canvas c in grid1.Children.OfType<Canvas>())
            {
                foreach (Label l in c.Children.OfType<Label>())
                {
                    l.MouseEnter += new MouseEventHandler(l_MouseEnter);
                    l.MouseLeave += new MouseEventHandler(l_MouseLeave);
                }
            }
        }

        private void l_MouseEnter(object sender, RoutedEventArgs e)
        {
            Label lb = (Label)sender;
            if (lb.Name != "")
            {
                text_label = text_block.Text = lb.Content.ToString();
                text_block.TextDecorations = TextDecorations.Underline;
                lb.Content = text_block;
            }
        }

        private void l_MouseLeave(object sender, RoutedEventArgs e)
        {
            Label lb = (Label)sender;
            if (lb.Name != "") lb.Content = text_label;
        }

        private void studiaza_Click(object sender, RoutedEventArgs e)
        {
            Studiaza form = new Studiaza();
            form.Show();
            this.Hide();
        }

        private void teste_Click(object sender, RoutedEventArgs e)
        {
            Teste form = new Teste();
            form.Show();
            this.Hide();
        }

        private void jocuri_Click(object sender, RoutedEventArgs e)
        {
            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void optiuni_Click(object sender, RoutedEventArgs e)
        {
            Optiuni form = new Optiuni();
            form.Show();
            this.Hide();
        }

        private void definire_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Definire form = new Definire(1);
            form.Show();
            this.Hide();
        }

        private void teorii_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teorii form = new Teorii(1);
            form.Show();
            this.Hide();
        }

        private void masurarea_inteligentei_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Masurarea_inteligentei form = new Masurarea_inteligentei(1);
            form.Show();
            this.Hide();
        }

        private void teste_de_inteligenta_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teste_de_inteligenta form = new Teste_de_inteligenta(1);
            form.Show();
            this.Hide();
        }

        private void teste_teoretice_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teste_teoretice form = new Teste_teoretice(1);
            form.Show();
            this.Hide();
        }

        private void testul_inteligentelor_multiple_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Testul_inteligentelor_multiple form = new Testul_inteligentelor_multiple(1);
            form.Show();
            this.Hide();
        }

        private void puzzle_img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Puzzle_cu_imagini_meniu form = new Puzzle_cu_imagini_meniu(1);
            form.Show();
            this.Hide();
        }

        private void puzzle_numere_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Puzzle_cu_numere_meniu form = new Puzzle_cu_numere_meniu(1);
            form.Show();
            this.Hide();
        }

        private void problema_reginelor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Problema_celor_n_regine_meniu form = new Problema_celor_n_regine_meniu(1);
            form.Show();
            this.Hide();
        }

        private void luminile_orasului_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Luminile_orasului_meniu form = new Luminile_orasului_meniu(1);
            form.Show();
            this.Hide();
        }

        private void gaseste_regula_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Gaseste_regula_meniu form = new Gaseste_regula_meniu(1);
            form.Show();
            this.Hide();
        }

        private void setari_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Setari form = new Setari(1);
            form.Show();
            this.Hide();
        }

        private void despre_soft_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Despre_soft form = new Despre_soft(1);
            form.Show();
            this.Hide();
        }

        private void deconectare_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void label_studiaza_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Studiaza form = new Studiaza();
            form.Show();
            this.Hide();
        }

        private void label_teste_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Teste form = new Teste();
            form.Show();
            this.Hide();
        }

        private void label_jocuri_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void label_optiuni_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Optiuni form = new Optiuni();
            form.Show();
            this.Hide();
        }

        private void studiaza_MouseEnter(object sender, MouseEventArgs e)
        {
            studiaza.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
        }

        private void studiaza_MouseLeave(object sender, MouseEventArgs e)
        {
            studiaza.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

        private void teste_MouseEnter(object sender, MouseEventArgs e)
        {
            teste_img.Source = new BitmapImage(new Uri("Images/test_paper_2.png", UriKind.Relative));
        }

        private void teste_MouseLeave(object sender, MouseEventArgs e)
        {
            teste_img.Source = new BitmapImage(new Uri("Images/test_paper.png", UriKind.Relative));
        }

        private void jocuri_MouseEnter(object sender, MouseEventArgs e)
        {
            jocuri_img.Source = new BitmapImage(new Uri("Images/puzzle_piece_2.png", UriKind.Relative));
        }

        private void jocuri_MouseLeave(object sender, MouseEventArgs e)
        {;
            jocuri_img.Source = new BitmapImage(new Uri("Images/puzzle_piece.png", UriKind.Relative));
        }

        private void optiuni_MouseEnter(object sender, MouseEventArgs e)
        {
            optiuni.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
        }

        private void optiuni_MouseLeave(object sender, MouseEventArgs e)
        {
            optiuni.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
        }

    }
}
