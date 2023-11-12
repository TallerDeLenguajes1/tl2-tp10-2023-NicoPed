using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed
{
    public interface ITareaRepository
{
    public List<Tarea> GetAllTareas();
    public Tarea GetTareaById(int id);
    public bool CreateTarea(Tarea tarea);
    public bool RemoveTarea(int id);
    public bool UpdateTarea(Tarea tarea);
    public List<Tarea> GetAllUsersTareas(int id_usuario);
    public List<Tarea> GetAllTablerosTareas(int id_tablero);
    public bool AssingTareaToUser(int id_usuario, int id_Tarea);
    public int CantTareasEnUnEstado(Tarea.estadoTarea estado);
}
}