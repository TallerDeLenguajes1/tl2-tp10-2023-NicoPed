using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;
using Microsoft.AspNetCore.Session;

namespace tl2_tp10_2023_NicoPed;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository _repository; 
    // = new UsuarioRepository();
    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository repository)
    {
        _logger = logger;
        _repository = repository;

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
        try
        {
            if (!estaLogueado() || !isAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var usuarios = _repository.GetAllUsuarios(); 
            var usuariosVM = new ListarUsuarioViewModel(usuarios);
            return View(usuariosVM.ListarUsariosVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {   
        try
        {
            if (!estaLogueado() || !isAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            return View(new CrearUsuarioViewModel());
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel usuario)
    {   
        try
        {
            if (!estaLogueado() || !isAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            //SI LO QUE SE ENVIO NO ES VALIDO
            if (!ModelState.IsValid)
            {
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });     
            }
            var newUsuario = new Usuario(usuario);
            _repository.CreateUsuario(newUsuario);
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
    public IActionResult EditarUsuario(int idUsuario)
    {  
        try
        {
            if (!estaLogueado() || !isAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var usuario = _repository.GetUsuarioById(idUsuario);
            var usuariosVM = new EditarUsuarioViewModel(usuario);
            return View(usuariosVM);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public IActionResult EditarUsuario(EditarUsuarioViewModel usuario)
    {   
        try
        {
            if (!estaLogueado() || !isAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });     
            }
            var usuarioActualizado = new Usuario(usuario);
            _repository.Updateusuario(usuarioActualizado);
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
    }

    //ELIMINAR
    public IActionResult DeleteUsuario(int idUsuario)
    {  
        try
        {
            if (!estaLogueado() || !isAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }        
            _repository.RemoveUsuario(idUsuario);
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
