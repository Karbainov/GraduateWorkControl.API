using GraduateWorkControl.DAL.Dtos;
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
    }
}
