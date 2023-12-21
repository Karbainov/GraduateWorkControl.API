using GraduateWorkControl.BLL.Models.MaterialModels;
using GraduateWorkControl.BLL.Models.StudentModels;
using GraduateWorkControl.Core;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.WorkModels
{
    public class TaskModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string? Deadline { get; set; }

        public string? Description { get; set; }

        public TaskState State { get; set; }

        public List<CommentModel>? Comments { get; set; }

        public StudentModel? Student { get; set; }

        public List<MaterialModel>? Materials { get; set; }
    }
}
