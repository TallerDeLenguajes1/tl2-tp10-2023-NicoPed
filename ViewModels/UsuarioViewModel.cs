using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class UsuarioViewModel{
    private Rol rolUsuario;
    private string? nombre_de_usuario;
    private int id_usuario;


    public Rol RolUsuario { get => rolUsuario; set => rolUsuario = value; }
    public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
    public int Id_usuario { get => id_usuario; set => id_usuario = value; }

    public UsuarioViewModel(Usuario usuario)
    {
        Id_usuario = usuario.Id_usuario;
        RolUsuario = usuario.RolDeUsuario;
        Nombre_de_usuario = usuario.Nombre_de_usuario;
    }
    public UsuarioViewModel()
    {
    }
}