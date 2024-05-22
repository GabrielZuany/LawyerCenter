using Microsoft.EntityFrameworkCore;
using API.Model;


namespace API.Infra
{
    public class ConnectionContext : DbContext
    {
        // DbSet is a collection of entities that can be queried. Maps to a table in the database.
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public string Host {get; private set;}
        public string Database {get; private set;}
        public string Username {get; private set;}
        public string Password {get; private set;}
        public int Port {get; private set;}

        public ConnectionContext(string host, string database, string username, string password, int port)
        {
            Host = host;
            Database = database;
            Username = username;
            Password = password;
            Port = port;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}");
        }
    }
}