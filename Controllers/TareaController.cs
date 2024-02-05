using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;
using Microsoft.AspNetCore.Session;

namespace tl2_tp10_2023_NicoPed;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private IUsuarioRepository _usuarioRepository;
    private ITableroRepository _TableroRepository;

    private ITareaRepository _repository;
    public TareaController(ILogger<TareaController> logger, ITareaRepository tareaRepository, IUsuarioRepository usuarioRepository, ITableroRepository tableroRepository)
    {
        _logger = logger;
        _repository = tareaRepository;
        _usuarioRepository = usuarioRepository;
        _TableroRepository = tableroRepository;
    }

    private bool estaLogueado(){
        if (HttpContext.Session !=null && (HttpContext.Session.GetString("rol") == (Rol.Administrador).ToString() || HttpContext.Session.GetString("rol") == (Rol.Operador).ToString()))
        {
            return true;
        }
        return false;
    }
    private bool esAdmin(){
       if (HttpContext.Session.GetString("rol") == (Rol.Administrador).ToString())
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
    public IActionResult Index(string idUsuario)
    {
        try
        {   
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            List<Tarea> tareas= new List<Tarea>();
            int id_usuario = int.Parse(idUsuario);
            tareas = _repository.GetAllUsersTareas(id_usuario); 
            var tareasVM = new ListarTareaViewModel(tareas);
            return View(tareasVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult ListarTareasDeTablero(int idTablero, string esPropietario, int idUsuario){
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
            tareasAsignadas = _repository.GetAllTablerosUsuarioTareas(idTablero, idUsuario);
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
                return RedirectToRoute(new { controller = "Tablero", action = "Index" });     
            }
            Tarea newTarea = new Tarea(tarea);
            _repository.CreateTarea(newTarea);
            return RedirectToRoute(new { controller = "Tarea", action = "ListarTareasDeTablero", idTablero = newTarea.Id_tablero, esPropietario = "True" });     

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
            var users = _usuarioRepository.GetAllUsuarios();
            var tareasVM = new EditarTareaViewModel(tarea, users);
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
                return RedirectToRoute(new { controller = "Tablero", action = "Index" });     
            }
            var tareaActualizada = new Tarea(tarea);
            _repository.UpdateTarea(tareaActualizada);
            return RedirectToRoute(new { controller = "Tarea", action = "ListarTareasDeTablero", idTablero = tareaActualizada.Id_tablero, esPropietario = "True" });     
        }catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    // [HttpDelete]
    public IActionResult DeleteTarea(int idTarea)
    {  
        try
        {
        if (!estaLogueado())
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        _repository.RemoveTarea(idTarea);
        var tarea = _repository.GetTareaById(idTarea);
        return RedirectToRoute(new { controller = "Tarea", action = "ListarTareasDeTablero", idTablero = tarea.Id_tablero, esPropietario = "True" });     
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public IActionResult ActualizarEstado(Tarea.estadoTarea estadoTarea, int idTarea){
        try
        {
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            _repository.ChangeEstado(estadoTarea, idTarea);
            var tarea = _repository.GetTareaById(idTarea);
            return RedirectToRoute(new { controller = "Tarea", action = "Index", idUsuario = tarea.Id_usuario_asignado});
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    [HttpGet]
    public IActionResult GestionDeTarea()
    {
        try
        {   
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!esAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            List<Tarea> tareas= new List<Tarea>();
            tareas = _repository.GetAllTareas();
            var tableros = new List<Tablero> ();
            tableros = _TableroRepository.GetAllTableros();
            var tareasVM = new GestionDeTareaViewModel(tareas, tableros);
            return View(tareasVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult SeleccionarTablero(){
        try
        {
            
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!esAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
                
            }   
            var tableros = _TableroRepository.GetAllTableros();
            return View(tableros);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }
    [HttpPost]
    public IActionResult SeleccionarTablero(int idTablero){
        try
        {
            
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!esAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
                
            }   
            return RedirectToRoute(new { controller = "Tarea", action = "CrearTarea", idTablero = idTablero });

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
