using DataLayerNetCore.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace DataLayerNetCore.SqlAdapters
{
    public class DistillationTable
    {
        private static string SQL_SELECT =
            "SELECT d.Id, d.date, d.startTime, d.endTime, d.amount, d.ethanolPercentage, d.distilledVolume, d.absoluteAlcoholVolume, d.price, "+
            "d.payed, c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, c.street, "+
            "c.houseNumber, city.Id, city.name, city.zipCode, dis.Id, dis.name, r.Id, r.name, m.Id, m.name, s.Id, s.name, s.startDate, s.endDate, "+
            "s.finished, s.distillationCount, p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id " +
            "FROM Distillation d JOIN Customer c ON c.Id = d.Customer_Id JOIN City city ON c.City_Id = city.Id JOIN Region r ON r.Id = city.Region_Id " +
            "JOIN District dis ON dis.Id = city.District_Id JOIN Season s ON s.Id = d.Season_Id JOIN Period p ON p.Id = d.Period_Id JOIN Material m ON m.Id = d.Material_Id;";

        private static string SQL_SELECT_ACTUAL_PERIOD =
            "SELECT d.Id, d.date, d.startTime, d.endTime, d.amount, d.ethanolPercentage, d.distilledVolume, d.absoluteAlcoholVolume, d.price, " +
            "d.payed, c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, c.street, " +
            "c.houseNumber, city.Id, city.name, city.zipCode, dis.Id, dis.name, r.Id, r.name, m.Id, m.name, s.Id, s.name, s.startDate, s.endDate, " +
            "s.finished, s.distillationCount, p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id " +
            "FROM Distillation d JOIN Customer c ON c.Id = d.Customer_Id JOIN City city ON c.City_Id = city.Id JOIN Region r ON r.Id = city.Region_Id " +
            "JOIN District dis ON dis.Id = city.District_Id JOIN Season s ON s.Id = d.Season_Id JOIN Period p ON p.Id = d.Period_Id JOIN Material m ON m.Id = d.Material_Id " +
            "WHERE p.Id = (SELECT Id FROM Period WHERE finished = 0);";

        private static string SQL_SELECT_ID =
            "SELECT d.Id, d.date, d.startTime, d.endTime, d.amount, d.ethanolPercentage, d.distilledVolume, d.absoluteAlcoholVolume, d.price, " +
            "d.payed, c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, c.street, " +
            "c.houseNumber, city.Id, city.name, city.zipCode, dis.Id, dis.name, r.Id, r.name, m.Id, m.name, s.Id, s.name, s.startDate, s.endDate, " +
            "s.finished, s.distillationCount, p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id " +
            "FROM Distillation d JOIN Customer c ON c.Id = d.Customer_Id JOIN City city ON c.City_Id = city.Id JOIN Region r ON r.Id = city.Region_Id " +
            "JOIN District dis ON dis.Id = city.District_Id JOIN Season s ON s.Id = d.Season_Id JOIN Period p ON p.Id = d.Period_Id JOIN Material m ON m.Id = d.Material_Id " +
            "WHERE d.Id = @Id;";

        private static string SQL_INSERT =
            "INSERT INTO Distillation (date, startTime, endTime, amount, ethanolPercentage, distilledVolume, absoluteAlcoholVolume, price, payed, Customer_Id, Material_Id, Season_Id, Period_Id) " +
            "VALUES (@date, @startTime, @endTime, @amount, @ethanolPercentage, @distilledVolume, @absoluteAlcoholVolume, @price, @payed, @Customer_Id, @Material_Id, @Season_Id, @Period_Id);";
        private static string SQL_DELETE = "DELETE FROM Distillation WHERE Id = @Id";
        private static string SQL_UPDATE =
            "UPDATE Distillation SET " +
            "date = @date, startTime = @startTime, endTime = @endTime, amount = @amount, ethanolPercentage = @ethanolPercentage, distilledVolume = @distilledVolume, " +
            "absoluteAlcoholVolume = @absoluteAlcoholVolume, price = @price, payed = @payed, Customer_Id = @Customer_Id, Material_Id = @Material_Id, Season_Id = @Season_Id, Period_Id = @Period_Id " +
            "WHERE Id = @Id;";

        public static int Update(Distillation distillation)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, distillation);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Delete(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {   
                SqlCommand sqlCom = db.CreateCommand("EXEC spDeleteDistillation @id");
                sqlCom.Parameters.AddWithValue("@id", id);
                int rows = db.ExecuteNonQuery(sqlCom);
                if (rows == -1)
                {
                    Console.WriteLine("Distillation record with id {0} can not be deleted.", id);
                }
                return rows;
            }
        }

        public static int Insert(Distillation distillation)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, distillation);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Distillation Select(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);

                sqlCom.Parameters.AddWithValue("@out", SqlDbType.Bit).Direction = ParameterDirection.Output;
                //after executing 
                //bool a = (bool)sqlCom.Parameters["@out"].Value;

                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Distillation> distillations = Read(reader);
                    if (distillations.Count == 1)
                    {
                        return distillations[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Distillation> Select()
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

        public static Collection<Distillation> SelectInActivePeriod()
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ACTUAL_PERIOD);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    return Read(reader);
                }
            }
        }

        private static Collection<Distillation> Read(SqlDataReader reader)
        {
            Collection<Distillation> distillations = new Collection<Distillation>();

            while(reader.Read())
            {
                Distillation d = new Distillation();
                Customer c = new Customer();
                City city = new City();
                Season s = new Season();
                Period p = new Period();
                Material m = new Material();
                int i = -1;
                d.Id = reader.GetInt32(++i);
                d.Date = reader.GetDateTime(++i);
                d.StartTime = reader.GetDateTime(++i);
                d.EndTime = reader.GetDateTime(++i);
                d.Amount = reader.GetDouble(++i); // probably will drop here
                d.EthanolPercentage = reader.GetDouble(++i);
                d.DistilledVolume = reader.GetDouble(++i);
                d.AbsoluteAlcoholVolume = reader.GetDouble(++i);
                d.Price = reader.GetDouble(++i);
                d.Payed =  reader.GetBoolean(++i);


                c.Id = reader.GetInt32(++i);
                c.Name = reader.GetString(++i);
                c.Surename = reader.GetString(++i);
                c.PersonalNumber = reader.GetString(++i);
                if (!reader.IsDBNull(++i)) { c.Phone = reader.GetString(i); }
                if (!reader.IsDBNull(++i)) { c.Email = reader.GetString(i); }
                c.DistilledVolume = reader.GetDouble(++i);
                c.RegistrationDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i)) { c.Note = reader.GetString(i); }
                c.Street = reader.GetString(++i);
                c.HouseNumber = reader.GetString(++i);

                city.Id = reader.GetInt32(++i);
                city.Name = reader.GetString(++i);
                city.ZipCode = reader.GetString(++i);
                city.District_Id = reader.GetInt32(++i);
                city.District = new District
                {
                    Id = reader.GetInt32(i),
                    Name = reader.GetString(++i)
                };
                city.Region_Id = reader.GetInt32(++i);
                city.Region = new Region
                {
                    Id = reader.GetInt32(i),
                    Name = reader.GetString(++i)
                };

                m.Id = reader.GetInt32(++i);
                m.Name = reader.GetString(++i);

                s.Id = reader.GetInt32(++i);
                s.Name = reader.GetString(++i);
                s.StartDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i)) { s.EndDate = reader.GetDateTime(i); }
                s.Finished = reader.GetBoolean(++i);
                s.DistillationCount = reader.GetInt32(++i);

                p.Id = reader.GetInt32(++i);
                p.Name = reader.GetString(++i);
                p.StartDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i)) { p.EndDate = reader.GetDateTime(i); }
                p.Finished = reader.GetBoolean(++i);
                p.Season = s;

                d.Customer_Id = c.Id;
                d.Season_Id = s.Id;
                d.Period_Id = p.Id;
                d.Material_Id = m.Id;

                c.City = city;
                d.Customer = c;
                d.Material = m;
                d.Season = s;
                d.Period = p;
                distillations.Add(d);
            }
            return distillations;
        }
        //(@date, @startTime, @endTime, @amount, @ethanolPercentage, @distilledVolume,
        // @absoluteAlcoholVolume, @price, @payed, @Customer_Id, @Material_Id, @Season_Id, @Period_Id)

        private static void PrepareCommand(SqlCommand sqlCom, Distillation distillation)
        {
            sqlCom.Parameters.AddWithValue("@Id", distillation.Id);
            sqlCom.Parameters.AddWithValue("@date", distillation.Date);
            sqlCom.Parameters.AddWithValue("@startTime", distillation.StartTime);
            sqlCom.Parameters.AddWithValue("@endTime", distillation.EndTime);
            sqlCom.Parameters.AddWithValue("@amount", distillation.Amount);
            sqlCom.Parameters.AddWithValue("@ethanolPercentage", distillation.EthanolPercentage);
            sqlCom.Parameters.AddWithValue("@distilledVolume", distillation.DistilledVolume);
            sqlCom.Parameters.AddWithValue("@absoluteAlcoholVolume", distillation.AbsoluteAlcoholVolume);
            sqlCom.Parameters.AddWithValue("@price", distillation.Price);
            if (distillation.Payed)
            {
                sqlCom.Parameters.AddWithValue("@payed", 1);
            }else
            {
                sqlCom.Parameters.AddWithValue("@payed", 0);
            }
            
            sqlCom.Parameters.AddWithValue("@Customer_Id", distillation.Customer_Id);
            sqlCom.Parameters.AddWithValue("@Material_Id", distillation.Material_Id);
            sqlCom.Parameters.AddWithValue("@Season_Id", distillation.Season_Id);
            sqlCom.Parameters.AddWithValue("@Period_Id", distillation.Period_Id);
        }
    }
}
