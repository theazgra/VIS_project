using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayerNetCore.Entities;
using DistilleryLogic;

namespace WebApp
{
    [Serializable]
    public class LoggedUser
    {
        private UserInfo _user;
        public bool LoggedIn { get; set; }

        public UserInfo User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                if (_user != null)
                    _user.Password = string.Empty;
            }
        }


        public LoggedUser()
        {
            LoggedIn = false;
        }

    }
}
