using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Viktalea.Application.Contracts.Services;

namespace Viktalea.Infraestructure.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public string? GetCurrentUsername()
        {
            return httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? "system";
        }
    }
}
