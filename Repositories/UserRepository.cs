using PrivateNotes.Entites;

namespace PrivateNotes.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(NotesDbContext context)
        :base(context)
    {
        
    }
}