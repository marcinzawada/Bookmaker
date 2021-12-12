using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using API;
using Application.Commands.Account.Login;
using Application.Models;
using Bogus;
using Domain.Entities;
using Infrastructure.Data;
using IntegrationTests.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntegrationTests
{
    public class BaseIntegrationTest
    {
        protected readonly HttpClient _testClient;
        protected static Faker _faker = new Faker("en");

        public BaseIntegrationTest()
        {
            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.Single(
                            d => d.ServiceType ==
                                 typeof(DbContextOptions<AppDbContext>));

                        services.Remove(descriptor);

                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDatabaseForTesting");
                        });

                        services.AddScoped<DatabaseForTestSeeder>();
                        services.AddScoped<PasswordHasher<User>>();

                        var sp = services.BuildServiceProvider();

                        using (var scope = sp.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<AppDbContext>();
                            var seeder = scopedServices.GetRequiredService<DatabaseForTestSeeder>();
                            var logger = scopedServices
                                .GetRequiredService<ILogger<BaseIntegrationTest>>();

                            db.Database.EnsureCreated();

                            try
                            {
                                seeder.Seed();
                            }
                            catch (Exception ex)
                            {
                                logger.LogError(ex, "An error occurred seeding the " +
                                                    "database with test messages. Error: {Message}", ex.Message);
                            }
                        }
                    });
                });

            _testClient = factory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response = await _testClient.PostAsJsonAsync("/api/account/login", 
                new LoginCommand("test@gmail.com", "Pass123!"));

            var result = await response.Content.ReadFromJsonAsync<Result<AuthDto>>();
            return result!.Content.Token;
        }
    }
}
