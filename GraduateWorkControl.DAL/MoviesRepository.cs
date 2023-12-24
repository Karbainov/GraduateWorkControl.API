using GraduateWorkControl.DAL.Dtos.Movies;
using Microsoft.EntityFrameworkCore;

namespace GraduateWorkControl.DAL;

public class MoviesRepository
{
    private Context _context;

    public MoviesRepository()
    {
        _context = new Context();
    }

    public int Register(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    public User GetUserById(int id)
    {
        return _context.Users
            .Include(u => u.WatchList)
            .Include(u => u.Ratings)
            .Where(s => s.Id == id).FirstOrDefault();
    }

    public User GetUserByCreds(string email, string password)
    {
        return _context.Users.Where(s => s.Email == email && s.Password == password).FirstOrDefault();
    }

    public void AddMediaToWatchList(UserWatchList data)
    {
        _context.UserWatchLists.Add(data);
        _context.SaveChanges();
    }

    public void RemoveMediaFromWatchList(UserWatchList data)
    {
        _context.UserWatchLists.Remove(data);
        _context.SaveChanges();
    }

    public UserWatchList FindMediaInWatchList(UserWatchList data)
    {
        return _context.UserWatchLists.Where(s => s.UserId == data.UserId && s.MediaId == data.MediaId).FirstOrDefault();
    }

    public void RateMedia(MovieRating data)
    {
        _context.Ratings.Add(data);
        _context.SaveChanges();
    }
}
