using BlogMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMvc.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public const string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=Blog8;Integrated Security=True;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
