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
    public class DistrictTable
    {
        private static string SQL_SELECT = "SELECT * FROM District";
        private static string SQL_SELECT_ID = "SELECT * FROM District WHERE Id = @Id";
        private static string SQL_INSERT = "INSERT INTO District (name) VALUES (@name)";
        private static string SQL_DELETE = "DELETE FROM District WHERE Id = @Id";
        private static string SQL_UPDATE = "UPDATE District SET name = @name WHERE Id = @Id";

        public static int Insert(District district)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, district);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Update(District district)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, district);
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
                    Console.WriteLine("District with ID {0} can not be deleted. There is City referencing this district.", id);
                }
                return rows;
            }
        }

        public static Collection<District> Select()
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

        public static District Select(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<District> districts = Read(reader);
                    if (districts.Count == 1)
                    {
                        return districts[0];
                    }
                }
            }
            return null;
        }


        //public static int InsertRange(Collection<District> districts)
        //{
        //    using (Database db = new Database())
        //    {
        //        int count = 0;
        //        SqlCommand sqlCom;
        //        foreach (District d in districts)
        //        {
        //             sqlCom = db.CreateCommand(SQL_INSERT);
        //            PrepareCommand(sqlCom, d);
        //            count += db.ExecuteNonQuery(sqlCom);
        //        }
        //        return count;
        //    }
        //}

        
        private static void PrepareCommand(SqlCommand sqlCom, District district)
        {
            sqlCom.Parameters.AddWithValue("@Id", district.Id);
            sqlCom.Parameters.AddWithValue("@name", district.name);
        }

        private static Collection<District> Read(SqlDataReader reader)
        {
            Collection<District> districts = new Collection<District>();
            while (reader.Read())
            {
                int i = -1;
                District r = new District();
                r.Id = reader.GetInt32(++i);
                r.name = reader.GetString(++i);
                districts.Add(r);
            }
            return districts;
        }
    }
}
