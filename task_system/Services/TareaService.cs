using task_system.Services;

public class TareaService : ITareaService
{
    private readonly List<Tarea> _tareas = new();

    public List<Tarea> ObtenerTareas() => _tareas;

    public void AgregarTarea(Tarea tarea)
    {
        tarea.Id = _tareas.Count + 1;
        _tareas.Add(tarea);
    }
}
