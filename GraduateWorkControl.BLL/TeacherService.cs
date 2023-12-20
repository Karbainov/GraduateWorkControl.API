using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.TeacherModels;
using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL
{
    public class TeacherService
    {
        TeacherRepository _teacherRepository;
        OptionsRepository _optionsRepository;
        Mapper _mapper;
        public TeacherService() 
        {
            _teacherRepository=new TeacherRepository();
            _optionsRepository=new OptionsRepository();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperTeacherProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddTecher(TeacherCreateModel teacher)
        {
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            teacherDto.Faculty = _optionsRepository.GetFacultyById(teacher.FacultyId);
            teacherDto.Subjects = _optionsRepository.GetSubjectById(teacher.SubjectsIds);
            return _teacherRepository.AddTeacher(teacherDto);
        }
    }
}
