using PrivateNotes.Entites;
using PrivateNotes.Models;
using PrivateNotes.Repositories;

namespace PrivateNotes.Services;

public class NoteServices : INoteServices
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserRepository _userRepository;

    public NoteServices(INoteRepository noteRepository,
        IUserRepository userRepository)
    {
        _noteRepository = noteRepository;
        _userRepository = userRepository;
    }

    public IEnumerable<Note> GetAllNotes()
    {
        return _noteRepository.Get();
    }

    public void AddNote(Note note)
    {
        _noteRepository.Create(note);
    }

    public IEnumerable<Note> GetUserNotes(string email)
    {
        return _userRepository.GetUserNotes(email).AsEnumerable();
    }

    public bool DeleteNote(int id)
    {
        var note = _noteRepository.Get(n => n.Id == id).FirstOrDefault();
        if (note != null)
        {
            _noteRepository.Remove(note);
            return true;
        }
        else return false;
    }
}