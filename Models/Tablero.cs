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

    public Tablero(CrearTableroViewModel crearTablero)
    {
        id_usuario_propietario = crearTablero.Id_usuario_propietario;
        Nombre = crearTablero.Nombre;
        Descripcion = crearTablero.Descripcion;
    }
    public Tablero(EditarTableroViewModel editarTablertoVW)
    {
        id_usuario_propietario = editarTablertoVW.Id_usuario_propietario;
        Nombre = editarTablertoVW.Nombre;
        Descripcion = editarTablertoVW.Descripcion;
        Id_tablero = editarTablertoVW.Id_tablero;
    }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }

}