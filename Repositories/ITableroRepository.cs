using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed
{
    public interface ITableroRepository
{
    public List<Tablero> GetAllTableros();
    public Tablero GetTableroById(int id);
    public void CreateTablero(Tablero tablero);
    public void RemoveTablero(int id);
    public void UpdateTablero(Tablero tablero);
    public List<Tablero> GetAllTablerosOfUser(int id_usuario);
    public List<Tablero> GetAssignedTasksTableros(int id_usuario);

}
}