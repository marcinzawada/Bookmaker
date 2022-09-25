using API.AppConfigs;
using API.ExtensionMethod;
using Application.Common.DependencyInjection;
using Application.Filters;
using Application.Middleware;
using FluentValidation.AspNetCore;
using Hangfire;
using Infrastructure.BackgroundJobs;
using Infrastructure.Common.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using System.Reflection;
using System.Threading.Tasks;

namespace API
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
                options.UseSqlServer(Configuration.GetConnectionString("SQL")));


            services.AddApiFootballServices();

            services.AddApplication();
            services.AddInfrastructure();

            services.ConfigureSwagger();

            services.ConfigureHangfire(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ApiFootballSeeder seeder, AppDbContext context, Supervisor supervisor)
        {
            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

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

            app.UseMiddleware<ExceptionHandlingMiddleware>();

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
                endpoints.MapHangfireDashboard();
            });

            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                ConfigureAsync(seeder).Wait();
                supervisor.Start();
            }

        }

        public async Task ConfigureAsync(ApiFootballSeeder seeder)
        {
            await seeder.SeedData().ConfigureAwait(false);
        }
    }
}
