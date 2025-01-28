using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Define la tabla 'Tareas' en la base de datos
    public DbSet<Tarea> Tareas { get; set; }
}
