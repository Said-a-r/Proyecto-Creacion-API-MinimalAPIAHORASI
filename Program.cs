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
        Description = "Proeycto de practica para aprender MinimalAPI"
    });
});



builder.Services.AddSingleton<PersonajeService>();
builder.Services.AddSingleton<CartaService>();
builder.Services.AddSingleton<EventoService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPersonajesEndpoints();
app.MapCartasEndpoints();
app.MapEventosEndpoints();

app.Run();