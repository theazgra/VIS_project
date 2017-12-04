using DataLayerNetCore.Entities;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DataLayerNetCore.SqlAdapters
{
    public class ReservationTable
    {
        private static string SQL_SELECT =
            "SELECT R.ID, R.RESERVATIONDATE, R.REQUESTEDDATE, R.CUSTOMER_ID, R.MATERIAL_ID, R. MATERIALAMOUNT, " +
            "C.NAME, C.SURENAME, C.PERSONALNUMBER, C.PHONE, C.EMAIL, C.DISTILLEDVOLUME, C.REGISTRATIONDATE, C.NOTE, " +
            "C.STREET, C.HOUSENUMBER, C.CITY_ID, CITY.NAME, CITY.ZIPCODE, REG.ID, REG.NAME, D.ID, D.NAME, " +
            "M.Name " +
            "FROM RESERVATION R " +
            "JOIN CUSTOMER C ON C.ID = R.CUSTOMER_ID " +
            "JOIN City city ON city.Id = c.City_Id " +
            "JOIN District d ON d.Id = city.District_Id " +
            "JOIN Material M on M.Id = R.Material_Id " +
            "JOIN Region REG ON REG.Id = city.Region_Id;";
        private static string SQL_SELECT_ID =
            "SELECT R.ID, R.RESERVATIONDATE, R.REQUESTEDDATE, R.CUSTOMER_ID, R.MATERIAL_ID, R. MATERIALAMOUT " +
            "C.NAME, C.SURENAME, C.PERSONALNUMBER, C.PHONE, C.EMAIL, C.DISTILLEDVOLUME, C.REGISTRATIONDATE, C.NOTE, " +
            "C.STREET, C.HOUSENUMBER, C.CITY_ID, CITY.NAME, CITY.ZIPCODE, R.ID, R.NAME, D.ID, D.NAME, " +
            "M.Name " +
            "FROM RESERVATION R " +
            "JOIN CUSTOMER C ON C.ID = R.CUSTOMER_ID" +
            "JOIN City city ON city.Id = c.City_Id " +
            "JOIN District d ON d.Id = city.District_Id " +
            "JOIN Material M on M.Id = R.Material_Id " +
            "JOIN Region r ON r.Id = city.Region_Id " +
            "WHERE R.ID = @ID;";
        private static string SQL_INSERT =
            "INSERT INTO RESERVATION (RESERVATIONDATE, REQUESTEDDATE, CUSTOMER_ID, MATERIAL_ID, MATERIALAMOUNT) " +
            "VALUES (@RESERVATIONDATE, @REQUESTEDDATE, @CUSTOMER_ID, @MATERIAL_ID, @MATERIALAMOUNT);";
        private static string SQL_DELETE = "DELETE FROM RESERVATIOn WHERE Id = @Id";
        private static string SQL_UPDATE =
            "UPDATE Period SET RESERVATIONDATE=@RESERVATIONDATE, REQUESTEDDATE=@REQUESTEDDATE, CUSTOMER_ID=@CUSTOMER_ID," +
            " MATERIAL_ID=@MATERIAL_ID, MATERIALAMOUNT=@MATERIALAMOUNT" +
            " WHERE Id = @Id;";

        public static int Update(Reservation reservation)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, reservation);
                sqlCom.Parameters.AddWithValue("@ID", reservation.Id);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Delete(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_DELETE);
                sqlCom.Parameters.AddWithValue("@ID", id);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Insert(Reservation reservation)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, reservation);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Reservation Select(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Reservation> reservations = Read(reader);
                    if (reservations.Count == 1)
                    {
                        return reservations[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Reservation> Select()
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

        private static Collection<Reservation> Read(SqlDataReader reader)
        {
            Collection<Reservation> reservations = new Collection<Reservation>();
            while (reader.Read())
            {
                int i = -1;

                Reservation r = new Reservation
                {
                    Id = reader.GetInt32(++i),
                    ReservationDateTime = reader.GetDateTime(++i),
                    RequestedDateTime = reader.GetDateTime(++i),
                    Customer_Id = reader.GetInt32(++i),
                    Material_Id = reader.GetInt32(++i),
                    MaterialAmount = reader.GetDouble(++i),
                    Customer = new Customer
                    {
                        Name = reader.GetString(++i),
                        Surename = reader.GetString(++i),
                        PersonalNumber = reader.GetString(++i),
                        Phone = !reader.IsDBNull(++i) ? reader.GetString(i) : string.Empty,
                        Email = !reader.IsDBNull(++i) ? reader.GetString(i) : string.Empty,
                        DistilledVolume = reader.GetDouble(++i),
                        RegistrationDate = reader.GetDateTime(++i),
                        Note = !reader.IsDBNull(++i) ? reader.GetString(i) : string.Empty,
                        Street = !reader.IsDBNull(++i) ? reader.GetString(i) : string.Empty,
                        HouseNumber = reader.GetString(++i),
                        City_Id = reader.GetInt32(++i),
                        City = new City
                        {
                            Id = reader.GetInt32(i),
                            Name = reader.GetString(++i),
                            ZipCode = reader.GetString(++i),
                            Region_Id = reader.GetInt32(++i),
                            Region = new Region
                            {
                                Id = reader.GetInt32(i),
                                Name = reader.GetString(++i)
                            },
                            District_Id = reader.GetInt32(++i),
                            District = new District
                            {
                                Id = reader.GetInt32(i),
                                Name = reader.GetString(++i)
                            }
                        }
                    },
                    Material = new Material
                    {
                        Name = reader.GetString(++i)
                    }
                };

                r.Customer.Id = r.Customer_Id;
                r.Material.Id = r.Material_Id;

                reservations.Add(r);
            }
            return reservations;
        }
        
        private static void PrepareCommand(SqlCommand sqlCom, Reservation reservation)
        {

            sqlCom.Parameters.AddWithValue("@RESERVATIONDATE", reservation.ReservationDateTime);
            sqlCom.Parameters.AddWithValue("@REQUESTEDDATE", reservation.RequestedDateTime);
            sqlCom.Parameters.AddWithValue("@CUSTOMER_ID", reservation.Customer_Id);
            sqlCom.Parameters.AddWithValue("@MATERIAL_ID", reservation.Material_Id);
            sqlCom.Parameters.AddWithValue("@MATERIALAMOUNT", reservation.MaterialAmount);

        }
    }
}
