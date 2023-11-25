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

    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }

}
