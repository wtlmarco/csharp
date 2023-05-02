using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Models;

namespace PrimeiroProjeto.Controllers;

public class HomeController : Controller
{
    public ViewResult Index(int? id)
    {
        return View(id);
    }
}
