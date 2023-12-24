namespace GraduateWorkControl.API.Models.Requests;

public class RegisterTravelUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
