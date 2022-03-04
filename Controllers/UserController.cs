using Microsoft.AspNetCore.Mvc;
using PrivateNotes.Entites;
using PrivateNotes.Models;
using PrivateNotes.Services;

namespace PrivateNotes.Controllers;

public class UserController : Controller
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public IActionResult AuthorizationPage()
    {
        return View();
    }
    public IActionResult RegistrationPage()
    {
        var data = new RegisterViewModel();
        return View(data);
    }

    public IActionResult Registration()
    {
        _userServices.AddUser("hardcode@mail.ru", "hardcodepassword");
        return View("RegistrationPage");
    }
}