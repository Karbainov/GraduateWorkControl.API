using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.Requests;
using GraduateWorkControl.API.Models.Responses;
using GraduateWorkControl.BLL;
using GraduateWorkControl.DAL.Dtos.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        private readonly Mapper _mapper;
        private readonly MoviesService _moviesService;

        public MoviesController()
        {
            _moviesService = new MoviesService();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingMoviesProfile());
            });
            _mapper = new Mapper(config);
        }

        [HttpPost("register")]
        public ActionResult<int> Register(RegisterUserRequest request)
        {
            return Ok(_moviesService.Register(_mapper.Map<User>(request)));
        }

        [HttpPost("login")]
        public ActionResult<UserResponse> Login(LoginRequest request)
        {
            var user = _moviesService.Login(request.Email, request.Password);

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
        public ActionResult<UserFullResponse> GetUserById(int userId)
        {
            return Ok(_mapper.Map<UserFullResponse>(_moviesService.GetUserById(userId)));
        }

        [Authorize]
        [HttpPost("watch-list")]
        public IActionResult AddMediaToWatchList(UserWatchList request)
        {
            _moviesService.AddMediaToWatchList(request);
            return Ok();
        }

        [Authorize]
        [HttpDelete("watch-list")]
        public IActionResult RemoveMediaFromWatchList(UserWatchList request)
        {
            _moviesService.RemoveMediaFromWatchList(request);
            return Ok();
        }

        [Authorize]
        [HttpPost("rating")]
        public IActionResult RateMedia(MovieRating request)
        {
            _moviesService.RateMedia(request);
            return Ok();
        }

    }
}
