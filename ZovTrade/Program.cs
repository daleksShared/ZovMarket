using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZovTrade
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


            if (Properties.Settings.Default.needFirstRunSplash)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.needFirstRunSplash = false;
                Properties.Settings.Default.Save();
               // MessageBox.Show("Первый запуск!!!");
            }

            ZOV.Tools.MyConnectionString.lastUserLogOn=(Properties.Settings.Default.cs_user);
            ZOV.Tools.MyConnectionString.set_Server(@"192.168.100.9\main");
            ZOV.Tools.MyConnectionString.set_InitialCatalog("reminder");
            Application.Run(new ZOV.Tools.frmLogin());

           

            Properties.Settings.Default.cs_user = ZOV.Tools.Security.UserName;
            Properties.Settings.Default.Save();
            Application.Run(new FrmDealers());
        }
    }
}
