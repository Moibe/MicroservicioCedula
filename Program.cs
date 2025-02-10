var builder = WebApplication.CreateBuilder(args);

// Agregar HttpClient
builder.Services.AddHttpClient();

// Configurar servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configurar el pipeline de la aplicación
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
