using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using task_system.Services;

var builder = WebApplication.CreateBuilder(args);

// Validar que la cadena de conexión esté configurada
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada. Verifica appsettings.json.");
}

// Configurar servicios
builder.Services.AddControllersWithViews();

// Registrar servicios personalizados
builder.Services.AddScoped<ITareaService, TareaService>();

// Configurar DbContext para MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Construir la aplicación
var app = builder.Build();

// Verificar la conexión a la base de datos al inicio
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.CanConnect(); // Verifica la conexión
        Console.WriteLine("Conexión con la base de datos establecida exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    }
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tareas}/{action=Index}/{id?}");

app.Run();
