using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarTableroViewModel{
    private List<TableroPropioViewModel> tablerosPropiosVM;
    private List<TableroAsignadoViewModel> tablerosAsignadosVM;
    public ListarTableroViewModel(List<Tablero> tablerosPropios,List<Tablero> tablerosAsignados, List<Usuario> usuarios)
    {

        tablerosPropiosVM = new List<TableroPropioViewModel>(); 
        foreach (var tablero in tablerosPropios)
        {
            var TableroViewM = new TableroPropioViewModel(tablero);
            TablerosPropiosVM.Add(TableroViewM);
        }
        
        tablerosAsignadosVM = new List<TableroAsignadoViewModel>(); 
        foreach (var tablero in tablerosAsignados)
        {
            var usuarioPropietario = new Usuario();
            usuarioPropietario = usuarios.FirstOrDefault(u => u.Id_usuario == tablero.Id_usuario_propietario);
            var TableroViewM = new TableroAsignadoViewModel(tablero, usuarioPropietario);
            TablerosAsignadosVM.Add(TableroViewM);
        }
    }
    public List<TableroPropioViewModel> TablerosPropiosVM { get => tablerosPropiosVM; }
    public List<TableroAsignadoViewModel> TablerosAsignadosVM { get => tablerosAsignadosVM; }
}
