using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IDbContext
    {
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

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
