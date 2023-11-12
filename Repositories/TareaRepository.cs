
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed
{
    public class TareaRepository : ITareaRepository
    {
        //LA CADENA DE CONEXION!!!!!!!!
        private string cadenaConexion = "Data Source=db/kanban.db;Cache=Shared";
       
        public bool AssingTareaToUser(int id_usuario, int id_Tarea)
        {
            throw new NotImplementedException();
        }

        public bool CreateTarea(Tarea tarea)
        {
            var resultado = false;
            var queryString = @"INSERT INTO tarea 
            (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado)
            VALUES(@id_tablero, @nombre, @estado, @descripcion, @color, @id_usu )";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            { 
                var command = new SQLiteCommand(queryString,connection);
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id_usu",tarea.Id_usuario_asignado));
                command.Parameters.Add(new SQLiteParameter("@id_tablero",tarea.Id_tablero));
                command.Parameters.Add(new SQLiteParameter("@nombre",tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado",tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descripcion",tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color",tarea.Color));
                command.ExecuteNonQuery();
                connection.Close();
                resultado = true;
            }
            return resultado;
        }

        public List<Tarea> GetAllTablerosTareas(int id_tablero)
        {
            var queryString = @"SELECT * FROM tarea
            WHERE id_tablero = @id_tab;";

            var tareas = new List<Tarea>();
            
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id_tab",id_tablero));
                
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                    {
                        var tarea = new Tarea();
                        tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        if (Enum.TryParse(typeof(Tarea.estadoTarea), reader["estado"].ToString(), out var estado))
                        {
                            tarea.Estado = (Tarea.estadoTarea)estado;
                        }
                        else
                        {
                            tarea.Estado = Tarea.estadoTarea.Ideas;
                        }
                        tareas.Add(tarea);
                    }
                }
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
            }
            return tareas;
        }

        public List<Tarea> GetAllTareas()
        {
            var queryString = @"SELECT * FROM tarea;";

            var tareas = new List<Tarea>();
            
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                
                connection.Open();
                                
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                    {
                        var tarea = new Tarea();
                        tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        
                        if (Enum.TryParse(typeof(Tarea.estadoTarea), reader["estado"].ToString(), out var estado))
                        {
                            tarea.Estado = (Tarea.estadoTarea)estado;
                        }
                        else
                        {
                            tarea.Estado = Tarea.estadoTarea.Ideas;
                        }
                        tareas.Add(tarea);
                    }
                }
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
            }
            return tareas;
        }

        public List<Tarea> GetAllUsersTareas(int id_usuario)
        {
            var queryString = @"SELECT * FROM tarea
            WHERE id_usuario_asignado = @id_usu;";

            var tareas = new List<Tarea>();
            
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id_usu",id_usuario));
                
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                    {
                        var tarea = new Tarea();
                        tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        if (Enum.TryParse(typeof(Tarea.estadoTarea), reader["estado"].ToString(), out var estado))
                        {
                            tarea.Estado = (Tarea.estadoTarea)estado;
                        }
                        else
                        {
                            tarea.Estado = Tarea.estadoTarea.Ideas;
                        }
                        tareas.Add(tarea);
                    }
                }
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
            }
            return tareas;
        }

        public Tarea GetTareaById(int id)
        {
            var queryString = @"SELECT * FROM tarea
            WHERE id_tarea = @id_tarea;";

            var tarea = new Tarea();
            
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id_tarea",id));
                
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                    {
                        tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        if (Enum.TryParse(typeof(Tarea.estadoTarea), reader["estado"].ToString(), out var estado))
                        {
                            tarea.Estado = (Tarea.estadoTarea)estado;
                        }
                        else
                        {
                            tarea.Estado = Tarea.estadoTarea.Ideas;
                        }
                    }
                }
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
            }
            return tarea;
        }

        public bool RemoveTarea(int id)
        {
            var resultado = false;
            var queryString = @"DELETE FROM tarea 
            WHERE id_tarea = @id ;";//LA CONSULTA
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id",id));
                command.ExecuteNonQuery();
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                resultado = true;
            }
            return resultado;
        }
        public int CantTareasEnUnEstado(Tarea.estadoTarea estado){
            var queryString = @"SELECT * FROM tarea
            WHERE estado = @estado;";

            var tareas = new List<Tarea>();
            
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@estado",estado));
                
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                    {
                        var tarea = new Tarea();
                        tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        if (Enum.TryParse(typeof(Tarea.estadoTarea), reader["estado"].ToString(), out var estad))
                        {
                            tarea.Estado = (Tarea.estadoTarea)estad;
                        }
                        else
                        {
                            tarea.Estado = Tarea.estadoTarea.Ideas;
                        }
                        tareas.Add(tarea);
                    }
                }
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
            }
            return tareas.Count;
        }
        public bool UpdateTarea(Tarea tarea)
        {
            var resultado = false;
            var queryString = @"UPDATE tarea SET id_tablero = @idTablero,nombre = @nombre, 
            estado = @estado, descripcion = @descripcion, color = @color,
            id_usuario_asignado = @id_usu
            WHERE id_tarea = @id";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@id",tarea.Id_tarea));
                command.Parameters.Add(new SQLiteParameter("@id_usu",tarea.Id_usuario_asignado));
                command.Parameters.Add(new SQLiteParameter("@nombre",tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@color",tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@estado",tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descripcion",tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@idTablero",tarea.Id_tablero));
                command.ExecuteNonQuery();
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                resultado = true;
            }
            return resultado;
        }
    }

}