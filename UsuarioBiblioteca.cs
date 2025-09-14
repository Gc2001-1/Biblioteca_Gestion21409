using System;

namespace Biblioteca_Gestion2
{
    public class UsuarioBiblioteca
    {
        public object Nombre { get; internal set; }

        public static implicit operator UsuarioBiblioteca(bool v)
        {
            throw new NotImplementedException();
        }
    }
}