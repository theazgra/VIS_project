using System.Data.SqlClient;
using DataLayerNetCore.Entities;
using System.Collections.ObjectModel;

namespace DataLayerNetCore.SqlAdapters
{
    class UserInfoTable
    {
        private static string SQL_SELECT =
            "SELECT ID, LOGIN, PASSWORD, USERLEVEL FROM USERINFO";
        private static string SQL_SELECT_ID =
           "SELECT ID, LOGIN, PASSWORD, USERLEVEL FROM USERINFO WHERE ID = @ID;";
        private static string SQL_INSERT =
            "INSERT INTO USERINFO (LOGIN, PASSWORD, USERLEVEL) VALUES (@LOGIN, @PASSWORD, @USERLEVEL);";
        private static string SQL_DELETE = "DELETE FROM USERINFO WHERE ID = @ID";
        private static string SQL_UPDATE =
            "UPDATE USERINFO SET LOGIN = @LOGIN, PASSWORD = @PASSWORD, USERLEVEL = @USERLEVEL WHERE ID = @ID";

        public static int Update(UserInfo userInfo)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(sqlCom, userInfo);
                sqlCom.Parameters.AddWithValue("@ID", userInfo.Id);
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

        public static int Insert(UserInfo userInfo)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_INSERT);
                PrepareCommand(sqlCom, userInfo);
                return db.ExecuteNonQuery(sqlCom);
            }
        }

        public static UserInfo Select(int id)
        {
            using (SqlServerDatabase db = new SqlServerDatabase())
            {
                SqlCommand sqlCom = db.CreateCommand(SQL_SELECT_ID);
                sqlCom.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = db.Select(sqlCom))
                {
                    Collection<UserInfo> userInfos = Read(reader);
                    if (userInfos.Count == 1)
                    {
                        return userInfos[0];
                    }
                }
            }
            return null;
        }

        public static Collection<UserInfo> Select()
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

        private static Collection<UserInfo> Read(SqlDataReader reader)
        {
            Collection<UserInfo> userInfos = new Collection<UserInfo>();
            while (reader.Read())
            {
                int i = -1;
                UserInfo ui = new UserInfo
                {
                    Id = reader.GetInt32(++i),
                    Login = reader.GetString(++i),
                    Password = reader.GetString(++i),
                    UserLevel = reader.GetInt32(++i)
                };

               
                userInfos.Add(ui);
            }
            return userInfos;
        }




        private static void PrepareCommand(SqlCommand sqlCom, UserInfo userInfo)
        {
            sqlCom.Parameters.AddWithValue("@LOGIN", userInfo.Login);
            sqlCom.Parameters.AddWithValue("@PASSWORD", userInfo.Password);
            sqlCom.Parameters.AddWithValue("@USERLEVEL", userInfo.UserLevel);
        }
    }
}
