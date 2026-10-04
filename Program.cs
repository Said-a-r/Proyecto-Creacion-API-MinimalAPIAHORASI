using proyectoAPICatalogoW.Services;
using proyectoAPICatalogoW.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Catalogo de cartas API",
        Version = "v1",
        Description = "Proyecto d practica para aprender MinimalAPI"
    });
});

builder.Services.AddSingleton<PersonajeService>();
builder.Services.AddSingleton<CartaService>();
builder.Services.AddSingleton<EventoService>();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var api = app.MapGroup("/api");

api.MapPersonajesEndpoints();
api.MapCartasEndpoints();
api.MapEventosEndpoints();

app.Run();