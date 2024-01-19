using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarTareasDeTableroViewModel{
    private List<TareaViewModel> tareas;
    private int idTablero;
    private bool esPropietario;
    public ListarTareasDeTableroViewModel(){

    }
    public ListarTareasDeTableroViewModel(List<Tarea> tareasTablero, int id_Tablero, bool _es_Propietario){
        tareas = new List<TareaViewModel>();
        idTablero = id_Tablero;
        esPropietario = _es_Propietario;
        foreach (var tarea in tareasTablero)
        {
            var newTarea = new TareaViewModel(tarea);
            tareas.Add(newTarea);
        }
    }
    public ListarTareasDeTableroViewModel(List<Tarea> tareasAsignadas, List<Tarea> tareasNOAsignadas, int id_Tablero, bool _es_Propietario){
        tareas = new List<TareaViewModel>();
        idTablero = id_Tablero;
        esPropietario = _es_Propietario;
        foreach (var tarea in tareasAsignadas)
        {
            var newTarea = new TareaViewModel(tarea);
            tareas.Add(newTarea);
        }
        foreach (var tarea in tareasNOAsignadas)
        {
            var newTarea = new TareaViewModel(tarea);
            tareas.Add(newTarea);
        }
    }
    public List<TareaViewModel> Tareas { get => tareas; }
    public int IdTablero { get => idTablero;}
    public bool EsPropietario { get => esPropietario; }
}