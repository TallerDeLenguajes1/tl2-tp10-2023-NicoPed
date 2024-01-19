using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;
using Microsoft.AspNetCore.Session;

namespace tl2_tp10_2023_NicoPed;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private IUsuarioRepository _usuarioRepository;

    private ITareaRepository _repository;
    public TareaController(ILogger<TareaController> logger, ITareaRepository tareaRepository, IUsuarioRepository usuarioRepository)
    {
        _logger = logger;
        _repository = tareaRepository;
        _usuarioRepository = usuarioRepository;
    }

    private bool estaLogueado(){
        if (HttpContext.Session !=null && (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Operador"))
        {
            return true;
        }
        return false;
    }
    private bool isAdmin(){
       if (HttpContext.Session.GetString("rol") == "Administrador")
       {
            return true;
       }
       return false;
    }
    private int obtenerId(){
        string? ids = HttpContext.Session.GetString("id");
        int id = 9999;
        if (ids != null)
        {
            id = int.Parse(ids);
        }
        return id;
    }
    public IActionResult Index()
    {
        try
        {   
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            List<Tarea> tareas= new List<Tarea>();
            tareas = _repository.GetAllUsersTareas(obtenerId()); 
            var tareasVM = new ListarTareaViewModel(tareas);
            return View(tareasVM.ListarTareaVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult ListarTareasDeTablero(int idTablero, string esPropietario){
        try
        {
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var propietario = bool.Parse(esPropietario);
            if (propietario)
            {
                List<Tarea> tareas = _repository.GetAllTablerosTareas(idTablero);
                return View(new ListarTareasDeTableroViewModel(tareas, idTablero, propietario));

            }
                
            List<Tarea> tareasAsignadas= new List<Tarea>();
            List<Tarea> tareasNoAsignadas= new List<Tarea>();
            tareasAsignadas = _repository.GetAllTablerosUsuarioTareas(idTablero, obtenerId());
            tareasNoAsignadas = _repository.GetAllTablerosNoAsiggnedTareas(idTablero);

            return View(new ListarTareasDeTableroViewModel(tareasAsignadas,tareasNoAsignadas, idTablero, propietario));
            
        }
        catch (System.Exception ex)
        {
            
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult CrearTarea(int idTablero)
    {   
        try
        {
            
        if (!estaLogueado())
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var usuarios = _usuarioRepository.GetAllUsuarios();
        return View(new CrearTareaViewModel(idTablero, usuarios));
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public IActionResult CrearTarea(CrearTareaViewModel tarea)
    {   
        try
        {
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Tarea", action = "Index" });     
            }
            Tarea newTarea = new Tarea(tarea);
            _repository.CreateTarea(newTarea);
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarTarea(int idTarea)
    {  
        try
        {
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var tarea = _repository.GetTareaById(idTarea);
            var tareasVM = new EditarTareaViewModel(tarea);
            return View(tareasVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public IActionResult EditarTarea(EditarTareaViewModel tarea)
    {   
        try
        {
            
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
            return RedirectToRoute(new { controller = "Tarea", action = "Index" });     
            }
            var tareaActualizada = new Tarea(tarea);
            _repository.UpdateTarea(tareaActualizada);
            return RedirectToAction("Index");
        }catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    //ELIMINAR
    public IActionResult DeleteTarea(int idTarea)
    {  
        try
        {
        if (!estaLogueado())
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        _repository.RemoveTarea(idTarea);
        return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
