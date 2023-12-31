using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository _repository;
    public TableroController(ILogger<TableroController> logger, ITableroRepository tableroRepository)
    {
        _logger = logger;
        _repository = tableroRepository;
    }

    //FUNCION PARA VER SI ESTA LOGUEADO Y QUE TIPO ES
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
// ------------------???????--------------------
    public IActionResult Index()
    {
        try
        {        
            if (!estaLogueado())
            {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            List<Tablero> tableros = new List<Tablero>();
            if (isAdmin())
            {
                tableros = _repository.GetAllTableros(); 
            }else
            {
                tableros = _repository.GetAllUsersTableros(obtenerId());
            }
                var tableroVM = new ListarTableroViewModel(tableros);
                return View(tableroVM.ListarTableroVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {   
        try
        {
            
            if (!estaLogueado())
            {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            CrearTableroViewModel nuevoTableroVM = new CrearTableroViewModel();
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
            if(!ModelState.IsValid) return RedirectToRoute(new{controller="Logueo", action="Index"});
                
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
//DUDAAAAAAAAAAAAAAA DEBO MANDAR EL ID_USU_PROP
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
