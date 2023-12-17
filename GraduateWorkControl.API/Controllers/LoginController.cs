using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost(Name = "Login")]
        public IActionResult Login(string email, string password)
        {
            List<Claim> claims=null;

            if (email == "admin")
            {
                claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, "admin")
                };
            }
            else if (email == "teacher")
            {
                claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, "teacher")
                };
            }
            else
            {
                claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, "student")
                };
            }


            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
