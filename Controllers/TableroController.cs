using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    // --------------------------------------
    public IActionResult Index()
    {
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
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
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        CrearTableroViewModel nuevoTableroVM = new CrearTableroViewModel();
        return View(nuevoTableroVM);
    }

    [HttpPost]
    public IActionResult CrearTablero(CrearTableroViewModel tablero)
    {   
        if (!estaLogueado())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
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
            RedirectToRoute(new { controller = "Login", action = "Index" });
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
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var tablero =  new Tablero (tableroVW);
        repository.UpdateTablero(tablero);
        return RedirectToAction("Index");
    }

    //ELIMINAR
    public IActionResult DeleteTablero(int idTablero)
    {  
        repository.RemoveTablero(idTablero);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
