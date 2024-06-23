using Microsoft.EntityFrameworkCore;
using API.Model;


namespace API.Infra
{
    public class ConnectionContext : DbContext
    {
        // DbSet is a collection of entities that can be queried. Maps to a table in the database.
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LawyerCategory> LawyerCategories { get; set; }
        public DbSet<ClientLawyer> ClientLawyers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = "localhost";
            int port = 5432;
            var database = "lawyercenter";
            var password = "minha_senha_forte_123";
            var username = "lawyercenter_aka_ifood_advogado";
            optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
        }
    }
}