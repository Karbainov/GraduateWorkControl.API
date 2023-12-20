using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL.Dtos
{
    public class TeacherDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [AllowNull]
        public string? PhoneNumber { get; set; }

        [Required]
        public FacultyDto? Faculty { get; set; }

        [Required]
        public ICollection<SubjectDto>? Subjects { get; set; }

        public List<StudentDto>? Students { get; set; }

        public List<ApplicationDto>? Applications { get; set; }

        public List<CommentDto>? Comments { get; set; }
    }
}
