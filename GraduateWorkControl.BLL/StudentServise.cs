using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.StudentModels;
using GraduateWorkControl.BLL.Models.TeacherModels;
using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL
{
    public class StudentServise
    {
        StudentRepository _studentRepository;
        Mapper _mapper;

        public StudentServise() 
        {
            _studentRepository = new StudentRepository();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperStudentProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddStudent(StudentCreateModel student)
        {
            var s=_mapper.Map<StudentDto>(student);
            return _studentRepository.AddStudent(s);
        }

        public StudentModel? GetStudentByLoginAndPassword(string login, string pasword)
        {
            var t = _studentRepository.GetStudentByLoginAndPassword(login, pasword);
            if (t == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<StudentModel>(t);
            }
        }
    }
}
