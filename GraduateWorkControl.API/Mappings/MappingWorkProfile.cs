using AutoMapper;
using GraduateWorkControl.API.Models.WorkModels.InputModels;
using GraduateWorkControl.BLL.Models.WorkModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingWorkProfile:Profile
    {
        public MappingWorkProfile() 
        {
            CreateMap<TaskInputModel, TaskCreateModel>();
            CreateMap<CommentInputModel, CommentCreateModel>();
        }
    }
}
