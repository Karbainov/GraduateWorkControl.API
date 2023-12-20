using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL.Dtos
{
    public class StudentDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string GroupNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [AllowNull]
        public string? PhoneNumber { get; set; }


        public List<ApplicationDto>? Application { get; set; }

        public List<TaskDto>? Tasks { get; set; } 
        
        public TeacherDto? Teacher { get; set; }

        public List<CommentDto>? Comments { get; set; }
    }
}
