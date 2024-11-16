using EscuelaApp.Persistencia;
using EscuelaApp.Persistencia.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//llamar metodo que inyecta nuestras dependencias
InyectarDependencias.ConfiguracionServicios(builder.Services); //builder.Services contiene coleccion de todas nuestras inyecciones

//agregar servicio httpsclient para poder hacer peticiones http
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configurar conexion string
builder.Services.AddDbContext<SchoolDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
    );

//agregar el servicio de autenticacion por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Login/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); //vida de la cookie
        options.AccessDeniedPath = "/Home/Index"; //redireccionar a donde se desee si hay un access denied
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
