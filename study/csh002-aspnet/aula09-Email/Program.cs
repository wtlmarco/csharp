using App.Services;
using App.Settings;

var builder = WebApplication.CreateBuilder(args);

var mvc = builder.Services.AddControllersWithViews();
mvc.AddRazorRuntimeCompilation();

/* Gmail SMTP Service */
//builder.Services.Configure<GMailSettings>(builder.Configuration.GetSection(nameof(GMailSettings)));
//builder.Services.AddSingleton<IEmailService, GMailService>();

/* Sending Blue SMTP Service */
//builder.Services.Configure<SendingBlueSettings>(builder.Configuration.GetSection(nameof(SendingBlueSettings)));
//builder.Services.AddSingleton<IEmailService, SendingBlueService>();

/* SendGrid Api Service */
//builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection(nameof(SendGridSettings)));
//builder.Services.AddSingleton<IEmailService, SendGridService>();

builder.Services.Configure<HostGatorSettings>(builder.Configuration.GetSection(nameof(HostGatorSettings)));
builder.Services.AddSingleton<IEmailService, HostGatorService>();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => {endpoints.MapDefaultControllerRoute();});

app.Run();
