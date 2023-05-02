using Microsoft.AspNetCore.Mvc;
using App.Services;
using System.Text;
using App.Extensions;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly IEmailService _emailService;

    public HomeController(IEmailService emailService)
    {
        this._emailService = emailService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> EnviarEmailTeste()
    {
        var html = new StringBuilder();
        html.Append("<h1>Teste de Seviço de Envio de E-mail</h1>");
        html.Append("<p>Este é um teste do serviço de envio de e-mails usando ASP.NET Core.</p>");

        await _emailService.SendEmailAsync("wtlmarco@gmail.com", "Teste de Serviço de E-mail", string.Empty, html.ToString());

        this.MostrarMensagem("Uma mensagem foi enviada para o e-mail wtlmarco@gmail.com.");

        return RedirectToAction(nameof(Index));
    }
}