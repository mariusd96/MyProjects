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
    public partial class Invata : Form
    {
        public Invata()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //pozitionam panoul pe centrul ecranului

            europa.Parent = pictureBox1;
            europa.BackColor = Color.Transparent;
            africa.Parent = pictureBox1;
            africa.BackColor = Color.Transparent;
            asia.Parent = pictureBox1;
            asia.BackColor = Color.Transparent;
            oceania.Parent = pictureBox1;
            oceania.BackColor = Color.Transparent;
            americanord.Parent = pictureBox1;
            americanord.BackColor = Color.Transparent;
            americasud.Parent = pictureBox1;
            americasud.BackColor = Color.Transparent;
        }

        private void africa1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Africa form = new Africa();
            form.Show();
            this.Hide();
        }

        private void africa1_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = true;
            americanord.Visible = false;
            americasud.Visible = false;
            asia.Visible = false;
            europa.Visible = false;
            oceania.Visible = false;
        }//facem vizibila eticheta cu textul "Africa" atunci cand cursorul este pe butonul cu acelasi text

        private void america_nord_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            America_Nord form = new America_Nord();
            form.Show();
            this.Close();
        }

        private void america_nord_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = false;
            americanord.Visible = true;
            americasud.Visible = false;
            asia.Visible = false;
            europa.Visible = false;
            oceania.Visible = false;
        }//facem vizibila eticheta cu textul "America de Nord" atunci cand cursorul este pe butonul cu acelasi text

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Meniu form = new Meniu();
            form.Show();
            this.Close();
        }

        private void america_sud_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            America_Sud form = new America_Sud();
            form.Show();
            this.Close();
        }

        private void america_sud_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = false;
            americanord.Visible = false;
            americasud.Visible = true;
            asia.Visible = false;
            europa.Visible = false;
            oceania.Visible = false;
        }//facem vizibila eticheta cu textul "America de Sud" atunci cand cursorul este pe butonul cu acelasi text

        private void asia1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Asia form = new Asia();
            form.Show();
            this.Hide();
        }

        private void asia1_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = false;
            americanord.Visible = false;
            americasud.Visible = false;
            asia.Visible = true; ;
            europa.Visible = false;
            oceania.Visible = false;
        }//facem vizibila eticheta cu textul "Asia" atunci cand cursorul este pe butonul cu acelasi text

        private void europa1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Europa form = new Europa();
            form.Show();
            this.Hide();
        }

        private void europa1_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = false;
            americanord.Visible = false;
            americasud.Visible = false;
            asia.Visible = false;
            europa.Visible = true;
            oceania.Visible = false;
        }//facem vizibila eticheta cu textul "Europa" atunci cand cursorul este pe butonul cu acelasi text

        private void oceania1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Oceania form = new Oceania();
            form.Show();
            this.Hide();
        }

        private void oceania1_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = false;
            americanord.Visible = false;
            americasud.Visible = false;
            asia.Visible = false;
            europa.Visible = false;
            oceania.Visible = true;
        }//facem vizibila eticheta cu textul "Oceania" atunci cand cursorul este pe butonul cu acelasi text

        private void Invata_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            africa.Visible = false;
            americanord.Visible = false;
            americasud.Visible = false;
            asia.Visible = false;
            europa.Visible = false;
            oceania.Visible = false;
        }//cand cursorul nu e pe niciun buton nu avem vreo eticheta vizibila        
    }
}
