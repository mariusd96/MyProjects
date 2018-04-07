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
    /// Interaction logic for Testul_inteligentelor_multiple.xaml
    /// </summary>
    public partial class Testul_inteligentelor_multiple : Window
    {
        string[] v = new string[100];
        int[] raspunsuri = new int[10];

        int n = 1, parametru;
        StreamResourceInfo cursor_soft;

        public Testul_inteligentelor_multiple(int nr)
        {
            InitializeComponent();
            if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "1") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor1.cur", UriKind.Relative));
            else if (String.Compare(Properties.Settings.Default.cursor[Properties.Settings.Default.nr_user], "2") == 0) cursor_soft = Application.GetResourceStream(new Uri("cursor2.cur", UriKind.Relative));
            this.Cursor = new Cursor(cursor_soft.Stream);

            parametru = nr;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            v[1] = "Gândeşti în imagini.";
            v[2] = "Înveţi făcând.";
            v[3] = "Eşti o persoană sigură pe tine.";
            v[4] = "Eşti atent la emoţii, vise, idei.";
            v[5] = "Cânţi la un instrument sau poate într-un cor.";
            v[6] = "Scrii corect.";
            v[7] = "Îţi place calculatorul.";
            v[8] = "Îţi place să fi înconjurat de plante."; 
            v[9] = "Înveţi văzând şi observând.";
            v[10] = "Te pricepi la tricotat.";
            v[11] = "Îţi place să lucrezi în echipă.";
            v[12] = "Ai încredere în propria intuiţie.";
            v[13] = "Colecţionezi CD-uri, casete şi discuri.";
            v[14] = "Îţi plac jocurile de cuvinte.";
            v[15] = "Îţi plac lucrurile logice.";
            v[16] = "Adesea te joci cu animalele.";
            v[17] = "Îţi aminteşti uşor figurile.";
            v[18] = "Îţi controlezi deplin motricitatea.";
            v[19] = "Simţi ce gândesc, simt şi cred ceilalţi oameni.";
            v[20] = "Trăieşti în propria ta lume.";
            v[21] = "Lucrezi ritmat, asociat cu muzica.";
            v[22] = "Îţi place să dezlegi cuvinte încrucişate.";
            v[23] = "Memorezi bine teorii şi principii.";
            v[24] = "Faci experimente cu plante şi animale.";
            v[25] = "Eşti priceput la rezolvarea de puzzle.";
            v[26] = "Comunici bine non-verbal.";
            v[27] = "Eşti un bun mediator de conflicte.";
            v[28] = "Ai opinii puternice.";
            v[29] = "Îţi aminteşti mai bine faptele pe fond muzical.";
            v[30] = "Ai talent la spus poveşti şi bancuri.";
            v[31] = "Îţi plac romanele SF.";
            v[32] = "Te simţi bine în pădure.";
            v[33] = "În timpul liber confecţionezi obiecte artizanale sau de artă" + "\r\n" + "plastică.";
            v[34] = "Te amesteci în tot telul de lucruri, poate inconştient.";
            v[35] = "Îţi place să te joci, să participi la activităţi de grup.";
            v[36] = "Ai un stil propriu, original de a te îmbrăca şi a te" + "\r\n" + "comporta.";
            v[37] = "Dai drumul la muzică pentru că te ajută să-ţi exprimi" + "\r\n" + "sentimentele.";
            v[38] = "Eşti un bun scriitor. Îţi place să scrii.";
            v[39] = "Se spune că eşti „strălucitor”, „deştept”, „inteligent”.";
            v[40] = "Îţi place să porţi haine din materiale naturale.";
            v[41] = "Îţi plac filmele, casetele video şi să fotografiezi.";
            v[42] = "Îţi plac activităţile fizice.";
            v[43] = "Vorbeşti mult cu vecinii.";
            v[44] = "Ai un hobby (de exemplu colecţionarea timbrelor).";
            v[45] = "Compui cântece pentru ocazii festive.";
            v[46] = "Se spune că eşti „isteţ”, „rapid” sau vorbăreţ”.";
            v[47] = "Reflectezi adesea la structuri, idei, concepte.";
            v[48] = "Week-end-ul ideal este o ieşire în natură.";
            v[49] = "Respecţi cu minuţiozitate locul lucrurilor în casă.";
            v[50] = "Preferi povestiri cu multă acţiune.";
            v[51] = "Îi înţelegi bine pe ceilalţi.";
            v[52] = "Ai o solidă încredere în tine despre care nu prea vorbeşti.";
            v[53] = "Se spune că eşti „muzical” sau „talentat”.";
            v[54] = "Gândeşti în cuvinte.";
            v[55] = "Înveţi mai bine senzorial şi examinând contextul.";
            v[56] = "Eşti un foarte bun bucătar.";
            v[57] = "Îţi plac tehnica şi maşinăriile.";
            v[58] = "Când vorbeşti, emoţionezi cu uşurinţă oamenii.";
            v[59] = "Ştii cu ce se ocupă colegii tăi în afara serviciului.";
            v[60] = "Se spune că eşti o „personalitate”, „bine informat”.";
            v[61] = "Obişnuieşti să fluieri sau să murmuri pentru tine.";
            v[62] = "Înveţi cel mai bine cu voce tare.";
            v[63] = "Eşti permanent întrebător şi sceptic.";
            v[64] = "În camera ta trebuie să fie cel puţin o floare.";
            v[65] = "Citeşti uşor hărţi şi grafice.";
            v[66] = "Imiţi bine.";
            v[67] = "Se spune că eşti un „bun ascultător”, „suportiv”.";
            v[68] = "Îţi cunoşti sentimentele.";
            v[69] = "Îţi place să dansezi sau să ieşi să asculţi muzică.";
            v[70] = "Îţi place să scrii.";
            v[71] = "Îţi plac ghicitorile, exerciţiile şi puzzle-urile logice.";
            v[72] = "Ai realizat cel puţin un insectar.";
            v[73] = "Adesea visezi cu ochi deschişi.";
            v[74] = "Se spune că eşti „bun dansator” sau atletic.";
            v[75] = "În timp ce vorbeşti, gândeşti.";
            v[76] = "Înveţi cel mai bine independent de alţii.";
            v[77] = "Ai întotdeauna opinii despre muzică.";
            v[78] = "Îţi aminteşti uşor nume şi detalii.";
            v[79] = "Gândeşti bine abstract şi teoretic.";
            v[80] = "Te simţi mai bine la o fermă decât în oraş.";
            v[81] = "Se spune despre tine că eşti „creativ”, „talentat”.";
            v[82] = "Te simţi bine când faci mişcare.";
            v[83] = "Înveţi cel mai bine în grupuri de studiu.";
            v[84] = "Ai o personalitate foarte puternică, te simţi independent.";
            v[85] = "Te deranjează zgomotul din camera.";
            v[86] = "Iţi place să citeşti cărţi bune.";
            v[87] = "Eşti bun la matematică.";
            v[88] = "Cunoşti orice copac după tipul de frunză.";

            enunt.Content = v[1].ToString();
        }

        private void nu_Click(object sender, RoutedEventArgs e)
        {
            if (n < 88)
            {
                n++;
                enunt.Content = v[n].ToString();
                label1.Content = n + "/88";
            }
            else
            {
                arata_rezultat();
            }
        }

        private void nu_MouseEnter(object sender, MouseEventArgs e)
        {
            nu.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            nu.Foreground = new SolidColorBrush(Colors.White);
        }

        private void nu_MouseLeave(object sender, MouseEventArgs e)
        {
            nu.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            nu.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void da_Click(object sender, RoutedEventArgs e)
        {
            if (n <= 88)
            {
                if (n % 8 == 0) raspunsuri[8]++;
                else raspunsuri[n % 8]++;
                n++;
                if (n <= 88)
                {
                    enunt.Content = v[n].ToString();
                    label1.Content = n + "/88";
                }
            }
            if (n > 88)
            {
                arata_rezultat();
            }
        }

        private void da_MouseEnter(object sender, MouseEventArgs e)
        {
            da.Background = new SolidColorBrush(Color.FromRgb(195, 9, 9));
            da.Foreground = new SolidColorBrush(Colors.White);
        }

        private void da_MouseLeave(object sender, MouseEventArgs e)
        {
            da.Background = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            da.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 211));
        }

        private void inapoi_Click(object sender, RoutedEventArgs e)
        {
            if (parametru == 0)
            {
                Teste form = new Teste();
                form.Show();
            }
            else if (parametru == 1)
            {
                Meniu form = new Meniu();
                form.Show();
            }
            this.Hide();
        }

        private void arata_rezultat()
        {
            border1.Visibility = Visibility.Hidden;
            border2.Visibility = Visibility.Visible;

            for (int i = 1; i <= 8; i++)
            {
                tabel.RowGroups[0].Rows.Add(new TableRow());
                TableRow currentRow = tabel.RowGroups[0].Rows[i];
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(raspunsuri[i].ToString()))));
                TableCell currentcell = tabel.RowGroups[0].Rows[i].Cells[1];
                currentcell.BorderThickness = new Thickness(2);
                currentcell.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            }
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
            Teste form = new Teste();
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
            nav_menu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 211));
            nav_menu.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 32, 15));
            nav_menu_img.Source = new BitmapImage(new Uri("Images/menu_brown.png", UriKind.Relative));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.R) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                arata_rezultat();
            }
        }
    }
}
