using System;
using System.Data.SqlClient;


namespace DataLayerNetCore
{
    public class SqlServerDatabase : IDisposable
    {
        private SqlConnection sqlConnection { get; set; }
        private SqlTransaction sqlTransaction { get; set; }
        private static string connectionString;
        
        public SqlServerDatabase()
        {
            sqlConnection = new SqlConnection();
            Connect(connectionString);
        }

        public bool Connect(string connectionString)
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    sqlConnection.ConnectionString = connectionString;
                    sqlConnection.Open();
                }
                catch (SqlException)
                {
                    throw new DatabaseException(1);
                }
            }
            return true;
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static void SetConnectionString(string connString)
        {
            connectionString = connString;
            //DayaLayer.NetCore.Properties.Resources.ConnectionString = connectionString;
            //Properties.Settings.Default.ConnectionString = connectionString;
            //Properties.Settings.Default.Save();
        }

        public void Close()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
            else
            {
                throw new DatabaseException();
            }
        }

        public void BeginTransaction(System.Data.IsolationLevel transactionLevel = System.Data.IsolationLevel.Serializable)
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlTransaction = sqlConnection.BeginTransaction(transactionLevel);
            }
            else
            {
                throw new DatabaseException();
            }
        }

        public void CommitTransaction()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlTransaction.Commit();
                Close();
            }
            else
            {
                throw new DatabaseException();
            }
			
        }

        public void RollbackTransction()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlTransaction.Rollback();
            }
            else
            {
                throw new DatabaseException();
            }
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                command.Connection = sqlConnection;
                int rows = 0;
                try
                {
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DatabaseException(e.Message);
                }
                return rows;
            }
            throw new DatabaseException();
        }

        public SqlCommand CreateCommand(string commandText)
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                throw new DatabaseException();
            }
            SqlCommand command = new SqlCommand(commandText);
            if (sqlTransaction != null)
            {
                command.Transaction = sqlTransaction;
            }
            return command;
        }

        public SqlDataReader Select(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = sqlConnection;
            SqlDataReader reader;
            try
            {
                reader = sqlCommand.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw new DatabaseException();
            }
            return reader;
        }

        public void Dispose()
        {
            Close();

            if (sqlConnection != null)
            {
                sqlConnection.Dispose();
            }

            if (sqlTransaction != null)
            {
                sqlTransaction.Dispose();
            }
        }
    }
}
