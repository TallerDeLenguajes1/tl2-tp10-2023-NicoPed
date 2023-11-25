using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed.ViewModels
{
    public class EditarUsuarioViewModel
    {
        private string? nombre_de_usuario;
        private string? contrasenia;
        private Rol rolUsuario;
        private int id_usuario;

        public EditarUsuarioViewModel()
        {
        }

        public EditarUsuarioViewModel(Usuario usuario)
        {
            Nombre_de_usuario = usuario.Nombre_de_usuario;
            Contrasenia = usuario.Contrasenia;
            RolUsuario = usuario.RolDeUsuario;
            Id_usuario = usuario.Id_usuario;
        }
        
        public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
        public string? Contrasenia { get => contrasenia; set => contrasenia = value; }
        public Rol RolUsuario { get => rolUsuario; set => rolUsuario = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
    }
}