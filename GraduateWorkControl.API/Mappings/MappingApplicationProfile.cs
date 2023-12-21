using AutoMapper;
using GraduateWorkControl.API.Models.ApplicationModels.InputModels;
using GraduateWorkControl.API.Models.ApplicationModels.OutputModels;
using GraduateWorkControl.BLL.Models.ApplicationModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingApplicationProfile:Profile
    {
        public MappingApplicationProfile()
        {
            CreateMap<NewApplicationInputModel, ApplicationCreateModel>();
            CreateMap<ApplicationModel, StudentsApplicationOutputModel>();
            CreateMap<ApplicationModel, TeachersApplicationOutputModel>();
        }
    }
}
