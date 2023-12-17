using GraduateWorkControl.Core;

namespace GraduateWorkControl.API.Models.ApplicationModels.OutputModels
{
    public class StudentsApplicationOutputModel
    {
        public int Id { get; set; }

        public ApplicationState ApplicationState { get; set; }

        public string TeachersFullName { get; set; }

        public string WorkTheme { get; set; }

        public string? CoveringLetter { get; set; }
    }
}
