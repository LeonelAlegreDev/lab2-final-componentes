using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logica
{
    public class PC
    {
        public Componente? Almacenamiento { get; set; }
        public Componente? CPU { get; set; }
        public Componente? Fuente { get; set; }
        public Componente? Monitor { get; set; }
        public Componente? RAM { get; set; }
        public Componente? Raton { get; set; }
        public Componente? TarjetaRed { get; set; }
        public Componente? TarjetaSonido { get; set; }
        public Componente? TarjetaGrafica { get; set; }
        public Componente? Teclado { get; set; }
        public Componente? UnidadOptica { get; set; }
        public decimal Total { get; set; }

        public PC()
        {
            Almacenamiento = null;
            CPU = null;
            Fuente = null;
            Monitor = null;
            RAM = null;
            Raton = null;
            TarjetaRed = null;
            TarjetaSonido = null;
            TarjetaGrafica = null;
            Teclado = null;
            UnidadOptica = null;
            Total = 0;
        }
        
        public decimal CalcularTotal()
        {
            decimal total = 0;

            total += Almacenamiento?.Precio ?? 0;
            total += CPU?.Precio ?? 0;
            total += Fuente?.Precio ?? 0;
            total += Monitor?.Precio ?? 0;
            total += RAM?.Precio ?? 0;
            total += Raton?.Precio ?? 0;
            total += TarjetaRed?.Precio ?? 0;
            total += TarjetaSonido?.Precio ?? 0;
            total += TarjetaGrafica?.Precio ?? 0;
            total += Teclado?.Precio ?? 0;
            total += UnidadOptica?.Precio ?? 0;

            return total;
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("PC: \n");

            if (Almacenamiento != null)
            {
                builder.Append("Almacenamiento: \n");
                builder.Append(Almacenamiento.ToString());
            }

            if (CPU != null)
            {
                builder.Append("CPU: \n");
                builder.Append(CPU.ToString());
            }

            if (Fuente != null)
            {
                builder.Append("Fuente: \n");
                builder.Append(Fuente.ToString());
            }

            if (Monitor != null)
            {
                builder.Append("Monitor: \n");
                builder.Append(Monitor.ToString());
            }

            if (RAM != null)
            {
                builder.Append("RAM: \n");
                builder.Append(RAM.ToString());
            }

            if (Raton != null)
            {
                builder.Append("Ratón: \n");
                builder.Append(Raton.ToString());
            }

            if (TarjetaRed != null)
            {
                builder.Append("Tarjeta de red: \n");
                builder.Append(TarjetaRed.ToString());
            }

            if (TarjetaSonido != null)
            {
                builder.Append("Tarjeta de sonido: \n");
                builder.Append(TarjetaSonido.ToString());
            }

            if (TarjetaGrafica != null)
            {
                builder.Append("Tarjeta gráfica: \n");
                builder.Append(TarjetaGrafica.ToString());
            }

            if (Teclado != null)
            {
                builder.Append("Teclado: \n");
                builder.Append(Teclado.ToString());
            }

            if (UnidadOptica != null)
            {
                builder.Append("Unidad óptica: \n");
                builder.Append(UnidadOptica.ToString());
            }

            builder.Append("Total: " + Total + "\n");

            return builder.ToString();
        }
    }
}
