using AutoMapper;
using GraduateWorkControl.API.Models.StudentModels.InputModels;
using GraduateWorkControl.API.Models.StudentModels.OutputModels;
using GraduateWorkControl.BLL.Models.StudentModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingStudentProfile:Profile
    {
        public MappingStudentProfile()
        {
            CreateMap<StudentRegistrationInfoInputModel, StudentCreateModel>();
            CreateMap<StudentModel, StudentInfoOutputModel>();
            CreateMap<StudentModel, StudentFullInfoOutputModel>();
            CreateMap<StudentInfoInputModel, StudentModel>();
        }
    }
}
