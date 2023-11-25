using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class ListarTareaViewModel{

    private List<TareaViewModel> listarTareaVM;
    public ListarTareaViewModel(List<Tarea> tareas)
    {
        ListarTareaVM = new List<TareaViewModel>();
        foreach (var tarea in tareas)
        {
            var UsuarioViewM = new TareaViewModel(tarea);
            ListarTareaVM.Add(UsuarioViewM);
        }
    }
    public List<TareaViewModel> ListarTareaVM { get => listarTareaVM; set => listarTareaVM = value; }
}
