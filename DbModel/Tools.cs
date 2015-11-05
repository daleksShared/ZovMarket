using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace DbModel
{
    public class Tools
    {
        public static string TradeConnectionString(string sqlConString
            )
        {

            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlConString,
                Metadata = @"res://*/Trade.csdl|res://*/Trade.ssdl|res://*/Trade.msl"
            };

            return entityBuilder.ToString();
        }

   
    }

}
