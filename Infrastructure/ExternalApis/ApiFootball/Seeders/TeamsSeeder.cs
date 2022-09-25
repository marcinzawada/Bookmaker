using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders;

public class TeamsSeeder : BaseSeeder
{
    public TeamsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
    {
    }

    public async Task SeedTeamsByExtLeagueId(IEnumerable<int> leagueIds)
    {
        var teams = new List<Team>();

        foreach (var leagueId in leagueIds)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == leagueId);

            if (_context.LeagueTeams.Any(x => x.LeagueId == league.Id))
                continue;

            var teamsToAdd = await _client.DownloadTeamsByLeagueId(leagueId);
            teams.AddRange(teamsToAdd);
        }

        await _context.Teams.AddRangeAsync(teams);
        await _context.SaveChangesAsync();
    }
}