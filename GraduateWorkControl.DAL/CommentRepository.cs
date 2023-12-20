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
    }
}
