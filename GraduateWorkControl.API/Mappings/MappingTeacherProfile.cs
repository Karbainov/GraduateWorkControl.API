using AutoMapper;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.API.Models.TeacherModels.OutputModels;
using GraduateWorkControl.BLL.Models.TeacherModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingTeacherProfile:Profile
    {
        public MappingTeacherProfile()
        {
            CreateMap<TeacherRegistrationInfoInputModel, TeacherCreateModel>();
            CreateMap<TeacherModel, TeacherInfoOutputModel>();
            CreateMap<TeacherModel, TeacherFullInfoOutputModel>();
            CreateMap<TeacherShortInfoInputModel, TeacherModel>();
            CreateMap<TeacherFullInfoInputModel, TeacherFullUpdateModel>();
        }
    }
}
