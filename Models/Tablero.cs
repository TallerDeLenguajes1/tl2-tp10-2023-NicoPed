using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;
public class Tablero{
    private int id_tablero;
    private int id_usuario_propietario;
    private string? nombre;
    private string? descripcion;

    public Tablero()
    {
    }

    public Tablero(CrearTableroViewModel tablero)
    {
        id_usuario_propietario = tablero.Id_usuario_propietario;
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
    }

    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}