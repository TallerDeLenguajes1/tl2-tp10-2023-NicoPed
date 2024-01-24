using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class GestionDeTareaViewModel{

    private List<TareaTableroViewModel> listarTareaVM;
    public GestionDeTareaViewModel(List<Tarea> tareas, List<Tablero> tableros)
    {
        ListarTareaVM = new List<TareaTableroViewModel>();
        foreach (var tarea in tareas)
        {
            var tablero = new Tablero();
            tablero = tableros.FirstOrDefault(u => u.Id_tablero == tarea.Id_tablero);
            var tareaViewM = new TareaTableroViewModel(tarea, tablero);
            ListarTareaVM.Add(tareaViewM);
        }
    }
    public List<TareaTableroViewModel> ListarTareaVM { get => listarTareaVM; set => listarTareaVM = value; }
}
