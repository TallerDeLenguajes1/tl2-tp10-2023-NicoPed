using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public IActionResult Login(LoginViewModel loginUsuario){
        var usuarioLogueado = repository.GetUsuario(loginUsuario.NombreUsuario, loginUsuario.ContraseniaUsuario);
        if(!String.IsNullOrEmpty(usuarioLogueado.Nombre_de_usuario)){
            LoguearUsuario(usuarioLogueado);
            if(HttpContext.Session.GetString("rol") == Rol.Administrador.ToString()) return RedirectToRoute(new {controller = "Usuario", action = "Index"});
            else return RedirectToRoute(new {controller = "Tablero", action="MisTableros"});
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
