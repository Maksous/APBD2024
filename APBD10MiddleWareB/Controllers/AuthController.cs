using APBD10.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace APBD10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = new IdentityUser { UserName = registerUserDto.UserName };
            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered succesfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            //Authorization
            var AccessToken = GenerateAccessToken(User);
            var refreshToken = GenerateRefreshToken();

            return Ok();
        }

        private object GenerateAccessToken(ClaimsPrincipal user)
        {
            //generateAccessToken
            return "token";
        }

        private String GenerateRefreshToken()
        {
            //GenerateRefreshToken
            return "refreshToken";
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto)
        {

            return Ok();
        }
    }
}
