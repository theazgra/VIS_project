﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RegistrationForm
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LoginMissing")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordMissing")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameMissing")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "SureNameMissing")]
        public string Surename { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PersonalNumberMissing")]
        public string PersonalNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "HouseNumberMissing")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CityNameMissing")]
        public string CityName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CityZipMissing")]
        public string CityZip { get; set; }


        public string Phone { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
    }
}
