using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.DTOs.Countries;
using ApiFootball.DTOs.Fixtures;
using ApiFootball.DTOs.Fixtures.Rounds;
using ApiFootball.DTOs.Labels;
using ApiFootball.DTOs.Seasons;
using Domain.Entities;
using LeagueDto = ApiFootball.DTOs.Leagues.LeagueDto;
using TeamDto = ApiFootball.DTOs.Teams.TeamDto;

namespace ApiFootball.Mappers
{
    public class ApiFootballMapper
    {
        private readonly CountryMapper _countryMapper;
        private readonly SeasonMapper _seasonMapper;
        private readonly LeagueMapper _leagueMapper;
        private readonly TeamMapper _teamMapper;
        private readonly LabelMapper _labelMapper;
        private readonly RoundMapper _roundMapper;
        private readonly FixturesMapper _fixtureMapper;


        public ApiFootballMapper(CountryMapper countryMapper, SeasonMapper seasonMapper, LeagueMapper leagueMapper, TeamMapper teamMapper, LabelMapper labelMapper, RoundMapper roundMapper, FixturesMapper fixtureMapper)
        {
            _countryMapper = countryMapper;
            _seasonMapper = seasonMapper;
            _leagueMapper = leagueMapper;
            _teamMapper = teamMapper;
            _labelMapper = labelMapper;
            _roundMapper = roundMapper;
            _fixtureMapper = fixtureMapper;
        }

        public Country MapCountryDtoToCountry(CountryDto dto) =>
            _countryMapper.MapDtoToModel(dto);

        public List<Country> MapCountryDtosToCountries(List<CountryDto> dtos) =>
            _countryMapper.MapDtosToModels(dtos);

        public Season MapSeasonDtoToSeason(SeasonDto dto) =>
            _seasonMapper.MapDtoToModel(dto);

        public List<Season> MapSeasonDtosToSeasons(List<SeasonDto> dtos) =>
            _seasonMapper.MapDtosToModels(dtos);

        public League MapLeagueDtoToLeague(LeagueDto dto) =>
            _leagueMapper.MapDtoToModel(dto);

        public List<League> MapLeagueDtosToLeagues(List<LeagueDto> dtos) =>
            _leagueMapper.MapDtosToModels(dtos);

        public Team MapTeamDtoToTeam(TeamDto dto, int extLeagueId)
        {
            dto.LeagueId = extLeagueId;
            return _teamMapper.MapDtoToModel(dto);
        }

        public List<Team> MapLeagueDtosToLeagues(List<TeamDto> dtos, int extLeagueId)
        {
            foreach (var teamDto in dtos)
            {
                teamDto.LeagueId = extLeagueId;
            }

            return _teamMapper.MapDtosToModels(dtos);
        }

        public List<Label> MapLabelDtosToLabels(List<LabelDto> dtos) =>
            _labelMapper.MapDtosToModels(dtos);

        public List<Round> MapRoundDtosToRounds(List<RoundDto> dtos) =>
            _roundMapper.MapDtosToModels(dtos);

        public List<Fixture> MapFixtureDtosToFixtures(List<FixtureDto> dtos) =>
            _fixtureMapper.MapDtosToModels(dtos);
    }
}
