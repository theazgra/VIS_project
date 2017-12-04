using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayerNetCore.Entities;
using DistilleryLogic;

namespace WebApp
{
    public class LoggedUser
    {
        public bool LoggedIn { get; private set; }
        public UserInfo User { get; private set; }

        public LoggedUser()
        {
            LoggedIn = false;
        }

        public bool LogInUser(UserInfo userInfo)
        {
            if (LoginLogic.CorrectCredentials(userInfo.Login, userInfo.Password))
            {
                LoggedIn = true;
                User = userInfo;
                return true;
            }
            else
            {
                LoggedIn = false;
                User = null;
                return false;
            }
        }
    }
}
