namespace PrivateNotes.Entites;

public class Note
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}