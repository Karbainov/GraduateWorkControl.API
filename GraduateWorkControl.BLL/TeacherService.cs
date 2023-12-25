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
                cfg.AddProfile(new MapperOptionsProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddTecher(TeacherCreateModel teacher)
        {
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            //teacherDto.Faculty = _optionsRepository.GetFacultyById(teacher.FacultyId);
            //teacherDto.Subjects = _optionsRepository.GetSubjectById(teacher.SubjectsIds);
            return _teacherRepository.AddTeacher(teacherDto, teacher.FacultyId, teacher.SubjectsIds);
        }

        public TeacherModel? GetTeacherByLoginAndPassword(string login, string pasword)
        {
            var t = _teacherRepository.GetTeacherByLoginAndPassword(login, pasword);
            if (t == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<TeacherModel>(t);
            }
        }

        public List<TeacherModel> GetAllTeachers()
        {
            return _mapper.Map<List<TeacherModel>>(_teacherRepository.GetAllTeachers());
        }

        public void UpdateTeacher(TeacherModel teacher)
        {
            _teacherRepository.UpdateTeacher(_mapper.Map<TeacherDto>(teacher));
        }

        public void UpdateFullTeacher(TeacherFullUpdateModel teacher)
        {
            var t = _mapper.Map<TeacherDto>(teacher);
            //t.Faculty = _optionsRepository.GetFacultyById(teacher.FacultyId);
            //t.Subjects = _optionsRepository.GetSubjectById(teacher.SubjectsIds);
            _teacherRepository.UpdateFullTeacher(t, teacher.FacultyId, teacher.SubjectsIds);
        }

        public TeacherModel GetTeacherById(int id)
        {
            return _mapper.Map<TeacherModel>(_teacherRepository.GetTeacherById(id));
        }

        public void DeleteTeacherById(int id) 
        {
            _teacherRepository.DeleteTeacheById(id);
        }

        public List<TeacherModel> GetTeachersByFacultyAndSubjects(int? faculty, List<int>? subject)
        {
            return _mapper.Map<List<TeacherModel>>(_teacherRepository.GetTeachersByFacultyAndSubjects(faculty, subject));
        }
    }
}
