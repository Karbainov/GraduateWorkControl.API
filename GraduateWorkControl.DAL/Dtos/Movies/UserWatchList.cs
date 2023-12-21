namespace GraduateWorkControl.DAL.Dtos.Movies;

public class UserWatchList
{
    public int UserId { get; set; }
    public int MediaId { get; set; }
    public User User { get; set; }
}
