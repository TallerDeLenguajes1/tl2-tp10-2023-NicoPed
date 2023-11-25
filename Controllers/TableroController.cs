using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository repository = new TableroRepository();
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
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
    // --------------------------------------
    public IActionResult Index()
    {
        if (!estaLogueado())
        {
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        List<Tablero> tableros = new List<Tablero>();
        if (isAdmin())
        {
            tableros = repository.GetAllTableros(); 
        }else
        {
            tableros = repository.GetAllUsersTableros(obtenerId());
        }
            var tableroVM = new ListarTableroViewModel(tableros);
            return View(tableroVM.ListarTableroVM);
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {   
        if (!estaLogueado())
        {
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        CrearTableroViewModel nuevoTableroVM = new CrearTableroViewModel();
        return View(nuevoTableroVM);
    }

    [HttpPost]
    public IActionResult CrearTablero(CrearTableroViewModel tablero)
    {   
        if (!estaLogueado())
        {
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        Tablero newTablero = new Tablero(tablero);
        repository.CreateTablero(newTablero);
        return RedirectToAction("Index");
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarTablero(int idTablero)
    {  
        if (!estaLogueado())
        {
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var tablero = repository.GetTableroById(idTablero);
        var tableroVM = new EditarTableroViewModel(tablero);
        return View(tableroVM);
    }
//DUDAAAAAAAAAAAAAAA DEBO MANDAR EL ID_USU_PROP
    [HttpPost]
    public IActionResult EditarTablero(EditarTableroViewModel tableroVW)
    {   
        if (!estaLogueado())
        {
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var tablero =  new Tablero (tableroVW);
        repository.UpdateTablero(tablero);
        return RedirectToAction("Index");
    }

    //ELIMINAR
    public IActionResult DeleteTablero(int idTablero)
    {  
        if (!estaLogueado())
        {
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        repository.RemoveTablero(idTablero);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
