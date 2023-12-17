using GraduateWorkControl.API.Models.StudentModels.OutputModels;
using GraduateWorkControl.Core;

namespace GraduateWorkControl.API.Models.ApplicationModels.OutputModels
{
    public class TeachersApplicationOutputModel
    {
        public int Id { get; set; }

        public StudentInfoOutputModel StudentInfo { get; set; }

        public ApplicationState ApplicationState { get; set; }

        public string WorkTheme { get; set; }

        public string? CoveringLetter { get; set; }
    }
}
