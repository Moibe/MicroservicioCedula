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

// Con ésto estoy usando lo de CORS
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();