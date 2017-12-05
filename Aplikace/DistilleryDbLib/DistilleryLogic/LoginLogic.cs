using System;
using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DistilleryLogic
{
    public class LoginLogic
    {
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
                    UserLevel = UserInfo.Customer
                };
            }
            catch (Exception)
            {}
            
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
