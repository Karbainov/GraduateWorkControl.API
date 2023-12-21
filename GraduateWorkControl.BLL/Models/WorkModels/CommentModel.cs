using GraduateWorkControl.BLL.Models.MaterialModels;
using GraduateWorkControl.BLL.Models.StudentModels;
using GraduateWorkControl.BLL.Models.TeacherModels;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.WorkModels
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string? Comment { get; set; }

        public StudentModel? Student { get; set; }

        public TeacherModel? Teacher { get; set; }

        public List<MaterialModel>? Materials { get; set; }
    }
}
