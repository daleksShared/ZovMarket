using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ZOV.Tools
{
    public static class MyConnectionString
    {
        private static string _Server = "";
        private static string _InitialCatalog = "";

        private static string _lastUserLogOn = "";
        public static string lastUserLogOn {
            get { return _lastUserLogOn; }
            set { _lastUserLogOn = value; }
        }
       

        public static void set_Server(string ServerName)
        {
            _Server = ServerName;
        }

        public static void set_InitialCatalog(string InitialCatalog)
        {
            _InitialCatalog = InitialCatalog;
        }

        private static string _uid = "getauthdata";
        private static string _pwd = "zow";
        
        public static string ConnectionString
        {
            get
            {
                return String.Format("Server={0};Initial catalog={1};uid={2};pwd={3}", _Server, _InitialCatalog, _uid, _pwd);
            }
        }

        public static string ExecuteScalarQuery(string commandText)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();


                SqlCommand comm = new SqlCommand(commandText, conn);

                comm.ExecuteScalar();
                return "";
            }
            catch (Exception E)
            {
                return E.Message;
            }
        }
    }
}
