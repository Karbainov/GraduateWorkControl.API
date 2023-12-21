using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class StudentRepository
    {
        private Context _context = Context.MainContext;

        public int AddStudent(StudentDto student)
        {
            student.IsDelited = false;
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.Id;
        }

        public List<StudentDto> GetAllStudents()
        {
            return _context.Students.Where(s=>!s.IsDelited).ToList();
        }

        public StudentDto GetStudentById(int id)
        {
            return _context.Students.Include(s => s.Teacher).Include(s => s.Teacher.Faculty).Include(s => s.Teacher.Subjects).Where(s => s.Id == id && !s.IsDelited).Single();
        }

        public List<StudentDto> GetStudentsByTeacherId(int id)
        {
            return _context.Students.Include(s=>s.Teacher).Where(s=>s.Teacher!=null && s.Teacher.Id== id && !s.IsDelited).ToList();
        }

        public StudentDto? GetStudentByLoginAndPassword(string login, string password)
        {
            return _context.Students.Where(t => t.Email == login && t.Password == password && !t.IsDelited).FirstOrDefault();
        }

        public void DeleteStudent(int id)
        {
            _context.Students.Where(s=>s.Id==id).Single().IsDelited = true;
            _context.SaveChanges();
        }

        public void UpdateStudent(StudentDto student)
        {
            var s = _context.Students.Where(s => s.Id == student.Id && !s.IsDelited).FirstOrDefault();
            if(s!=null)
            {
                s.PhoneNumber = student.PhoneNumber;
                s.GroupNumber = student.GroupNumber;
                s.Email = student.Email;
                s.Password = student.Password;
                s.FirstName = student.FirstName;
                s.LastName  = student.LastName;
            }
            _context.SaveChanges();
        }
    }
}
