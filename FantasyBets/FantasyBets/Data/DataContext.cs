using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public class DataContext : IdentityDbContext<FantasyUser>
    {
        public static readonly string FantasyDb = nameof(FantasyDb).ToLower();

        public DbSet<Round>? Rounds { get; set; }
        public DbSet<Season>? Seasons { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<BetSelection>? BetSelections { get; set; }
        public DbSet<BetType>? BetTypes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasMany(s => s.Rounds).WithOne(r => r.Season);
                entity.HasIndex(s => s.Code);
            });
            modelBuilder.Entity<Round>(entity =>
            {
                entity.HasMany(r => r.Games).WithOne(g => g.Round);
                entity.HasIndex(r => r.Number);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasMany(t => t.GamesAsHome).WithOne(g => g.HomeTeam).HasForeignKey(g => g.HomeTeamId);
                entity.HasMany(t => t.GamesAsAway).WithOne(g => g.AwayTeam).HasForeignKey(g => g.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<BetSelection>(entity =>
            {
                entity.HasOne(b => b.BetType).WithMany(b => b.BetSelections).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(b => b.Game).WithMany(g => g.BetSelections).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(b => b.User).WithMany(u => u.BetSelections).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
                entity.HasIndex(b => b.Result);
            });
        }
    }
}
