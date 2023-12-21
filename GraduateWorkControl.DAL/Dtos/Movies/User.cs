namespace GraduateWorkControl.DAL.Dtos.Movies;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
    public List<UserWatchList> WatchList { get; set; }
    public List<MovieRating> Ratings { get; set; }
}
