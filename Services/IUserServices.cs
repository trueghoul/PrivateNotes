namespace PrivateNotes.Services;

public interface IUserServices
{
    bool AddUser(string email, string password);
    bool GetUser(string email, string password);
}