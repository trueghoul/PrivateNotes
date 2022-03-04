using PrivateNotes.Entites;

namespace PrivateNotes.Repositories;

public class NoteRepository : GenericRepository<Note>, INoteRepository
{
    public NoteRepository(NotesDbContext context)
        : base(context)
    {
        
    }
}