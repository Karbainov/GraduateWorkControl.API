using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.ApplicationModels;
using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL
{
    public class ApplicationService
    {
        private ApplicationRepository _applicationRepository;
        private TeacherRepository _teacherRepository;
        private StudentRepository _studentRepository;
        private Mapper _mapper;
        public ApplicationService()
        {
            _applicationRepository = new ApplicationRepository();
            _studentRepository=new StudentRepository();
            _teacherRepository = new TeacherRepository();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperApplicationProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddApplication(ApplicationCreateModel application)
        {
            var ap=_mapper.Map<ApplicationDto>(application);
            ap.Student =_studentRepository.GetStudentById(application.StudentId);
            ap.Teacher =_teacherRepository.GetTeacherById(application.TeacherId);
            return _applicationRepository.AddApplication(ap);
        }
    }
}
