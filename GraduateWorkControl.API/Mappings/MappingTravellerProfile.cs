using AutoMapper;
using GraduateWorkControl.API.Models.Requests;
using GraduateWorkControl.API.Models.Responses;
using GraduateWorkControl.DAL.Dtos.Travel;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingTravellerProfile : Profile
    {
        public MappingTravellerProfile()
        {
            CreateMap<RegisterTravelUserRequest, Traveller>();
            CreateMap<Traveller, TravellerResponse>();
        }
    }
}
