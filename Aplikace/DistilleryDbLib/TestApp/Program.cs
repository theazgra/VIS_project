using System;
using DataLayerNetCore;
using DataLayerNetCore.Entities;
//using DataLayerNetCore.Adapters;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString =
                @"data source = dbsys.cs.vsb.cz\STUDENT; initial catalog = mor0146; user id = mor0146; password = Wt0pEzMOWp";
            //IDatabase xmlDb = DBFactory.GetDatabase(DBType.XmlDatabase, "DBXML.xml");
            IDatabase sqlDb = DBFactory.GetDatabase(DBType.SqlServer, connString);

            sqlDb.SelectAll(new Customer());

            

            
        }
    }
}