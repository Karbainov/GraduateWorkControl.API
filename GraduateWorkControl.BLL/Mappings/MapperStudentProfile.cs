using AutoMapper;
using GraduateWorkControl.BLL.Models.StudentModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Mappings
{
    public class MapperStudentProfile:Profile
    {
        public MapperStudentProfile() 
        {
            CreateMap<StudentCreateModel, StudentDto>();
            CreateMap<StudentDto, StudentModel>().ReverseMap();
        }
    }
}
