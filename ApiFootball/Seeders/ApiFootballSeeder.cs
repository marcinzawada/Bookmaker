using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace ApiFootball.Seeders
{
    public class ApiFootballSeeder
    {
        private readonly AppDbContext _context;
        private readonly CountriesSeeder _countriesSeeder;
        private readonly SeasonsSeeder _seasonsSeeder;
        private readonly LeaguesSeeder _leaguesSeeder;
        private readonly TeamsSeeder _teamSeeder;
        private readonly SportSeeder _sportSeeder;
        private readonly LabelsSeeder _labelsSeeder;
        private readonly RoundsSeeder _roundsSeeder;
        private readonly FixturesSeeder _fixturesSeeder;
        private readonly OddsSeeder _oddsSeeder;
        private readonly BookiesSeeder _bookiesSeeder;

        public ApiFootballSeeder(CountriesSeeder countriesSeeder, SeasonsSeeder seasonsSeeder, LeaguesSeeder leaguesSeeder, TeamsSeeder teamSeeder, AppDbContext context, SportSeeder sportSeeder, LabelsSeeder labelsSeeder, RoundsSeeder roundsSeeder, FixturesSeeder fixturesSeeder, OddsSeeder oddsSeeder, BookiesSeeder bookiesSeeder)
        {
            _countriesSeeder = countriesSeeder;
            _seasonsSeeder = seasonsSeeder;
            _leaguesSeeder = leaguesSeeder;
            _teamSeeder = teamSeeder;
            _context = context;
            _sportSeeder = sportSeeder;
            _labelsSeeder = labelsSeeder;
            _roundsSeeder = roundsSeeder;
            _fixturesSeeder = fixturesSeeder;
            _oddsSeeder = oddsSeeder;
            _bookiesSeeder = bookiesSeeder;
        }

        public async Task SeedData()
        {
            //var databaseCreated = await _context.Database.EnsureCreatedAsync();
            //await _seasonsSeeder.SeedSeasons();
            //await _countriesSeeder.SeedCountries();
            //await _sportSeeder.SeedSport();
            //await _leaguesSeeder.SeedLeagues();
            //await _labelsSeeder.SeedLabels();
            //await _bookiesSeeder.SeedBookies();

            //await _teamSeeder.SeedTeamsByExtLeagueId(1252);
            //await _roundsSeeder.SeedRoundsByExtLeagueId(1252);
            //await _fixturesSeeder.SeedFixturesByExtLeagueId(1252);
            await _oddsSeeder.SeedOdds(1252);
        }

    }
}
