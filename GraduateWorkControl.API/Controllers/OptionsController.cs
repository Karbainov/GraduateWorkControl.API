using GraduateWorkControl.API.Models.OutputModels;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.API.Models.TeacherModels.OutputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : Controller
    {
        [Authorize]
        [HttpGet("faculty", Name = "GetAllFacultys")]
        public IActionResult GetAllFacultys()
        {
            var a = new List<FacultyOutputModel>()
            {
                new FacultyOutputModel()
                {
                    Id = 1,
                    Name = "Pragramming"
                },
                new FacultyOutputModel()
                {
                    Id = 2,
                    Name = "Phisics"
                },
            };
            return Ok(a);
        }

        [Authorize]
        [HttpGet("subject", Name = "GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            var a = new List<SubjectOutputModel>()
            {
                new SubjectOutputModel()
                {
                    Id = 1,
                    Name = "Pragramming"
                },
                new SubjectOutputModel()
                {
                    Id = 2,
                    Name = "Math"
                },
                new SubjectOutputModel()
                {
                    Id = 3,
                    Name = "OOP"
                },

            };
            return Ok(a);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("faculty", Name = "AddFaculty")]
        public IActionResult AddFaculty(string name)
        {
            return Ok(10);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("subject", Name = "AddSubject")]
        public IActionResult AddSubject(string name)
        {
            return Ok(10);
        }

        [Authorize(Roles = "admin")]
        [HttpPut ("faculty/{id}", Name = "ChangeFacultyName")]
        public IActionResult ChangeFacultyName(string newName)
        {
            return Ok(10);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("subject/{id}", Name = "ChangeSubjectName")]
        public IActionResult ChangeSubjectName(string newName)
        {
            return Ok(10);
        }
    }
}
