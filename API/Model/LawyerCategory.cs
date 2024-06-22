using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("lawyercategory")]
    public class LawyerCategory{
        [Column("id")]
        public Guid Id {get; set;} 
        [Column("typeint")]
        public int TypeInt {get; set;}
        [Column("alias")]
        public string Alias {get; set;}
        [Column("registrationdate")]
        public DateTime RegistrationDate {get; set;}

        public LawyerCategory(Guid id, int typeInt, string alias, DateTime registrationDate){
            Id = id;
            TypeInt = typeInt;
            Alias = alias;
            RegistrationDate = registrationDate;
        }
    }
}