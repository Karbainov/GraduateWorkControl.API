using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.Requests;
using GraduateWorkControl.API.Models.Responses;
using GraduateWorkControl.BLL;
using GraduateWorkControl.DAL.Dtos.Travel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("api/travel")]
    public class TravelController : Controller
    {
        private readonly Mapper _mapper;
        private readonly TravelService _travelService;

        public TravelController()
        {
            _travelService = new TravelService();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTravellerProfile());
            });
            _mapper = new Mapper(config);
        }

        [HttpPost("register")]
        public ActionResult<int> Register(RegisterTravelUserRequest request)
        {
            return Ok(_travelService.Register(_mapper.Map<Traveller>(request)));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _travelService.Login(request.Email, request.Password);

            if (user is null) return Unauthorized();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new("Id", user.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Json(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public ActionResult<TravellerResponse> GetUserById(int userId)
        {
            return Ok(_mapper.Map<TravellerResponse>(_travelService.GetUserById(userId)));
        }

    }
}
