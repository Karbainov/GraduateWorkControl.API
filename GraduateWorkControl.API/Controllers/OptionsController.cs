using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.OutputModels;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.API.Models.TeacherModels.OutputModels;
using GraduateWorkControl.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : Controller
    {
        private OptionsService _optionsService;
        private Mapper _mapper;
        public OptionsController()
        {
            _optionsService = new OptionsService();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingOptionsProfile());
            });
            _mapper = new Mapper(config);
        }

        //[Authorize]
        [HttpGet("faculty", Name = "GetAllFacultys")]
        public IActionResult GetAllFacultys()
        {
            return Ok(_mapper.Map<List<FacultyOutputModel>>(_optionsService.GetAllFacultys()));
        }

        //[Authorize]
        [HttpGet("subject", Name = "GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            return Ok(_mapper.Map<List<SubjectOutputModel>>(_optionsService.GetAllSubjects()));
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("faculty", Name = "AddFaculty")]
        public IActionResult AddFaculty(string name)
        {
            return Ok(_optionsService.AddFaculty(name));
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("subject", Name = "AddSubject")]
        public IActionResult AddSubject(string name)
        {
            return Ok(_optionsService.AddSubject(name));
        }

        //[Authorize(Roles = "admin")]
        [HttpPut ("faculty/{id}", Name = "ChangeFacultyName")]
        public IActionResult ChangeFacultyName(int id, string newName)
        {
            _optionsService.UpdateFaculty(id, newName);
            return Ok();
        }

        //[Authorize(Roles = "admin")]
        [HttpPut("subject/{id}", Name = "ChangeSubjectName")]
        public IActionResult ChangeSubjectName(int id, string newName)
        {
            _optionsService.UpdateSubject(id, newName);
            return Ok();
        }
    }
}
