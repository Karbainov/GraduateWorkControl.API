using AutoMapper;
using GraduateWorkControl.API.Models.OutputModels;
using GraduateWorkControl.BLL.Models.OptionsModels;

namespace GraduateWorkControl.API.Mappings
{
    public class MappingOptionsProfile:Profile
    {
        public MappingOptionsProfile()
        {
            CreateMap<SubjectModel, SubjectOutputModel>();
            CreateMap<FacultyModel, FacultyOutputModel>();
        }
    }
}
