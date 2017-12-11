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
            "SELECT d.Id, d.date, d.startTime, d.endTime, d.amount, d.ethanolPercentage, d.distilledVolume, d.absoluteAlcoholVolume, d.price, " +
            "d.payed, d.Customer_Id, d.Material_Id, d.Season_Id, d.Period_Id " +
            "FROM Distillation d";

        /*
        private static string SQL_SELECT_ACTUAL_PERIOD =
            "SELECT d.Id, d.date, d.startTime, d.endTime, d.amount, d.ethanolPercentage, d.distilledVolume, d.absoluteAlcoholVolume, d.price, " +
            "d.payed, c.Id, c.name, c.surename, c.personalNumber, c.phone, c.email, c.distilledVolume, c.registrationDate, c.note, c.street, " +
            "c.houseNumber, city.Id, city.name, city.zipCode, dis.Id, dis.name, r.Id, r.name, m.Id, m.name, s.Id, s.name, s.startDate, s.endDate, " +
            "s.finished, s.distillationCount, p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id " +
            "FROM Distillation d JOIN Customer c ON c.Id = d.Customer_Id JOIN City city ON c.City_Id = city.Id JOIN Region r ON r.Id = city.Region_Id " +
            "JOIN District dis ON dis.Id = city.District_Id JOIN Season s ON s.Id = d.Season_Id JOIN Period p ON p.Id = d.Period_Id JOIN Material m ON m.Id = d.Material_Id " +
            "WHERE p.Id = (SELECT Id FROM Period WHERE finished = 0);";
        */
        private static string SQL_SELECT_ID =
           "SELECT d.Id, d.date, d.startTime, d.endTime, d.amount, d.ethanolPercentage, d.distilledVolume, d.absoluteAlcoholVolume, d.price, " +
            "d.payed, d.Customer_Id, d.Material_Id, d.Season_Id, d.Period_Id " +
            "FROM Distillation d " + 
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

        private static Collection<Distillation> Read(SqlDataReader reader)
        {
            Collection<Distillation> distillations = new Collection<Distillation>();

            while(reader.Read())
            {
                Distillation d = new Distillation();
                int i = -1;
                d.Id = reader.GetInt32(++i);
                d.Date = reader.GetDateTime(++i);
                d.StartTime = reader.GetDateTime(++i);
                d.EndTime = reader.GetDateTime(++i);
                d.Amount = reader.GetDouble(++i);
                d.EthanolPercentage = reader.GetDouble(++i);
                d.DistilledVolume = reader.GetDouble(++i);
                d.AbsoluteAlcoholVolume = reader.GetDouble(++i);
                d.Price = reader.GetDouble(++i);
                d.Payed =  reader.GetBoolean(++i);
                d.Customer_Id = reader.GetInt32(++i);
                d.Material_Id = reader.GetInt32(++i);
                d.Season_Id = reader.GetInt32(++i);
                d.Period_Id = reader.GetInt32(++i);


                distillations.Add(d);
            }
            return distillations;
        }

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
