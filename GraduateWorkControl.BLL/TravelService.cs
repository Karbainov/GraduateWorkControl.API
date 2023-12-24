using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos.Travel;

namespace GraduateWorkControl.BLL;

public class TravelService
{
    private TravelRepository _travelRepository;

    public TravelService()
    {
        _travelRepository = new TravelRepository();
    }

    public int Register(Traveller user)
    {
        return _travelRepository.Register(user);
    }

    public Traveller Login(string email, string password)
    {
        return _travelRepository.GetUserByCreds(email, password);
    }

    public Traveller GetUserById(int id)
    {
        return _travelRepository.GetUserById(id);
    }
}
