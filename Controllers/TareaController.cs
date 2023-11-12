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
    
    [HttpPost]
    public IActionResult CrearTarea(Tarea tarea)
    {   
        repository.UpdateTarea(tarea);
        return RedirectToAction("Index");
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarTarea(int idTarea)
    {  
        var tarea = repository.GetTareaById(idTarea);
        return View(tarea);
    }

    [HttpPost]
    public IActionResult EditarTarea(Tarea tarea)
    {   
        
        repository.UpdateTarea(tarea);
        return RedirectToAction("Index");
    }

    //ELIMINAR
    public IActionResult DeleteTarea(int idTarea)
    {  
        repository.RemoveTarea(idTarea);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
