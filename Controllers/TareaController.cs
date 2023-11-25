using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository repository = new TareaRepository();
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
    }

    private bool estaLogueado(){
        if (HttpContext.Session !=null)
        {
            return true;
        }
        return false;
    }
    private bool isAdmin(){
       if (HttpContext.Session.GetString("rol") == "admin")
       {
            return true;
       }
       return false;
    }
    private int obtenerId(){
        int id = (int) HttpContext.Session.GetInt32("id"); 
        return id;
    }
    public IActionResult Index()
    {
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        List<Tarea> tareas= new List<Tarea>();
        if (isAdmin())
        {
            tareas = repository.GetAllTareas();
        }else
        {
            tareas = repository.GetAllUsersTareas(obtenerId()); 
        }
        var tareasVM = new ListarTareaViewModel(tareas);
        return View(tareasVM.ListarTareaVM);
    }

    [HttpGet]
    public IActionResult CrearTarea()
    {   
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        return View(new CrearTareaViewModel());
    }

    [HttpPost]
    public IActionResult CrearTarea(CrearTareaViewModel tarea)
    {   
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        Tarea newTarea = new Tarea(tarea);
        repository.CreateTarea(newTarea);
        return RedirectToAction("Index");
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarTarea(int idTarea)
    {  
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var tarea = repository.GetTareaById(idTarea);
        var tareasVM = new EditarTareaViewModel(tarea);
        return View(tareasVM);
    }

    [HttpPost]
    public IActionResult EditarTarea(EditarTareaViewModel tarea)
    {   
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var tareaActualizada = new Tarea(tarea);
        repository.UpdateTarea(tareaActualizada);
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
