using GraduateWorkControl.DAL.Dtos;
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
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.Id;
        }
    }
}
