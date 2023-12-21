using GraduateWorkControl.BLL.Models.StudentModels;
using GraduateWorkControl.BLL.Models.TeacherModels;
using GraduateWorkControl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.ApplicationModels
{
    public class ApplicationModel
    {
        public int Id { get; set; }

        public StudentModel Student { get; set; }

        public TeacherModel Teacher { get; set; }

        public ApplicationState ApplicationState { get; set; }

        public string WorkTheme { get; set; }

        public string? CoveringLetter { get; set; }
    }
}
