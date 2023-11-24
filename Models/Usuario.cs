namespace tl2_tp10_2023_NicoPed;

public enum Rol{
    Administrador,
    Operador
}
public class Usuario{
    private int id_usuario;
    private string? nombre_de_usuario;
    private string? contrasenia;

    private Rol rolDeUsuario;


    public int Id_usuario { get => id_usuario; set => id_usuario = value; }
    public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
    public string? Contrasenia { get => contrasenia; set => contrasenia = value; }
    public Rol RolDeUsuario { get => rolDeUsuario; set => rolDeUsuario = value; }

    public Usuario()
    {
    
    }
    public Usuario(LoginViewModel loginViewModel)
    {          
        Nombre_de_usuario = loginViewModel.NombreUsuario;
        Contrasenia = loginViewModel.ContraseniaUsuario;
    } 

}