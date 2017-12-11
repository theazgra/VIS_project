using DataLayerNetCore.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DataLayerNetCore.SqlAdapters
{
    public class CityTable
    {
        private static string SQL_SELECT = "SELECT c.Id, c.name, c.zipCode, c.District_Id, c.Region_Id FROM City c";
        private static string SQL_SELECT_ID = "SELECT c.Id, c.name, c.zipCode, c.District_Id, c.Region_Id FROM City c WHERE c.Id = @Id";
        private static string SQL_SELECT_BY_REGION = "SELECT c.Id, c.name, c.zipCode, c.Distric_Id, c.Region_Id FROM City c WHERE c.Region_Id = @Region_Id";
        private static string SQL_INSERT = "INSERT INTO City (name, zipCode, District_Id, Region_Id) VALUES (@name, @zipCode, @District_Id, @Region_Id)";
        private static string SQL_DELETE = "DELETE FROM City WHERE Id = @Id";
        private static string SQL_UPDATE = "UPDATE City SET name = @name, zipCode = @zipCode, District_Id = @District_Id, Region_Id = @Region_Id WHERE Id = @Id";

        

        public static int Insert(City city)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, city);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Update(City city)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, city);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Delete(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
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
            using (SqlServerDatabase db = new SqlServerDatabase())
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
            using (SqlServerDatabase db = new SqlServerDatabase())
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
            using (SqlServerDatabase db = new SqlServerDatabase())
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
                    Name = reader.GetString(++i),
                    ZipCode = reader.GetString(++i),
                    District_Id = reader.GetInt32(++i),
                    Region_Id = reader.GetInt32(++i)
                };
                cities.Add(c);
            }
            return cities;
        }

        private static void PrepareCommand(SqlCommand sqlCom, City city)
        {
            sqlCom.Parameters.AddWithValue("@Id", city.Id);
            sqlCom.Parameters.AddWithValue("@name", city.Name);
            sqlCom.Parameters.AddWithValue("@zipCode", city.ZipCode);
            sqlCom.Parameters.AddWithValue("@District_Id", city.District_Id);
            sqlCom.Parameters.AddWithValue("@Region_Id", city.Region_Id);
        }        
    }
}
