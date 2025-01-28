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
    public IActionResult CrearTarea(Tarea tarea)
    {
        if (ModelState.IsValid)
        {
            _tareaService.AgregarTarea(tarea); // Llama al servicio para guardar la tarea
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Datos inválidos" });
    }

}