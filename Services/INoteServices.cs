using PrivateNotes.Entites;

namespace PrivateNotes.Services;

public interface INoteServices
{
    IEnumerable<Note> GetAllNotes();
    Note AddNote(string content, DateTime creationDate);
}