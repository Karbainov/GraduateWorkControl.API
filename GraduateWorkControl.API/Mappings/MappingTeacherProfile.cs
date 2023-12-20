using AutoMapper;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.BLL.Models.TeacherModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingTeacherProfile:Profile
    {
        public MappingTeacherProfile()
        {
            CreateMap<TeacherRegistrationInfoInputModel, TeacherCreateModel>();
        }
    }
}
