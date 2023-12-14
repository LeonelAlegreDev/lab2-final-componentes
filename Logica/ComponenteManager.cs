using Datos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class ComponenteManager
    {
        public static async Task<List<Componente>> GetAll()
        {
            DataAcces<Componente> dataAcces = new DataAcces<Componente>();
            string command = "SELECT * FROM componentes;";
            List<Componente> componentes = new List<Componente>();

            try
            {
                MySqlDataReader reader = await dataAcces.GetReader(command);
                while (await reader.ReadAsync())
                {
                    Componente componente = new Componente(reader.GetInt32("id"),
                                                   reader.GetString("nombre"),
                                                   reader.GetString("modelo"),
                                                   reader.GetString("especificaciones"),
                                                   reader.GetString("tipo_componente"),
                                                   reader.GetDecimal("precio"));

                    componentes.Add(componente);
                }
                return componentes;
            }
            catch
            {
                throw;
            }
        }
        public static async Task<Componente> GetById(int id)
        {
            DataAcces<Componente> dataAcces = new DataAcces<Componente>();
            string command = $"SELECT * FROM componentes WHERE id = {id};";

            try
            {
                MySqlDataReader reader = await dataAcces.GetReader(command);
                if (await reader.ReadAsync())
                {
                    Componente componente = new Componente(reader.GetInt32("id"),
                                                   reader.GetString("nombre"),
                                                   reader.GetString("modelo"),
                                                   reader.GetString("especificaciones"),
                                                   reader.GetString("tipo_componente"),
                                                   reader.GetDecimal("precio"));
                    return componente;
                }
                else throw new Exception($"No se encontro componente con ID {id}");
            }
            catch
            {
                throw;
            }
        }

    }
}