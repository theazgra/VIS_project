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
    public class CustomerTable
    {
        private static string SQL_INSERT =  "INSERT INTO Customer " +
                                            "(name, surename, personalNumber, phone, email, registrationDate, note, City_Id, street, houseNumber) " +
                                            "VALUES (@name, @surename, @personalNumber, @phone, @email, @registrationDate, @note, @City_Id, @street, @houseNumber) ";
        private static string SQL_SELECT = "SELECT c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, " +
                                            "c.street, c.houseNumber, c.City_Id, city.name, city.zipCode, r.Id, r.name, d.Id, d.name " +
                                            "FROM Customer c " +
                                            "JOIN City city ON city.Id = c.City_Id " + 
                                            "JOIN District d ON d.Id = city.District_Id " +
                                            "JOIN Region r ON r.Id = city.Region_Id ";
        private static string SQL_SELECT_ID ="SELECT c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, " +
                                            "c.street, c.houseNumber, c.City_Id, city.name, city.zipCode, r.Id, r.name, d.Id, d.name " +
                                            "FROM Customer c " +
                                            "JOIN City city ON city.Id = c.City_Id " +
                                            "JOIN District d ON d.Id = city.District_Id " +
                                            "JOIN Region r ON r.Id = city.Region_Id " +
                                            "WHERE c.ID = @Id" ;
        private static string SQL_SELECT_BY_SURENAME = "SELECT c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, " +
                                            "c.street, c.houseNumber, c.City_Id, city.name, city.zipCode, r.Id, r.name, d.Id, d.name " +
                                            "FROM Customer c " +
                                            "JOIN City city ON city.Id = c.City_Id " +
                                            "JOIN District d ON d.Id = city.District_Id " +
                                            "JOIN Region r ON r.Id = city.Region_Id " +
                                            "WHERE c.surename LIKE @surename + '%'";

        private static string SQL_UPDATE =  "UPDATE Customer " +
                                            "SET name = @name, surename = @surename, personalNumber = @personalNumber, phone = @phone, email = @email, "+
                                            "distilledVolume = @distilledVolume, registrationDate = @registrationDate, note = @note, City_Id = @City_Id, street = @street, houseNumber = @houseNumber " +
                                            "WHERE Id = @Id";
        private static string SQL_DELETE = "DELETE FROM Customer WHERE Id = @Id";

        public static int Update(Customer customer)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, customer);
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
                    Console.WriteLine("Customer with Id {0} can not be deleted. There is distillation referencing him.");
                }
                return rows;
            }
        }

        public static int Insert(Customer customer)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, customer);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Customer Select(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Customer> customers = Read(reader);
                    if (customers.Count == 1)
                    {
                        return customers[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Customer> Select()
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

    
        public static Collection<Customer> SelectBySurename(string surename)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_BY_SURENAME);
                sqlCom.Parameters.AddWithValue("@surename", surename);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    return Read(reader);
                }
            }
        }

        private static Collection<Customer> Read(SqlDataReader reader)
        {
            Collection<Customer> customers = new Collection<Customer>();
            while (reader.Read())
            {
                int i = -1;
                Customer c = new Customer();
                c.Id = reader.GetInt32(++i);
                c.name = reader.GetString(++i);
                c.surename = reader.GetString(++i);
                c.personalNumber = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    c.phone = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    c.email = reader.GetString(i);
                }
                c.distilledVolume = reader.GetDouble(++i);
                c.registrationDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    c.note = reader.GetString(++i);
                }
                c.street = reader.GetString(++i);
                c.houseNumber = reader.GetString(++i);
                c.City_Id = reader.GetInt32(++i);
                c.City = new City
                {
                    Id = reader.GetInt32(i),
                    name = reader.GetString(++i),
                    zipCode = reader.GetString(++i),
                    Region_Id = reader.GetInt32(++i),
                    Region = new Region
                    {
                        Id = reader.GetInt32(i),
                        name = reader.GetString(++i)
                    },
                    District_Id = reader.GetInt32(++i),
                    District = new District
                    {
                        Id = reader.GetInt32(i),
                        name = reader.GetString(++i)
                    }
                };
                customers.Add(c);
            }
            return customers;
        }




        private static void PrepareCommand(SqlCommand sqlCom, Customer customer)
        {
            sqlCom.Parameters.AddWithValue("@Id", customer.Id);
            sqlCom.Parameters.AddWithValue("@name", customer.name);
            sqlCom.Parameters.AddWithValue("@surename", customer.surename);
            sqlCom.Parameters.AddWithValue("@personalNumber", customer.personalNumber);
            sqlCom.Parameters.AddWithValue("@distilledVolume", customer.distilledVolume);
            sqlCom.Parameters.AddWithValue("@registrationDate", customer.registrationDate);
            sqlCom.Parameters.AddWithValue("@City_Id", customer.City_Id);
            sqlCom.Parameters.AddWithValue("@street", customer.street);
            sqlCom.Parameters.AddWithValue("@houseNumber", customer.houseNumber);

            if (customer.email == null)
            {
                sqlCom.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@email", customer.email);
            }

            if (customer.phone == null)
            {
                sqlCom.Parameters.AddWithValue("@phone", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@phone", customer.phone);
            }
            if (customer.note == null)
            {
                sqlCom.Parameters.AddWithValue("@note", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@note", customer.note);
            }
        }
    }
}
