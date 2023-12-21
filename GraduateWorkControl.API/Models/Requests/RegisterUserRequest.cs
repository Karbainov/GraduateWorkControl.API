namespace GraduateWorkControl.API.Models.Requests;

public class RegisterUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
}
