using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Revolutii_care_au_schimbat_lumea
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
