using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("client")]
    public class Client
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; }
        [Column("name")]
        public string Name { get; private set; }
        [Column("cpf")]
        public string Cpf { get; private set; }
        [Column("email")]
        public string Email { get; private set; }
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

        public Client(string name, string cpf, string email, string postalcode, string country, string state, string city, DateTime registrationDate, DateTime? lastUpdate, string? photo)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Postalcode = postalcode ?? throw new ArgumentNullException(nameof(postalcode));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            State = state ?? throw new ArgumentNullException(nameof(state));
            City = city ?? throw new ArgumentNullException(nameof(city));
            RegistrationDate = registrationDate == DateTime.MinValue ? throw new ArgumentNullException(nameof(registrationDate)) : registrationDate;
            LastUpdate = lastUpdate;
            Photo = photo;
        }

        public Client()
        {
        }
    }
}
