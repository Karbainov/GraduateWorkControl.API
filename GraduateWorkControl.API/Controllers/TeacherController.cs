using AutoMapper;
using GraduateWorkControl.API.Models.OutputModels;
using GraduateWorkControl.API.Models.TeacherModels.InputModels;
using GraduateWorkControl.API.Models.TeacherModels.OutputModels;
using GraduateWorkControl.BLL;
using GraduateWorkControl.API.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GraduateWorkControl.BLL.Models.TeacherModels;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : Controller
    {
        TeacherService _teacherService;
        Mapper _mapper;

        public TeacherController()
        {
            _teacherService = new TeacherService();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTeacherProfile());
                cfg.AddProfile(new MappingOptionsProfile());
            });
            _mapper = new Mapper(config);
        }

        [Authorize(Roles = "admin, student")]
        [HttpGet(Name = "GetAllTeachersInfoForAdmin")]
        public IActionResult GetAllTeachersInfoForAdmin()
        {
            return Ok(_mapper.Map<List<TeacherInfoOutputModel>>(_teacherService.GetAllTeachers()));
        }

        [Authorize(Roles = "admin, teacher")]
        [HttpGet("{id}",Name = "GetFullTeacherInfoById")]
        public IActionResult GetFullTeacherInfoById(int id)
        {
            return Ok(_mapper.Map<TeacherFullInfoOutputModel>(_teacherService.GetTeacherById(id)));
        }

        [HttpGet("application", Name = "GetTeachersByFacultyAndSubject")]
        public IActionResult GetTeachersByFacultyAndSubject([FromQuery] TeachersFacultyAndSubjectInputModel facultyAndSubject)
        {
            return Ok(_mapper.Map<List<TeacherInfoOutputModel>>(_teacherService.GetTeachersByFacultyAndSubjects(facultyAndSubject.FacultyName, facultyAndSubject.SubjectName)));
        }

        [Authorize(Roles = "admin")]
        [HttpPost(Name = "AddTeacher")]
        public IActionResult AddTeacher(TeacherRegistrationInfoInputModel teacher)
        {
            var t =_mapper.Map<TeacherCreateModel>(teacher);
            return Ok(_teacherService.AddTecher(t));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}", Name = "UpdateTeacherByAdmin")]
        public IActionResult UpdateTeacherByAdmin(TeacherFullInfoInputModel teacher)
        {
            _teacherService.UpdateFullTeacher(_mapper.Map<TeacherFullUpdateModel>(teacher));
            return Ok();
        }

        [Authorize(Roles = "teacher")]
        [HttpPut(Name = "UpdateTeacherByUser")]
        public IActionResult UpdateTeacherByUser(TeacherShortInfoInputModel teacher)
        {
            _teacherService.UpdateTeacher(_mapper.Map<TeacherModel>(teacher));
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}",Name = "DeleteTeacherById")]
        public IActionResult DeleteTeacherById(int id)
        {
            _teacherService.DeleteTeacherById(id);
            return Ok();
        }
    }
}
