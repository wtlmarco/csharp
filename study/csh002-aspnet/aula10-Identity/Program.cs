using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

using App.Models;
using App.Policies;
using App.Settings;
using App.Services;

var builder = WebApplication.CreateBuilder(args);

var mvc = builder.Services.AddControllersWithViews();
mvc.AddRazorRuntimeCompilation();

builder.Services.Configure<HostGatorSettings>(builder.Configuration.GetSection(nameof(HostGatorSettings)));
builder.Services.AddSingleton<IEmailService, HostGatorService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddIdentity<UsuarioModel, IdentityRole<int>>(options => {
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//Provedor de HASH alternativo
builder.Services.UpgradePasswordSecurity().UseBcrypt<UsuarioModel>();

//Aumento do padrão de cálculo do Hash para aumentar a segurança
// builder.Services.Configure<PasswordHasherOptions>(options => {
//     options.IterationCount = 310000;
// });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("MaiorDeIdade", policy => {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new MaiorDeIdadeRequirement(18));
    });   
});

builder.Services.AddSingleton<IAuthorizationHandler, MaiorDeIdadeHandler>();

builder.Services.ConfigureApplicationCookie(options => {
    options.Cookie.Name = "AppControleUsuarios";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.SlidingExpiration = true;
    options.LoginPath = "/Usuario/Login";
    options.LogoutPath = "/Home/Index";
    options.AccessDeniedPath = "/Usuario/AcessoRestrito";
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapDefaultControllerRoute();
});

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using(var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UsuarioModel>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

    Inicializador.InicializarIdentity(userManager, roleManager);
}

//app.MapGet("/", () => "Hello World!");

app.Run();
