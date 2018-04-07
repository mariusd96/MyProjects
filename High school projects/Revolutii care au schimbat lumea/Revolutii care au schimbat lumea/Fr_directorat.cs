﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revolutii_care_au_schimbat_lumea
{
    public partial class Fr_directorat : Form
    {
        public Fr_directorat()
        {
            InitializeComponent();
            this.Cursor = new Cursor(GetType(), "franta_cursor.cur");
        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Fr_desfasurare form = new Fr_desfasurare();
            form.Show();
            this.Hide();
        }

        private void text_Click(object sender, EventArgs e)
        {
            if (text.Text == "Arată text")
            {
                label1.Visible = true;
                text.Text = "Ascunde text";
            }
            else
            {
                label1.Visible = false;
                text.Text = "Arată text";
            }
        }
    }
}
