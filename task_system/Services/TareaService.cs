using task_system.Services;
using task_system.Models;

public class TareaService : ITareaService
{
    private readonly AppDbContext _dbContext;

    public TareaService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Tarea> ObtenerTareas() => _dbContext.Tareas.ToList();

    public void AgregarTarea(Tarea tarea)
    {
        Console.WriteLine($"Guardando tarea: {tarea.Titulo}, {tarea.Descripcion}");
        _dbContext.Tareas.Add(tarea);
        _dbContext.SaveChanges(); 
    }

    public Tarea ObtenerTareaPorId(int id)
    {
        return _dbContext.Tareas.FirstOrDefault(t => t.Id == id);
    }

    public void EliminarTarea(int id)
    {
        var tarea = _dbContext.Tareas.FirstOrDefault(t => t.Id == id);
        if (tarea != null)
        {
            Console.WriteLine($"Eliminando tarea con Id={id}: {tarea.Titulo}");
            _dbContext.Tareas.Remove(tarea);
            _dbContext.SaveChanges();
        }
        else
        {
            Console.WriteLine($"No se encontró la tarea con Id={id} para eliminar.");
        }
    }


}
