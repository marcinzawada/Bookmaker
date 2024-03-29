﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211108162736_AddedReadCouponsToUser")]
    partial class AddedReadCouponsToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.BetValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("BetId")
                        .HasColumnType("int");

                    b.Property<decimal>("Odd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Value")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("BetValues");
                });

            modelBuilder.Entity("Domain.Entities.Bookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExtBookmakerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Bookies");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Flag")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCouponWinning")
                        .HasColumnType("bit");

                    b.Property<int>("ReadCouponId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCourse")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Domain.Entities.CouponBetValue", b =>
                {
                    b.Property<int>("CouponId")
                        .HasColumnType("int");

                    b.Property<int>("BetValueId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsBetWinning")
                        .HasColumnType("bit");

                    b.HasKey("CouponId", "BetValueId");

                    b.HasIndex("BetValueId");

                    b.ToTable("CouponBetValues");
                });

            modelBuilder.Entity("Domain.Entities.Fixture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Elapsed")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExtFixtureId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FirstHalfStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Referee")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<int?>("ScoreId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SecondHalfStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedBetsAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Venue")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("RoundId");

                    b.HasIndex("ScoreId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Domain.Entities.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExtLabelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("Domain.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("ExtLeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Flag")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("HasCoverageStandings")
                        .HasColumnType("bit");

                    b.Property<bool>("HasEvents")
                        .HasColumnType("bit");

                    b.Property<bool>("HasLineups")
                        .HasColumnType("bit");

                    b.Property<bool>("HasOdds")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPlayers")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPlayersStatistics")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPredictions")
                        .HasColumnType("bit");

                    b.Property<bool>("HasStandings")
                        .HasColumnType("bit");

                    b.Property<bool>("HasStatistics")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTopScorers")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("SeasonEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SeasonStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("SportId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Domain.Entities.LeagueTeam", b =>
                {
                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("LeagueId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("LeagueTeams");
                });

            modelBuilder.Entity("Domain.Entities.PotentialBet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookieId")
                        .HasColumnType("int");

                    b.Property<int>("FixtureId")
                        .HasColumnType("int");

                    b.Property<int>("LabelId")
                        .HasColumnType("int");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookieId");

                    b.HasIndex("FixtureId");

                    b.HasIndex("LabelId");

                    b.HasIndex("LeagueId");

                    b.ToTable("PotentialBets");
                });

            modelBuilder.Entity("Domain.Entities.ReadCoupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CouponId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCouponWinning")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CouponId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("ReadCoupons");
                });

            modelBuilder.Entity("Domain.Entities.ReadCouponItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayTeamGoals")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamGoalsExtraTime")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamGoalsPenalty")
                        .HasColumnType("int");

                    b.Property<string>("AwayTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HomeTeamGoals")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamGoalsExtraTime")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamGoalsPenalty")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsBetWinning")
                        .HasColumnType("bit");

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatchWinnerOption")
                        .HasColumnType("int");

                    b.Property<decimal>("Odd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReadCouponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReadCouponId");

                    b.ToTable("ReadCouponItems");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.RoomUser", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoomUsers");
                });

            modelBuilder.Entity("Domain.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Domain.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExtFixtureId")
                        .HasColumnType("int");

                    b.Property<int?>("ExtraTimeAwayGoals")
                        .HasColumnType("int");

                    b.Property<int?>("ExtraTimeHomeGoals")
                        .HasColumnType("int");

                    b.Property<int>("FixtureId")
                        .HasColumnType("int");

                    b.Property<int?>("FullTimeAwayGoals")
                        .HasColumnType("int");

                    b.Property<int?>("FullTimeHomeGoals")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsAwayTeam")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsHomeTeam")
                        .HasColumnType("int");

                    b.Property<int?>("HalftimeAwayGoals")
                        .HasColumnType("int");

                    b.Property<int?>("HalftimeHomeGoals")
                        .HasColumnType("int");

                    b.Property<int?>("PenaltyAwayGoals")
                        .HasColumnType("int");

                    b.Property<int?>("PenaltyHomeGoals")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FixtureId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Domain.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Domain.Entities.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("ExtTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("Founded")
                        .HasColumnType("int");

                    b.Property<bool>("IsNational")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("VenueAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("VenueCapacity")
                        .HasColumnType("int");

                    b.Property<string>("VenueCity")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("VenueName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("VenueSurface")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("GameTokens")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.BetValue", b =>
                {
                    b.HasOne("Domain.Entities.PotentialBet", "Bet")
                        .WithMany("BetValues")
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("Domain.Entities.Coupon", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Coupons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CouponBetValue", b =>
                {
                    b.HasOne("Domain.Entities.BetValue", "BetValue")
                        .WithMany()
                        .HasForeignKey("BetValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Coupon", "Coupon")
                        .WithMany("CouponBetValues")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BetValue");

                    b.Navigation("Coupon");
                });

            modelBuilder.Entity("Domain.Entities.Fixture", b =>
                {
                    b.HasOne("Domain.Entities.Team", "AwayTeam")
                        .WithMany("AwayFixtures")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Team", "HomeTeam")
                        .WithMany("HomeFixtures")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Round", "Round")
                        .WithMany()
                        .HasForeignKey("RoundId");

                    b.HasOne("Domain.Entities.Score", "Score")
                        .WithMany()
                        .HasForeignKey("ScoreId");

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("League");

                    b.Navigation("Round");

                    b.Navigation("Score");
                });

            modelBuilder.Entity("Domain.Entities.League", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Leagues")
                        .HasForeignKey("CountryId");

                    b.HasOne("Domain.Entities.Season", "Season")
                        .WithMany("Leagues")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Season");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Domain.Entities.LeagueTeam", b =>
                {
                    b.HasOne("Domain.Entities.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Team", "Team")
                        .WithMany("Leagues")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Domain.Entities.PotentialBet", b =>
                {
                    b.HasOne("Domain.Entities.Bookie", "Bookie")
                        .WithMany()
                        .HasForeignKey("BookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Fixture", "Fixture")
                        .WithMany("Bets")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Label", "Label")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.League", "League")
                        .WithMany("Bets")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bookie");

                    b.Navigation("Fixture");

                    b.Navigation("Label");

                    b.Navigation("League");
                });

            modelBuilder.Entity("Domain.Entities.ReadCoupon", b =>
                {
                    b.HasOne("Domain.Entities.Coupon", "Coupon")
                        .WithOne("ReadCoupon")
                        .HasForeignKey("Domain.Entities.ReadCoupon", "CouponId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("ReadCoupons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Coupon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ReadCouponItem", b =>
                {
                    b.HasOne("Domain.Entities.ReadCoupon", "ReadCoupon")
                        .WithMany("Items")
                        .HasForeignKey("ReadCouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReadCoupon");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.HasOne("Domain.Entities.User", "Admin")
                        .WithMany("ManagedRooms")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Domain.Entities.RoomUser", b =>
                {
                    b.HasOne("Domain.Entities.Room", "Room")
                        .WithMany("RoomUsers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RoomUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Round", b =>
                {
                    b.HasOne("Domain.Entities.League", "League")
                        .WithMany("Rounds")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("Domain.Entities.Score", b =>
                {
                    b.HasOne("Domain.Entities.Fixture", "Fixture")
                        .WithMany()
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Fixture");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("Leagues");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Domain.Entities.Coupon", b =>
                {
                    b.Navigation("CouponBetValues");

                    b.Navigation("ReadCoupon");
                });

            modelBuilder.Entity("Domain.Entities.Fixture", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("Domain.Entities.League", b =>
                {
                    b.Navigation("Bets");

                    b.Navigation("Rounds");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Domain.Entities.PotentialBet", b =>
                {
                    b.Navigation("BetValues");
                });

            modelBuilder.Entity("Domain.Entities.ReadCoupon", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Navigation("RoomUsers");
                });

            modelBuilder.Entity("Domain.Entities.Season", b =>
                {
                    b.Navigation("Leagues");
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.Navigation("AwayFixtures");

                    b.Navigation("HomeFixtures");

                    b.Navigation("Leagues");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Coupons");

                    b.Navigation("ManagedRooms");

                    b.Navigation("ReadCoupons");

                    b.Navigation("RoomUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
