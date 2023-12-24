using GraduateWorkControl.API.Models.MaterialModels.OutputModels;
using GraduateWorkControl.BLL;
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
        private TeacherService _teacherService;
        private StudentServise _studentServise;

        public LoginController()
        {
            _teacherService = new TeacherService();
            _studentServise= new StudentServise();
        }

        [HttpPost(Name = "Login")]
        public IActionResult Login(string email, string password)
        {
            List<Claim> claims=null;
            int id;
            string role = "";
            if (email == "admin" && password=="admin")
            {
                claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, "admin")
                };

                id = 0;
                role= "admin";
            }
            else 
            {
                var t = _teacherService.GetTeacherByLoginAndPassword(email, password);
                if (t != null)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, t.Email),
                        new Claim(ClaimTypes.Role, "teacher"),
                        new Claim("Id",t.Id.ToString())
                    };

                    id = t.Id;
                    role= "teacher";
                }
                else
                {
                    var s=_studentServise.GetStudentByLoginAndPassword(email,password);
                    if(s != null)
                    {
                        claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, s.Email),
                            new Claim(ClaimTypes.Role, "student"),
                            new Claim("Id",s.Id.ToString())
                        };
                    }

                    id = s.Id;
                    role = "student";
                }
            }

            if (claims == null)
            {
                return NotFound("User not found");
            }

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            LoginOutputModel model = new LoginOutputModel()
            {
                Id = id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                Role = role
            };

            return Ok(model);
        }
    }
}
