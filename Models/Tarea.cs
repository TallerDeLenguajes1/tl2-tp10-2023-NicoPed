namespace tl2_tp09_2023_NicoPed;

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

    public int Id_tarea { get => id_tarea; set => id_tarea = value; }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
    public estadoTarea Estado { get => estado; set => estado = value; }
}