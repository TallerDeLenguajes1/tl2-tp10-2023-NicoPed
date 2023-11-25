using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository repository = new UsuarioRepository();
    public UsuarioController(ILogger<UsuarioController> logger)
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
    public IActionResult Index()
    {
        if (!estaLogueado() || !isAdmin())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var usuarios = repository.GetAllUsuarios(); 
        var usuariosVM = new ListarUsuarioViewModel(usuarios);
        return View(usuariosVM.ListarUsariosVM);
    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {   
        if (!estaLogueado() || !isAdmin())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        return View(new CrearUsuarioViewModel());
    }

    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel usuario)
    {   
        if (!estaLogueado() || !isAdmin())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var newUsuario = new Usuario(usuario);
        repository.CreateUsuario(newUsuario);
        return RedirectToAction("Index");
    }
   
   //MODIFICAR
    [HttpGet]
    public IActionResult EditarUsuario(int idUsuario)
    {  
        if (!estaLogueado() || !isAdmin())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var usuario = repository.GetUsuarioById(idUsuario);
        return View(usuario);
    }

    [HttpPost]
    public IActionResult EditarUsuario(EditarUsuarioViewModel usuario)
    {   
        if (!estaLogueado() || !isAdmin())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var usuarioActualizado = new Usuario(usuario);
        repository.Updateusuario(usuarioActualizado);
        return RedirectToAction("Index");
    }

    //ELIMINAR
    public IActionResult DeleteUsuario(int idUsuario)
    {  
        if (!estaLogueado() || !isAdmin())
        {
            RedirectToRoute(new { controller = "Login", action = "Index" });
        }        
        repository.RemoveUsuario(idUsuario);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
