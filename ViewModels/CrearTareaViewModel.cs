using System.ComponentModel.DataAnnotations;
using System.Drawing;
using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class CrearTareaViewModel{
    private int id_tablero;
    private string? nombre;
    private Tarea.estadoTarea estado;
    private string? descripcion;
    private string? color;
    private int id_usuario_asignado;

    public CrearTareaViewModel()
    {
    }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id Tablero")]
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Nombre")]
    public string? Nombre { get => nombre; set => nombre = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Descripcion")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Color")]
    public string? Color { get => color; set => color = value; }
    
    [Display(Name = "Id Usuario Asignado")]
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Estado")]
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }

}
