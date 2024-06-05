using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Model
{
    [Table("systemuser")]
    public class SystemUser
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; }
        [Column("email")]
        public string Email { get; private set; }
        [Column("password")]
        public string Password { get; private set; }
        [Column("usertype")]
        public int Role { get; private set; }

        [Column("registrationdate")]
        public DateTime RegistrationDate { get; private set; }
        [Column("lastupdate")]
        public DateTime? LastUpdate { get; private set; }

        public SystemUser(string email, string password, int role, DateTime registrationDate, DateTime? lastUpdate)
        {
            Id = Guid.NewGuid();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role != 1 && role != 2 ? throw new ArgumentOutOfRangeException(nameof(role)) : role;
            RegistrationDate = registrationDate == DateTime.MinValue ? throw new ArgumentNullException(nameof(registrationDate)) : registrationDate;
            LastUpdate = lastUpdate;
        }
    }
}