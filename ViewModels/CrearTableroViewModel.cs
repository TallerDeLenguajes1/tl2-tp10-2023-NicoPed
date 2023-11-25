using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_NicoPed.ViewModels;
public class CrearTableroViewModel
{
    private int id_usuario_propietario;
    private string? nombre;
    private string? descripcion;

    public CrearTableroViewModel()
    {
    }
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id Usuario Propietario")]
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Nombre Del Tablero")]
    public string? Nombre { get => nombre; set => nombre = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Descripcion")] 
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}