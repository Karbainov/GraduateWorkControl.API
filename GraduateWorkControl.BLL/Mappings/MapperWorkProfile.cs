using AutoMapper;
using GraduateWorkControl.BLL.Models.MaterialModels;
using GraduateWorkControl.BLL.Models.WorkModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Mappings
{
    public class MapperWorkProfile:Profile
    {
        public MapperWorkProfile() 
        {
            CreateMap<TaskCreateModel, TaskDto>();
            CreateMap<CommentCreateModel, CommentDto>();
            CreateMap<TaskDto, TaskModel>().ReverseMap();
            CreateMap<CommentDto,CommentModel>().ReverseMap();
            CreateMap<MaterialDto, MaterialModel>().ReverseMap();
            CreateMap<TaskUpdateModel, TaskDto>().ReverseMap();
        }
    }
}
