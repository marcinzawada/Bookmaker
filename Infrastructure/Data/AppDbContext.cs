using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<BetValue> BetValues { get; set; }

        public DbSet<Bookie> Bookies { get; set; }

        public DbSet<Fixture> Fixtures { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<Odd> Odds { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CouponBetValue> CouponBetValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>()
                .HasMany(b => b.BetValues)
                .WithOne(bv => bv.Bet);

            modelBuilder.Entity<Odd>()
                .HasMany(o => o.Bets)
                .WithOne(b => b.Odd);

            modelBuilder.Entity<Fixture>()
                .HasMany(f => f.Odds)
                .WithOne(o => o.Fixture);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Odds)
                .WithOne(o => o.League);

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Leagues)
                .WithOne(l => l.Season);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Leagues)
                .WithOne(l => l.Country);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Teams)
                .WithOne(t => t.Country);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Odds)
                .WithOne(o => o.League);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Rounds)
                .WithOne(r => r.League);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Teams)
                .WithOne(t => t.League);

            modelBuilder.Entity<Fixture>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeFixtures)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Fixture>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayFixtures)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Fixture>()
                .HasMany(x => x.Odds)
                .WithOne(x => x.Fixture)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<CouponBetValue>()
                .HasKey(x => new {x.CouponId, x.BetValueId});
        }
    }
}