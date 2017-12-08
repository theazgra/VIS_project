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
            userInfo.Password = Hashing.Hash(userInfo.Password);

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
            userInfo.Password = Hashing.Hash(userInfo.Password);

            try
            {
                return db.Insert(userInfo);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e.Message, e);
            }
        }

        public static UserInfo LoginUser(string login, string password)
        {
            IDatabase db = Configuration.GetDatabase();

            UserInfo foundUser = null;
            
            ICollection<UserInfo> users = db.SelectAll(new UserInfo());
            try
            {
                foundUser = users.Where(u => u.Login == login).Single();
            }
            catch (Exception)
            { }

            if (foundUser == null)
                return null;

            if (Hashing.HashMatch(foundUser.Password, password))
                return foundUser;
            else
                return null;
        }

        public static UserInfo Login(string login, string password)
        {
            IDatabase db = Configuration.GetDatabase();

            ICollection<Customer> customers = db.SelectAll(new Customer());
            UserInfo foundUser = null;
            try
            {
                Customer cc = customers.Where(c => c.Login == login).Single();
                foundUser = new UserInfo
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
                foundUser = users.Where(u => u.Login == login).Single();
            }
            catch (Exception)
            { }

            if (foundUser == null)
                return null;

            if (Hashing.HashMatch(foundUser.Password, password))
                return foundUser;
            else
                return null;
        }
    }
}
