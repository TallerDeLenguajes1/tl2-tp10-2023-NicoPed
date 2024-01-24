using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_NicoPed.ViewModels;
public class SeleccionarTableroViewModel
{
    private int id_tablero;
    private string? nombre;

    public SeleccionarTableroViewModel()
    {
    }

    public SeleccionarTableroViewModel(Tablero tablero)
    {
        Nombre = tablero.Nombre;
        Id_tablero = tablero.Id_tablero;
    }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre del tablero")]
    public string? Nombre { get => nombre; set => nombre = value; }
    [Display(Name = "Descripción del tablero")]
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
}