using Logica;

namespace Aplicacion
{
    public class Menu
    {
        public Usuario? User { get; private set; }
        public PCBuilder PcBuilder = new PCBuilder();
        public PC? Pc { get; private set; }

        public Menu()
        {
            User = null;
        }

        public void Mostrar()
        {
            if (User != null)
            {
                // Valida el tipo de usuario
                switch (User.TipoUsuario)
                {
                    case "cliente":
                        // Mostramos el menu para clientes
                        _MostrarMenuCliente();
                        break;
                    case "admin":
                        // Mostramos el menu para administradores
                        _MostrarMenuAdmin();
                        break;
                }
            }
            else{
                // Muestra el menu para Usuario no registrado
                _MostrarMenuDefault();
            }
        }
        private void _MostrarMenuCliente()
        {
            Console.Clear();
            Console.WriteLine("-------------- Menu Principal --------------");
            Console.WriteLine("Bienvenido " + User?.Nombre);
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Ver componentes");
            Console.WriteLine("2. Añadir componente al carrito");
            Console.WriteLine("3. Eliminar componente del carrito");
            Console.WriteLine("4. Armar PC");
            Console.WriteLine("5. Salir");
        }
        private void _MostrarMenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("-------------- Menu Principal --------------");
            Console.WriteLine("Bienvenido " + User?.Nombre);
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Listar clientes");
            Console.WriteLine("2. Listar componenetes");
            Console.WriteLine("3. Modificar componente");
            Console.WriteLine("4. Borrar componente");
            Console.WriteLine("5. Listar PCs");
            Console.WriteLine("6. Salir");
        }
        private void _MostrarMenuDefault()
        {
            Console.Clear();
            Console.WriteLine("-------------- Menu Principal --------------");
            Console.WriteLine("Bienvenido!");
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Registrarse");
            Console.WriteLine("2. Iniciar sesion");
            Console.WriteLine("3. Salir");
        }
        public string? LeerOpcion()
        {
            return Console.ReadLine();
        }
        public async Task<bool> ManejarOpcion(string? opcion)
        {
            bool result = false; // TRUE ES PARA SALIR FALSE ES PARA CONTINUAR
            if (User is null)
            {
                result = await _ManejarOpcionDefault(opcion);
            }
            else
            {
                switch (User.TipoUsuario)
                {
                    case "cliente":
                        result = await _ManejarOpcionCliente(opcion);
                        break;

                    case "admin":
                        result = _ManejarOpcionAdmin(opcion);
                        break;
                }
            }
            
            Console.WriteLine("Presione cualquier tecla para continuar ...");
            Console.ReadKey();
            return result;   // TRUE ES PARA SALIR FALSE ES PARA CONTINUAR
        }
        private async Task<bool> _ManejarOpcionDefault(string? opcion)
        {
            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("-------------- Registrarse --------------");
                    try
                    {
                        Console.WriteLine("Ingrese su nombre completo:");
                        string? nombre = LeerOpcion();
                        Console.WriteLine("Ingrese su email:");
                        string? email = LeerOpcion();
                        Console.WriteLine("Ingrese su contrasena:");
                        string? contrasena = LeerOpcion();

                        bool result = await Auth.Registrarse(nombre, email, contrasena, "cliente");

                        if (result) Console.WriteLine("Usuario registrado con exito.");
                        else Console.WriteLine("No se pudo registrar usuario.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al registrar usuario.");
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("-------------- Iniciar Sesion --------------");
                    try
                    {
                        Console.WriteLine("Ingrese su email:");
                        string? email = LeerOpcion();
                        Console.WriteLine("Ingrese su contrasena:");
                        string? contrasena = LeerOpcion();

                        User = await Auth.IniciarSesion(email, contrasena);
                        Console.WriteLine("Sesion inciada con exito.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al iniciar sesion.");
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Gracias por usar la aplicacion!");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Opcion ingresada no valida");
                    break;
            }
            return false;   // TRUE ES PARA SALIR FALSE ES PARA CONTINUAR
        }
        private async Task<bool> _ManejarOpcionCliente(string? opcion)
        {
            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("-------------- Lista de Componentes --------------");
                    try
                    {
                        List<Componente> componentes = await ComponenteManager.GetAll();

                        foreach (Componente componente in componentes)
                        {
                            Console.WriteLine(componente.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al listar componentes.");
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("-------------- Añadir Componente --------------");
                    Console.WriteLine("Ingresar ID del componente:");
                    string? id_componente = Console.ReadLine();
                    if (id_componente != null && int.TryParse(id_componente, out int id))
                    {
                        try
                        {
                            Componente componente = await ComponenteManager.GetById(id);

                            switch (componente.TipoComponente)
                            {
                                case TiposComponente.Almacenamiento:
                                    PcBuilder.SetAlmacenamiento(componente);
                                    break;

                                case TiposComponente.CPU:
                                    PcBuilder.SetCPU(componente);
                                    break;

                                case TiposComponente.Fuente:
                                    PcBuilder.SetFuente(componente);
                                    break;

                                case TiposComponente.Monitor:
                                    PcBuilder.SetMonitor(componente);
                                    break;

                                case TiposComponente.RAM:
                                    PcBuilder.SetRAM(componente);
                                    break;

                                case TiposComponente.Raton:
                                    PcBuilder.SetRaton(componente);
                                    break;

                                case TiposComponente.TarjetaRed:
                                    PcBuilder.SetTarjetaRed(componente);
                                    break;

                                case TiposComponente.TarjetaSonido:
                                    PcBuilder.SetTarjetaSonido(componente);
                                    break;

                                case TiposComponente.TarjetaGrafica:
                                    PcBuilder.SetTarjetaGrafica(componente);
                                    break;

                                case TiposComponente.Teclado:
                                    PcBuilder.SetTeclado(componente);
                                    break;

                                case TiposComponente.UnidadOptica:
                                    PcBuilder.SetUnidadOptica(componente);
                                    break;

                                default:
                                    Console.WriteLine("Tipo de componente no valido.");
                                    break;
                            }
                            Console.WriteLine("Componente agregado con exito.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al listar añadir componente.");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error. ID no valido");
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("-------------- Eliminar Componente --------------");
                    List<Componente> componentes_delete = PcBuilder.ListarComponentes();
                    if(componentes_delete.Count() > 0)
                    {
                        foreach (Componente componente in componentes_delete)
                        {
                            Console.WriteLine(componente.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se anadieron componentes.");
                        break;
                    }
                    Console.WriteLine("Ingresar ID del componente a remover:");
                    string? id_remove_componente = Console.ReadLine();
                    if (id_remove_componente != null && int.TryParse(id_remove_componente, out int id_remove_componente_parsed))
                    {
                        foreach (Componente componente in componentes_delete)
                        {
                            if(componente.Id == id_remove_componente_parsed)
                            {
                                try
                                {
                                    PcBuilder.RemoveComponente(componente);
                                    Console.WriteLine("Componente removido con exito.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error al remover componente.");
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error. ID no valido");
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("-------------- Armar PC --------------");
                    Pc = PcBuilder.GetPC();
                    Console.WriteLine("PC Armada con exito");
                    Console.WriteLine(Pc.ToString());
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Gracias por usar la aplicacion!");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Opcion ingresada no valida");
                    break;
            }
            return false;   // TRUE ES PARA SALIR FALSE ES PARA CONTINUAR
        }
        private bool _ManejarOpcionAdmin(string? opcion)
        {
            Console.WriteLine("1. Listar clientes");
            Console.WriteLine("2. Listar componenetes");
            Console.WriteLine("3. Modificar componente");
            Console.WriteLine("4. Borrar componente");
            Console.WriteLine("5. Listar PCs");
            Console.WriteLine("6. Salir");
            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("-------------- Lista de Clientes --------------");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("-------------- Lista de Componentes --------------");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("-------------- Modificar Componente --------------");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("-------------- Borrar Componente --------------");
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("-------------- Lista de PCs --------------");
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Gracias por usar la aplicacion!");
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Opcion ingresada no valida");
                    break;
            }
            return false;   // TRUE ES PARA SALIR FALSE ES PARA CONTINUAR
        }
    }
}
