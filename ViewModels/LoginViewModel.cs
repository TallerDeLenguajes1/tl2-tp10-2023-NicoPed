using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_NicoPed.ViewModels;

public class LoginViewModel
{
    private string? nombreUsuario;
    private string? contraseniaUsuario;
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre De Usuario")]
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Contraseña")]
    public string ContraseniaUsuario { get => contraseniaUsuario; set => contraseniaUsuario = value; }
}