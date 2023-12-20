using AutoMapper;
using GraduateWorkControl.API.Models.StudentModels.InputModels;
using GraduateWorkControl.BLL.Models.StudentModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingStudentProfile:Profile
    {
        public MappingStudentProfile()
        {
            CreateMap<StudentRegistrationInfoInputModel, StudentCreateModel>();
        }
    }
}
