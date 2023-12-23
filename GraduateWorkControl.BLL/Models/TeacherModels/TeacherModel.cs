using GraduateWorkControl.BLL.Models.OptionsModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.TeacherModels
{
    public class TeacherModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? FatherName { get; set; }

        public string Email { get; set; }

        public string? PhotoLink { get; set; }
        
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public FacultyModel? Faculty { get; set; }

        public List<SubjectModel>? Subjects { get; set; }
    }
}
