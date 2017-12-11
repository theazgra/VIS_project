using System;
using DistilleryLogic;
using DataLayerNetCore;
using DataLayerNetCore.SqlAdapters;

namespace TestAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration.SetDbConnection(
            //  DataLayerNetCore.DBType.XmlDatabase,
            //  @"C:\Users\Vojtěch\Source\Repos\VIS_projekt\Aplikace\DistilleryDbLib\WebApp\DistXml.xml");
            

            DBFactory.configuredDbType = DBType.SqlServer;
            DBFactory.configuredConnectionString = @"data source = dbsys.cs.vsb.cz\STUDENT; initial catalog = mor0146; user id = mor0146; password = Wt0pEzMOWp";

            var list = ReservationTable.Select();
            var one = ReservationTable.Select(1);

            //Console.WriteLine(one.District);





        }
    }
}
