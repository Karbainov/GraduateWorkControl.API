using GraduateWorkControl.API.Models.OutputModels;

namespace GraduateWorkControl.API.Models.TeacherModels.InputModels
{
    public class TeacherFullInfoInputModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhotoLink { get; set; }

        public string Password { get; set; }

        public int FacultyId { get; set; }

        public List<int> SubjectsIds { get; set; }
    }
}
