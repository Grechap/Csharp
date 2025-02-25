using Microsoft.EntityFrameworkCore;

namespace APIDatabase
{
    public class ApiWithDB : DbContext
    {
        public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}