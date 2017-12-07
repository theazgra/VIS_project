using System;
using Microsoft.AspNetCore.Mvc;
using DistilleryLogic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private UserSession _userSession;
        private string _oldLogin;

        public AdministrationController(UserSession userSession)
        {
            _userSession = userSession;
        }

        private bool UserAllowed(int maxLevel = DataLayerNetCore.Entities.UserInfo.Employee)
        {
            if (!_userSession.GetLoggedUser(HttpContext).LoggedIn)
            {
                return false;
            }
            else if (_userSession.GetLoggedUser(HttpContext).User.UserLevel > maxLevel)
            {
                return false;
            }

            return true;
        }

        private void SetViewData()
        {
            LoggedUser loggedUse = _userSession.GetLoggedUser(HttpContext);
            loggedUse.SetViewData(ViewData);
        }

        public IActionResult Index()
        {
            SetViewData();
            if (!UserAllowed())
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            return View();
        }

        public IActionResult ReservationList()
        {
            SetViewData();
            if (!UserAllowed())
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            ViewData["reservationDic"] = ReservationLogic.GetReservationByDayInPeriod(DateTime.Today, DateTime.Today.AddMonths(1));

            return View();
        }

        public IActionResult ReservationDetail(int id)
        {
            SetViewData();
            if (!UserAllowed())
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            if (ReservationLogic.GetReservation(id) is DataLayerNetCore.Entities.Reservation r)
                return View(r);
            else
            {
                ViewData["Warning"] = "Neexistující rezervace.";
                return View("Warning");
            }
        }

        public IActionResult CustomerDetail(int id)
        {
            SetViewData();
            if (!UserAllowed())
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            if (CustomerLogic.GetCustomer(id) is DataLayerNetCore.Entities.Customer c)
            {
                return View(c);
            }
            else
            {
                ViewData["Warning"] = "Neexistující zákazník.";
                return View("Warning");
            }
        }

        public IActionResult UserSettings()
        {
            SetViewData();
            if (!UserAllowed(DataLayerNetCore.Entities.UserInfo.Administrator))
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            return View();
        }

        [HttpPost]
        public IActionResult UserSettings(string search)
        {
            SetViewData();
            if (!UserAllowed(DataLayerNetCore.Entities.UserInfo.Administrator))
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            ViewData["CustomerData"] = UserLogic.SearchByLogin(search);

            return View();
        }

        public IActionResult UserDetail(int id)
        {
            SetViewData();
            if (!UserAllowed(DataLayerNetCore.Entities.UserInfo.Administrator))
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            if (UserLogic.GetUser(id) is DataLayerNetCore.Entities.UserInfo c)
            {
                _oldLogin = c.Login;
                UserInfoForm user = new UserInfoForm
                {
                    Id = c.Id,
                    Login = c.Login,
                    Password = c.Password,
                    UserLevelName = c.UserLevel == DataLayerNetCore.Entities.UserInfo.Administrator ? "Administrátor" : "Zaměstnanec"
                };

                return View(user);
            }
            else
            {
                ViewData["Warning"] = "Neexistující uživatel.";
                return View("Warning");
            }
        }

        [HttpPost]
        public IActionResult UserDetail(UserInfoForm model)
        {
            SetViewData();
            if (!UserAllowed(DataLayerNetCore.Entities.UserInfo.Administrator))
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            if (ModelState.IsValid && (UserLogic.LoginAvaible(model.Login) || model.Login == UserLogic.GetUser(model.Id).Login))
            {
                UserLogic.UpdateUser(new DataLayerNetCore.Entities.UserInfo
                {
                    Id = model.Id,
                    Login = model.Login,
                    Password = model.Password,
                    UserLevel = model.UserLevelName == "Administrátor" ? DataLayerNetCore.Entities.UserInfo.Administrator :
                    DataLayerNetCore.Entities.UserInfo.Employee
                });

                return RedirectToAction("UserSettings", "Administration");
            }

            model.LoginAvaible = UserLogic.LoginAvaible(model.Login);

            return View(model);
        }

        public IActionResult NewUser()
        {
            SetViewData();
            if (!UserAllowed(DataLayerNetCore.Entities.UserInfo.Administrator))
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            return View();
        }

        [HttpPost]
        public IActionResult NewUser(UserInfoForm model)
        {
            SetViewData();
            if (!UserAllowed(DataLayerNetCore.Entities.UserInfo.Administrator))
            {
                ViewData["Warning"] = "Neautorizovaný přístup.";
                return View("Warning");
            }

            model.LoginAvaible = UserLogic.LoginAvaible(model.Login);

            if (ModelState.IsValid && model.LoginAvaible)
            {
                try
                {
                    UserLogic.CreateUser(new DataLayerNetCore.Entities.UserInfo
                    {
                        Login = model.Login,
                        Password = model.Password,
                        UserLevel = model.UserLevelName == "Administrátor" ? DataLayerNetCore.Entities.UserInfo.Administrator :
                                                                                DataLayerNetCore.Entities.UserInfo.Employee
                    });

                    return RedirectToAction("UserSettings", "Administration");
                }
                catch (Exception)
                {
                }
            }

            return View(model);
        }
    }
}