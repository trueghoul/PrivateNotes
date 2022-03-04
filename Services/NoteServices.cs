using PrivateNotes.Entites;
using PrivateNotes.Models;
using PrivateNotes.Repositories;

namespace PrivateNotes.Services;

public class NoteServices : INoteServices
{
    private readonly INoteRepository _noteRepository;

    public NoteServices(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public IEnumerable<Note> GetAllNotes()
    {
        return _noteRepository.Get();
    }

    public Note AddNote(string content, DateTime creationDate)
    {
        var note = new Note()
        {
            Content = content,
            CreationDate = creationDate
        };
        _noteRepository.Create(note);
        //Изменить снизу проверку (мб юзать маппер хз)
        return _noteRepository.Get(n => n.Content == note.Content).FirstOrDefault();
    }
}