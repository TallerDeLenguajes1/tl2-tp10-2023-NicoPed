using System.Drawing;
using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class TareaViewModel{
    private string? nombre;
    private Tarea.estadoTarea estado;
    private string? descripcion;
    private string? color;

    public TareaViewModel()
    {
    }

    public TareaViewModel(Tarea tarea)
    {
        Nombre = tarea.Nombre;
        Estado = tarea.Estado;
        Color = tarea.Color;
        Estado = tarea.Estado;
    }

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public Tarea.estadoTarea Estado { get => estado; set => estado = value; }
}
