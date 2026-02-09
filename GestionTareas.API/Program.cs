using GestionTareas.Aplicacion.Interfaces;
using GestionTareas.Aplicacion.Servicios;
using GestionTareas.Infraestructura.Persistencia.Conexion;
using GestionTareas.Infraestructura.Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ====== Configuración DB ======
var connectionString = builder.Configuration.GetConnectionString("Default");
Console.WriteLine("CS(Default) = " + connectionString);

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Falta ConnectionStrings:Default en appsettings.json");
}

// ====== DI (Clean Architecture) ======
builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(connectionString));

builder.Services.AddScoped<ITareaRepositorio, TareaRepositorio>();
builder.Services.AddScoped<ConsultaTareasServicio>();

var app = builder.Build();

 
    app.UseSwagger();
    app.UseSwaggerUI();
 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
