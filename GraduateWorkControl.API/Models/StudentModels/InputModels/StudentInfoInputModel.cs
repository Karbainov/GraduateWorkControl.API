namespace GraduateWorkControl.API.Models.StudentModels.InputModels
{
    public class StudentInfoInputModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string GroupNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
