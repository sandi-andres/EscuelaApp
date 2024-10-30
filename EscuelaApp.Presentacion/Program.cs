using EscuelaApp.Persistencia;
using EscuelaApp.Persistencia.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//llamar metodo que inyecta nuestras dependencias
InyectarDependencias.ConfiguracionServicios(builder.Services); //builder.Services contiene coleccion de todas nuestras inyecciones

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configurar conexion string
builder.Services.AddDbContext<SchoolDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
