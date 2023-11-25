using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;
using Microsoft.AspNetCore.Session;

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
        if (HttpContext.Session !=null && (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Operador"))
        {
            return true;
        }
        return false;
    }
    private bool isAdmin(){
        string? rol = HttpContext.Session.GetString("rol");
       if (rol == "Administrador")
       {
            return true;
       }
       return false;
    }
    public IActionResult Index()
    {
        if (!estaLogueado() || !isAdmin())
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
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
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        return View(new CrearUsuarioViewModel());
    }

    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel usuario)
    {   
        if (!estaLogueado() || !isAdmin())
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
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
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        var usuario = repository.GetUsuarioById(idUsuario);
        var usuariosVM = new EditarUsuarioViewModel(usuario);
        return View(usuariosVM);
    }

    [HttpPost]
    public IActionResult EditarUsuario(EditarUsuarioViewModel usuario)
    {   
        if (!estaLogueado() || !isAdmin())
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
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
            return RedirectToRoute(new { controller = "Login", action = "Index" });
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
