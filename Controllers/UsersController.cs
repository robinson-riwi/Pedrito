using Microsoft.AspNetCore.Mvc;
using Pedrito.Data;
using Pedrito.Models;

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

    public IActionResult Store([Bind("Names,LastNames,Email")] User user)
    {
        if (ModelState.IsValid)
        {
            _context.Add(user);
            _context.SaveChanges();
            TempData["message"] = "Niceee usuario creado :)";
            return RedirectToAction(nameof(Index));
        }

        return BadRequest();
    }

    [HttpDelete]
    public IActionResult Destroy(int id)
    {
        var user = _context.users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.users.Remove(user);
        _context.SaveChanges();
        TempData["message"] = "El usuario ha eliminado";
        return RedirectToAction(nameof(Index));
    }
}