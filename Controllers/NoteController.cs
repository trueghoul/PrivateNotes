using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateNotes.Entites;
using PrivateNotes.Models;
using PrivateNotes.Services;

namespace PrivateNotes.Controllers;

[Authorize]
public class NoteController : Controller
{
    private readonly INoteServices _noteServices;
    private readonly IUserServices _userServices;
    public NoteController(INoteServices noteServices,
        IUserServices userServices)
    {
        _noteServices = noteServices;
        _userServices = userServices;
    }

    [HttpGet]
    public IActionResult Show()
    {
        var notes = _noteServices.GetUserNotes(User.Identity.Name).ToList();
        return View(notes);
    }

    [HttpGet]
    public IActionResult AddNew()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddNew(NoteViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var note = new Note()
        {
            Content = model.Content,
            UserId = _userServices.GetId(User.Identity.Name)
        };
        _noteServices.AddNote(note);
        return RedirectToAction("Show", "Note");
    }
    
    public ActionResult Delete(int id)
    {
        _noteServices.DeleteNote(id); 
        return RedirectToAction("Show", "Note");
    }
}