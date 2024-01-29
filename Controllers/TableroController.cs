using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository _repository;
    private IUsuarioRepository _usuarioRepository;
    public TableroController(ILogger<TableroController> logger, ITableroRepository tableroRepository, IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
        _repository = tableroRepository;
    }

    //FUNCION PARA VER SI ESTA LOGUEADO Y QUE TIPO ES
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
// ------------------???????--------------------
    
//Nuevo index solo me muestra los tableros propios y asignados
    public IActionResult Index(string idUsuario)
    {
        try
        {        
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
                List<Tablero> tablerosPropios = new List<Tablero>();
                List<Tablero> tablerosAsignados = new List<Tablero>();
                List<Usuario> usuarios = new List<Usuario>();
                int id_usuario = int.Parse(idUsuario);
                // obtenerId();
                tablerosPropios = _repository.GetAllTablerosOfUser(id_usuario);
                tablerosAsignados = _repository.GetAssignedTasksTableros(id_usuario);
                usuarios = _usuarioRepository.GetAllUsuarios();
                var tableroVM = new ListarTableroViewModel(tablerosPropios, tablerosAsignados, usuarios);
                
                return View(tableroVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }


    [HttpGet]
    public IActionResult CrearTablero(int idUsuario)
    {   
        try
        {
            
            if (!estaLogueado())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (idUsuario == -999)
            {
                idUsuario = obtenerId();
            }
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            CrearTableroViewModel nuevoTableroVM = new CrearTableroViewModel(usuario);
            return View(nuevoTableroVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public IActionResult CrearTablero(CrearTableroViewModel tablero)
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
            Tablero newTablero = new Tablero(tablero);
            _repository.CreateTablero(newTablero);
            
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
    public IActionResult EditarTablero(int idTablero)
    {  
        try
        {
            
            if(!ModelState.IsValid) return RedirectToRoute(new{controller="Logueo", action="Index"});

            if (!estaLogueado())
            {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var tablero = _repository.GetTableroById(idTablero);
            var tableroVM = new EditarTableroViewModel(tablero);
            return View(tableroVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }
    [HttpPost]
    public IActionResult EditarTablero(EditarTableroViewModel tableroVW)
    {   
        try{
            if (!estaLogueado())
            {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
            return RedirectToRoute(new { controller = "Tablero", action = "Index" });     
            }
            var tablero =  new Tablero (tableroVW);
            _repository.UpdateTablero(tablero);
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    //ELIMINAR
    public IActionResult DeleteTablero(int idTablero)
    {  
        try
        {
            if (!estaLogueado())
            {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            _repository.RemoveTablero(idTablero);
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult GestionDeTablero(){
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
                List<Tablero> tableros = new List<Tablero>();
                tableros = _repository.GetAllTableros();
                List<Usuario> usuarios = new List<Usuario>();
                usuarios = _usuarioRepository.GetAllUsuarios();
                
                var tableroVM = new GestionDeTableroViewModel(tableros, usuarios);
                return View(tableroVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }
    
    [HttpGet]
    public IActionResult SeleccionarUsuario(){
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
                List<Usuario> usuarios = new List<Usuario>();
                usuarios = _usuarioRepository.GetAllUsuarios();
                var usuariosVM = new ListarUsuarioViewModel(usuarios);
                return View(usuariosVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    
    }

    [HttpPost]
    public IActionResult SeleccionarUsuario(int idUsuario){
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
            return RedirectToRoute(new { controller = "Tablero", action = "CrearTablero", idUsuario = idUsuario });

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
