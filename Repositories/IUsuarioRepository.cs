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
    public bool CreateUsuario(Usuario usuario);
    public bool RemoveUsuario(int id);
    public bool Updateusuario(Usuario usuario);
}
}