using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoClick_FirstBlood
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
            Application.Run(Form1.Instance);
        }
    }
}
