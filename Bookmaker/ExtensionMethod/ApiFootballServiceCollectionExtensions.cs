using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootball.Client;
using ApiFootball.Mappers;
using ApiFootball.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace Bookmaker.ExtensionMethod
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

            services.AddScoped<ApiFootballSeeder>();
            services.AddScoped<CountriesSeeder>();
            services.AddScoped<LeaguesSeeder>();
            services.AddScoped<SeasonsSeeder>();
            services.AddScoped<TeamsSeeder>();
            services.AddScoped<SportSeeder>();
            services.AddScoped<LabelsSeeder>();
            services.AddScoped<RoundsSeeder>();
            services.AddScoped<FixturesSeeder>();
        }
    }
}
