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
    public class TaskRepository
    {
        private Context _context = Context.MainContext;

        public int AddTask(TaskDto task)
        {
            _context.Task.Add(task);
            _context.SaveChanges();
            return task.Id;
        }

        public TaskDto GetTaskById(int id) 
        {
            return _context.Task.Include(t=>t.Comments).ThenInclude(c=>c.Teacher).Include(t => t.Comments).ThenInclude(c => c.Student).Where(t => t.Id == id).FirstOrDefault();
        }

        public List<TaskDto> GetAllTasksByStudentId(int id)
        {
            return _context.Task.Include(t=>t.Student).Where(t=>t.Student.Id==id).ToList();
        }

        public void UpdateTask(TaskDto task)
        {
            var t=_context.Task.Where(t => t.Id == task.Id).FirstOrDefault();
            if(t!=null)
            {
                t.Number = task.Number;
                t.Name = task.Name;
                t.Description = task.Description;
                t.Number= task.Number;
            }
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var t = _context.Task.Where(t => t.Id == id).FirstOrDefault();
            if (t != null)
            {
                _context.Remove(t);
            }
            _context.SaveChanges();
        }

        public void ChangeTaskState(int id, TaskState taskState)
        {
            var t=_context.Task.Where(t => t.Id == id).FirstOrDefault();
            if (t!=null)
            {
                t.State= taskState;
            }
            _context.SaveChanges();
        }

        public TeacherDto GetTeacherFromTask(int id)
        {
            return _context.Task.Include(t => t.Student).Include(t => t.Student.Teacher).Where(t => t.Id == id).FirstOrDefault().Student.Teacher;
        }

        public StudentDto GetStudentFromTask(int id)
        {
            return _context.Task.Include(t => t.Student).Where(t => t.Id == id).FirstOrDefault().Student;
        }
    }
}
