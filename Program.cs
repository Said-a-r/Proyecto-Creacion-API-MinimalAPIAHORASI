using proyectoAPICatalogoW.Services;
using proyectoAPICatalogoW.Endpoints;
using proyectoAPICatalogoW.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Falta la cadena de conexión DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "catalogo de cartas API",
        Version = "v2",
        Description = "Proyecto de practica Migraciones"
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddSingleton<PersonajeService>();
builder.Services.AddSingleton<CartaService>();
builder.Services.AddSingleton<EventoService>();

builder.Services.AddSingleton<ICifradoService, CifradoService>();
builder.Services.AddScoped<IJugadorService, JugadorService>();
builder.Services.AddScoped<IMisionService, MisionService>();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

var api = app.MapGroup("/api");

api.MapPersonajesEndpoints();
api.MapCartasEndpoints();
api.MapEventosEndpoints();

app.Run();