using DistilleryDbLib.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Adapters
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
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, distillation);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Delete(int id)
        {
            using (Database db = new Database())
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
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, distillation);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Distillation Select(int id)
        {
            using (Database db = new Database())
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
            using (Database db = new Database())
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
            using (Database db = new Database())
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
                d.date = reader.GetDateTime(++i);
                d.startTime = reader.GetDateTime(++i);
                d.endTime = reader.GetDateTime(++i);
                d.amount = reader.GetDouble(++i); // probably will drop here
                d.ethanolPercentage = reader.GetDouble(++i);
                d.distilledVolume = reader.GetDouble(++i);
                d.absoluteAlcoholVolume = reader.GetDouble(++i);
                d.price = reader.GetDouble(++i);
                d.payed =  reader.GetBoolean(++i);


                c.Id = reader.GetInt32(++i);
                c.name = reader.GetString(++i);
                c.surename = reader.GetString(++i);
                c.personalNumber = reader.GetString(++i);
                if (!reader.IsDBNull(++i)) { c.phone = reader.GetString(i); }
                if (!reader.IsDBNull(++i)) { c.email = reader.GetString(i); }
                c.distilledVolume = reader.GetDouble(++i);
                c.registrationDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i)) { c.note = reader.GetString(i); }
                c.street = reader.GetString(++i);
                c.houseNumber = reader.GetString(++i);

                city.Id = reader.GetInt32(++i);
                city.name = reader.GetString(++i);
                city.zipCode = reader.GetString(++i);
                city.District_Id = reader.GetInt32(++i);
                city.District = new District
                {
                    Id = reader.GetInt32(i),
                    name = reader.GetString(++i)
                };
                city.Region_Id = reader.GetInt32(++i);
                city.Region = new Region
                {
                    Id = reader.GetInt32(i),
                    name = reader.GetString(++i)
                };

                m.Id = reader.GetInt32(++i);
                m.name = reader.GetString(++i);

                s.Id = reader.GetInt32(++i);
                s.name = reader.GetString(++i);
                s.startDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i)) { s.endDate = reader.GetDateTime(i); }
                s.finished = reader.GetBoolean(++i);
                s.distillationCount = reader.GetInt32(++i);

                p.Id = reader.GetInt32(++i);
                p.name = reader.GetString(++i);
                p.startDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i)) { p.endDate = reader.GetDateTime(i); }
                p.finished = reader.GetBoolean(++i);
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
            sqlCom.Parameters.AddWithValue("@date", distillation.date);
            sqlCom.Parameters.AddWithValue("@startTime", distillation.startTime);
            sqlCom.Parameters.AddWithValue("@endTime", distillation.endTime);
            sqlCom.Parameters.AddWithValue("@amount", distillation.amount);
            sqlCom.Parameters.AddWithValue("@ethanolPercentage", distillation.ethanolPercentage);
            sqlCom.Parameters.AddWithValue("@distilledVolume", distillation.distilledVolume);
            sqlCom.Parameters.AddWithValue("@absoluteAlcoholVolume", distillation.absoluteAlcoholVolume);
            sqlCom.Parameters.AddWithValue("@price", distillation.price);
            if (distillation.payed)
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
