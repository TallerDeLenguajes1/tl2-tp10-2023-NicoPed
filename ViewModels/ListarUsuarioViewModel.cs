using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarUsuarioViewModel{

    private List<UsuarioViewModel> listarUsariosVM;
    public ListarUsuarioViewModel(List<Usuario> usuarios)
    {
        ListarUsariosVM = new List<UsuarioViewModel>();
        foreach (var usuario in usuarios)
        {
            var UsuarioViewM = new UsuarioViewModel(usuario);
            ListarUsariosVM.Add(UsuarioViewM);
        }
    }
    public List<UsuarioViewModel> ListarUsariosVM { get => listarUsariosVM; set => listarUsariosVM = value; }
}
