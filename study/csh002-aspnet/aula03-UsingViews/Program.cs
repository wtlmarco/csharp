var builder = WebApplication.CreateBuilder(args);

//Habilita MVC
var mvcBuilder = builder.Services.AddControllersWithViews();

//Permitir o Auto-Update da View durante a execução
if(builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
