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
        Console.WriteLine($"Recibiendo datos: Titulo={tarea.Titulo}, Descripcion={tarea.Descripcion}");

        if (ModelState.IsValid)
        {
            _tareaService.AgregarTarea(tarea);
            return Json(new { success = true });
        }

        Console.WriteLine("Error en ModelState: Datos inválidos");
        return Json(new { success = false, message = "Datos inválidos" });
    }

   [HttpPost]
    public IActionResult EliminarTarea(int id)
    {
        Console.WriteLine($"Id recibido en el controlador: {id}");

        var tarea = _tareaService.ObtenerTareaPorId(id);
        if (tarea != null)
        {
            Console.WriteLine($"Tarea encontrada: {tarea.Id}");
            _tareaService.EliminarTarea(id);
            return Json(new { success = true });
        }
        
        Console.WriteLine("Tarea no encontrada en la base de datos.");
        return Json(new { success = false, message = "Tarea no encontrada" });
    }




}