using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL.Dtos
{
    public class CommentDto
    {
        [Key]
        public int Id { get; set; }

        [AllowNull]
        public string? Comment { get; set; }

        [AllowNull]
        public StudentDto? Student { get; set; }

        [AllowNull]
        public TeacherDto? Teacher { get; set; }

        public TaskDto? Task { get; set; }

        public List<MaterialDto>? Materials { get; set; }
    }
}
