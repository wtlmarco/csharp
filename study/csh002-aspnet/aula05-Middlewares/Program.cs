using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ContadorOptions>(options =>{
    options.Quantidade = 5;
});

var app = builder.Build();


app.UseTempoExecucao(); 

app.Map("/caminhoB", appB => {
    appB.Run(async context => {
        await context.Response.WriteAsync("\nProcessado pela ramificação B");
    });
});

app.MapWhen(
    context => context.Request.Query.ContainsKey("caminhoC"),
    appc => {
        appc.Run(async context => {
            await context.Response.WriteAsync("\nProcessado pela ramificação C");
        });
});

app.UseWhen(
    context => context.Request.Query.ContainsKey("caminhoD"),
    appc => {
        appc.Use(async (context,next) => {
            await context.Response.WriteAsync("\nProcessado pela ramificação D");
            await next();
        });
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("===");
    await next();
    await context.Response.WriteAsync("===");
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync(">>>");
    await next();
    await context.Response.WriteAsync("<<<");
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("[[[");
    await next();
    await context.Response.WriteAsync("]]]");
});

app.Run(async context => 
{
    await context.Response.WriteAsync("Middleware Terminal");
});

//app.MapGet("/", () => "Ola Mundo!");

app.Run();
