using PrivateNotes.Entites;

namespace PrivateNotes.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    List<Note> GetUserNotes(string email);
}