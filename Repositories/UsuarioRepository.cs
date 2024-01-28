using Encrypt.Net.Text;
using System.Data.SQLite;

namespace tl2_tp10_2023_NicoPed
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // private string cadenaConexion = @"Data Source = DB/kanban.sqlite;Initial Catalog=Northwind;" + "Integrated Security=true";
        private readonly string cadenaConexion;
        public UsuarioRepository(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        // = "Data Source=db/kanban.db;Cache=Shared";

        public void CreateUsuario(Usuario usuario)
        {
            try
            {
            var queryString = @"INSERT INTO usuario (nombre_de_usuario, contrasenia, rol)
            VALUES(@nombre,@contrasenia, @rol);"; //LA CONSULTA
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@nombre",usuario.Nombre_de_usuario));
                command.Parameters.Add(new SQLiteParameter("@contrasenia",Cifrado.sha256(usuario.Contrasenia).Hash));                
                command.Parameters.Add(new SQLiteParameter("@rol",usuario.RolDeUsuario));
                command.ExecuteNonQuery();
                connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                
            }
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL CREAR EL USUARIO en la bd");
            }
        }
        public List<Usuario> GetAllUsuarios()
        {
            try{
                var queryString = @"SELECT * FROM usuario;"; //LA CONSULTA
                
                List<Usuario> usuarios = new List<Usuario>(); //COMO ES GETALL NECESITO UNA LISTA

                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    SQLiteCommand command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    connection.Open();
                
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) //AQUI CAMBIA DEPENDIENDO DE LO QU NECESITE
                        {
                            var usuari = new Usuario();
                            usuari.Id_usuario = Convert.ToInt32(reader["id_usuario"]);
                            usuari.Nombre_de_usuario = reader["nombre_de_usuario"].ToString();
                            usuari.Contrasenia = reader["contrasenia"].ToString();
                            usuari.RolDeUsuario = (Rol) Convert.ToInt32(reader["rol"]);
                            usuarios.Add(usuari);
                        }
                    }
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                }
                if (usuarios == null)
                {
                    throw new Exception("ERROR AL LISTAR LOS USUARIOS en la bd");                
                }
                return usuarios;
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL LISTAR LOS USUARIOS en la bd");
            }
        }

        public Usuario GetUsuarioById(int idUsuario)
        {
            try{
                SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
                var usuario = new Usuario();
                SQLiteCommand command = connection.CreateCommand();
            
                command.CommandText = "SELECT * FROM usuario WHERE id_usuario = @idUsuario"; //el id = @idDirector permite la seguridad en las consultas
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));//y aqui "defino" esa variable para buscar
            
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //AQUI CAMBIA
                    {
                        usuario.Id_usuario = Convert.ToInt32(reader["id_usuario"]);
                        usuario.Nombre_de_usuario = reader["nombre_de_usuario"].ToString();
                        usuario.Contrasenia = reader["contrasenia"].ToString();
                        usuario.RolDeUsuario = (Rol) Convert.ToInt32(reader["rol"]);
                    }
                connection.Close();
                if (usuario == null)
                {
                  throw new Exception($"ERROR AL OBTRNER EL USUARIO de id{idUsuario} en la bd");                    
                }
                return usuario;
                }
            }
            catch (System.Exception)
            {
                
                throw new Exception($"ERROR AL OBTRNER EL USUARIO de id{idUsuario} en la bd");
            }
        }
        public void RemoveUsuario(int id)
        {
            try{
                var queryString = @"DELETE FROM usuario 
                WHERE id_usuario = @id ;";//LA CONSULTA
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
                
                throw new Exception($"ERROR AL REMOVER EL USUARIO de id{id}en la bd");
            }
        }

        public void Updateusuario(Usuario usuario)
        {
            try{
                var queryString = @"UPDATE usuario SET nombre_de_usuario = @nombre ,contrasenia = @contrasenia, rol = @rol 
                WHERE id_usuario = @id;"; //LA CONSULTA
                using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
                {
                    var command = new SQLiteCommand(queryString, connection); //Y ESTO ES IGUAL EN TODOS LADOS
                    connection.Open();
                    command.Parameters.Add(new SQLiteParameter("@nombre",usuario.Nombre_de_usuario));
                    command.Parameters.Add(new SQLiteParameter("@contrasenia",Cifrado.sha256(usuario.Contrasenia).Hash));                
                    command.Parameters.Add(new SQLiteParameter("@rol",usuario.RolDeUsuario));
                    command.Parameters.Add(new SQLiteParameter("@id",usuario.Id_usuario));
                    command.ExecuteNonQuery();
                    connection.Close(); //SIEMPRE CERRRAR!!!!!!!!!!!!!!!!!!!!!!
                    
                }
            }
            catch (System.Exception)
            {
                
                throw new Exception("ERROR AL ACTUALIZAR EL USUARIO en la bd");
            }
        }
    public Usuario GetUsuario(string nombre, string contrasenia)
    {
        try{
            Usuario usuario = new Usuario();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                string queryString = @"SELECT * FROM Usuario WHERE nombre_de_usuario = @nombreUsuario AND contrasenia = @contrasenia;";
                
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@nombreUsuario", nombre));
                // command.Parameters.Add(new SQLiteParameter("@contrasenia",contrasenia));
                command.Parameters.Add(new SQLiteParameter("@contrasenia",Cifrado.sha256(contrasenia).Hash));                
                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read()){
                        usuario.Id_usuario = Convert.ToInt32(reader["id_usuario"]);
                        usuario.Nombre_de_usuario = reader["nombre_de_usuario"].ToString();
                        usuario.Contrasenia = reader["contrasenia"].ToString();
                        usuario.RolDeUsuario = (Rol) Convert.ToInt32(reader["rol"]);
                    }
                }
                connection.Close();
            }
            if(usuario == null){
                throw new Exception($"ERROR AL OBTENER EL USUARIO de nombre{nombre} y contraseña {contrasenia} en la bd");
            }

            return usuario;
        }
        catch (System.Exception)
        {
            
            throw new Exception($"ERROR AL OBTENER EL USUARIO de nombre{nombre} y contraseña {contrasenia} en la bd");
        }
    }
    }

    // internal class SQLiteConnection
    // {
    //     private string cadenaConexion;

    //     public SQLiteConnection(string cadenaConexion)
    //     {
    //         this.cadenaConexion = cadenaConexion;
    //     }
    // }
}