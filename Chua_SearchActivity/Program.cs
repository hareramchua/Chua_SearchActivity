using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chua_SearchActivity
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.Run((Form)new MainForm());
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An unhandled exception '" + ex.Message + "' has occurred. \nPlease tell me at hareram.chua@cit.edu so that I can try fix this bug. Thank you", "Error");
            }
        }
    }
}
