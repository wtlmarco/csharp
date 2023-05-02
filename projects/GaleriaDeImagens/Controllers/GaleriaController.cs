using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using App.Models;

namespace App.Controllers;

public class GaleriaController : Controller
{
    private readonly DatabaseContext db;
    
    public GaleriaController(DatabaseContext db)
    {
        this.db = db;
    }

    public IActionResult Index()
    {
        var galerias = db.Galerias.AsNoTracking().ToList();
        return View(galerias);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Cadastrar(Galeria galeria)
    {
        if(ModelState.IsValid)
        {
            db.Galerias.Add(galeria);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        return View(galeria);
    }

    public IActionResult Alterar(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        
        var galeria = db.Galerias.Find(id);
        if(galeria == null)
        {
            return NotFound();
        }

        return View(galeria);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Alterar(Galeria galeria)
    {
        if(ModelState.IsValid)
        {
            db.Entry(galeria).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        return View(galeria);
    }

    public IActionResult Excluir(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        
        var galeria = db.Galerias.Find(id);
        if(galeria == null)
        {
            return NotFound();
        }

        return View(galeria);
    }

    [HttpPost, ValidateAntiForgeryToken]
    [ActionName("Excluir")]
    public IActionResult ExecutarExclusao(int? id)
    {
        var galeria = db.Galerias.Find(id);
        if(galeria == null)
        {
            return NotFound();
        }

        db.Galerias.Remove(galeria);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
}