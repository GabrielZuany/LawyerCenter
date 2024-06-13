using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("clientlawyer")]
    public class ClientLawyer
    {
        [Column("id")]
        public Guid Id {get; set;}
        [Column("lawyerid")]
        public Guid LawyerId {get; set;}
        [Column("clientid")]
        public Guid ClientId {get; set;}
        [Column("relationcreatedin")]
        public DateTime RelationCreatedIn {get; set;}
    }
}