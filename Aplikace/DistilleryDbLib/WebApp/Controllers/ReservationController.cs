using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using DistilleryLogic;

namespace WebApp.Controllers
{
    public class ReservationController : Controller
    {
        private UserSession _userSession;

        public ReservationController(UserSession userSession)
        {
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            
            ShowLoggedUser();
            return View();
        }

        public IActionResult NewReservation()
        {
            ShowLoggedUser();

            if (!_userSession.GetLoggedUser(HttpContext).LoggedIn)
            {
                ViewData["Warning"] = "Není přihlášen uživatel.";
                return View("Warning");
            }

            ViewData["Materials"] = MaterialLogic.MaterialNames();
            

            return View(new ReservationForm() { RequstedDate = DateTime.Now });
        }

        [HttpPost]
        public IActionResult NewReservation(ReservationForm model, string returnUrl = null)
        {
            ShowLoggedUser();
            ViewData["Materials"] = MaterialLogic.MaterialNames();

            if (ModelState.IsValid)
            {
                model.AvaibleDateTime = ReservationLogic.IsDateTimeAvaible(model.RequstedDate);

                if (model.RequstedDate < DateTime.Now)
                    model.AvaibleDateTime = false;

                if (model.AvaibleDateTime)
                {
                    try
                    {
                        ReservationLogic.CreateReservation(
                        _userSession.GetLoggedUser(HttpContext).User.Id,
                        model.RequstedDate,
                        model.Material,
                        model.MaterialAmount);

                        return RedirectToAction("ReservationList");
                    }
                    catch (DatabaseException e)
                    {
                        return View("Error", new ErrorViewModel() { RequestId = e.Message });
                    }
                    
                }
            }


            return View(model);
        }

        public IActionResult ReservationList()
        {
            ShowLoggedUser();
            int customerId = _userSession.GetLoggedUser(HttpContext).User.Id;
            ViewData["PendingReservations"] = ReservationLogic.PendingReservations(customerId);
            ViewData["FinishedReservations"] = ReservationLogic.FinishedReservations(customerId);


            return View();
        }

        private void ShowLoggedUser()
        {
            LoggedUser loggedUser = _userSession.GetLoggedUser(HttpContext);
            loggedUser.SetViewData(ViewData);
        }

    }
}