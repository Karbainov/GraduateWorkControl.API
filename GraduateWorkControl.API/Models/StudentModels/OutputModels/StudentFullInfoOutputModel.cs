using GraduateWorkControl.API.Models.TeacherModels.OutputModels;

namespace GraduateWorkControl.API.Models.StudentModels.OutputModels
{
    public class StudentFullInfoOutputModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GroupNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public TeacherInfoOutputModel Teacher { get; set; }
    }
}
