using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<PotentialBet> PotentialBets { get; set; }

        public DbSet<BetValue> BetValues { get; set; }

        public DbSet<Bookie> Bookies { get; set; }

        public DbSet<Fixture> Fixtures { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomUser> RoomUsers { get; set; }

        public DbSet<CouponBetValue> CouponBetValues { get; set; }

        public DbSet<LeagueTeam> LeagueTeams { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<ReadCoupon> ReadCoupons { get; set; }
        
        public DbSet<ReadCouponItem> ReadCouponItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PotentialBet>()
                .HasMany(b => b.BetValues)
                .WithOne(bv => bv.Bet);

            modelBuilder.Entity<PotentialBet>()
                .HasOne(b => b.Fixture)
                .WithMany(bv => bv.Bets)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PotentialBet>()
                .HasOne(b => b.League)
                .WithMany(bv => bv.Bets)
                .OnDelete(DeleteBehavior.NoAction);

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
                .HasMany(l => l.Rounds)
                .WithOne(r => r.League);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Teams)
                .WithOne(t => t.League)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Leagues)
                .WithOne(lt => lt.Team)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fixture>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeFixtures)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fixture>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayFixtures)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LeagueTeam>()
                .HasKey(x => new {x.LeagueId, x.TeamId});

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<CouponBetValue>()
                .HasKey(x => new { x.CouponId, x.BetValueId });

            modelBuilder.Entity<RoomUser>()
                .HasKey(x => new { x.RoomId, x.UserId });

            modelBuilder.Entity<RoomUser>()
                .HasOne(x => x.User)
                .WithMany(x => x.RoomUsers)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReadCoupon>()
                .HasOne(x => x.Coupon)
                .WithOne(x => x.ReadCoupon)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReadCoupon>()
                .HasOne(x => x.User)
                .WithMany(x => x.ReadCoupons)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}