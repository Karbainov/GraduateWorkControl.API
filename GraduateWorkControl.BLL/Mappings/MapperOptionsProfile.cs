using AutoMapper;
using GraduateWorkControl.BLL.Models.OptionsModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Mappings
{
    public class MapperOptionsProfile : Profile
    {
        public MapperOptionsProfile() 
        {
            CreateMap<SubjectModel, SubjectDto>().ReverseMap();
            CreateMap<FacultyModel, FacultyDto>().ReverseMap();

        }
    }
}
