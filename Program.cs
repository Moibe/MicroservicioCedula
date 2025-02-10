var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod() 
                   .AllowAnyHeader(); 
        });
});

// Agregar HttpClient
builder.Services.AddHttpClient();

// Configurar servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

// Usar la política de CORS
app.UseCors("AllowAllOrigins");

// Configurar el pipeline de la aplicación
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
