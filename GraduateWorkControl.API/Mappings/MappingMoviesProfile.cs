using AutoMapper;
using GraduateWorkControl.API.Models.Requests;
using GraduateWorkControl.API.Models.Responses;
using GraduateWorkControl.DAL.Dtos.Movies;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingMoviesProfile : Profile
    {
        public MappingMoviesProfile()
        {
            CreateMap<RegisterUserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<User, UserFullResponse>();
            CreateMap<UserWatchList, UserWatchListResponse>();
            CreateMap<MovieRating, MovieRatingResponse>();
        }
    }
}
