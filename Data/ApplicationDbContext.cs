using Microsoft.EntityFrameworkCore;
using LojaMicroservice.Models;


namespace LojaMicroservice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loja> Lojas { get; set; }
    }
}
