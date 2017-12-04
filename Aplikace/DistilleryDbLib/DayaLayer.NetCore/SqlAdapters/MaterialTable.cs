using DataLayerNetCore.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DataLayerNetCore.SqlAdapters
{
    public class MaterialTable
    {
        private static string SQL_SELECT = "SELECT * FROM Material";
        private static string SQL_SELECT_ID = "SELECT * FROM Material WHERE Id = @Id";
        private static string SQL_INSERT = "INSERT INTO Material (name) VALUES (@name)";
        private static string SQL_DELETE = "DELETE FROM Material WHERE Id = @Id";
        private static string SQL_UPDATE = "UPDATE Material SET name = @name WHERE Id = @Id";

        public static int Insert(Material material)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, material);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Update(Material material)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, material);
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
                    Console.WriteLine("Material with Id {0} can not be deleted. There is distillation referencing this material", id);
                }
                return rows;
            }
        }

        public static Collection<Material> Select()
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

        public static Material Select(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);


                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Material> materials = Read(reader);
                    if (materials.Count == 1)
                    {
                        return materials[0];
                    }
                }
            }
            return null;
        }

        private static Collection<Material> Read(SqlDataReader reader)
        {
            Collection<Material> materials = new Collection<Material>();
            while (reader.Read())
            {
                int i = -1;
                Material m = new Material();
                m.Id = reader.GetInt32(++i);
                m.Name = reader.GetString(++i);
                materials.Add(m);
            }
            return materials;
        }

        private static void PrepareCommand(SqlCommand command, Material material)
        {
            command.Parameters.AddWithValue("@Id", material.Id);
            command.Parameters.AddWithValue("@name", material.Name);
        }
    }
}
