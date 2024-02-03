using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_NicoPed.ViewModels;
public class TableroPropioViewModel
{
    private int id_tablero;
    private string? nombre;
    private string? descripcion;

    public TableroPropioViewModel()
    {
    }

    public TableroPropioViewModel(Tablero tablero)
    {
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
        Id_tablero = tablero.Id_tablero;
    }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre Del Tablero")]
    public string? Nombre { get => nombre; set => nombre = value; }
    [Display(Name = "Descripción Del Tablero")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
}