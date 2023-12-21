using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class CommentRepository
    {
        private Context _context = Context.MainContext;

        public int AddComment(CommentDto comment)
        {
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
