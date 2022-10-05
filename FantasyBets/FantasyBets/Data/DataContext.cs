using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public static readonly string FantasyDb = nameof(FantasyDb).ToLower();

        public DbSet<Round>? Rounds { get; set; }
        public DbSet<Season>? Seasons { get; set; }
        public DbSet<Team>? Teams { get; set; }
        //public DbSet<Game>? Games { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Season>().HasMany(s => s.Rounds).WithOne(r => r.Season);
            modelBuilder.Entity<Round>().HasMany(r => r.Games).WithOne(g => g.Round);
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasMany(t => t.GamesAsHome).WithOne(g => g.HomeTeam).HasForeignKey(g => g.HomeTeamId);
                entity.HasMany(t => t.GamesAsAway).WithOne(g => g.AwayTeam).HasForeignKey(g => g.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
