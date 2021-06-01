using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFootball.DTOs.Teams;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using static System.String;

namespace ApiFootball.Mappers
{
    public class TeamMapper : BaseMapper, IDtoToModelMapper<TeamDto, Team>
    {
        private readonly ILogger<TeamMapper> _logger;

        public TeamMapper(AppDbContext context, ILogger<TeamMapper> logger) : base(context)
        {
            _logger = logger;
        }

        public Team MapDtoToModel(TeamDto dto)
        {
            var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == dto.LeagueId);
            var country = _context.Countries.FirstOrDefault(x => x.Name == dto.Country);

            if (league == null)
                _logger.LogError($"League not found. ExtLeagueId: {dto.LeagueId}");

            if (country == null)
                _logger.LogError($"Country not found. Country: {dto.Country}");

            return new Team
            {
                Leagues = new List<LeagueTeam>
                {
                    new LeagueTeam
                    {
                        LeagueId = league?.Id ?? 0,
                    }
                },
                ExtTeamId = dto.TeamId,
                Name = dto.Name,
                Code = dto.Code,
                Logo = dto.Logo,
                IsNational = dto.IsNational,
                CountryId = country?.Id,
                Founded = dto.Founded,
                VenueName = dto.VenueName,
                VenueSurface = dto.VenueSurface,
                VenueAddress = dto.VenueAddress,
                VenueCity = dto.VenueCity,
                VenueCapacity = dto.VenueCapacity
            };
        }

        public List<Team> MapDtosToModels(List<TeamDto> dtos)
        {
            var teams = new List<Team>();

            foreach (var teamDto in dtos)
            {
                teams.Add(MapDtoToModel(teamDto));
            }

            return teams;
        }
    }
}
