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
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
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
        
        public Client(Guid id, string name, string cpf, string email, string password, string postalcode, string country, string state, string city, DateTime registrationDate, DateTime? lastUpdate, string? photo)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
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
