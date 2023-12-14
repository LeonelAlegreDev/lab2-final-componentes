using Aplicacion;
using Logica;

class Program
{
    static async Task Main()
    {
        // Crea una instancia del menu
        var menu = new Menu();

        // Determina cuando detener el programa
        bool salir = false;

        do
        {
            // Muestra el menu
            menu.Mostrar();

            // Lee la opcion por consola
            string? opcion = menu.LeerOpcion();

            // Maneja la opcion
            salir = await menu.ManejarOpcion(opcion);
            
        } while (salir == false);
    }
}