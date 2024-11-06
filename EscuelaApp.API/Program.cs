using EscuelaApp.Persistencia;
using EscuelaApp.Persistencia.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//llamar metodo que inyecta nuestras dependencias
InyectarDependencias.ConfiguracionServicios(builder.Services); //builder.Services contiene coleccion de todas nuestras inyecciones

//Configurar conexion string
builder.Services.AddDbContext<SchoolDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
