using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using App.Extensions;
using App.ViewModels;
using App.Models;
using App.Services;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;

namespace App.Controllers;

public class UsuarioController : Controller
{
    private readonly UserManager<UsuarioModel> _userManager;

    private readonly SignInManager<UsuarioModel> _signInManager;

    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly IEmailService _emailService;

    public UsuarioController(UserManager<UsuarioModel> userManager,
        SignInManager<UsuarioModel> signInManager, 
        RoleManager<IdentityRole<int>> roleManager,
        IEmailService emailService)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._roleManager = roleManager;
        this._emailService = emailService;
    }

    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> Index()
    {
        var usuarios = await _userManager.Users.AsNoTracking().ToListAsync();
        var admins = (await _userManager.GetUsersInRoleAsync("administrador")).Select(u => u.UserName);

        ViewBag.Administradores = admins;

        return View(usuarios);
    }

    [HttpGet]
    public async Task<IActionResult> Cadastrar()
    {
        return View(new CadastrarUsuarioViewModel());
    }

    [HttpGet]
    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> CadastrarAdmin(string id)
    {
        if(!string.IsNullOrEmpty(id))
        {
            var usuarioBD = await _userManager.FindByIdAsync(id);
            if(usuarioBD == null)
            {
                this.MostrarMensagem("Usuario não encontrado,", true);
                return RedirectToAction("Index", "Home");
            }

            var usuarioVM = new CadastrarUsuarioViewModel
            {
                Id = usuarioBD.Id,
                NomeCompleto = usuarioBD.NomeCompleto,
                DataNascimento= usuarioBD.DataNascimento,
                CPF= usuarioBD.CPF,
                Email = usuarioBD.Email,
                Telefone = usuarioBD.PhoneNumber
            };

            return View(usuarioVM);
        }
        return View(new CadastrarUsuarioViewModel());
    }

    private bool EntidadeExiste(int id)
    {
        return (_userManager.Users.AsNoTracking().Any(u => u.Id == id));
    }

    private static void MapearCadastrarUsusarioViewModel(CadastrarUsuarioViewModel entidadeOrigem, UsuarioModel entidadeDestino)
    {
        entidadeDestino.NomeCompleto = entidadeOrigem.NomeCompleto;
        entidadeDestino.DataNascimento = entidadeOrigem.DataNascimento;
        entidadeDestino.CPF = entidadeOrigem.CPF;
        entidadeDestino.UserName = entidadeOrigem.Email;
        entidadeDestino.Email = entidadeOrigem.Email;
        entidadeDestino.NormalizedUserName = entidadeOrigem.Email.ToUpper().Trim();
        entidadeDestino.NormalizedEmail = entidadeOrigem.Email.ToUpper().Trim();
        entidadeDestino.PhoneNumber = entidadeOrigem.Telefone;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarUsuarioViewModel usuarioVM)
    {
        ModelState.Remove("Id");

        if(ModelState.IsValid)
        {
            var usuarioBD = await _userManager.FindByEmailAsync(usuarioVM.Email);
            if(usuarioBD != null)
            {
                ModelState.AddModelError("Email", "Já existe um usuário cadastrado com este e-mail.");

                return View(usuarioBD);
            }

            usuarioBD = new UsuarioModel();
            MapearCadastrarUsusarioViewModel(usuarioVM, usuarioBD);

            var resultado = await _userManager.CreateAsync(usuarioBD, usuarioVM.Senha);
            if(resultado.Succeeded)
            {
                var dataNascimentoClaim = new Claim(ClaimTypes.DateOfBirth,
                    usuarioBD.DataNascimento.Date.ToShortDateString());
                await _userManager.AddClaimAsync(usuarioBD, dataNascimentoClaim);
                await EnviarLinkConfirmacaoEmailAsync(usuarioBD);

                this.MostrarMensagem("Usuário cadastrado com sucesso. Uma mensagem de confirmação foi enviada para seu e-mail. Clique no link de confirmação recebido para concluir o processo de cadastro.");

                return RedirectToAction("Login");
            }
            else
            {
                this.MostrarMensagem("Não foi possível cadastrar o usuário.", true);
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(usuarioVM);
            }
        }
        else
        {
            return View(usuarioVM);
        }
    }

    [HttpPost]
    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> CadastrarAdmin([FromForm] CadastrarUsuarioViewModel usuarioVM)
    {
        if(usuarioVM.Id > 0)
        {
            ModelState.Remove("Senha");
            ModelState.Remove("ConfSenha");
        }
        else
        {
            ModelState.Remove("Id");
        }

        if(ModelState.IsValid)
        {
            if(EntidadeExiste(usuarioVM.Id))
            {
                var usuarioBD = await _userManager.FindByIdAsync(usuarioVM.Id.ToString());
                bool alterouEmail = false;

                if(usuarioVM.Email != usuarioBD.Email) 
                {
                    if(_userManager.Users.Any(u => u.NormalizedEmail == usuarioVM.Email.ToUpper().Trim()))
                    {
                        ModelState.AddModelError("Email", "Já existe um usuário cadastrado com este e-mail.");

                        return View(usuarioVM);
                    }
                    else
                    {
                        usuarioBD.EmailConfirmed = false;
                        alterouEmail = true;
                    }
                }   
                
                MapearCadastrarUsusarioViewModel(usuarioVM, usuarioBD);

                var resultado = await _userManager.UpdateAsync(usuarioBD);
                if(resultado.Succeeded)
                {
                    var dataNascimentoClaim = new Claim(ClaimTypes.DateOfBirth,
                        usuarioBD.DataNascimento.Date.ToShortDateString());
                    await _userManager.AddClaimAsync(usuarioBD, dataNascimentoClaim);

                    if(alterouEmail)
                    {
                        await EnviarLinkConfirmacaoEmailAsync(usuarioBD);
                        this.MostrarMensagem("Usuário alterado com sucesso. Uma mensagem com um link de confirmação de e-mail foi enviado para o e-mail do usuário.");
                    }
                    else
                    {
                        this.MostrarMensagem("Usuário alterado com sucesso.");
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    this.MostrarMensagem("Não foi possível alterar o usuário.", true);
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View(usuarioVM);
                }
            }
            else
            {
                var usuarioBD = await _userManager.FindByEmailAsync(usuarioVM.Email);
                if(usuarioBD != null)
                {
                    ModelState.AddModelError("Email", "Já existe um usuário cadastrado com este e-mail.");

                    return View(usuarioBD);
                }

                usuarioBD = new UsuarioModel();
                MapearCadastrarUsusarioViewModel(usuarioVM, usuarioBD);

                var resultado = await _userManager.CreateAsync(usuarioBD, usuarioVM.Senha);
                if(resultado.Succeeded)
                {
                    var dataNascimentoClaim = new Claim(ClaimTypes.DateOfBirth,
                        usuarioBD.DataNascimento.Date.ToShortDateString());
                    await _userManager.AddClaimAsync(usuarioBD, dataNascimentoClaim);
                    await EnviarLinkConfirmacaoEmailAsync(usuarioBD);

                    this.MostrarMensagem("Usuário cadastrado com sucesso. Uma mensagem de confirmação foi enviada para seu e-mail. Clique no link de confirmação recebido para concluir o processo de cadastro.");

                    return RedirectToAction("Login");
                }
                else
                {
                    this.MostrarMensagem("Não foi possível cadastrar o usuário.", true);
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View(usuarioVM);
                }
            }
        }
        else
        {
            return View(usuarioVM);
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginViewModel login)
    {
        if(ModelState.IsValid)
        {
            var usuario = await _userManager.FindByEmailAsync(login.Usuario);
            if(usuario == null)
            {
                this.MostrarMensagem("Credenciais inválidas. Tente novamente.", true);
                
                return View(login);
            }
            
            if(!_userManager.IsEmailConfirmedAsync(usuario).Result)
            {
                this.MostrarMensagem("Este e-mail ainda não foi confirmado. Confirme e tente fazer o login novamente.", true);

                return View(login);
            }

            var resultado = await _signInManager.PasswordSignInAsync(login.Usuario, login.Senha, login.Lembrar,false);
            if(resultado.Succeeded)
            {
                login.ReturnUrl = login.ReturnUrl ?? "~/";
                return LocalRedirect(login.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de login inválida. Reveja seus dados de acesso e tente novamente.");

                return View(login);
            }
        }
        else
        {
            return View(login);
        }
    }

    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        if(returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet]
    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> Excluir(int? id)
    {
        if(!id.HasValue)
        {
            this.MostrarMensagem("Usuário não informado.", true);
            return RedirectToAction(nameof(Index));
        }

        if(!EntidadeExiste(id.Value))
        {
            this.MostrarMensagem("Usuário não encontrado.", true);
            return RedirectToAction(nameof(Index));
        }

        var usuario = await _userManager.FindByIdAsync(id.ToString());

        return View(usuario);
    }

    [HttpPost]
    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> ExcluirPost(int id)
    {
        var usuario = await _userManager.FindByIdAsync(id.ToString());
        if(usuario != null)
        {
            var resultado = await _userManager.DeleteAsync(usuario);
            if(resultado.Succeeded)
            {
                this.MostrarMensagem("Usuário excluído com sucesso.");
            }
            else
            {
                this.MostrarMensagem("Não foi possível excluir o usuário.",true);
            }
        }
        else
        {
            this.MostrarMensagem("Usuário não encontrado.",true);
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult AcessoRestrito([FromQuery] string returnUrl)
    {
        return View(model: returnUrl);
    }

    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> AddAdministrador(int id)
    {
        var usuario = await _userManager.FindByIdAsync(id.ToString());
        if(usuario != null)
        {
            var resultado = await _userManager.AddToRoleAsync(usuario, "administrador");
            if(resultado.Succeeded)
            {
                this.MostrarMensagem($"Perfil administrador adicionado com sucesso para <b>{usuario.UserName}</b>");
            }
            else
            {
                this.MostrarMensagem($"Não foi possível adicionar perfil administrador para <b>{usuario.UserName}</b>", true);
            }

            return RedirectToAction(nameof(Index));
        }
        else
        {
            this.MostrarMensagem("Usuario não encontrado.", true);
            
            return RedirectToAction(nameof(Index));
        }
    }

    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> RemAdministrador(int id)
    {
        var usuario = await _userManager.FindByIdAsync(id.ToString());
        if(usuario != null)
        {
            var resultado = await _userManager.RemoveFromRoleAsync(usuario, "administrador");
            if(resultado.Succeeded)
            {
                this.MostrarMensagem($"Perfil administrador removido com sucesso para <b>{usuario.UserName}</b>");
            }
            else
            {
                this.MostrarMensagem($"Não foi possível remover perfil administrador para <b>{usuario.UserName}</b>", true);
            }

            return RedirectToAction(nameof(Index));
        }
        else
        {
            this.MostrarMensagem("Usuario não encontrado.", true);
            
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public IActionResult EsqueciSenha()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EsqueciSenha([FromForm] EsqueciSenhaViewModel dados)
    {
        if(ModelState.IsValid)
        {
            if(_userManager.Users.AsNoTracking().Any(u => u.NormalizedEmail == dados.Email.ToUpper().Trim()))
            {
                var usuario = await _userManager.FindByEmailAsync(dados.Email);
                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                var urlConfirmacao = Url.Action(nameof(RedefinirSenha), "Usuario", new { token }, Request.Scheme);

                var mensagem = new StringBuilder();
                mensagem.Append($"<p>Olá, {usuario.NomeCompleto.PrimeiraPalavra()}.</p>");
                mensagem.Append("<p>Houve uma solicitação de redefinição de senha para seu usuário em nosso site. Se não foi você que fez a solicitação, ignore essa mensagem. Caso tenha sido você, clique no link abaixo para criar sua nova senha:</p>");
                mensagem.Append($"<p><a href='{urlConfirmacao}'>Redefinir Senha</a></p>");
                mensagem.Append("<p>Atenciosamente, <br>Equipe de Suporte</p>");

                await _emailService.SendEmailAsync(usuario.Email, "Redefinição de Senha", "", mensagem.ToString());

                return View(nameof(EmailRedefinicaoEnviado));
            }
            else
            {
                this.MostrarMensagem($"Usuário/e-mail <b>{dados.Email}</b> não encontrado.");

                return View();
            }
        }
        else
        {
             return View(dados);
        }
    }

    public IActionResult EmailRedefinicaoEnviado()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RedefinirSenha(string token)
    {
        var modelo = new RedefinirSenhaViewModel();
        modelo.Token = token;
        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> RedefinirSenha([FromForm] RedefinirSenhaViewModel dados)
    {
        if(ModelState.IsValid)
        {
            var usuario = await _userManager.FindByEmailAsync(dados.Email);
            var resultado = await _userManager.ResetPasswordAsync(usuario, dados.Token, dados.NovaSenha);

            if(resultado.Succeeded)
            {
                this.MostrarMensagem($"Senha definida com sucesso! Agora você já pode fazer login com a nova senha.");

                return View(nameof(Login));
            }
            else
            {
                this.MostrarMensagem($"Não foi possível redefinir a senha. Verifique se preencheu a senha corretamente. Se o problema persistir, entre em contato com o suporte.");

                return View(dados);
            }
        }
        else
        {
            return View(dados);
        }
    }

    [HttpGet, Authorize]
    public IActionResult AlterarSenha()
    {
        return View();
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> AlterarSenha([FromForm] AlterarSenhaViewModel dados)
    {
        if(ModelState.IsValid)
        {
            var usuario = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            var resultado = await _userManager.ChangePasswordAsync(usuario, dados.SenhaAtual, dados.NovaSenha);

            if(resultado.Succeeded)
            {
                this.MostrarMensagem($"Sua senha foi alterada com sucesso! Identifique-se usando a nova senha.");

                await _signInManager.SignOutAsync();

                return RedirectToAction(nameof(Login), "Usuario");
            }
            else
            {
                this.MostrarMensagem($"Não foi possível alterar sua senha. Confira os dados informados e tente novamente.");

                return View(dados);
            }
        }
        else
        {
            return View(dados);
        }
    }

    private async Task EnviarLinkConfirmacaoEmailAsync(UsuarioModel usuario)
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
        
        var urlConfirmacao = Url.Action("ConfirmarEmail","Usuario", new {email = usuario.Email, token }, Request.Scheme);

        var mensagem = new StringBuilder();
        mensagem.Append($"<p>Olá, {usuario.NomeCompleto.PrimeiraPalavra()}.</p>");
        mensagem.Append("<p>Recebemos o seu cadastro em nosso sistema. Para concluir o processo de cadastro, clique no link a seguir:</p>");
        mensagem.Append($"<p><a href='{urlConfirmacao}'>Confirmar Cadastro</a></p>");
        mensagem.Append("<p>Atenciosamente, <br> Equipe de Suporte</p>");

        await _emailService.SendEmailAsync(usuario.Email, "Confirmação de Cadastro", "", mensagem.ToString()); 
    }

    private async Task EnviarLinkConfirmacaoAlteracaoEmailAsync(UsuarioModel usuario)
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
        
        var urlConfirmacao = Url.Action("ConfirmarEmail","Usuario", new {email = usuario.Email, token }, Request.Scheme);

        var mensagem = new StringBuilder();
        mensagem.Append($"<p>Olá, {usuario.NomeCompleto.PrimeiraPalavra()}.</p>");
        mensagem.Append("<p>Recebemos sua solicitação de alteração de e-mailem nosso sistema. Para concluir o processo de cadastro, clique no link a seguir:</p>");
        mensagem.Append($"<p><a href='{urlConfirmacao}'>Confirmar Cadastro</a></p>");
        mensagem.Append("<p>Atenciosamente, <br> Equipe de Suporte</p>");

        await _emailService.SendEmailAsync(usuario.Email, "Confirmação de Cadastro", "", mensagem.ToString()); 
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmarEmail(string email, string token)
    {
        var usuario = await _userManager.FindByEmailAsync(email);
        if(usuario == null)
        {
            this.MostrarMensagem("Não foi possível confirmar o e-mail. Usuário não encontrado", true);
        }

        var resultado = await _userManager.ConfirmEmailAsync(usuario, token);
        if(resultado.Succeeded)
        {
            this.MostrarMensagem("E-mail confirmado com sucesso! Agora você já está liberado para fazer o login");
        }
        else
        {
            this.MostrarMensagem("Não foi possível validar seu e-mail. Tente novamente em alguns minutos. Se o problema persistir, entre em contato com o suporte.", true);
        }

        return RedirectToAction("Login","Usuario");
    }

    [HttpGet, Authorize]
    public async Task<IActionResult> Alterar()
    {
        var usuarioLogado = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
        if(usuarioLogado == null)
        {
            return NotFound();
        }

        var usuarioVM = new AlterarUsuarioViewModel()
        {
            NomeCompleto = usuarioLogado.NomeCompleto,
            Email = usuarioLogado.Email,
            Telefone = usuarioLogado.PhoneNumber,
            DataNascimento = usuarioLogado.DataNascimento 
        };

        return View(usuarioVM);
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> Alterar([FromForm] AlterarUsuarioViewModel usuarioVM)
    {
        if(!ModelState.IsValid)
        {
            return View(usuarioVM);
        }

        var usuarioBD = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
        if(usuarioBD == null)
        {
            return NotFound();
        }

        bool alterouEmail = false;
        if(usuarioVM.Email != usuarioBD.Email)
        {
            if(_userManager.Users.Any(u => u.Email == usuarioVM.Email))
            {
                ModelState.AddModelError("Email", "Este e-mail já está cadastrado em nosso sistema para outro usuário. Tente outro.");

               return View(usuarioVM);
            }
            else
            {
                alterouEmail = true;
                usuarioBD.EmailConfirmed = false;
            }   
        }

        usuarioBD.NomeCompleto = usuarioVM.NomeCompleto;
        usuarioBD.DataNascimento = usuarioVM.DataNascimento;
        usuarioBD.PhoneNumber = usuarioVM.Telefone;
        usuarioBD.Email = usuarioVM.Email;
        usuarioBD.UserName = usuarioVM.Email;

        var resultado = await _userManager.UpdateAsync(usuarioBD);

        if(resultado.Succeeded)
        {
            var dataNascimentoClaim = new Claim(ClaimTypes.DateOfBirth, usuarioBD.DataNascimento.Date.ToShortDateString());

            await _userManager.AddClaimAsync(usuarioBD, dataNascimentoClaim);

            if(alterouEmail)
            {
                await EnviarLinkConfirmacaoAlteracaoEmailAsync(usuarioBD);

                this.MostrarMensagem("Dados cadastrais alterados com sucesso. Como você alterou seu e-mail, uma menagem com um link de confirmação de e-mail foi enviada para o novo e-mail cadastrado e sua sessão foi finalizada. Para continuar, acesse o link de confirmação no e-mail que você recebeu e faça o login novamente.");

                await _signInManager.SignOutAsync();

                return RedirectToAction("Login");
            }
            else
            {
                this.MostrarMensagem("Dados cadastrais alterados com sucesso.");

                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            this.MostrarMensagem("Não foi possível alterar os dados cadastrais.", true);
            foreach (var error in resultado.Errors)
            {  
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(usuarioVM);
        }
    }
}