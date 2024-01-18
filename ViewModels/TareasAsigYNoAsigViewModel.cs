using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class TareasAsigYNoAsigViewModel{
    private List<TareaViewModel> tareas;
    public TareasAsigYNoAsigViewModel(){

    }
    public TareasAsigYNoAsigViewModel(List<Tarea> tareasAsignadas, List<Tarea> tareasNOAsignadas){

        foreach (var tarea in tareasAsignadas)
        {
            var newTarea = new TareaViewModel(tarea);
            tarea.Add(newTarea);
        }
        foreach (var tarea in tareasNOAsignadas)
        {
            var newTarea = new TareaViewModel(tarea);
            tarea.Add(newTarea);
        }
    }
    public List<TareaViewModel> Tareas { get => tareas; }
}