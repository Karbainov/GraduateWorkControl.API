namespace GraduateWorkControl.API.Models.StudentModels.OutputModels
{
    public class StudentInfoOutputModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string GroupNumber { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
