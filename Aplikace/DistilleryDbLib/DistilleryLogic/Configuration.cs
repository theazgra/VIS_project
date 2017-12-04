using DataLayerNetCore;

namespace DistilleryLogic
{
    public static class Configuration
    {
        
        internal static DBType dbType = DBType.SqlServer;
        internal static string connectionString = string.Empty;

        internal static IDatabase GetDatabase()
        {
            return DBFactory.GetDatabase(dbType, connectionString);
        }

        public static void SetDbConnection(DBType type, string connString)
        {
            dbType = type;
            connectionString = connString;
        }

        public static void SetDbConnectionType(DBType type)
        {
            dbType = type;
        }
    }
}
