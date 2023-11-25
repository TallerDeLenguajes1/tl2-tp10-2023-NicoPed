using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
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

            return RedirectToRoute(new {controller = "Home", action="index"});
        }else{
            return RedirectToAction("Index");
        }
    }

    private void LoguearUsuario(Usuario usuario){
        HttpContext.Session.SetString("id", usuario.Id_usuario.ToString());
        HttpContext.Session.SetString("usuario", usuario.Nombre_de_usuario);
        HttpContext.Session.SetString("rol", usuario.RolDeUsuario.ToString());
    }
}
