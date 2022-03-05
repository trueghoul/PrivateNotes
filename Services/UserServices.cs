using PrivateNotes.Entites;
using PrivateNotes.Repositories;

namespace PrivateNotes.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public bool AddUser(string email, string password)
    {
        var tempUser = _userRepository.Get(u => u.Email == email).FirstOrDefault();
        if (tempUser != null) return false;
        var user = new User()
        {
            Email = email,
            Password = password
        };
        _userRepository.Create(user);
        return true;
    }
    public bool HasUser(string email, string password)
    {
        var user = _userRepository.Get(u => u.Email == email && u.Password == password).FirstOrDefault();
        return user != null;
    }

    public int NumberOfNotes(string email)
    {
        return _userRepository.GetUserNotes(email).Count;
    }

    public int GetId(string email)
    {
        return _userRepository.Get(u => u.Email == email).FirstOrDefault().Id;
    }
}