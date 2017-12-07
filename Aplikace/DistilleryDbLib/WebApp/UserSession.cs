using Microsoft.AspNetCore.Http;

namespace WebApp
{
    public class UserSession
    {
        const string USER_KEY = "user_info";
       
        public LoggedUser GetLoggedUser(HttpContext httpContext)
        {
            if (httpContext == null)
                return new LoggedUser();
            LoggedUser user =  httpContext.Session.Get<LoggedUser>(USER_KEY);

            return user ?? new LoggedUser();
        }

        public void SetLoggedUser(HttpContext httpContext, LoggedUser loggedUser)
        {
            if (httpContext != null)
                httpContext.Session.Set(USER_KEY, loggedUser);
        }
    }
}
