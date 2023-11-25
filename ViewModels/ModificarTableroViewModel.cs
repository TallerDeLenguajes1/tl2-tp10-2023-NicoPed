namespace tl2_tp10_2023_NicoPed.ViewModels;
public class ModificarTableroViewModel
{
    private int id_usuario_propietario;
    private string? nombre;
    private string? descripcion;

    public ModificarTableroViewModel(Tablero tablero)
    {
        Id_usuario_propietario = tablero.Id_usuario_propietario;
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
    }

    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}