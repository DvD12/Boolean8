using Microsoft.EntityFrameworkCore;

namespace PizzaMvc.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public const string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=Pizza8;Integrated Security=True;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
