using Microsoft.AspNetCore.Mvc;
using task_system.Services;

public class TareasController : Controller
{
    private readonly ITareaService _tareaService;

    public TareasController(ITareaService tareaService)
    {
        _tareaService = tareaService;
    }

    public IActionResult Index()
    {
        var tareas = _tareaService.ObtenerTareas();
        return View(tareas);
    }

    [HttpPost]
    public IActionResult CrearTarea([FromBody] Tarea tarea)
    {

        if (string.IsNullOrWhiteSpace(tarea.Responsable))
        {
            tarea.Responsable = "Sin asignar";
        }

        Console.WriteLine($"Recibiendo datos: Titulo={tarea.Titulo}, Descripcion={tarea.Descripcion}, Responsable: {tarea.Responsable}");

        if (ModelState.IsValid)
        {
            _tareaService.AgregarTarea(tarea);
            return Json(new { success = true });
        }

        Console.WriteLine("Error en ModelState: Datos inválidos");
        return Json(new { success = false, message = "Datos inválidos" });
    }

    [HttpPost]
    public IActionResult EditarTarea(Tarea tarea)
    {
        try
        {
            var tareaExistente = _tareaService.ObtenerTareaPorId(tarea.Id);
            if (tareaExistente != null)
            {
               
                if (!string.IsNullOrWhiteSpace(tarea.Titulo))
                    tareaExistente.Titulo = tarea.Titulo;

                if (!string.IsNullOrWhiteSpace(tarea.Descripcion))
                    tareaExistente.Descripcion = tarea.Descripcion;

                if (!string.IsNullOrWhiteSpace(tarea.Responsable))
                    tareaExistente.Responsable = tarea.Responsable;

                
                tareaExistente.Estado = tarea.Estado;

                _tareaService.ActualizarTarea(tareaExistente);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Tarea no encontrada" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar la tarea: {ex.Message}");
            return Json(new { success = false, message = "Error al editar la tarea" });
        }
    }



}


