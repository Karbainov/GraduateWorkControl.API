using AutoMapper;
using GraduateWorkControl.BLL.Models.TeacherModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Mappings
{
    public class MapperTeacherProfile : Profile
    {
       public MapperTeacherProfile() 
        {
            CreateMap<TeacherCreateModel, TeacherDto>();
        }

    }
}
