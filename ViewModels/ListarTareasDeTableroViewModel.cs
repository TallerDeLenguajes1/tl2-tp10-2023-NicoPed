using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarTareasDeTableroViewModel{
    private List<TareaViewModel> tareasAsignadas;
    private List<TareaViewModel> tareasNoAsignadas;
    private int idTablero;
    private bool esPropietario;
    public ListarTareasDeTableroViewModel(){

    }
    public ListarTareasDeTableroViewModel(List<Tarea> tareasTablero, int id_Tablero, bool _es_Propietario){
        tareasAsignadas = new List<TareaViewModel>();
        tareasNoAsignadas = new List<TareaViewModel>();
        idTablero = id_Tablero;
        esPropietario = _es_Propietario;
        foreach (var tarea in tareasTablero)
        {
            var newTarea = new TareaViewModel(tarea);
            tareasAsignadas.Add(newTarea);
        }
    }
    public ListarTareasDeTableroViewModel(List<Tarea> asignadas, List<Tarea> noAsignadas, int id_Tablero, bool _es_Propietario){
        tareasAsignadas = new List<TareaViewModel>();
        tareasNoAsignadas = new List<TareaViewModel>();
        
        idTablero = id_Tablero;
        esPropietario = _es_Propietario;
        foreach (var tarea in asignadas)
        {
            var newTarea = new TareaViewModel(tarea);
            tareasAsignadas.Add(newTarea);
        }
        foreach (var tarea in noAsignadas)
        {
            var newTarea = new TareaViewModel(tarea);
            tareasNoAsignadas.Add(newTarea);
        }
    }
    public List<TareaViewModel> TareasAsignadas { get => tareasAsignadas; }
    public int IdTablero { get => idTablero;}
    public bool EsPropietario { get => esPropietario; }
    public List<TareaViewModel> TareasNoAsignadas { get => tareasNoAsignadas;}
}