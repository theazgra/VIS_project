using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using DistilleryLogic;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private LoggedUser loggedUser;

        public HomeController(LoggedUser user)
        {
            loggedUser = user;
            ViewData["loggedIn"] = loggedUser.LoggedIn;
        }

        public IActionResult Index(CustomerModel model, string submit)
        {

            LoginCustomer(model);

            if (submit == "logOut")
                LogOutCustomer();


            return View(model);

        }

        public IActionResult Registration()
        {
            ViewData["loggedIn"] = loggedUser.LoggedIn;
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationForm model)
        {
            ViewData["loggedIn"] = loggedUser.LoggedIn;
            if (ModelState.IsValid)
            {
                CustomerLogic.CreateCustomer(new DataLayerNetCore.Entities.Customer
                {
                    Login = model.Login,
                    Password = model.Password,
                    Name = model.Name,
                    Surename = model.Surename,
                    PersonalNumber = model.PersonalNumber,
                    City = new DataLayerNetCore.Entities.City
                    {
                        Name = model.CityName,
                        ZipCode = model.CityZip
                    },
                    Street = model.Street,
                    HouseNumber = model.HouseNumber,
                    Phone = model.Phone,
                    Email = model.Email
                });



                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private void LogOutCustomer()
        {
            //ViewData["loggedIn"] = false;
            ViewData["loggedIn"] = loggedUser.LoggedIn;
        }

        private void LoginCustomer(CustomerModel model)
        {
            bool loggedIn = LoginLogic.CorrectCredentials(model.Login, model.Password);

            //ViewData["loggedIn"] = loggedIn;
            ViewData["loggedIn"] = loggedUser.LoggedIn;

            if (loggedIn)
                ViewData["customer"] = model.Login;
        }
    }
}