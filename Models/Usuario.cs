namespace tl2_tp09_2023_NicoPed;

public class Usuario{
    private int id_usuario;
    private string? nombre_de_usuario;

    public Usuario()
    {
    }

    public int Id_usuario { get => id_usuario; set => id_usuario = value; }
    public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
}