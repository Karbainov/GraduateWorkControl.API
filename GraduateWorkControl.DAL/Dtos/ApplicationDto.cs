using GraduateWorkControl.Core;
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
    public class ApplicationDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(ApplicationState))]
        public ApplicationState ApplicationState { get; set; }

        [Required]
        [StringLength(255)]
        public string WorkTheme { get; set; }

        [AllowNull]
        public string? CoveringLetter { get; set; }

        public StudentDto? Student { get; set; }

        public TeacherDto? Teacher { get; set; }
    }
}
