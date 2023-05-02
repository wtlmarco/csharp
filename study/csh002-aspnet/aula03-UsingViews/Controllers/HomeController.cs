using Microsoft.AspNetCore.Mvc;

using aula03_CRUD.Models;

namespace aula03_CRUD.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.QtdeUsuarios = Usuario.Listagem.Count();

        return View();
    }

    [HttpGet]
    public IActionResult Cadastrar(int? id)
    {
        var usuario = new Usuario();
        if(id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
        {
            usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
            return View(usuario);
        }
        
        return View(usuario);
    }

    [HttpPost]
    public IActionResult Cadastrar(Usuario usuario)
    {
        Usuario.Salvar(usuario);
        return RedirectToAction("Usuarios");
    }

    public IActionResult Usuarios()
    {
        return View(Usuario.Listagem);
    }

    [HttpGet]
    public IActionResult Excluir(int? id)
    {
        var usuario = new Usuario();
        if(id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
        {
            usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
            return View(usuario);
        }
        
        return RedirectToAction("Usuarios");
    }

    [HttpPost]
    public IActionResult Excluir(Usuario usuario)
    {
        TempData["Excluiu"] = Usuario.Excluir(usuario.IdUsuario);
        return RedirectToAction("Usuarios");
    }
}