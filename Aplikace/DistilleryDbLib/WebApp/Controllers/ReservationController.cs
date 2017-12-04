using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ReservationController : Controller
    {
        private LoggedUser loggedUser;

        public ReservationController(LoggedUser user)
        {
            this.loggedUser = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult NewReservation(ReservationForm model, string returnUrl = null)
        {
            ViewData["newCustomer"] = false;

            if (model.RequstedDate == DateTime.MinValue)
                model.RequstedDate = DateTime.Now;
            return View(model);
        }

    }
}