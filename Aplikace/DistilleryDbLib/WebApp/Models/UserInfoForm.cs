using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UserInfoForm
    {
        public int Id               { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LoginMissing")]
        public string Login         { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordMissing")]
        public string Password      { get; set; }
        public string UserLevelName { get; set; }

        public bool LoginAvaible { get; set; } = true;
    }
}
