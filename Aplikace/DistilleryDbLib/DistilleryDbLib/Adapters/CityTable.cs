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
    public class CityTable
    {
        private static string SQL_SELECT = "SELECT c.Id, c.name, c.zipCode, d.Id, d.Name, r.Id, r.Name FROM City c JOIN District d ON d.Id = c.District_Id JOIN Region r ON r.Id = c.Region_Id";
        private static string SQL_SELECT_ID = "SELECT c.Id, c.name, c.zipCode, d.Id, d.Name, r.Id, r.Name FROM City c JOIN District d ON d.Id = c.District_Id JOIN Region r ON r.Id = c.Region_Id WHERE c.Id = @Id";
        private static string SQL_SELECT_BY_REGION = "SELECT c.Id, c.name, c.zipCode, d.Id, d.Name, r.Id, r.Name FROM City c JOIN District d ON d.Id = c.District_Id JOIN Region r ON r.Id = c.Region_Id WHERE r.Id = @Region_Id";
        private static string SQL_INSERT = "INSERT INTO City (name, zipCode, District_Id, Region_Id) VALUES (@name, @zipCode, @District_Id, @Region_Id)";
        private static string SQL_DELETE = "DELETE FROM City WHERE Id = @Id";
        private static string SQL_UPDATE = "UPDATE City SET name = @name, zipCode = @zipCode, District_Id = @District_Id, Region_Id = @Region_Id WHERE Id = @Id";

        public static int Insert(City city)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, city);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Update(City city)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, city);
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
                    Console.WriteLine("City with ID {0} can not be deleted. There is Customer referencing this city.", id);
                }

                return rows;
            }
        }

        public static Collection<City> SelectByRegion(int regionId)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_BY_REGION);
                sqlCom.Parameters.AddWithValue("@Region_Id", regionId);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    return Read(reader);
                }
            }
        }

        public static Collection<City> Select()
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

        public static City Select(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<City> cities = Read(reader);
                    if (cities.Count == 1)
                    {
                        return cities[0];
                    }
                }
            }
            return null;
        }
        
        private static Collection<City> Read(SqlDataReader reader)
        {
            Collection<City> cities = new Collection<City>();
            while (reader.Read())
            {
                int i = -1;
                City c = new City
                {
                    Id = reader.GetInt32(++i),
                    name = reader.GetString(++i),
                    zipCode = reader.GetString(++i),
                    District_Id = reader.GetInt32(++i),
                    District = new District
                    {
                        Id = reader.GetInt32(i),
                        name = reader.GetString(++i)
                    },
                    Region_Id = reader.GetInt32(++i),
                    Region = new Region
                    {
                        Id = reader.GetInt32(i),
                        name = reader.GetString(++i)
                    }
                };
                cities.Add(c);
            }
            return cities;
        }

        private static void PrepareCommand(SqlCommand sqlCom, City city)
        {
            sqlCom.Parameters.AddWithValue("@Id", city.Id);
            sqlCom.Parameters.AddWithValue("@name", city.name);
            sqlCom.Parameters.AddWithValue("@zipCode", city.zipCode);
            sqlCom.Parameters.AddWithValue("@District_Id", city.District_Id);
            sqlCom.Parameters.AddWithValue("@Region_Id", city.Region_Id);
        }
    }
}
