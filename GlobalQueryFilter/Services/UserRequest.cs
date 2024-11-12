using GlobalQueryFilter.Domain.Contracts.Common;
using Microsoft.AspNetCore.Http;

namespace GlobalQueryFilter.Api.Services
{
    public class UserRequest : IUserRequest
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserRequest(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Email => _contextAccessor.HttpContext?.Request.Headers["user-email"] ?? string.Empty;
    }
}
