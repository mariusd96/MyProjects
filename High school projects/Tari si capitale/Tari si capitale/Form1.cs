using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Tari_si_capitale
{
    public partial class Form1 : Form
    {
        SoundPlayer sound;
        int n;
        public Form1(int x)
        {
            InitializeComponent();
            sound = new SoundPlayer("mix3.wav");//selectam melodia
            timer1.Start();//pornim cronometrul
            progressBar1.Value = 0;
            n = x;/*atunci cand pornim programul x are valoarea 1
                   valoarea 1 inseamna ca am pornit programul si vream sa invatam
                   valoarea 0 se obtine atunci cand vrem sa inchidem programul, mai precis prin apasarea butonul "Inchidere" din urmatoarea fereastra*/
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);//"umplem" progressbar-ul nostru cu cate o unitate
            if (progressBar1.Value == progressBar1.Maximum)//cand progressbar-ul a atins valoarea maxima ni se arata ferestra de meniu
            {
                timer1.Stop();//oprim cronometrul
                sound.PlayLooping();//pornim melodia; atunci cand melodia s-a terminat va porni de la capat indiferent in ce parte a soft-ului suntem
                Meniu form = new Meniu();
                form.Show();//ni se arata fereastra de meniu
                this.Hide();//facem invizibila aceasta fereastra pt a se vedea fereastra de meniu
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (n == 0)
            {
                sound.Stop();//cand inchidem programul oprim si melodia
                this.Close();//inchidem programul
            }
        }

    }
}
