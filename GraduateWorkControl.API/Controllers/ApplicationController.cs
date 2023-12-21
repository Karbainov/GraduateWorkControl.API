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
                cfg.AddProfile(new MappingStudentProfile());
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
            var t = _applicationService.GetApplicationByUserId(studentId);
            var s = _mapper.Map<StudentsApplicationOutputModel>(t);
            s.TeachersFullName = $"{t.Teacher.FirstName} {t.Teacher.LastName}";
            return Ok(s);
        }

        //[Authorize(Roles = "teacher")]
        [HttpGet("teacher/{teacherId}", Name = "GetApplicationsByTeacherId")]
        public IActionResult GetApplicationsByTeacherId(int teacherId)
        {
            return Ok(_mapper.Map<List<TeachersApplicationOutputModel>>(_applicationService.GetApplicationsByTeacherId(teacherId)));
        }

        //[Authorize(Roles = "teacher")]
        [HttpPut("teacher/{teacherId}/{applicationId}", Name= "AnswerApplicationByTeacher")]
        public IActionResult AnswerApplicationByTeacher(int applicationId, ApplicationState newState)
        {
            _applicationService.AnswerApplicationByTeacher(applicationId, newState);
            return Ok();
        }

        //[Authorize(Roles = "student")]
        [HttpPut("{studentId}", Name = "DeniedApplicationByStudent")]
        public IActionResult DeniedApplicationByStudent(int studentId)
        {
           _applicationService.DeniedApplicationByStudent(studentId);
           return Ok();
        }
    }
}
