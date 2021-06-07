using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int GetUserId()
        {
            if (User is null)
                throw new ForbidException();

            var idIsValid = int.TryParse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var userId);

            if (!idIsValid)
                throw new ForbidException();

            return userId;
        }
    }
}
