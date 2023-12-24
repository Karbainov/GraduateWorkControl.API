using GraduateWorkControl.Core;
using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class ApplicationRepository
    {
        private Context _context = Context.MainContext;

        public int AddApplication(ApplicationDto application)
        {
            application.ApplicationState = Core.ApplicationState.Сonsideration;
            _context.Applications.Add(application);
            _context.SaveChanges(); 
            return application.Id;
        }
        
        public ApplicationDto? GetApplicationByUserId(int userId)
        {
            var s = _context.Applications.Include(a => a.Student).Include(a => a.Teacher).Where(a => a.Student.Id == userId).ToList();
            if (s.Count > 0)
            {
                return s[s.Count - 1];
            }
            else
            {
                return null;
            }
        }

        public List<ApplicationDto> GetApplicationsByTeacherId(int teacherId) 
        {
            return _context.Applications.Include(a => a.Student).Include(a => a.Teacher).Where(a => a.Teacher.Id == teacherId && a.ApplicationState==Core.ApplicationState.Сonsideration).ToList();
        }

        public void DeniedApplicationByStudent(int studentId)
        {
            var a = _context.Applications.Include(a => a.Student).Where(a => a.Student.Id == studentId).FirstOrDefault();
            if (a != null)
            {
                a.ApplicationState = Core.ApplicationState.DeniedByStydent;
            }
            _context.SaveChanges();
        }

        public void AnswerApplicationByTeacher(int applicationId, ApplicationState newState)
        {
            var a = _context.Applications.Include(a => a.Student).Include(a => a.Teacher).Where(a => a.Id == applicationId).FirstOrDefault();
            if (a != null)
            {
                a.ApplicationState= newState;
                a.Student.Teacher = a.Teacher;
            }

            _context.SaveChanges();
        }
    }
}
