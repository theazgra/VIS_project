using DataLayerNetCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayerNetCore.Xml;

namespace DataLayerNetCore
{
    public class DBFactory
    {
        public static DBType configuredDbType = DBType.SqlServer;
        public static string configuredConnectionString;

        public static IDatabase GetDatabase(DBType dBType, string connectionString)
        {
            switch (dBType)
            {
                case DBType.SqlServer:
                    return new SqlDatabase(connectionString);
                case DBType.XmlDatabase:
                    return new XmlDatabase(connectionString);
            }
            return null;
        }
    }
}

