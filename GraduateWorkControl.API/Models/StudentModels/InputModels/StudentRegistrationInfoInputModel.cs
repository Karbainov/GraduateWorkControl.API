namespace GraduateWorkControl.API.Models.StudentModels.InputModels
{
    public class StudentRegistrationInfoInputModel
    {
        public string FullName { get; set; }

        public string GroupNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
