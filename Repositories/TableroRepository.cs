
using System.Data.SQLite;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed;

namespace tl2_tp10_2023_NicoPed
{
    public class TableroRepository : ITableroRepository
    {
        //LA CADENA DE CONEXION!!!!!!!!
        private readonly string cadenaConexion; 
        // = "Data Source=db/kanban.db;Cache=Shared";

        public TableroRepository(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public void CreateTablero(Tablero tablero)
        {
            try
            {            
                var queryString = @"INSERT INTO tablero (id_usuario_propietario, nombre, descripcion)
                VALUES(@id_usu, @nombre, @descripcion)";
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                { 
                    var command = new SQLiteCommand(queryString,connection);
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id_usu",tablero.Id_usuario_propietario));
                    command.Parameters.Add(new SQLiteParameter("@nombre",tablero.Nombre));
                    command.Parameters.Add(new SQLiteParameter("@descripcion",tablero.Descripcion));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL CREAR EL TABLERO");
            }
            
        }

        public List<Tablero> GetAllTableros()
        {
            try
            {
                var queryString = @"SELECT * FROM tablero;";

                var tableros = new List<Tablero>();
                
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    connection.Open();
                
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                        {
                            var tablero = new Tablero();
                            tablero.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                            tablero.Id_usuario_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                            tablero.Nombre = reader["nombre"].ToString();
                            tablero.Descripcion = reader["descripcion"].ToString();
                            tableros.Add(tablero);
                        }
                    }
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                }
                if (tableros == null)
                {
                    throw new Exception("ERROR AL OBTENER LOS TABLEROS");
                }
                return tableros;

            }
            catch (System.Exception)
            {
                throw new Exception("ERROR AL OBTENER LOS TABLEROS");
            }
        }

        public List<Tablero> GetAllUsersTableros(int id_usuario)
        {
            try
            {
                var queryString = @"SELECT * FROM tablero
                WHERE id_usuario_propietario = @id_usu;";

                var tableros = new List<Tablero>();
                
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id_usu",id_usuario));
                    
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                        {
                            var tablero = new Tablero();
                            tablero.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                            tablero.Id_usuario_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                            tablero.Nombre = reader["nombre"].ToString();
                            tablero.Descripcion = reader["descripcion"].ToString();
                            tableros.Add(tablero);
                        }
                    }
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                }
                if (tableros == null)
                {
                    throw new Exception($"ERROR AL OBTENER LOS TABLEROS DEL USUARIO DEL USUARIO {id_usuario}");
                }
                return tableros;
            }
            catch (System.Exception)
            {
                
                throw new Exception($"ERROR AL OBTENER LOS TABLEROS DEL USUARIO DEL USUARIO {id_usuario}");
            }
        }

        public Tablero GetTableroById(int id)
        {
            try
            {
                
                var queryString = @"SELECT * FROM tablero
                WHERE id_tablero = @id_tablero;";

                var tablero = new Tablero();
                
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id_tablero",id));
                    
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QUE NECESITE
                        {
                            tablero.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                            tablero.Id_usuario_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                            tablero.Nombre = reader["nombre"].ToString();
                            tablero.Descripcion = reader["descripcion"].ToString();
                        }
                    }
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                }
                if (tablero == null)
                {
                    throw new Exception($"ERROR AL OBTENER EL TABLERO DE ID {id}");
                }
                return tablero;
            }
            catch (System.Exception)
            {
                
                throw new Exception($"ERROR AL OBTENER EL TABLERO DE ID {id}");
            }
        }

        public void RemoveTablero(int id)
        {
            try
            {
                var queryString = @"DELETE FROM tablero 
                WHERE id_tablero = @id ;";//LA CONSULTA
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
                
                throw new Exception("ERROR AL ELIMINAR EL TABLERO en la BD");
            }
        }

        public void UpdateTablero(Tablero tablero)
        {
            try
            {
                var queryString = @"UPDATE tablero SET id_usuario_propietario = @id_usu
                ,nombre = @nombre, descripcion = @descripcion
                WHERE id_tablero = @id";
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    var command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@id_usu",tablero.Id_usuario_propietario));
                    command.Parameters.Add(new SQLiteParameter("@nombre",tablero.Nombre));
                    command.Parameters.Add(new SQLiteParameter("@descripcion",tablero.Descripcion));
                    command.Parameters.Add(new SQLiteParameter("@id",tablero.Id_tablero));
                    command.ExecuteNonQuery();
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                }
                
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL ACTUALIZAR EL TABLERO en la bd");
            }
        }
    }

}