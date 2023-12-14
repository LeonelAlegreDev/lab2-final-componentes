using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataAcces<T>
    {
        private string _connectionString = "server=localhost;database=lab2;uid=root;pwd=secret_password;";

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>>GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<MySqlDataReader> GetReader(string sql_command)
        {
            // Conectarse a la base de datos
            MySqlConnection cnn = new MySqlConnection(_connectionString); ;
            await cnn.OpenAsync();
            MySqlCommand command = new MySqlCommand(sql_command, cnn);

            try
            {
                MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
                return reader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> PostNew(string sql_command)
        {
            MySqlConnection cnn = new MySqlConnection(_connectionString);
            await cnn.OpenAsync();
            MySqlCommand command = new MySqlCommand(sql_command, cnn);

            // Ejecutar la consulta
            try
            {
                //Ejecuta la consulta y devuelve el ultimo ID ingresado
                int lastId = Convert.ToInt32(await command.ExecuteScalarAsync());
                return lastId;
            }
            catch
            {
                // Lanzar el error
                throw new Exception("Fallo la ejecucion al cargar " + typeof(T).Name);
                //throw;
            }
            throw new NotImplementedException();
        }

        public bool UpdateById(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
