using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface Builder
    {
        void Reset();
        void SetAlmacenamiento(Componente almacenamiento);
        void SetCPU(Componente cpu);
        void SetFuente(Componente fuente);
        void SetMonitor(Componente monitor);
        void SetRAM(Componente ram);
        void SetRaton(Componente raton);
        void SetTarjetaRed(Componente tarjetaRed);
        void SetTarjetaSonido(Componente tarjetaSonido);
        void SetTarjetaGrafica(Componente tarjetaGrafica);
        void SetTeclado(Componente teclado);
        void SetUnidadOptica(Componente unidadOptica);
        PC GetPC();
    }
}
