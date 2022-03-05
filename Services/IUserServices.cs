using PrivateNotes.Entites;

namespace PrivateNotes.Services;

public interface IUserServices
{
    bool AddUser(string email, string password);
    bool HasUser(string email, string password);
    int NumberOfNotes(string email);
    int GetId(string email);
}