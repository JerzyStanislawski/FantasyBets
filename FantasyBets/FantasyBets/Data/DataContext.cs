using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.EnsureCreated();
        }
    }
}
