using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace App.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Policy = "MaiorDeIdade")]
    public IActionResult ParaMaiores()
    {
        return View();
    }
}