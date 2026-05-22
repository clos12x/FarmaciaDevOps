var builder = WebApplication.CreateBuilder(args);

// Permitir acceso desde Docker
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Servicios
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger siempre activo
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FarmaciaDevOps API V1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();

// Controladores
app.MapControllers();

app.Run();