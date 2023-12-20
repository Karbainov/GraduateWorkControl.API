using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.ApplicationModels.InputModels;
using GraduateWorkControl.API.Models.ApplicationModels.OutputModels;
using GraduateWorkControl.BLL;
using GraduateWorkControl.BLL.Models.ApplicationModels;
using GraduateWorkControl.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : Controller
    {
        Mapper _mapper;
        ApplicationService _applicationService;

        public ApplicationController()
        {
            _applicationService = new ApplicationService();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingApplicationProfile());
            });
            _mapper = new Mapper(config);
        }

        //[Authorize(Roles = "student")]
        [HttpPost(Name = "AddNewApplication")]
        public IActionResult AddNewApplication(NewApplicationInputModel application)
        {

            return Ok(_applicationService.AddApplication(_mapper.Map<ApplicationCreateModel>(application)));
        }

        //[Authorize(Roles = "student")]
        [HttpGet("{studentId}", Name = "GetApplicationByStudentId")]
        public IActionResult GetApplicationByStudentId(int studentId) 
        {
            var a = new StudentsApplicationOutputModel()
            {
                Id = 1,
                TeachersFullName = "Boris Borisovich",
                ApplicationState = Core.ApplicationState.Сonsideration,
                WorkTheme="qwerty",
                CoveringLetter= "qwerty qwerty qwerty qwerty",
            };

            return Ok(a);
        }

        //[Authorize(Roles = "teacher")]
        [HttpGet("teacher/{teacherId}", Name = "GetApplicationsByTeacherId")]
        public IActionResult GetApplicationsByTeacherId(int teacherId)
        {
            var a = new List<TeachersApplicationOutputModel>()
                {
                    new TeachersApplicationOutputModel()
                    {
                        Id = 1,
                        StudentInfo=new Models.StudentModels.OutputModels.StudentInfoOutputModel(),
                        ApplicationState = Core.ApplicationState.Сonsideration,
                        WorkTheme = "qwerty",
                        CoveringLetter = "qwerty qwerty qwerty qwerty",
                    }
                };

            return Ok(a);
        }

        //[Authorize(Roles = "teacher")]
        [HttpPut("teacher/{teacherId}/{applicationId}", Name= "AnswerApplicationByTeacher")]
        public IActionResult AnswerApplicationByTeacher(int applicationId, ApplicationState newState)
        {
            return Ok();
        }

        //[Authorize(Roles = "student")]
        [HttpPut("{studentId}", Name = "DeniedApplicationByStudent")]
        public IActionResult DeniedApplicationByStudent(int studentId)
        {
           return Ok();
        }
    }
}
