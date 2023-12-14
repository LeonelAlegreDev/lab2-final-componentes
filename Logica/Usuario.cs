using Datos;

namespace Logica
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public string Contrasena { get; set; }


        public Usuario(int id, string nombre, string email, string contrasena, string tipoUsuario)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            TipoUsuario = tipoUsuario;
            Contrasena = contrasena;
        }

        // Metodos auxiliares opcionales
        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Email: {Email}, TipoUsuario: {TipoUsuario}";
        }
    }
}