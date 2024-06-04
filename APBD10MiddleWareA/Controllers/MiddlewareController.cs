using APBD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace APBD9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddlewareController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MiddlewareController(IConfiguration _configuration)
        {
            _configuration = configuration;
        }


        //authorize for authorized users
        [Authorize]
        [HttpGet]
        public IActionResult getMed()
        {
            return Ok();
        }

        //allowAnonymous for not authorized users
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            Claim[] userclaim = new[]
            {
                new Claim(ClaimTypes.Name,"test"),
                new Claim(ClaimTypes.Role,"user"),
                new Claim(ClaimTypes.Role,"admin")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //creating a token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            //return Ok(new { token });
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = "refresh_token"
            });
        }
    }
}
