using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EstoqueWeb.Models;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

var mvcBuilder = builder.Services.AddControllersWithViews();
mvcBuilder.AddRazorRuntimeCompilation();

builder.Services.AddDbContext<EstoqueWebContext>(options => options.UseSqlite(Configuration.GetConnectionString("EstoqueWebContext")));

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");

app.Run();
