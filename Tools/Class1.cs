using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZovTrade;
using  ZovTrade.Properties;

namespace Tools
{
    public class Paramss
    {
        public static bool Logged = false;
        public static string User;


        public static string PW;
        public static string DS;
        public static string IC;
        public static void init()
        {
            loginform LoggForm = new loginform();
            //while (Logged != true)
            //{

            if (LoggForm.ShowDialog() == DialogResult.OK)
            {
                PW = LoggForm.tbPW.Text;
                User = ((ComboboxItem)LoggForm.cbUser.SelectedItem).Value.ToString();
                tools.userShowName = ((ComboboxItem)LoggForm.cbUser.SelectedItem).Text.ToString();
                Logged = true;
                LoggForm.Dispose();
            }
            else
            { Environment.Exit(0); };

        }

        public static bool IsDate(string inputstring)
        {
            DateTime dt;
            return DateTime.TryParse(inputstring, out dt);
        }
        public static string GetConnectionString()
        {
            if (Logged != true) { init(); };
            if (Logged == false) { Environment.Exit(0); }

            SqlConnectionStringBuilder oldstr = new SqlConnectionStringBuilder(global::Properties.Settings.Default["barcodeCS"].ToString());

            SqlConnectionStringBuilder builder =
               new SqlConnectionStringBuilder();
            builder.PersistSecurityInfo = false;
            builder.DataSource = oldstr.DataSource;
            builder.InitialCatalog = oldstr.InitialCatalog;
            if (User == string.Empty) User = "guest";
            builder.UserID = User;
            Properties.Settings.Default.cs_user = User;
            Properties.Settings.Default.Save();
            builder.Password = PW;
            builder.IntegratedSecurity = false;
            builder.ConnectTimeout = 15;
            builder.Encrypt = true;
            builder.TrustServerCertificate = true;
            Properties.Settings.Default["barcodeCS"] = builder.ConnectionString;
            tools.cs = builder.ConnectionString;

            tools.username = User;
            return builder.ConnectionString;


        }

    }
}
