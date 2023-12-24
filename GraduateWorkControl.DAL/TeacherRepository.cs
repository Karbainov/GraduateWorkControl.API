using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class TeacherRepository
    {
        private Context _context;

        public TeacherRepository()
        {
            _context = new Context();
        }

        public int AddTeacher(TeacherDto teacherDto)
        {
            teacherDto.IsDeleted = false;
            _context.Teachers.Add(teacherDto);
            _context.SaveChanges();

            return teacherDto.Id;
        }

        public TeacherDto GetTeacherById(int id)
        {
            return _context.Teachers.Include(t => t.Subjects).Include(t => t.Faculty).Where(s => s.Id == id && !s.IsDeleted).Single();
        }

        public TeacherDto? GetTeacherByLoginAndPassword(string login, string password) 
        {
            return _context.Teachers.Where(t => t.Email == login && t.Password == password && !t.IsDeleted).FirstOrDefault();
        }

        public List<TeacherDto> GetAllTeachers()
        {
            var t= _context.Teachers.Include(t => t.Subjects).Include(t => t.Faculty).Where(t => !t.IsDeleted).ToList();
            return t;
        }

        public void UpdateTeacher(TeacherDto teacherDto)
        {
            var t=_context.Teachers.Where(t => t.Id == teacherDto.Id && !t.IsDeleted).FirstOrDefault();
            if(t != null)
            {
                t.PhoneNumber = teacherDto.PhoneNumber;
                t.Email = teacherDto.Email;
            }
            _context.SaveChanges();
        }

        public void UpdateFullTeacher(TeacherDto teacherDto)
        {
            var t = _context.Teachers.Where(t => t.Id == teacherDto.Id && !t.IsDeleted).FirstOrDefault();
            if (t != null)
            {
                t.PhoneNumber = teacherDto.PhoneNumber;
                t.Email = teacherDto.Email;
                t.FirstName = teacherDto.FirstName;
                t.LastName = teacherDto.LastName;
                t.Password = teacherDto.Password;
                t.Subjects = teacherDto.Subjects;
                t.Faculty = teacherDto.Faculty;
            }
            _context.SaveChanges();
        }

        public void DeleteTeacheById(int id)
        {
            var t=_context.Teachers.Where(t => t.Id == id).FirstOrDefault();
            if( t != null )
            {
                t.IsDeleted = true;
            }
            _context.SaveChanges();
        }

        public List<TeacherDto> GetTeachersByFacultyAndSubjects(int? faculty, List<int>? subject)
        {
            if (faculty != null && subject != null && subject.Count > 0)
            {
                var ans = _context.Teachers.Include(t => t.Subjects).Include(t => t.Faculty)
                    .Where(t => (t.Faculty.Id == faculty && t.Subjects.Where(s => subject.Contains(s.Id)).Count() > 0) && !t.IsDeleted).ToList();
                return ans;
            }
            else if(faculty != null)
            {
                var ans = _context.Teachers.Include(t => t.Subjects).Include(t => t.Faculty)
                    .Where(t => (t.Subjects.Where(s => subject.Contains(s.Id)).Count() > 0) && !t.IsDeleted).ToList();
                return ans;
            }
            else if(subject != null && subject.Count > 0)
            {
                var ans = _context.Teachers.Include(t => t.Subjects).Include(t => t.Faculty)
                    .Where(t => (t.Faculty.Id == faculty) && !t.IsDeleted).ToList();
                return ans;
            }
            else
            {
                return new List<TeacherDto> { };
            }
        }

    }
}
