﻿using System;
using DataLayerNetCore.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        internal void SetViewData(ViewDataDictionary viewData)
        {
            viewData["loggedIn"] = LoggedIn;
            if (LoggedIn)
            {
                viewData["userName"] = User.Login;
                viewData["userLevel"] = User.UserLevel;
            }
        }

    }
}
