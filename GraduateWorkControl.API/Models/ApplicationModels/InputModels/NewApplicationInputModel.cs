using GraduateWorkControl.API.Models.StudentModels.InputModels;

namespace GraduateWorkControl.API.Models.ApplicationModels.InputModels
{

    public class NewApplicationInputModel
    {
        public int StudentId {  get; set; } 

        public int TeacherId { get; set; }

        public string WorkTheme { get; set;}

        public string? CoveringLetter { get;set;}
    }
}
