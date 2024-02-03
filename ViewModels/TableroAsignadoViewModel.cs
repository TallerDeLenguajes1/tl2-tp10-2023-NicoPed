using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_NicoPed.ViewModels;
public class TableroAsignadoViewModel
{
    private int id_tablero;
    private string? nombre;
    private string? descripcion;
    private string? nombreUsuarioPropietario;
    public TableroAsignadoViewModel()
    {
    }

    public TableroAsignadoViewModel(Tablero tablero, Usuario usuario)
    {
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
        Id_tablero = tablero.Id_tablero;
        nombreUsuarioPropietario = usuario.Nombre_de_usuario;
    }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre Del Tablero")]
    public string? Nombre { get => nombre; set => nombre = value; }
    [Display(Name = "Descripción Del Tablero")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public string? NombreUsuarioPropietario { get => nombreUsuarioPropietario; set => nombreUsuarioPropietario = value; }
}