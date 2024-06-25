using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class LawyerViewModel
    {
        [Display(Name = "name")]
        public string Name { get; set; }
        [Display(Name = "cpf")]
        public string Cpf { get; set; }
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "password")]
        public string Password { get; set; }
        [Display(Name = "professionalid")]
        public string ProfessionalId { get; set; }
        [Display(Name = "postalcode")]
        public string Postalcode { get; set; }
        [Display(Name = "country")]
        public string Country { get; set; }
        [Display(Name = "state")]
        public string State { get; set; }
        [Display(Name = "city")]
        public string City { get; set; }
        [Display(Name = "photo")]
        public string? Photo { get; set; }
        public int CategoryEnumIdentifier { get; set; }
        [Display(Name = "description")]
        public string? Description { get; set; }
        [Display(Name = "age")]
        public int Age { get; set; }
    }
}