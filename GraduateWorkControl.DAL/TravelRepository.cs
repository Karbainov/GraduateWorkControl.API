using GraduateWorkControl.DAL.Dtos.Travel;

namespace GraduateWorkControl.DAL;

public class TravelRepository
{
    private Context _context;

    public TravelRepository()
    {
        _context = new Context();
    }

    public int Register(Traveller user)
    {
        _context.Travellers.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    public Traveller GetUserById(int id)
    {
        return _context.Travellers
            .Where(s => s.Id == id)
            .FirstOrDefault();
    }

    public Traveller GetUserByCreds(string email, string password)
    {
        return _context.Travellers.Where(s => s.Email == email && s.Password == password).FirstOrDefault();
    }
}
