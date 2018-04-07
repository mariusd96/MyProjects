using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revolutii_care_au_schimbat_lumea
{
    public partial class Rev_eng_desfasurare : Form
    {
        int x;
        public Rev_eng_desfasurare()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "anglia_cursor.cur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rev_eng form = new Rev_eng();
            form.Show();
            this.Hide();
        }

        private void Rev_eng_desfasurare_Load(object sender, EventArgs e)
        {

        }

        private void text_Click(object sender, EventArgs e)
        {
            if (text.Text == "Arată text")
            {
                if (x == 1)
                {
                    label1.Visible = true;
                    text.Text = "Ascunde text";
                }
                if (x == 2)
                {
                    label2.Visible = true;
                    text.Text = "Ascunde text";
                }
                if (x == 3)
                {
                    label3.Visible = true;
                    text.Text = "Ascunde text";
                }
                if (x == 4)
                {
                    label4.Visible = true;
                    text.Text = "Ascunde text";
                }
            }
            else
            {
                if (x == 1)
                {
                    label1.Visible = false;
                    text.Text = "Arată text";
                }
                if (x == 2)
                {
                    label2.Visible = false;
                    text.Text = "Arată text";
                }
                if (x == 3)
                {
                    label3.Visible = false;
                    text.Text = "Arată text";
                }
                if (x == 4)
                {
                    label4.Visible = false;
                    text.Text = "Arată text";
                }
            }
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            BackgroundImage = Properties.Resources.Battle_of_Naseby;
            parl.Visible = true;
            razboi.Visible = true;
            cromwell.Visible = true;
            stuart.Visible = true;
            button1.Visible = true;
            inapoi.Visible = false;
            text.Visible = false;
        }

        private void stuart_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            parl.Visible = false;
            razboi.Visible = false;
            cromwell.Visible = false;
            stuart.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 4;
        }

        private void razboi_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            parl.Visible = false;
            razboi.Visible = false;
            cromwell.Visible = false;
            stuart.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 2;
        }

        private void cromwell_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            BackgroundImage = Properties.Resources.Oliver_Cromwell_by_Samuel_Cooper;
            parl.Visible = false;
            razboi.Visible = false;
            cromwell.Visible = false;
            stuart.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 3;
        }

        private void parl_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            BackgroundImage = Properties.Resources.LongParliament;
            parl.Visible = false;
            razboi.Visible = false;
            cromwell.Visible = false;
            stuart.Visible = false;
            button1.Visible = false;
            inapoi.Visible = true;
            text.Visible = true;
            x = 1;
        }
    }
}
