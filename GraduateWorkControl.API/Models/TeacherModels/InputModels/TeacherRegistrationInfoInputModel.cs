namespace GraduateWorkControl.API.Models.TeacherModels.InputModels
{
    public class TeacherRegistrationInfoInputModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int FacultyId { get; set; }

        public List<int> SubjectsIds { get; set; }
    }
}
