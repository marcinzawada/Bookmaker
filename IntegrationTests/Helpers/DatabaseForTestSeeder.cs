using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace IntegrationTests.Helpers;

public class DatabaseForTestSeeder
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher;

    public DatabaseForTestSeeder(AppDbContext context, PasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public void Seed()
    {
        if (_context.Users.Any())
            return;

        var users = SeedUser();


    }

    private List<User> SeedUser()
    {
        var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "test@gmail.com",
                    PasswordHash = _passwordHasher.HashPassword(null!, "Pass123!"),
                    UserName = "username"
                },
                new User
                {
                    Id = 2,
                    Email = "test2@gmail.com",
                    PasswordHash = _passwordHasher.HashPassword(null!, "Pass123!"),
                    UserName = "username2"
                },
            };

        _context.Users.AddRange(users);
        _context.SaveChanges();

        return users;
    }


}


