using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tari_si_capitale
{
    public partial class Biblioteca : Form
    {
        int x;
        public Biblioteca(int nr)
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            cAfrica.Parent = pictureBox1;
            cAfrica.BackColor = Color.Transparent;
            cAmericaN.Parent = pictureBox1;
            cAmericaN.BackColor = Color.Transparent;
            cAmericaS.Parent = pictureBox1;
            cAsia.Parent = pictureBox1;
            cAsia.BackColor = Color.Transparent;
            cAmericaS.BackColor = Color.Transparent;
            cEuropa.Parent = pictureBox1;
            cEuropa.BackColor = Color.Transparent;
            cOceania.Parent = pictureBox1;
            cOceania.BackColor = Color.Transparent;
            if (nr == 5 || nr == 6)
            {
                continente.Parent = pictureBox1;
                continente.BackColor = Color.Transparent;
            }
            else
            {
                continente.Visible = false;
                label7.Visible = false;
            }
            x = nr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            Jocuri form = new Jocuri();
            form.Show();
            this.Hide();
        }

        private void cAfrica_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 1)
            {
                T_Africa form = new T_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 2)
            {
                C_Africa form = new C_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 3)
            {
                S_Africa form = new S_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 4)
            {
                TCS_Africa form = new TCS_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 5)
            {
                TA_Africa form = new TA_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_Africa form = new CA_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 7)
            {
                CC_Africa form = new CC_Africa();
                form.Show();
                this.Hide();
            }
            if (x == 8)
            {
                LC_Africa form = new LC_Africa();
                form.Show();
                this.Hide();
            }
        }

        private void cAmericaN_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 1)
            {
                T_AmericaN form = new T_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 2)
            {
                C_AmericaN form = new C_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 3)
            {
                S_AmericaN form = new S_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 4)
            {
                TCS_AmericaN form = new TCS_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 5)
            {
                TA_AmericaN form = new TA_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_AmericaN form = new CA_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 7)
            {
                CC_AmericaN form = new CC_AmericaN();
                form.Show();
                this.Hide();
            }
            if (x == 8)
            {
                LC_AmericaN form = new LC_AmericaN();
                form.Show();
                this.Hide();
            }
        }

        private void cAmericaS_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 1)
            {
                T_AmericaS form = new T_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 2)
            {
                C_AmericaS form = new C_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 3)
            {
                S_AmericaS form = new S_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 4)
            {
                TCS_AmericaS form = new TCS_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 5)
            {
                TA_AmericaS form = new TA_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_AmericaS form = new CA_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 7)
            {
                CC_AmericaS form = new CC_AmericaS();
                form.Show();
                this.Hide();
            }
            if (x == 8)
            {
                LC_AmericaS form = new LC_AmericaS();
                form.Show();
                this.Hide();
            }
        }

        private void cAsia_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 1)
            {
                T_Asia form = new T_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 2)
            {
                C_Asia form = new C_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 3)
            {
                S_Asia form = new S_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 4)
            {
                TCS_Asia form = new TCS_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 5)
            {
                TA_Asia form = new TA_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_Asia form = new CA_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 7)
            {
                CC_Asia form = new CC_Asia();
                form.Show();
                this.Hide();
            }
            if (x == 8)
            {
                LC_Asia form = new LC_Asia();
                form.Show();
                this.Hide();
            }
        }

        private void cEuropa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 1)
            {
                T_Europa form = new T_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 2)
            {
                C_Europa form = new C_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 3)
            {
                S_Europa form = new S_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 4)
            {
                TCS_Europa form = new TCS_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 5)
            {
                TA_Europa form = new TA_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_Europa form = new CA_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 7)
            {
                CC_Europa form = new CC_Europa();
                form.Show();
                this.Hide();
            }
            if (x == 8)
            {
                LC_Europa form = new LC_Europa();
                form.Show();
                this.Hide();
            }
        }

        private void cOceania_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 1)
            {
                T_Oceania form = new T_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 2)
            {
                C_Oceania form = new C_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 3)
            {
                S_Oceania form = new S_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 4)
            {
                TCS_Oceania form = new TCS_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 5)
            {
                TA_Oceania form = new TA_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_Oceania form = new CA_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 7)
            {
                CC_Oceania form = new CC_Oceania();
                form.Show();
                this.Hide();
            }
            if (x == 8)
            {
                LC_Oceania form = new LC_Oceania();
                form.Show();
                this.Hide();
            }
        }

        private void continente_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (x == 5)
            {
                TA_continente form = new TA_continente();
                form.Show();
                this.Hide();
            }
            if (x == 6)
            {
                CA_continente form = new CA_continente();
                form.Show();
                this.Hide();
            }
        }
    }
}
