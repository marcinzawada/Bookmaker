using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Infrastructure.ExternalApis.ApiFootball.Mappers;
using Infrastructure.ExternalApis.ApiFootball.Seeders;
using Microsoft.Extensions.DependencyInjection;
using BookieDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Bookies.BookieDto;

namespace WebAPI.ExtensionMethod
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
            services.AddScoped<BetMapper>();

            services.AddScoped<ApiFootballSeeder>();
            services.AddScoped<CountriesSeeder>();
            services.AddScoped<LeaguesSeeder>();
            services.AddScoped<SeasonsSeeder>();
            services.AddScoped<TeamsSeeder>();
            services.AddScoped<SportSeeder>();
            services.AddScoped<LabelsSeeder>();
            services.AddScoped<RoundsSeeder>();
            services.AddScoped<FixturesSeeder>();
            services.AddScoped<BetsSeeder>();
            services.AddScoped<BookiesSeeder>();
        }
    }
}
