using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("lawyer")]
    public class Lawyer
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("professionalid")]
        public string ProfessionalId { get; set; }
        [Column("lawyercategoryid")]
        public Guid LawyerCategoryId { get; set; }
        [Column("postalcode")]
        public string Postalcode { get; set; }
        [Column("country")]
        public string Country { get; set; }
        [Column("state")]
        public string State { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("registrationdate")]
        public DateTime RegistrationDate { get; set; }
        [Column("lastupdate")]
        public DateTime? LastUpdate { get; set; }
        [Column("photo")]
        public string? Photo { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }

        public Lawyer(Guid id, string name, string cpf, string professionalId, Guid lawyerCategoryId, string postalcode, string country, string state, string city, DateTime registrationDate, DateTime? lastUpdate, string? photo)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            ProfessionalId = professionalId ?? throw new ArgumentNullException(nameof(professionalId));
            LawyerCategoryId = lawyerCategoryId == Guid.Empty ? throw new ArgumentNullException(nameof(lawyerCategoryId)) : lawyerCategoryId;
            Postalcode = postalcode ?? throw new ArgumentNullException(nameof(postalcode));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            State = state ?? throw new ArgumentNullException(nameof(state));
            City = city ?? throw new ArgumentNullException(nameof(city));
            RegistrationDate = registrationDate == DateTime.MinValue ? throw new ArgumentNullException(nameof(registrationDate)) : registrationDate;
            LastUpdate = lastUpdate;
            Photo = photo;
        }
    }
}
