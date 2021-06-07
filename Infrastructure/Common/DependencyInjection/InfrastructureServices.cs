﻿using System.Reflection;
using Application.Common.Interfaces;
using Application.Common.JWT;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.DependencyInjection
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IUserContextService, UserContextService>();

            return services;
        }
    }
}