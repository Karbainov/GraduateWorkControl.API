using GraduateWorkControl.DAL.Dtos.Movies;

namespace GraduateWorkControl.API.Models.Responses;

public class UserFullResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
    public List<UserWatchListResponse> WatchList { get; set; }
    public List<MovieRatingResponse> Ratings { get; set; }
}
