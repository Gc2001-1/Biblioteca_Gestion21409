using System;

namespace Biblioteca_Gestion2
{
    public class UsuarioBiblioteca
    {
        private string text1;
        private string text2;

        public UsuarioBiblioteca(string text1, string text2)
        {
            this.text1 = text1;
            this.text2 = text2;
        }

        public object Nombre { get; internal set; }
        public object Carnet { get; internal set; }
         



        // Solución para CS0161: Se debe devolver un valor en todas las rutas de acceso.
        // Solución para IDE0060: El parámetro 'v' no se usa, pero es necesario para la firma del operador implícito.
        public static implicit operator UsuarioBiblioteca(bool v)
        {
            // Retorna un nuevo objeto UsuarioBiblioteca con valores predeterminados.
            return new UsuarioBiblioteca(string.Empty, string.Empty);
        }
    }
}