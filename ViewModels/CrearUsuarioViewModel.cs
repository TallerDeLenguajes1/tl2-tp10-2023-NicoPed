using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed.ViewModels
{
    public class CrearUsuarioViewModel
    {
        private string? nombre_de_usuario;
        private string? contrasenia;
        private Rol rolUsuario;

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre De Usuario")]
        public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Contraseña")]
        public string? Contrasenia { get => contrasenia; set => contrasenia = value; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Rol")]
        public Rol RolUsuario { get => rolUsuario; set => rolUsuario = value; }
        
    }
}