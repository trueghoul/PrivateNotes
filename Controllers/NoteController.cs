using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateNotes.Entites;
using PrivateNotes.Services;

namespace PrivateNotes.Controllers;

public class NoteController : Controller
{
    private readonly INoteServices _noteServices;
    public NoteController(INoteServices noteServices)
    {
        _noteServices = noteServices;
    }

    public IActionResult Show()
    {
        var notes = _noteServices.GetAllNotes().ToList();
        return View(notes);
    }

    [HttpPost]
    public IActionResult AddNew()
    {
        _noteServices.AddNote("qwe123", DateTime.Now);
        return Show();
    }
}