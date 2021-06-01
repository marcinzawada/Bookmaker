using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.DTOs.Countries;
using ApiFootball.DTOs.Fixtures.Rounds;
using ApiFootball.DTOs.Labels;
using ApiFootball.DTOs.Odds;
using ApiFootball.DTOs.Seasons;
using Domain.Entities;
using BookieDto = ApiFootball.DTOs.Bookies.BookieDto;
using FixtureDto = ApiFootball.DTOs.Fixtures.FixtureDto;
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
        private readonly IDtoToModelMapper<BookieDto, Bookie> _bookieMapper;
        private readonly IDtoToModelMapper<OddDto, FixtureOdd> _oddMapper;


        public ApiFootballMapper(CountryMapper countryMapper, SeasonMapper seasonMapper,
            LeagueMapper leagueMapper, TeamMapper teamMapper, LabelMapper labelMapper,
            RoundMapper roundMapper, FixturesMapper fixtureMapper,
            IDtoToModelMapper<BookieDto, Bookie> bookieMapper, IDtoToModelMapper<OddDto, FixtureOdd> oddMapper)
        {
            _countryMapper = countryMapper;
            _seasonMapper = seasonMapper;
            _leagueMapper = leagueMapper;
            _teamMapper = teamMapper;
            _labelMapper = labelMapper;
            _roundMapper = roundMapper;
            _fixtureMapper = fixtureMapper;
            _bookieMapper = bookieMapper;
            _oddMapper = oddMapper;
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

        public List<Bookie> MapBookieDtosToBookies(List<BookieDto> dtos) =>
            _bookieMapper.MapDtosToModels(dtos);

        public List<FixtureOdd> MapOddDtosToFixtureOdds(List<OddDto> dtos) =>
            _oddMapper.MapDtosToModels(dtos);
    }
}
