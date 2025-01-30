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
        Console.WriteLine($"Guardando tarea: {tarea.Titulo}, {tarea.Descripcion}, {tarea.Responsable}");
        _dbContext.Tareas.Add(tarea);
        _dbContext.SaveChanges(); 
    }

    public Tarea ObtenerTareaPorId(int id)
    {
        var tarea = _dbContext.Tareas.FirstOrDefault(t => t.Id == id);
        Console.WriteLine(tarea != null ? $"Tarea encontrada: {tarea.Titulo}" : $"No se encontró la tarea con Id={id}");
        return tarea;
    }

    public void ActualizarTarea(Tarea tarea)
    {
        var tareaExistente = _dbContext.Tareas.Find(tarea.Id);
        if (tareaExistente != null)
        {
            tareaExistente.Titulo = tarea.Titulo;
            tareaExistente.Descripcion = tarea.Descripcion;
            tareaExistente.Responsable = tarea.Responsable;
            _dbContext.SaveChanges();
        }
    }


}
