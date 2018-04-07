using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tari_si_capitale
{
    public partial class Resurse : Form
    {
        public Resurse()
        {
            InitializeComponent();
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Width / 2, this.ClientSize.Height / 2 - panel1.Height / 2);
            //pozitionam panoul pe centrul ecranului
            richTextBox1.Location = new Point(panel1.Width / 2 - richTextBox1.Width / 2, 50);//pozitionam caseta de text aproximativ pe centrul panoului
            citire();
        }

        private void citire()
        {
            string filetext = File.ReadAllText("Resurse/resurse.txt");//citim informatia din fisierul resurse.txt
            richTextBox1.Text = filetext;//caseta de text contine textul din fisierul resurse.txt
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Meniu form = new Meniu();
            form.Show();
            this.Hide();
        }
    }
}
