using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class GestionDeTableroViewModel{
    private List<TableroAsignadoViewModel> tableros;
    public GestionDeTableroViewModel(List<Tablero> _tableros, List<Usuario> usuarios)
    {   
        tableros = new List<TableroAsignadoViewModel>(); 
        foreach (var tablero in _tableros)
        {
            var usuarioPropietario = new Usuario();
            usuarioPropietario = usuarios.FirstOrDefault(u => u.Id_usuario == tablero.Id_usuario_propietario);
            var TableroViewM = new TableroAsignadoViewModel(tablero, usuarioPropietario);
            Tableros.Add(TableroViewM);
        }
    }
    public List<TableroAsignadoViewModel> Tableros { get => tableros; }
}
