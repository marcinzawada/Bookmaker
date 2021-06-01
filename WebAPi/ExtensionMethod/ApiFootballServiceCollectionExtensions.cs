using ApiFootball.Client;
using ApiFootball.DTOs.Odds;
using ApiFootball.Mappers;
using ApiFootball.Seeders;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using BookieDto = ApiFootball.DTOs.Bookies.BookieDto;

namespace API.ExtensionMethod
{
    public static class ApiFootballServiceCollectionExtensions
    {
        public static void AddApiFootballServices(this IServiceCollection services)
        {
            services.AddScoped<IApiFootballClient, ApiFootballClient>();

            services.AddScoped<ApiFootballMapper>();
            services.AddScoped<BookieMapper>();
            services.AddScoped<CountryMapper>();
            services.AddScoped<FixturesMapper>();
            services.AddScoped<LabelMapper>();
            services.AddScoped<LeagueMapper>();
            services.AddScoped<ScoreMapper>();
            services.AddScoped<SeasonMapper>();
            services.AddScoped<TeamMapper>();
            services.AddScoped<RoundMapper>();
            services.AddScoped<IDtoToModelMapper<BookieDto, Bookie>, BookieMapper>();
            services.AddScoped<IDtoToModelMapper<OddDto, FixtureOdd>, OddMapper>();

            services.AddScoped<ApiFootballSeeder>();
            services.AddScoped<CountriesSeeder>();
            services.AddScoped<LeaguesSeeder>();
            services.AddScoped<SeasonsSeeder>();
            services.AddScoped<TeamsSeeder>();
            services.AddScoped<SportSeeder>();
            services.AddScoped<LabelsSeeder>();
            services.AddScoped<RoundsSeeder>();
            services.AddScoped<FixturesSeeder>();
            services.AddScoped<OddsSeeder>();
            services.AddScoped<BookiesSeeder>();
        }
    }
}
