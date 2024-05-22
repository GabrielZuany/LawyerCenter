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
        public Guid Id { get; private set; }
        [Column("name")]
        public string Name { get; private set; }
        [Column("cpf")]
        public string Cpf { get; private set; }
        [Column("professionalid")]
        public string ProfessionalId { get; private set; }
        [Column("lawyercategoryid")]
        public Guid LawyerCategoryId { get; private set; }
        [Column("postalcode")]
        public string Postalcode { get; private set; }
        [Column("country")]
        public string Country { get; private set; }
        [Column("state")]
        public string State { get; private set; }
        [Column("city")]
        public string City { get; private set; }
        [Column("registrationdate")]
        public DateTime RegistrationDate { get; private set; }
        [Column("lastupdate")]
        public DateTime? LastUpdate { get; private set; }
        [Column("photo")]
        public string? Photo { get; private set; } // picture path on server ----> add this column in table (doesn't exist yet)

        public Lawyer(string name, string cpf, string professionalId, Guid lawyerCategoryId, string postalcode, string country, string state, string city, DateTime registrationDate, DateTime? lastUpdate, string? photo)
        {
            Id = Guid.NewGuid();
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
