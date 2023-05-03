using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly DatabaseContext db;

    public HomeController(DatabaseContext db)
    {
        this.db = db;
    }

    public IActionResult Index()
    {
        var galerias = db.Galerias.Include(g => g.Imagens).AsNoTracking().ToList();

        return View(galerias);
    }
}