using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.Dtos;
using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var user = new ApplicationUser()
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email,
                City = signupDto.City
            };

            var result = await _userManager.CreateAsync(user, signupDto.Password);

            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(x => x.Description).ToList();
                return BadRequest(Response<NoContent>.Fail(errorMessages, 400));
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaims = User.Claims.FirstOrDefault(x=>x.Type ==  JwtRegisteredClaimNames.Sub);

            if (userIdClaims is null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(userIdClaims.Value);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                City= user.City
            });
        }
    }
}
    