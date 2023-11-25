namespace tl2_tp10_2023_NicoPed.ViewModels;
public class EditarTableroViewModel
{
    private string? nombre;
    private string? descripcion;
    private int id_tablero;
    private int id_usuario_propietario;

    public EditarTableroViewModel(Tablero tablero)
    {
        Id_tablero = tablero.Id_tablero;
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
        id_usuario_propietario = tablero.Id_usuario_propietario;
    }

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
}