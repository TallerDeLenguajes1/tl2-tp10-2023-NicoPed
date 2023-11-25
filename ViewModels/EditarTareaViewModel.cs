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

    private int id_tarea;

    public EditarTareaViewModel()
    {
    }

    public EditarTareaViewModel(Tarea tarea)
    {
        Id_tablero = tarea.Id_tablero;
        Nombre = tarea.Nombre;
        Estado = tarea.Estado;
        Color = tarea.Color;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        Id_usuario_asignado = tarea.Id_usuario_asignado;
        Id_tarea = tarea.Id_tarea;
    }

    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }
    public int Id_tarea { get => id_tarea; set => id_tarea = value; }
}
