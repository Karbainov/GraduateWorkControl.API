using AutoMapper;
using GraduateWorkControl.BLL.Models.ApplicationModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Mappings
{
    public class MapperApplicationProfile:Profile
    {
        public MapperApplicationProfile() 
        {
            CreateMap<ApplicationCreateModel, ApplicationDto>();
        }
    }
}
