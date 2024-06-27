using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class ClientViewModel
    {
        [Display(Name = "name")]
        public string Name { get; set; }
        [Display(Name = "cpf")]
        public string Cpf { get; set; }
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "password")]
        public string Password { get; set; }
        [Display(Name = "postalcode")]
        public string Postalcode { get; set; }
        [Display(Name = "state")]
        public string State { get; set; }
        [Display(Name = "city")]
        public string City { get; set; }
        [Display(Name = "photo")]
        public string? Photo { get; set; }
    }
}