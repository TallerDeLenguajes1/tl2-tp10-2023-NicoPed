using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp10_2023_NicoPed;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository repository = new UsuarioRepository();
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var usuarios = repository.GetAllUsuarios(); 
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {   
        return View(new Usuario());
    }

    [HttpPost]
    public IActionResult CrearUsuario(Usuario usuario)
    {   
        repository.CreateUsuario(usuario);
        return RedirectToAction("Index");
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarUsuario(int idUsuario)
    {  
        var usuario = repository.GetUsuarioById(idUsuario);
        return View(usuario);
    }

    [HttpPost]
    public IActionResult EditarUsuario(Usuario usuario)
    {   
        
        repository.Updateusuario(usuario);
        return RedirectToAction("Index");
    }

    //ELIMINAR
    public IActionResult DeleteUsuario(int idUsuario)
    {  
        repository.RemoveUsuario(idUsuario);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
