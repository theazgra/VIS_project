using DistilleryDbLib.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Adapters
{
    public class RegionTable
    {
        private static string SQL_SELECT = "SELECT * FROM Region";
        private static string SQL_SELECT_ID = "SELECT * FROM Region WHERE Id = @Id";
        private static string SQL_INSERT = "INSERT INTO Region (name) VALUES (@name)";
        private static string SQL_DELETE = "DELETE FROM Region WHERE Id = @Id";
        private static string SQL_UPDATE = "UPDATE Region SET name = @name WHERE Id = @Id";

        public static int Insert(Region region)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, region);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Update(Region region)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, region);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Delete(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_DELETE);
                sqlCom.Parameters.AddWithValue("@Id", id);
                int rows = 0;
                try
                {
                    rows = db.ExecuteNonQuery(sqlCom);
                }
                catch (DatabaseException)
                {
                    Console.WriteLine("Region with ID {0} can not be deleted. There is City referencing this region.", id);
                }
                return rows;
            }
        }

        public static Collection<Region> Select()
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    return Read(reader);
                }
            }
        }

        public static Region Select(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Region> regions = Read(reader);
                    if (regions.Count == 1)
                    {
                        return regions[0];
                    }
                }
            }
            return null;
        }

        private static void PrepareCommand(SqlCommand sqlCom, Region region)
        {
            sqlCom.Parameters.AddWithValue("@Id", region.Id);
            sqlCom.Parameters.AddWithValue("@name", region.name);
        }

        private static Collection<Region> Read(SqlDataReader reader)
        {
            Collection<Region> regions = new Collection<Region>();
            while (reader.Read())
            {
                int i = -1;
                Region r = new Region();
                r.Id = reader.GetInt32(++i);
                r.name = reader.GetString(++i);
                regions.Add(r);
            }
            return regions;
        }
    }
}
