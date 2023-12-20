using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL.Dtos
{
    public class MaterialDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        public TaskDto? Tasks { get; set; }

        public CommentDto? Comments { get; set; }
    }
}
