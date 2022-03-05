using System.ComponentModel.DataAnnotations;

namespace PrivateNotes.Models;

public class NoteViewModel
{
    [Required(ErrorMessage = "Required")]
    public string Content { get; set; }
}