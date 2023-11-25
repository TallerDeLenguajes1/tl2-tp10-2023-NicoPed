using tl2_tp10_2023_NicoPed.ViewModels;

namespace tl2_tp10_2023_NicoPed;

public class Tarea{
    public enum estadoTarea{
        Ideas,
        ToDo,
        Doing,
        Rewiev,
        Done
    }
    private int id_tarea;
    private int id_tablero;
    private string? nombre;
    private estadoTarea estado;
    private string? descripcion;
    private string? color;
    private int id_usuario_asignado;

    public Tarea()
    {
    }

    public Tarea(CrearTareaViewModel tareaViewModel)
    {
        Id_tablero = tareaViewModel.Id_tablero;
        Nombre = tareaViewModel.Nombre;
        Estado = tareaViewModel.Estado;
        Descripcion = tareaViewModel.Descripcion;
        Color = tareaViewModel.Color;
        Id_usuario_asignado = tareaViewModel.Id_usuario_asignado;
    }

    public Tarea(EditarTareaViewModel tareaViewModel)
    {
        Id_tarea = tareaViewModel.Id_tarea;
        Id_tablero = tareaViewModel.Id_tablero;
        Nombre = tareaViewModel.Nombre;
        Estado = tareaViewModel.Estado;
        Descripcion = tareaViewModel.Descripcion;
        Color = tareaViewModel.Color;
        Id_usuario_asignado = tareaViewModel.Id_usuario_asignado;
    }

    public int Id_tarea { get => id_tarea; set => id_tarea = value; }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
    public estadoTarea Estado { get => estado; set => estado = value; }
}