using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarTableroViewModel{

    private List<TableroViewModel> listarTableroVM;
    public ListarTableroViewModel(List<Tablero> tableros)
    {
        ListarTableroVM = new List<TableroViewModel>();
        foreach (var tablero in tableros)
        {
            var UsuarioViewM = new TableroViewModel(tablero);
            ListarTableroVM.Add(UsuarioViewM);
        }
    }
    public List<TableroViewModel> ListarTableroVM { get => listarTableroVM; set => listarTableroVM = value; }
}
