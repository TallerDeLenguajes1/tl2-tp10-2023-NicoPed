
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed
{
    public class TareaRepository : ITareaRepository
    {
        //LA CADENA DE CONEXION!!!!!!!!
        private readonly string cadenaConexion;

        public TareaRepository(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        //= "Data Source=db/kanban.db;Cache=Shared";

        public void AssingTareaToUser(int id_usuario, int id_Tarea)
        {
            throw new NotImplementedException();
        }

        public void CreateTarea(Tarea tarea)
        {
            try
            {
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
                    
                }
                
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL CREAR LA TAREA en la bd");
            }
        }

        public List<Tarea> GetAllTablerosTareas(int id_tablero)
        {
            try{
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
                if (tareas == null)
                {
                    throw new Exception("ERROR AL OBTENER LAS TAREAS DE UN TABLERO en la bd");
                }
                return tareas;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LAS TAREAS DE UN TABLERO en la bd");
            }
        }

        public List<Tarea> GetAllTareas()
        {
            try{
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
                if (tareas == null)
                {
                    throw new Exception("ERROR AL OBTENER LAS TAREAS");
                }
                return tareas;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LAS TAREAS");
            }
        }

        public List<Tarea> GetAllUsersTareas(int id_usuario)
        {
            try{
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
                if (tareas == null)
                {
                    throw new Exception("ERROR AL OBTENER LAS TAREAS DE UN USUARIO en la bd");
                }
                return tareas;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LAS TAREAS DE UN USUARIO en la bd");
            }
        }

        public Tarea GetTareaById(int id)
        {
            try{
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
                if (tarea == null)
                {
                    throw new Exception("ERROR AL OBTENER LA TAREA en la bd");
                }
                return tarea;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LA TAREA en la bd");
            }
        }

        public void RemoveTarea(int id)
        {
            try{
                var queryString = @"DELETE FROM tarea 
                WHERE id_tarea = @id ;";//LA CONSULTA
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    var command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id",id));
                    command.ExecuteNonQuery();
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                    
                }
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL REMOVER LA TAREA en la bd");
            }   
        }
        public int CantTareasEnUnEstado(Tarea.estadoTarea estado){
            try{
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
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LAS TAREAS DE UN ESTADO en la bd");
            }
        }
        public void UpdateTarea(Tarea tarea)
        {
            try{    
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
                    
                }
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL ACTUALIZAR LA TAREA en la bd");
            }
        }

        public List<Tarea> GetAllTablerosUsuarioTareas(int id_tablero, int id_usuario)
        {
            try
            {
                var queryString = @"SELECT id_tarea, id_tablero, nombre, descripcion, color, estado FROM
                tablero INNER JOIN tarea USING (id_tablero)
                INNER JOIN usuario ON id_usuario = id_usuario_asignado
                WHERE id_tablero = @id_tablero AND id_usuario = @id_usu"; 
                
                var tareas = new List<Tarea>();
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id_usu",id_usuario));
                    command.Parameters.Add(new SQLiteParameter("@id_tablero",id_tablero));
                    
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            var tarea = new Tarea();
                            tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                            tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                            tarea.Nombre = reader["nombre"].ToString();
                            tarea.Descripcion = reader["descripcion"].ToString();
                            tarea.Color = reader["color"].ToString();
                            tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                            //CAMBIAR POR LA FORMA MAS SIMPLE
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
                    connection.Close(); 
                }
                return tareas;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LAS TAREAS DEL TABLERO DE USUARIO LA TAREA en la bd");
            };
            /*
            Select * FROM tablero 
Inner Join tarea USING (id_tablero)
INNER JOIN usuario ON id_usuario = id_usuario_asignado
WHERE id_tablero = 1;*/
        }
    }
        public List<Tarea> GetAllTablerosNoAsiggnedTareas(int id_tablero){
            try
            {
                var queryString = @"SELECT id_tarea, id_tablero, nombre, descripcion, color, estado FROM
                tablero INNER JOIN tarea USING (id_tablero)
                LEFT JOIN usuario ON id_usuario = id_usuario_asignado
                WHERE id_tablero = @id_tablero AND id_usuario_asignado IS NULL"; 
                
                var tareas = new List<Tarea>();
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id_tablero",id_tablero));
                    
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            var tarea = new Tarea();
                            tarea.Id_tarea = Convert.ToInt32(reader["id_tarea"]);
                            tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                            tarea.Nombre = reader["nombre"].ToString();
                            tarea.Descripcion = reader["descripcion"].ToString();
                            tarea.Color = reader["color"].ToString();
                            tarea.Id_usuario_asignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                            //CAMBIAR POR LA FORMA MAS SIMPLE
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
                    connection.Close(); 
                }
                return tareas;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL OBTENER LAS TAREAS DEL TABLERO DE USUARIO LA TAREA en la bd");
            }
        }
}
