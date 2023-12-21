using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos.Movies;

namespace GraduateWorkControl.BLL;

public class MoviesService
{
    private MoviesRepository _moviesRepository;

    public MoviesService()
    {
        _moviesRepository = new MoviesRepository();
    }

    public int Register(User user)
    {
        return _moviesRepository.Register(user);
    }

    public User Login(string email, string password)
    {
        return _moviesRepository.GetUserByCreds(email, password);
    }

    public User GetUserById(int id)
    {
        return _moviesRepository.GetUserById(id);
    }

    public void AddMediaToWatchList(UserWatchList data) => _moviesRepository.AddMediaToWatchList(data);

    public void RemoveMediaFromWatchList(UserWatchList data) { 
        var entity = _moviesRepository.FindMediaInWatchList(data);
        _moviesRepository.RemoveMediaFromWatchList(entity); 
    }

    public void RateMedia(MovieRating data) => _moviesRepository.RateMedia(data);
}
