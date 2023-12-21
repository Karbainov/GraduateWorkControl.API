namespace GraduateWorkControl.DAL.Dtos.Movies;

public class MovieRating
{
    public int UserId { get; set; }
    public int MediaId { get; set; }
    public int Rating { get; set; }
    public User User { get; set; }
}
