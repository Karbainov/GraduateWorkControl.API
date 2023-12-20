using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.ApplicationModels
{
    public class ApplicationCreateModel
    {
        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public string WorkTheme { get; set; }

        public string? CoveringLetter { get; set; }
    }
}
