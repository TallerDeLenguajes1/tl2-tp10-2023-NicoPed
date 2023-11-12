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
    public bool CreateTablero(Tablero tablero);
    public bool RemoveTablero(int id);
    public bool UpdateTablero(Tablero tablero);
    public List<Tablero> GetAllUsersTableros(int id_usuario);
    
}
}