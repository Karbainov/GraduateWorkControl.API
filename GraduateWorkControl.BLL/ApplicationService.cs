using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.ApplicationModels;
using GraduateWorkControl.Core;
using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;
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
                cfg.AddProfile(new MapperStudentProfile());
                cfg.AddProfile(new MapperTeacherProfile());
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

        public ApplicationModel GetApplicationByUserId(int id)
        {   
            return _mapper.Map<ApplicationModel>(_applicationRepository.GetApplicationByUserId(id));
        }

        public List<ApplicationModel> GetApplicationsByTeacherId(int id)
        {
            return _mapper.Map<List<ApplicationModel>>(_applicationRepository.GetApplicationsByTeacherId(id));
        }

        public void DeniedApplicationByStudent(int studentId)
        {
            _applicationRepository.DeniedApplicationByStudent(studentId);
        }

        public void AnswerApplicationByTeacher(int applicationId, ApplicationState newState)
        {
            _applicationRepository.AnswerApplicationByTeacher(applicationId, newState);
        }
    }
}
