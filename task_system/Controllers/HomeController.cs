using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    public IActionResult Error()
    {
      
        var exceptionDetails = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

        if (exceptionDetails != null)
        {
         
            Debug.WriteLine($"Ruta del error: {exceptionDetails.Path}");
            Debug.WriteLine($"Excepción: {exceptionDetails.Error}");
        }

        return View();
    }
}
