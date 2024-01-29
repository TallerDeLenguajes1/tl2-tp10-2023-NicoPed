using System.Drawing;
using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class TareaViewModel{
    private int id_tarea;
    private string? nombre;
    private Tarea.estadoTarea estado;
    private string? descripcion;
    private string? color;
    private int id_usuario_asignado;
    public TareaViewModel()
    {
    }

    public TareaViewModel(Tarea tarea)
    {
        Id_tarea = tarea.Id_tarea;
        Nombre = tarea.Nombre;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        Estado = tarea.Estado;
        id_usuario_asignado = tarea.Id_usuario_asignado;
    }

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }
    public int Id_tarea { get => id_tarea; set => id_tarea = value; }
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
}
