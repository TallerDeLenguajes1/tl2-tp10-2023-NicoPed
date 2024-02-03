using System.ComponentModel.DataAnnotations;
using System.Drawing;
using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class EditarTareaViewModel{
    private int id_tablero;
    private string? nombre;
    private Tarea.estadoTarea estado;
    private string? descripcion;
    private string? color;
    private int id_usuario_asignado;

    private List<Usuario>? usuarios;
    private int id_tarea;

    public EditarTareaViewModel()
    {
    }

    public EditarTareaViewModel(Tarea tarea, List<Usuario> users)
    {
        Id_tablero = tarea.Id_tablero;
        Nombre = tarea.Nombre;
        Estado = tarea.Estado;
        Color = tarea.Color;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        Id_usuario_asignado = tarea.Id_usuario_asignado;
        Id_tarea = tarea.Id_tarea;
        usuarios = users;
    }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id Tablero")]
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Nombre")]
    public string? Nombre { get => nombre; set => nombre = value; }
    
    [Display(Name = "Descripción")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    
    [Display(Name = "Color")]
    public string? Color { get => color; set => color = value; }
    
    [Display(Name = "Id Usuario Asignado")]
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Estado")]
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id Tarea")]
    public int Id_tarea { get => id_tarea; set => id_tarea = value; }
    public List<Usuario>? Usuarios { get => usuarios; }
}
