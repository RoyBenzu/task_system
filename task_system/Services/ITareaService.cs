namespace task_system.Services
{
    public interface ITareaService
    {
        List<Tarea> ObtenerTareas();
        void AgregarTarea(Tarea tarea);
        Tarea ObtenerTareaPorId(int id);
        void EliminarTarea(int id);
    }
}

