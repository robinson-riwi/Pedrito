using Microsoft.AspNetCore.Mvc;
using Pedrito.Data;

namespace Pedrito.Controllers;

public class UsersController : Controller
{
    private readonly MysqlDbContext _context;

    public UsersController(MysqlDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // ViewModel
        var users = _context.users.ToList();
        return View(users);
    }

    public IActionResult Details(int id)
    {
        var user = _context.users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
}