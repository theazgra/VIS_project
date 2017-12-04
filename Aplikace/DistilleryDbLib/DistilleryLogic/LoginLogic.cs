using System;
using DataLayerNetCore;

namespace DistilleryLogic
{
    public class LoginLogic
    {
        public static bool CorrectCredentials(string login, string password)
        {
            //probably have just one instance of database??
            //IDatabase db = Configuration.GetDatabase();

            if (login == "vojta" && password == "moravec")
                return true;



            return false;
        }
    }
}
