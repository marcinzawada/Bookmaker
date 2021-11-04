using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Countries;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.Rounds;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Labels;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Odds;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Seasons;
using BookieDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Bookies.BookieDto;
using FixtureDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.FixtureDto;
using LeagueDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Leagues.LeagueDto;
using TeamDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Teams.TeamDto;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
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
        private readonly OddToBetMapper _betMapper;


        public ApiFootballMapper(CountryMapper countryMapper, SeasonMapper seasonMapper,
            LeagueMapper leagueMapper, TeamMapper teamMapper, LabelMapper labelMapper,
            RoundMapper roundMapper, FixturesMapper fixtureMapper,
            IDtoToModelMapper<BookieDto, Bookie> bookieMapper, OddToBetMapper betMapper)
        {
            _countryMapper = countryMapper;
            _seasonMapper = seasonMapper;
            _leagueMapper = leagueMapper;
            _teamMapper = teamMapper;
            _labelMapper = labelMapper;
            _roundMapper = roundMapper;
            _fixtureMapper = fixtureMapper;
            _bookieMapper = bookieMapper;
            _betMapper = betMapper;
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

        public List<PotentialBet> MapOddDtosToBets(List<OddDto> dtos) =>
            _betMapper.MapOddDtosToBets(dtos);
    }
}
