using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application.Common.DependencyInjection;
using Application.Filters;
using Application.Models;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Common.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Seeders;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using WebAPI.AppConfigs;
using WebAPI.ExtensionMethod;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                opt.Filters.Add(new ModelValidatorFilter());
            }).AddFluentValidation(opt => 
                opt.RegisterValidatorsFromAssembly(Assembly.Load("Application")));

            services.AddAuthentication(Configuration);

            services.AddAuthorization();

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddScoped<ModelValidatorFilter>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLExpress")));


            services.AddApiFootballServices();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddApplication();
            services.AddInfrastructure();

            services.ConfigureSwagger();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            ApiFootballSeeder seeder, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi(options =>
            {
                options.DocumentName = "swagger";
                options.Path = "/swagger/v1/swagger.json";
                options.PostProcess = (document, _) =>
                {
                    document.Schemes.Add(OpenApiSchema.Https);
                };
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwaggerUi3(options =>
            {
                options.DocumentPath = "/swagger/v1/swagger.json";
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                ConfigureAsync(seeder).Wait();
            }
        }

        public async Task ConfigureAsync(ApiFootballSeeder seeder)
        {
            await seeder.SeedData().ConfigureAwait(false);
        }
    }
}
