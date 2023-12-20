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
            });
            _mapper = new Mapper(config);
        }

        //[Authorize(Roles = "admin")]
        [HttpGet(Name = "GetAllTeachersInfoForAdmin")]
        public IActionResult GetAllTeachersInfoForAdmin()
        {
            var a = new List<TeacherInfoOutputModel>()
            { 
                new TeacherInfoOutputModel()
                {
                    Id = 1,
                    //FullName="Anton Antonovich",
                    Email = "Anton@Anton.Anton",
                    PhoneNumber="+999999999999",
                    Faculty=new FacultyOutputModel()
                    {
                        Id=1,
                        Name="Programming"
                    }
                },
                new TeacherInfoOutputModel()
                {
                    Id = 2,
                    //FullName="Boris Borisovich",
                    Email = "Boris@Boris.Boris",
                    Faculty=new FacultyOutputModel()
                    {
                        Id=2,
                        Name="Phisics"
                    }
                }
            };

            return Ok(a);
        }

        //[Authorize(Roles = "admin, teacher")]
        [HttpGet("{id}",Name = "GetFullTeacherInfoById")]
        public IActionResult GetFullTeacherInfoById(int id)
        {
            var a=new TeacherFullInfoOutputModel() 
            { 
                Id = id,
                ////FullName="Anton Antonovich",
                Email = "Anton@Anton.Anton",
                PhoneNumber="+999999999999",
                Password="Aaaaa",
                Faculty=new FacultyOutputModel()
                {
                    Id=1,
                    Name="Programming"
                },
                Subjects = new List<SubjectOutputModel>
                {
                    new SubjectOutputModel()
                    {
                        Id=1,
                        Name="OOP"
                    },
                    new SubjectOutputModel()
                    {
                        Id=2,
                        Name="DB"
                    }
                }
            };

            return Ok(a);
        }

        [HttpGet("application", Name = "GetTeachersByFacultyAndSubject")]
        public IActionResult GetTeachersByFacultyAndSubject(TeachersFacultyAndSubjectInputModel facultyAndSubject)
        {

            var a = new List<TeacherInfoOutputModel>()
            {
                new TeacherInfoOutputModel()
                {
                    Id = 1,
                    //FullName="Anton Antonovich",
                    Email = "Anton@Anton.Anton",
                    PhoneNumber="+999999999999",
                    Faculty=new FacultyOutputModel()
                    {
                        Id=1,
                        Name=facultyAndSubject.FacultyName
                    }
                },
                new TeacherInfoOutputModel()
                {
                    Id = 2,
                    //FullName="Boris Borisovich",
                    Email = "Boris@Boris.Boris",
                    Faculty=new FacultyOutputModel()
                    {
                        Id=2,
                        Name=facultyAndSubject.FacultyName
                    }
                }
            };

            return Ok(a);
        }

        //[Authorize(Roles = "admin")]
        [HttpPost(Name = "AddTeacher")]
        public IActionResult AddTeacher(TeacherRegistrationInfoInputModel teacher)
        {
            var t =_mapper.Map<TeacherCreateModel>(teacher);
            return Ok(_teacherService.AddTecher(t));
        }

        //[Authorize(Roles = "admin")]
        [HttpPut("{id}", Name = "UpdateTeacherByAdmin")]
        public IActionResult UpdateTeacherByAdmin(TeacherFullInfoInputModel teacher)
        {
            return Ok();
        }

        //[Authorize(Roles = "teacher")]
        [HttpPut(Name = "UpdateTeacherByUser")]
        public IActionResult UpdateTeacherByUser(TeacherShortInfoInputModel teacher)
        {
            return Ok();
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}",Name = "DeleteTeacherById")]
        public IActionResult DeleteTeacherById(int id)
        {
            return Ok();
        }
    }
}
