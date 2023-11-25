using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed.ViewModels;
namespace tl2_tp10_2023_NicoPed;

public class LoginController: Controller
{
    private readonly ILogger<LoginController> _logger;
    private IUsuarioRepository repository;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
        repository = new UsuarioRepository();
    }

    [HttpGet]
    public IActionResult Index(){
        return View();
    }

    [HttpPost] // AQUI VIENE EL LOGIN DEL FORM
    public IActionResult Login(LoginViewModel loginUsuario){

        var usuarioLogueado = repository.GetUsuario(loginUsuario.NombreUsuario, loginUsuario.ContraseniaUsuario);
        
        if(usuarioLogueado != null){
            
            LoguearUsuario(usuarioLogueado); //SI ESTA 

            if(HttpContext.Session.GetString("rol") == Rol.Administrador.ToString())
                return RedirectToRoute(new {controller = "Usuario", action = "Index"});
             else 
                return RedirectToRoute(new {controller = "Tablero", action="MisTableros"});
        }else{
            return RedirectToAction("Index");
        }
    }

    private void LoguearUsuario(Usuario usuario){
        HttpContext.Session.SetInt32("id", usuario.Id_usuario);
        HttpContext.Session.SetString("usuario", usuario.Nombre_de_usuario);
        HttpContext.Session.SetString("rol", usuario.RolDeUsuario.ToString());
    }
}
