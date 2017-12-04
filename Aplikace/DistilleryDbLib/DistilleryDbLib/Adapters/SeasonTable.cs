﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistilleryDbLib.Classes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace DistilleryDbLib.Adapters
{
    public class SeasonTable
    {
        private static string SQL_SELECT = "SELECT Id, name, startDate, endDate, finished, distillationCount FROM Season;";
        private static string SQL_SELECT_ID = "SELECT Id, name, startDate, endDate, finished, distillationCount FROM Season WHERE Id = @Id;";
        private static string SQL_SELECT_FINISHED = "SELECT Id, name, startDate, endDate, finished, distillationCount FROM Season WHERE finished = @finished;";
        private static string SQL_INSERT = "INSERT INTO Season (name, startDate, endDate, finished, distillationCount) VALUES (@name, @startDate, @endDate, @finished, @distillationCount);";
        private static string SQL_DELETE = "DELETE FROM Season WHERE Id = @Id";
        private static string SQL_UPDATE =
            "UPDATE Season SET name = @name, startDate = @startDate, endDate = @endDate, " +
            "finished = @finished, distillationCount = @distillationCount WHERE Id = @Id;";


        public static Season Select(int id)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Season> seasons = Read(reader);
                    if (seasons.Count == 1)
                    {
                        return seasons[0];
                    }
                }
            }
            return null;
        }

        public static int StartNewSeason()
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand("EXEC spNewSeason");
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static Collection<Season> Select()
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

        public static Collection<Season> SelectClosedSeasons()
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

        public static string ActiveSeasonName()
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_FINISHED);
                sqlCom.Parameters.AddWithValue("@finished", 0);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<Season> unfinishedSeasons =  Read(reader);
                    if (unfinishedSeasons.Count == 1)
                    {
                        return unfinishedSeasons[0].name;
                    }
                }
            }
            return null;
        }

        public static int Insert(Season season)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, season);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static int Update(Season season)
        {
            using (Database db = new Database())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, season);
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
                    Console.WriteLine("Season with Id {0} can not be deleted. There is distillation or period referecing this season.", id);
                }

                return rows;
            }
        }

        private static Collection<Season> Read(SqlDataReader reader)
        {
            Collection<Season> seasons = new Collection<Season>();
            while (reader.Read())
            {
                int i = -1;
                Season s = new Season()
                {
                    Id = reader.GetInt32(++i),
                    name = reader.GetString(++i),
                    startDate = reader.GetDateTime(++i)
                };
                if (!reader.IsDBNull(++i))
                {
                    s.endDate = reader.GetDateTime(i);
                }
                s.finished = reader.GetBoolean(++i);
                s.distillationCount = reader.GetInt32(++i);

                seasons.Add(s);
            }
            return seasons;
        }

        private static void PrepareCommand(SqlCommand sqlCom, Season season)
        {
            sqlCom.Parameters.AddWithValue("@Id", season.Id);
            sqlCom.Parameters.AddWithValue("@name", season.name);
            sqlCom.Parameters.AddWithValue("@startDate", season.startDate);
            sqlCom.Parameters.AddWithValue("@finished", season.finished);
            sqlCom.Parameters.AddWithValue("@distillationCount", season.distillationCount);
            if (season.endDate == null)
            {
                sqlCom.Parameters.AddWithValue("@endDate", DBNull.Value);
            }
            else
            {
                sqlCom.Parameters.AddWithValue("@endDate", season.endDate);
            }
        }
    }
}