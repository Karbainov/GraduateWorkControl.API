﻿using AutoMapper;
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
            _studentRepository = new StudentRepository();
            _teacherRepository = new TeacherRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperApplicationProfile());
                cfg.AddProfile(new MapperStudentProfile());
                cfg.AddProfile(new MapperTeacherProfile());
                cfg.AddProfile(new MapperOptionsProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddApplication(ApplicationCreateModel application)
        {
            var ap = _mapper.Map<ApplicationDto>(application);
            return _applicationRepository.AddApplication(ap, application.StudentId, application.TeacherId);
        }

        public ApplicationModel? GetApplicationByUserId(int id)
        {
            var a = _applicationRepository.GetApplicationByUserId(id);
            if (a == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<ApplicationModel>(a);
            }
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
