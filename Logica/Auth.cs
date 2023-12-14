using Datos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class Auth
    {
        public static async Task<bool> Registrarse(string? nombre, string? email, string? contrasena, string? tipo_usuario)
        {
            bool result = false;
            DataAcces<Usuario> dataAcces = new DataAcces<Usuario>();
            string command = $"INSERT INTO usuarios (nombre, email, contrasena, tipo_usuario) VALUES ('{nombre}', '{email}', '{contrasena}', '{tipo_usuario}'); SELECT LAST_INSERT_ID();";
            int id = await dataAcces.PostNew(command);

            if(id > 0) result = true;
            
            return result;
        }
        public static async Task<Usuario> IniciarSesion(string? email, string? contrasena)
        {
            DataAcces<Usuario> dataAcces = new DataAcces<Usuario>();
            string command = $"SELECT * FROM usuarios WHERE email = '{email}' AND contrasena = '{contrasena}';";

            MySqlDataReader reader = await dataAcces.GetReader(command);

            if (await reader.ReadAsync())
            {
                return new Usuario(reader.GetInt32("id"),
                                   reader.GetString("nombre"),
                                   reader.GetString("email"),
                                   reader.GetString("contrasena"),
                                   reader.GetString("tipo_usuario"));
            }
            else throw new Exception("Email o contrasena incorrecta");
        }
    }
}
