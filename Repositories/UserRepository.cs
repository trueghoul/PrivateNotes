using Microsoft.EntityFrameworkCore;
using PrivateNotes.Entites;

namespace PrivateNotes.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(NotesDbContext context)
        :base(context)
    {
        
    }

    public List<Note> GetUserNotes(string email)
    {
        return _context.Notes.Where(n => n.User.Email == email).AsNoTracking().ToList();
    }
}