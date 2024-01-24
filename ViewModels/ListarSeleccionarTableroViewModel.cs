using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarSeleccionarTableroViewModel{
    private List<SeleccionarTableroViewModel> tableros;
    public ListarSeleccionarTableroViewModel(List<Tablero> _tableros)
    {

        tableros = new List<SeleccionarTableroViewModel>(); 
        foreach (var tablero in _tableros)
        {
            var TableroViewM = new SeleccionarTableroViewModel(tablero);
            Tableros.Add(TableroViewM);
        }
        
    }
    public List<SeleccionarTableroViewModel> Tableros { get => tableros; }
}
