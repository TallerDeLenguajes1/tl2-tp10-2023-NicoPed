using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp10_2023_NicoPed;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository repository = new TareaRepository();
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tareas = repository.GetAllTareas();
        return View(tareas);
    }

    // [HttpGet]
    // public IActionResult CrearTarea()
    // {   
    //     return View(new Tarea());
    // }

 
    // [HttpPost]
    // public IActionResult CrearTarea(Tarea Tarea)
    // {   
    //     Tarea.Id = Tareas.Count()+1;
    //     Tareas.Add(Tarea);
    //     return RedirectToAction("Index");
    // }
   
    // [HttpGet]
    // public IActionResult EditarTarea(int idTarea)
    // {  
    //     return View( Tareas.FirstOrDefault( Tarea => Tarea.Id == idTarea));
    // }


    // [HttpPost]
    // public IActionResult EditarTarea(Tarea Tarea)
    // {   
        
    //     var Tarea2 = Tareas.FirstOrDefault( Tarea => Tarea.Id == Tarea.Id);
    //     Tarea2.Nombre = Tarea.Nombre;
    //     Tarea2.Precio = Tarea.Precio;

    //     return RedirectToAction("Index");
    // }

    
    // public IActionResult DeleteTarea(int idTarea)
    // {  
    //    var TareaBuscado = Tareas.FirstOrDefault( Tarea => Tarea.Id == idTarea);
    //    Tareas.Remove(TareaBuscado);
    //   return RedirectToAction("Index");
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
