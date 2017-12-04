using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistilleryDbLib.Classes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;

namespace DistilleryDbLib.Adapters
{
    public class PeriodTable
    {
        private static string SQL_SELECT = 
            "SELECT p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id, s.name, s.startDate, s.endDate, s.finished, s.distillationCount "+
            "FROM Period p JOIN Season s ON s.Id = p.Season_Id;";
        private static string SQL_SELECT_ID =
            "SELECT p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id, s.name, s.startDate, s.endDate, s.finished, s.distillationCount " +
            "FROM Period p JOIN Season s ON s.Id = p.Season_Id " +
            "WHERE p.Id = @Id;";
        private static string SQL_SELECT_FINISHED =
            "SELECT p.Id, p.name, p.startDate, p.endDate, p.finished, p.Season_Id, s.name, s.startDate, s.endDate, s.finished, s.distillationCount " +
            "FROM Period p JOIN Season s ON s.Id = p.Season_Id " +
            "WHERE p.finished = @finished;";
        private static string SQL_INSERT = "INSERT INTO Period (name, startDate, Season_Id, endDate, finished) VALUES (@name, @startDate, @Season_Id, @endDate, @finished);";
        private static string SQL_DELETE = "DELETE FROM Period WHERE Id = @Id";
        private static string SQL_UPDATE =
            "UPDATE Period SET name = @name, startDate = @startDate, endDate = @endDate, " +
            "finished = @finished, Season_Id = @Season_Id WHERE Id = @Id;";

        public static int Insert(Period period)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, period);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Collection<MonthReport> ClosePeriod()
        {
            using (Database db = new Database())
            {
                Collection<MonthReport> report;
                SqlCommand sqlFunc = db.CreateCommand("SELECT * FROM sfMonthReport()");
                using (SqlDataReader reader = db.Select(sqlFunc))
                {
                    report = ReadReport(reader);
                }
                SqlCommand sqlCom = db.CreateCommand("EXEC spCloseMonthPeriod");
                db.ExecuteNonQuery(sqlCom);
                return report;
            }
        }

       

        public static int Update(Period period)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, period);
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
                    Console.WriteLine("Period with Id {0} can not be deleted. There is distillation referencing it.", id);
                }

                return rows;
            }
        }

        public static Collection<Period> Select()
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

        public static Period Select(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Period> periods = Read(reader);
                    if (periods.Count == 1)
                    {
                        return periods[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Period> SelectClosedPeriods()
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_FINISHED);
                sqlCom.Parameters.AddWithValue("@finished", 1);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    return Read(reader);
                }
            }
        }
        
        public static string ActivePeriodName()
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_FINISHED);
                sqlCom.Parameters.AddWithValue("@finished", 0);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Period> activePeriods = Read(reader);
                    if (activePeriods.Count == 1)
                    {
                        return activePeriods[0].name;
                    }
                }
            }
            return null;
        }

        private static Collection<MonthReport> ReadReport(SqlDataReader reader)
        {
            Collection<MonthReport> report = new Collection<MonthReport>();
            while (reader.Read())
            {
                int i = -1;
                MonthReport mr = new MonthReport
                {
                    date = reader.GetDateTime(++i),
                    surename = reader.GetString(++i),
                    adress = reader.GetString(++i),
                    absVolume = reader.GetDouble(++i),
                    materialName = reader.GetString(++i),
                    payed = reader.GetBoolean(++i),
                    price = reader.GetDouble(++i)
                };
                report.Add(mr);
            }
            return report;
        }

        private static Collection<Period> Read(SqlDataReader reader)
        {
            Collection<Period> periods = new Collection<Period>();
            while (reader.Read())
            {
                int i = -1;
                Period p = new Period();
                Season s = new Season();
                p.Id = reader.GetInt32(++i);
                p.name = reader.GetString(++i);
                p.startDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    p.endDate = reader.GetDateTime(i);
                }
                p.finished = reader.GetBoolean(++i);
                p.Season_Id = reader.GetInt32(++i);

                s.Id = reader.GetInt32(i);
                s.name = reader.GetString(++i);
                s.startDate = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    s.endDate = reader.GetDateTime(i);
                }
                s.finished = reader.GetBoolean(++i);
                s.distillationCount = reader.GetInt32(++i);
                p.Season = s;

                periods.Add(p);
            }
            return periods;
        }

        private static void PrepareCommand(SqlCommand sqlCom, Period period)
        {
            sqlCom.Parameters.AddWithValue("@Id", period.Id);
            sqlCom.Parameters.AddWithValue("@name", period.name);
            sqlCom.Parameters.AddWithValue("@startDate", period.startDate);
            sqlCom.Parameters.AddWithValue("@Season_Id", period.Season_Id);
            sqlCom.Parameters.Add("@finished", SqlDbType.Bit).Value = period.finished;

            if (period.endDate != null)
            {
                sqlCom.Parameters.AddWithValue("@endDate", period.endDate);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@endDate", DBNull.Value);
            }
        }
    }
}
