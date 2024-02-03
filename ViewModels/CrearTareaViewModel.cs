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
    private List<Usuario>? usuarios;
    public CrearTareaViewModel()
    {
    }
    public CrearTareaViewModel(int idTablero, List<Usuario> users)
    {
        Id_tablero = idTablero;
        usuarios = users;
    }

    [Display(Name = "Id Tablero")]
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Nombre")]
    public string? Nombre { get => nombre; set => nombre = value; }
    
    [Display(Name = "Descripción")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    
    [Display(Name = "Color")]
    public string? Color { get => color; set => color = value; }
    
    [Display(Name = "Usuario Asignado")]
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Estado")]
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }
    public List<Usuario>? Usuarios { get => usuarios;}
}
