using GraduateWorkControl.API.Models.OutputModels;
using GraduateWorkControl.API.Models.StudentModels.InputModels;
using GraduateWorkControl.API.Models.StudentModels.OutputModels;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.API.Models.TeacherModels.OutputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        [Authorize(Roles = "admin")]
        [HttpGet(Name = "GetAllStudentsInfoForAdmin")]
        public IActionResult GetAllStudentsInfoForAdmin()
        {
            var a = new List<StudentInfoOutputModel>()
            {
                new StudentInfoOutputModel()
                {
                    Id = 1,
                    FullName="Anton Antonovich",
                    Email = "Anton@Anton.Anton",
                    PhoneNumber="+999999999999",
                    GroupNumber="123112"
                },
                new StudentInfoOutputModel()
                {
                    Id = 2,
                    FullName="Boris Borisovich",
                    Email = "Boris@Boris.Boris",
                    GroupNumber="123112"
                }
            };

            return Ok(a);
        }

        [Authorize(Roles = "teacher")]
        [HttpGet("by-teacher/{teacherId}", Name = "GetAllStudentsInfoByTeacherId")]
        public IActionResult GetAllStudentsInfoByTeacherId(int teacherId)
        {
            var a = new List<StudentInfoOutputModel>()
            {
                new StudentInfoOutputModel()
                {
                    Id = 1,
                    FullName="Anton Antonovich",
                    Email = "Anton@Anton.Anton",
                    PhoneNumber="+999999999999",
                    GroupNumber="123112"
                },
                new StudentInfoOutputModel()
                {
                    Id = 2,
                    FullName="Boris Borisovich",
                    Email = "Boris@Boris.Boris",
                    GroupNumber="123112"
                }
            };

            return Ok(a);
        }

        [Authorize(Roles = "admin, student")]
        [HttpGet("{id}", Name = "GetFullStudentInfoById")]
        public IActionResult GetFullStudentInfoById(int id)
        {
            var a = new StudentFullInfoOutputModel()
            {
                Id = id,
                FullName = "Anton Antonovich",
                Email = "Anton@Anton.Anton",
                PhoneNumber = "+999999999999",
                Password = "Aaaaa",
                GroupNumber="sadas",
                Teacher= new TeacherInfoOutputModel()
                {
                    Id = 2,
                    FullName = "Boris Borisovich",
                    Email = "Boris@Boris.Boris",
                    Faculty = new FacultyOutputModel()
                    {
                        Id = 2,
                        Name ="Programming"
                    }
                }
            };

            return Ok(a);
        }


        [HttpPost(Name = "AddStudent")]
        public IActionResult AddStudent(StudentRegistrationInfoInputModel student)
        {
            return Ok(10);
        }

        [Authorize(Roles = "student")]
        [HttpPut("{id}", Name = "UpdateStudent")]
        public IActionResult UpdateStudent(StudentInfoInputModel student)
        {
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}", Name = "DeleteStudentById")]
        public IActionResult DeleteStudentById(int id)
        {
            return Ok();
        }
    }
}
