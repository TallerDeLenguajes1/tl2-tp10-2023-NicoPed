using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using tl2_tp10_2023_NicoPed.ViewModels;
namespace tl2_tp10_2023_NicoPed;

public class LoginController: Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IUsuarioRepository _repository;

//ESTA BIEN ASI???????
    public LoginController(ILogger<LoginController> logger, IUsuarioRepository usuarioRepository)
    {
        _logger = logger;
        _repository = usuarioRepository;
    }

    [HttpGet]
    public IActionResult Index(){
        return View();
    }

    [HttpPost] // AQUI VIENE EL LOGIN DEL FORM
    public IActionResult Login(LoginViewModel loginUsuario){
        try
        {
            //CONTROLA SI ELMODELO ES VALIDO
            if(!ModelState.IsValid) return RedirectToAction("Index");

            var usuarioLogueado = _repository.GetUsuario(loginUsuario.NombreUsuario, loginUsuario.ContraseniaUsuario);
            
            //YA NO HAGO ESTE CONTROL YA DIRECTAMENTE SI FALLA SE IRA POR EL CATCH
            // if(usuarioLogueado != null){
                
                LoguearUsuario(usuarioLogueado); //SI ESTA 
                _logger.LogInformation($"El usuario {usuarioLogueado.Nombre_de_usuario} ingreso correctamente");
                return RedirectToRoute(new {controller = "Home", action="index"});
            // }else{
                // return RedirectToAction("Index");
            // }
        }
        catch (System.Exception ex)
        {
            // ex_ Logueo tipo error
            _logger.LogWarning($"Error: {ex.ToString()} Intento de acceso invalido - Usuario: {loginUsuario.NombreUsuario} - Clave ingresada: {loginUsuario.ContraseniaUsuario}");
            return RedirectToAction("Index");
        }
    }

    private void LoguearUsuario(Usuario usuario){
        HttpContext.Session.SetString("id", usuario.Id_usuario.ToString());
        HttpContext.Session.SetString("usuario", usuario.Nombre_de_usuario);
        HttpContext.Session.SetString("rol", usuario.RolDeUsuario.ToString());
    }
}
