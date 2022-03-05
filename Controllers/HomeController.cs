using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateNotes.Entites;
using PrivateNotes.Models;
using PrivateNotes.Services;

namespace PrivateNotes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserServices _userServices;
    public HomeController(ILogger<HomeController> logger,
        IUserServices userServices)
    {
        _userServices = userServices;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var email = User.Identity.Name;
        if (email != null)
        {
            var index = new IndexViewModel()
            {
                Email = email,
                NumberOfNotes = _userServices.NumberOfNotes(email)
            };
            return View(index);
        }
        else
            return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}