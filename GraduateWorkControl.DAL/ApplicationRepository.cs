using GraduateWorkControl.DAL.Dtos;
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
            _context.Applications.Add(application);
            _context.SaveChanges(); 
            return application.Id;
        }
    }
}
