namespace tl2_tp10_2023_NicoPed.ViewModels;
using System.ComponentModel.DataAnnotations;

public class EditarTableroViewModel
{
    private string? nombre;
    private string? descripcion;
    private int id_tablero;
    private int id_usuario_propietario;

    public EditarTableroViewModel()
    {
    }

    public EditarTableroViewModel(Tablero tablero)
    {
        Id_tablero = tablero.Id_tablero;
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
        id_usuario_propietario = tablero.Id_usuario_propietario;
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
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id_tablero")] 
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }

    
}