using AutoMapper;
using GraduateWorkControl.API.Models.MaterialModels.OutputModels;
using GraduateWorkControl.API.Models.WorkModels.InputModels;
using GraduateWorkControl.API.Models.WorkModels.OutputModels;
using GraduateWorkControl.BLL.Models.MaterialModels;
using GraduateWorkControl.BLL.Models.WorkModels;
using GraduateWorkControl.DAL.Dtos;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingWorkProfile:Profile
    {
        public MappingWorkProfile() 
        {
            CreateMap<TaskInputModel, TaskCreateModel>();
            CreateMap<CommentInputModel, CommentCreateModel>();
            CreateMap<TaskModel, TaskShortOutputModel>();
            CreateMap<TaskModel, TaskOutputModel>();
            CreateMap<CommentModel,CommentOutputModel>();
            CreateMap<MaterialModel, MaterialOutputModel>();
            CreateMap<TaskInputModel, TaskUpdateModel>();
        }
    }
}
