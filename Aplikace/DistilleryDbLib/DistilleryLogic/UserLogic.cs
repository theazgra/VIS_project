using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DistilleryLogic
{
    public class UserLogic
    {
        public static bool LoginAvaible(string login)
        {

            IDatabase db = Configuration.GetDatabase();

            if (db.SelectAll(new Customer()).Count(c => c.Login == login) > 0)
                return false;
            if (db.SelectAll(new UserInfo()).Count(u => u.Login == login) > 0)
                return false;

            return true;
        }

        public static UserInfo GetUser(int id)
        {
            IDatabase db = Configuration.GetDatabase();

            return db.Select(new UserInfo(), id);
        }

        public static int UpdateUser(UserInfo userInfo)
        {
            IDatabase db = Configuration.GetDatabase();

            return db.Update(userInfo);
        }

        public static ICollection<UserInfo> SearchByLogin(string login)
        {
            IDatabase db = Configuration.GetDatabase();

            if (string.IsNullOrEmpty(login))
                return db.SelectAll(new UserInfo());

            return db.SelectAll(new UserInfo()).Where(user => user.Login.StartsWith(login, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public static int CreateUser(UserInfo userInfo)
        {
            IDatabase db = Configuration.GetDatabase();

            try
            {
                return db.Insert(userInfo);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e.Message, e);
            }
        }

        public static UserInfo Login(string login, string password)
        {
            IDatabase db = Configuration.GetDatabase();

            ICollection<Customer> customers = db.SelectAll(new Customer());

            try
            {
                Customer cc = customers.Where(c => c.Login == login && c.Password == password).Single();
                return new UserInfo
                {
                    Id = cc.Id,
                    Login = cc.Login,
                    Password = cc.Password,
                    UserLevel = cc.UserLevel
                };
            }
            catch (Exception)
            { }

            ICollection<UserInfo> users = db.SelectAll(new UserInfo());
            try
            {
                UserInfo user = users.Where(u => u.Login == login && u.Password == password).Single();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
