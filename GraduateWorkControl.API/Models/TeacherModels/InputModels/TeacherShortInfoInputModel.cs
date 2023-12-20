using GraduateWorkControl.API.Models.OutputModels;

namespace GraduateWorkControl.API.Models.TeacherModels.InputModels
{
    public class TeacherShortInfoInputModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
