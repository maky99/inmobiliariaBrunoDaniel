using Microsoft.AspNetCore.Authentication.Cookies;
using DinkToPdf;
using DinkToPdf.Contracts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Usuario/Login";
    options.LogoutPath = "/Usuarios/Logout";
    options.AccessDeniedPath = "/Home/Privacy";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);//tiempo de duracion de la cookie
});

builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("Empleado", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador", "Empleado"));
    options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador", "Empleado"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//archivos css, jpg.js,etc

app.UseRouting();
//se habilita la autenticacion
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();


