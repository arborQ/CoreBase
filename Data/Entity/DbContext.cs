using Data.Entity.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Data.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=CoreStartDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}