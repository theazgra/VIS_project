using DataLayerNetCore.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DataLayerNetCore.SqlAdapters
{
    public class CustomerTable
    {
        private static string SQL_INSERT =  "INSERT INTO Customer " +
                                            "(name, surename, personalNumber, phone, email, registrationDate, note, City_Id, street, houseNumber, login, password, userlevel) " +
                                            "VALUES (@name, @surename, @personalNumber, @phone, @email, @registrationDate, @note, @City_Id, @street, @houseNumber, @login, @password, @userlevel) ";
        private static string SQL_SELECT = "SELECT c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, " +
                                            "c.street, c.houseNumber, c.City_Id, c.login, c.password, c.userlevel " +
                                            "FROM Customer c;";
        private static string SQL_SELECT_ID ="SELECT c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, " +
                                            "c.registrationDate, c.note, " +
                                            "c.street, c.houseNumber, c.City_Id, c.login, c.password, c.userlevel " +
                                            "FROM Customer c " +
                                            "WHERE c.ID = @Id" ;
        private static string SQL_SELECT_BY_SURENAME = "SELECT c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, " +
                                            "c.registrationDate, c.note, " +
                                            "c.street, c.houseNumber, c.City_Id, c.login, c.password, c.userlevel " +
                                            "FROM Customer c " +
                                            "WHERE c.surename LIKE @surename + '%'";

        private static string SQL_UPDATE =  "UPDATE Customer " +
                                            "SET name = @name, surename = @surename, personalNumber = @personalNumber, phone = @phone, email = @email, "+
                                            "distilledVolume = @distilledVolume, registrationDate = @registrationDate, note = @note, City_Id = @City_Id, street = @street, houseNumber = @houseNumber, login = @login, password = @password, userlevel = @userlevel " +
                                            "WHERE Id = @Id";
        private static string SQL_DELETE = "DELETE FROM Customer WHERE Id = @Id";

        public static int Update(Customer customer)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, customer);
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
                    Console.WriteLine("Customer with Id {0} can not be deleted. There is distillation referencing him.");
                }
                return rows;
            }
        }

        public static int Insert(Customer customer)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, customer);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Customer Select(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
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
            using (SqlServerDatabase db = new SqlServerDatabase())
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
            using (SqlServerDatabase db = new SqlServerDatabase())
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
                c.Name = reader.GetString(++i);
                c.Surename = reader.GetString(++i);
                c.PersonalNumber = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    c.Phone = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    c.Email = reader.GetString(i);
                }
                c.DistilledVolume = reader.GetDouble(++i);
                c.RegistrationDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    c.Note = reader.GetString(++i);
                }
                c.Street = reader.GetString(++i);
                c.HouseNumber = reader.GetString(++i);
                c.City_Id = reader.GetInt32(++i);

                c.Login = reader.GetString(++i);
                c.Password = reader.GetString(++i);
                c.UserLevel = reader.GetInt32(++i);
                customers.Add(c);
            }
            return customers;
        }




        private static void PrepareCommand(SqlCommand sqlCom, Customer customer)
        {
            sqlCom.Parameters.AddWithValue("@Id", customer.Id);
            sqlCom.Parameters.AddWithValue("@name", customer.Name);
            sqlCom.Parameters.AddWithValue("@surename", customer.Surename);
            sqlCom.Parameters.AddWithValue("@personalNumber", customer.PersonalNumber);
            sqlCom.Parameters.AddWithValue("@distilledVolume", customer.DistilledVolume);
            sqlCom.Parameters.AddWithValue("@registrationDate", customer.RegistrationDate);
            sqlCom.Parameters.AddWithValue("@City_Id", customer.City_Id);
            sqlCom.Parameters.AddWithValue("@street", customer.Street);
            sqlCom.Parameters.AddWithValue("@houseNumber", customer.HouseNumber);
            sqlCom.Parameters.AddWithValue("@login", customer.Login);
            sqlCom.Parameters.AddWithValue("@password", customer.Password);
            sqlCom.Parameters.AddWithValue("@userlevel", customer.UserLevel);

            if (customer.Email == null)
            {
                sqlCom.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@email", customer.Email);
            }

            if (customer.Phone == null)
            {
                sqlCom.Parameters.AddWithValue("@phone", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@phone", customer.Phone);
            }
            if (customer.Note == null)
            {
                sqlCom.Parameters.AddWithValue("@note", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@note", customer.Note);
            }
        }
    }
}
