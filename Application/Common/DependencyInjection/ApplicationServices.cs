using System.Reflection;
using Application.Common.JWT;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.DependencyInjection
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            return services;
        }
    }
}
