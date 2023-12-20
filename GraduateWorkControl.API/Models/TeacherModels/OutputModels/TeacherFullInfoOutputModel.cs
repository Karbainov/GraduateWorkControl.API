using GraduateWorkControl.API.Models.OutputModels;

namespace GraduateWorkControl.API.Models.TeacherModels.OutputModels
{
    public class TeacherFullInfoOutputModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password {  get; set; }

        public string? PhoneNumber { get; set; }

        public FacultyOutputModel Faculty { get; set; }

        public List<SubjectOutputModel> Subjects { get; set; }
    }
}
