using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp10_2023_NicoPed;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository repository = new TableroRepository();
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tableros = repository.GetAllTableros(); 
        return View(tableros);
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {   
        return View(new Tablero());
    }

    [HttpPost]
    public IActionResult CrearTablero(Tablero tablero)
    {   
        repository.CreateTablero(tablero);
        return RedirectToAction("Index");
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarTablero(int idTablero)
    {  
        var tablero = repository.GetTableroById(idTablero);
        return View(tablero);
    }

    [HttpPost]
    public IActionResult EditarTablero(Tablero tablero)
    {   
        
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
