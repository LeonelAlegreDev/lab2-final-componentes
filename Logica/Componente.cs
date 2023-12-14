using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public string Especificaciones { get; set; }
        public TiposComponente TipoComponente { get; set; }
        public decimal Precio { get; set; }

        public Componente(int id, string nombre, string modelo, string especificaciones, string tipoComponente, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Modelo = modelo;
            Especificaciones = especificaciones;
            TipoComponente = (TiposComponente)Enum.Parse(typeof(TiposComponente), tipoComponente);
            Precio = precio;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Modelo: {Modelo}, Especificaciones: {Especificaciones}, TipoComponente: {TipoComponente}, Precio: {Precio}\n";
        }
    }
}
