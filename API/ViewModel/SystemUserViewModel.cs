using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class SystemUserViewModel
    {
        [Display(Name = "email")]
        public string Email {get; set;}

        [Display(Name = "password")]
        public string Password {get; set;}

        [Display(Name = "usertype")]
        public int Role {get; set;}
    }
}