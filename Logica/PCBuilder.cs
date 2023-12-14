using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PCBuilder : Builder
    {
        private PC _pc = new PC();

        public PCBuilder()
        {
            Reset();
        }
        
        public PC GetPC()
        {
            _pc.Total = _pc.CalcularTotal();
            PC pc = _pc;
            Reset();

            return pc;
        }

        public void Reset()
        {
            _pc = new PC();
        }

        public void SetAlmacenamiento(Componente almacenamiento)
        {
            if (almacenamiento.TipoComponente == TiposComponente.Almacenamiento)
            {
                _pc.Almacenamiento = almacenamiento;
            }
            else throw new Exception("Componente de almacenamiento no valido");
        }

        public void SetCPU(Componente cpu)
        {
            if (cpu.TipoComponente == TiposComponente.CPU)
            {
                _pc.CPU = cpu;
            }
            else throw new Exception("Componente de CPU no valido");
        }

        public void SetFuente(Componente fuente)
        {
            if (fuente.TipoComponente == TiposComponente.Fuente)
            {
                _pc.Fuente = fuente;
            }
            else throw new Exception("Componente de fuente no valido");
        }

        public void SetMonitor(Componente monitor)
        {
            if (monitor.TipoComponente == TiposComponente.Monitor)
            {
                _pc.Monitor = monitor;
            }
            else throw new Exception("Componente de monitor no valido");
        }

        public void SetRAM(Componente ram)
        {
            if (ram.TipoComponente == TiposComponente.RAM)
            {
                _pc.RAM = ram;
            }
            else throw new Exception("Componente de RAM no valido");
        }

        public void SetRaton(Componente raton)
        {
            if (raton.TipoComponente == TiposComponente.Raton)
            {
                _pc.Raton = raton;
            }
            else throw new Exception("Componente de raton no valido");
        }

        public void SetTarjetaGrafica(Componente tarjetaGrafica)
        {
            if (tarjetaGrafica.TipoComponente == TiposComponente.TarjetaGrafica)
            {
                _pc.TarjetaGrafica = tarjetaGrafica;
            }
            else throw new Exception("Componente de tarjeta grafica no valido");
        }

        public void SetTarjetaRed(Componente tarjetaRed)
        {
            if (tarjetaRed.TipoComponente == TiposComponente.TarjetaRed)
            {
                _pc.TarjetaGrafica = tarjetaRed;
            }
            else throw new Exception("Componente de tarjeta de red no valido");
        }

        public void SetTarjetaSonido(Componente tarjetaSonido)
        {
            if (tarjetaSonido.TipoComponente == TiposComponente.TarjetaSonido)
            {
                _pc.TarjetaSonido = tarjetaSonido;
            }
            else throw new Exception("Componente de tarjeta sonido no valido");
        }

        public void SetTeclado(Componente teclado)
        {
            if (teclado.TipoComponente == TiposComponente.Teclado)
            {
                _pc.Teclado = teclado;
            }
            else throw new Exception("Componente de teclado no valido");
        }

        public void SetUnidadOptica(Componente unidadOptica)
        {
            if (unidadOptica.TipoComponente == TiposComponente.UnidadOptica)
            {
                _pc.UnidadOptica = unidadOptica;
            }
            else throw new Exception("Componente de unidad optica no valido");
        }

        public void RemoveAlmacenamiento()
        {
            _pc.Almacenamiento = null;
        }
        public void RemoveCPU()
        {
            _pc.CPU = null;
        }
        public void RemoveFuente()
        {
            _pc.Fuente = null;
        }
        public void RemoveMonitor()
        {
            _pc.Monitor = null;
        }
        public void RemoveRAM()
        {
            _pc.RAM = null;
        }
        public void RemoveRaton()
        {
            _pc.Raton = null;
        }
        public void RemoveTarjetaGrafica()
        {
            _pc.TarjetaGrafica = null;
        }
        public void RemoveTarjetaRed()
        {
            _pc.TarjetaRed = null;
        }
        public void RemoveTarjetaSonido()
        {
            _pc.TarjetaSonido = null;
        }
        public void RemoveTeclado()
        {
            _pc.Teclado = null;
        }
        public void RemoveUnidadOptica()
        {
            _pc.UnidadOptica = null;
        }
        public void RemoveComponente(Componente componente)
        {
            switch (componente.TipoComponente)
            {
                case TiposComponente.Almacenamiento:
                    _pc.Almacenamiento = null;
                    break;

                case TiposComponente.CPU:
                    _pc.CPU = null;
                    break;

                case TiposComponente.Fuente:
                    _pc.Fuente = null;
                    break;

                case TiposComponente.Monitor:
                    _pc.Monitor = null;
                    break;

                case TiposComponente.RAM:
                    _pc.RAM = null;
                    break;

                case TiposComponente.Raton:
                    _pc.Raton = null;
                    break;

                case TiposComponente.TarjetaRed:
                    _pc.TarjetaRed = null;
                    break;

                case TiposComponente.TarjetaSonido:
                    _pc.TarjetaSonido = null;
                    break;

                case TiposComponente.TarjetaGrafica:
                    _pc.TarjetaGrafica = null;
                    break;

                case TiposComponente.Teclado:
                    _pc.Teclado = null;
                    break;

                case TiposComponente.UnidadOptica:
                    _pc.UnidadOptica = null;
                    break;

                default:
                    throw new Exception("Tipo de componente no valido.");
            }
        }

        public List<Componente> ListarComponentes()
        {
            List<Componente> componentes = new List<Componente>();
            
            if (_pc.Almacenamiento != null) componentes.Add(_pc.Almacenamiento);
            if (_pc.CPU != null) componentes.Add(_pc.CPU);
            if (_pc.Fuente != null) componentes.Add(_pc.Fuente);
            if (_pc.Monitor != null) componentes.Add(_pc.Monitor);
            if (_pc.RAM != null) componentes.Add(_pc.RAM);
            if (_pc.Raton != null) componentes.Add(_pc.Raton);
            if (_pc.TarjetaGrafica != null) componentes.Add(_pc.TarjetaGrafica);
            if (_pc.TarjetaRed != null) componentes.Add(_pc.TarjetaRed);
            if (_pc.TarjetaSonido != null) componentes.Add(_pc.TarjetaSonido);
            if (_pc.Teclado != null) componentes.Add(_pc.Teclado);
            if (_pc.UnidadOptica != null) componentes.Add(_pc.UnidadOptica);

            return componentes;
        }
    }
}
