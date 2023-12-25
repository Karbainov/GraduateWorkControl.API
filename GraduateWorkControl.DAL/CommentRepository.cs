using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class CommentRepository
    {
        private Context _context;

        public CommentRepository()
        {
            _context = new Context();
        }

        public int AddComment(CommentDto comment, int taskId, bool isTeacher, List<int> materialsId)
        {
            if (materialsId != null)
            {
                comment.Materials = _context.Materials.Where(s => materialsId.Contains(s.Id)).ToList();
            }

            comment.Task=_context.Task.Where(t=>t.Id == taskId).FirstOrDefault();

            if(isTeacher)
            {
                comment.Teacher= _context.Task.Include(t=>t.Student).ThenInclude(s=>s.Teacher).FirstOrDefault(t => t.Id == comment.Task.Id).Student.Teacher;
            }
            else
            {
                comment.Student = _context.Task.Include(t=>t.Student).FirstOrDefault(t => t.Id == comment.Task.Id).Student;
            }
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment.Id;
        }

        public void DeleteComment(int id)
        {
            var c= _context.Comments.Where(c => c.Id == id).FirstOrDefault();
            if (c != null)
            {
                _context.Comments.Remove(c);
            }
            _context.SaveChanges();
        }
    }
}
