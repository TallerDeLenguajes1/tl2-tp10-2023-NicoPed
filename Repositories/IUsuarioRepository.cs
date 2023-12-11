using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed
{
    public interface IUsuarioRepository
{
    public List<Usuario> GetAllUsuarios();
    public Usuario GetUsuarioById(int id);
    public void CreateUsuario(Usuario usuario);
    public void RemoveUsuario(int id);
    public void Updateusuario(Usuario usuario);
    public Usuario GetUsuario(string nombreUsuario, string contraseniaUsuario);
    
    }
}