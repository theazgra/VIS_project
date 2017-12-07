using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using DistilleryLogic;
using DataLayerNetCore.Entities;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private UserSession _userSession;

        public HomeController(UserSession session)
        {
            _userSession = session;
        }

        public IActionResult Index()
        { 
            ShowLoggedUser();
            return View();
        }

        [HttpPost]
        public IActionResult Index(string login, string password, string submit)
        {
            if (submit == "logOut")
                LogOutCustomer();
            else
                LoginCustomer(login, password);

            return View();
        }

        public IActionResult Registration()
        {
            ShowLoggedUser();

            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationForm model)
        {
            ShowLoggedUser();

            model.GoodPersonalNumber = CustomerLogic.GoodPersonalNumber(model.PersonalNumber);
            model.LoginAvaible = UserLogic.LoginAvaible(model.Login);
            

            if (ModelState.IsValid && model.LoginAvaible && model.GoodPersonalNumber)
            { 
                try
                {
                    CustomerLogic.CreateCustomer(new Customer
                    {
                        Login = model.Login,
                        Password = model.Password,
                        Name = model.Name,
                        Surename = model.Surename,
                        PersonalNumber = model.PersonalNumber,
                        City = new City
                        {
                            Name = model.CityName,
                            ZipCode = model.CityZip
                        },
                        Street = model.Street,
                        HouseNumber = model.HouseNumber,
                        Phone = model.Phone,
                        Email = model.Email
                    });
                }
                catch (DatabaseException e)
                {
                    return View("Error", new ErrorViewModel { RequestId = e.Message });
                }

                return RedirectToAction("RegistrationCompleted", "Home", new { result = "OK" });
            }
            return View(model);
        }

        public IActionResult RegistrationCompleted(string result)
        {
            if (result != "OK")
            {
                ShowLoggedUser();
                return View("Error", new ErrorViewModel { RequestId = "RegCompletedNotAvaible" });
            }


            ShowLoggedUser();
            return View();
        }

        private void ShowLoggedUser()
        {
            LoggedUser loggedUser = _userSession.GetLoggedUser(HttpContext);
            loggedUser.SetViewData(ViewData);
        }

        private void LogOutCustomer()
        {
            LoggedUser loggedUser = new LoggedUser
            {
                LoggedIn = false,
                User = null
            };
            _userSession.SetLoggedUser(HttpContext, loggedUser);
            ViewData["loggedIn"] = loggedUser.LoggedIn;
        }

        private void LoginCustomer(string login, string password)
        {
            if (UserLogic.Login(login, password) is DataLayerNetCore.Entities.UserInfo user)
            {
                LoggedUser loggedUser = new LoggedUser
                {
                    User = user,
                    LoggedIn = true
                };

                _userSession.SetLoggedUser(HttpContext, loggedUser);
            }

            ShowLoggedUser();
        }
    }
}