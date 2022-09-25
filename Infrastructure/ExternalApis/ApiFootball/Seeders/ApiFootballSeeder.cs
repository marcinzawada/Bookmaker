using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders;

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
    private readonly BetsSeeder _betsSeeder;
    private readonly BookiesSeeder _bookiesSeeder;

    public ApiFootballSeeder(
        CountriesSeeder countriesSeeder,
        SeasonsSeeder seasonsSeeder,
        LeaguesSeeder leaguesSeeder,
        TeamsSeeder teamSeeder,
        AppDbContext context,
        SportSeeder sportSeeder,
        LabelsSeeder labelsSeeder,
        RoundsSeeder roundsSeeder,
        FixturesSeeder fixturesSeeder,
        BetsSeeder oddsSeeder,
        BookiesSeeder bookiesSeeder)
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
        _betsSeeder = oddsSeeder;
        _bookiesSeeder = bookiesSeeder;
    }

    public async Task SeedData()
    {
        await _context.Database.MigrateAsync();
        await _seasonsSeeder.SeedSeasons();
        await _countriesSeeder.SeedCountries();
        await _sportSeeder.SeedSport();
        await _leaguesSeeder.SeedLeagues();
        await _labelsSeeder.SeedLabels();
        await _bookiesSeeder.SeedBookies();
        await _teamSeeder.SeedTeamsByExtLeagueId(new List<int> { 4063, 4165, 4075, 4049, 4222, 4226 });
        await _roundsSeeder.SeedRoundsByExtLeagueId(new List<int> { 4063, 4165, 4075, 4049, 4222, 4226 });
        await _fixturesSeeder.SeedFixturesByExtLeagueId(new List<int> { 4063, 4165, 4075, 4049, 4222, 4226 });
        await _betsSeeder.SeedBetsByLeagueId(new List<int> { 4063, 4165, 4075, 4049, 4222, 4226 });
    }
    //La Liga - 3513
    //Premier League - 3456
    //UEFA Champions League - 3431
    //Bundesliga 1 - 3510

    //end 2022-07
    //Premier League Ghana - 3925
    //NPFL Nigeria - 4006
    //Primera Division - Apertura Paraguay - 4138
    //A Lyga Lithuania - 4196

    //end 2022-08
    //Northern NSW NPL - Australia - 4049
    //Victoria NPL - Australia - 4061
    //Queensland NPL - Australia - 4101
    //National Premier Leagues - Australia - 4137
    //South Australia NPL - Australia - 4191
    //Premier League - Kyrgyzstan - 4213
    //1 Lyga - Lithuania - 4222
    //Naisten Liiga - Finland - 4226
    //Segunda Division - Venezuela - 4254

    //06-2022
    //4063,4165,4075,4049,4222,4226

}