using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace FreeCourse.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _contextAccessor;

        public SharedIdentityService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        //public string GetUserId => _contextAccessor.HttpContext.User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;

        //public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
