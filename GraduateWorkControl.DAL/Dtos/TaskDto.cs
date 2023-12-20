using GraduateWorkControl.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL.Dtos
{
    public class TaskDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        [AllowNull]
        public string? Deadline { get; set; }

        [AllowNull]
        public string? Description { get; set; }

        [Required]
        [EnumDataType(typeof(TaskState))]
        public TaskState State { get; set; }

        public ICollection<CommentDto>? Comments { get; set; } = new List<CommentDto>();

        public StudentDto? Student { get; set; }

        public ICollection<MaterialDto>? Materials { get; set; }
    }
}
