using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.OutputModels;
using GraduateWorkControl.API.Models.StudentModels.InputModels;
using GraduateWorkControl.API.Models.StudentModels.OutputModels;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.API.Models.TeacherModels.OutputModels;
using GraduateWorkControl.BLL;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.StudentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        Mapper _mapper;
        StudentServise _studentServise;

        public StudentController()
        {
            _studentServise=new StudentServise();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingStudentProfile());
                cfg.AddProfile(new MappingTeacherProfile());
                cfg.AddProfile(new MappingOptionsProfile());
            });
            _mapper = new Mapper(config);
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet(Name = "GetAllStudentsInfoForAdmin")]
        public IActionResult GetAllStudentsInfoForAdmin()
        {
            return Ok(_mapper.Map<List<StudentInfoOutputModel>>(_studentServise.GetAllStudents()));
        }

        [Authorize(Roles = "teacher")]
        [HttpGet("by-teacher/{teacherId}", Name = "GetAllStudentsInfoByTeacherId")]
        public IActionResult GetAllStudentsInfoByTeacherId(int teacherId)
        {
            var s=_studentServise.GetStudentsByTeacherId(teacherId);
            
            return Ok(_mapper.Map<List<StudentInfoOutputModel>>(s));
        }

        [Authorize(Roles = "admin, student")]
        [HttpGet("{id}", Name = "GetFullStudentInfoById")]
        public IActionResult GetFullStudentInfoById(int id)
        {
            var s=_studentServise.GetStudentById(id);

            return Ok(_mapper.Map<StudentFullInfoOutputModel>(s));
        }

        [HttpPost(Name = "AddStudent")]
        public IActionResult AddStudent(StudentRegistrationInfoInputModel student)
        {
            var s = _mapper.Map<StudentCreateModel>(student);
            return Ok(_studentServise.AddStudent(s));
        }

        [Authorize(Roles = "student")]
        [HttpPut("{id}", Name = "UpdateStudent")]
        public IActionResult UpdateStudent(StudentInfoInputModel student)
        {
            _studentServise.UpdateStudent(_mapper.Map<StudentModel>(student));
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}", Name = "DeleteStudentById")]
        public IActionResult DeleteStudentById(int id)
        {
            _studentServise.DeleteStudent(id);
            return Ok();
        }
    }
}
