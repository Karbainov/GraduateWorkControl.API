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
        private Context _context = Context.MainContext;

        public int AddTeacher(TeacherDto teacherDto)
        {
            _context.Teachers.Add(teacherDto);
            _context.SaveChanges();

            return teacherDto.Id;
        }

        public TeacherDto GetTeacherById(int id)
        {
            return _context.Teachers.Where(s => s.Id == id).Single();
        }
    }
}
