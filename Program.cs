using proyectoAPICatalogoW.Services;
using proyectoAPICatalogoW.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()); 
});


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

app.UseCors();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var api = app.MapGroup("");

api.MapPersonajesEndpoints();
api.MapCartasEndpoints();
api.MapEventosEndpoints();

app.Run();