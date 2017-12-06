using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DistilleryLogic;

namespace WebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private UserSession _userSession;
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
    }
}