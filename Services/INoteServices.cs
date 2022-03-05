using PrivateNotes.Entites;

namespace PrivateNotes.Services;

public interface INoteServices
{
    IEnumerable<Note> GetAllNotes();
    void AddNote(Note note);
    IEnumerable<Note> GetUserNotes(string email);
    bool DeleteNote(int id);
}