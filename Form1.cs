using System;
using System.Windows.Forms;

namespace Biblioteca_Gestion2
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }

        public abstract class MaterialBiblioteca 
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int AnioPublicacion { get; set; }
            public bool Prestado { get; private set; }
            public UsuarioBiblioteca UsuarioPrestamo { get; private set;}

            public MaterialBiblioteca(string titulo, string autor, int anioPublicacion)
            {
                Titulo = titulo;
                Autor = autor;
                AnioPublicacion = anioPublicacion;
                Prestado = false;
                UsuarioPrestamo = false;
            }
        
            public void AsignarPrestamo(UsuarioBiblioteca usuario)
            {
                Prestado = true;
                UsuarioPrestamo = usuario;
            }
            public void DevolverPrestamo()
            {
                Prestado = false;
                UsuarioPrestamo = null;
            }

            public virtual string ObtenerDescripcion()
            {
                return $"{Titulo}-{Autor} {AnioPublicacion}.";
            }

            public string ObtenerEstadoPrestamo()
            {
                return Prestado ? $"Prestado a {UsuarioPrestamo.Nombre}" : "Disponible";
            }
        }
        
        public class Libro : MaterialBiblioteca
        {
            public string ISBN { get; set; }
            public int NumeroPaginas { get; set; }
            public Libro(string titulo, string autor, int anioPublicacion, string isbn, int numeroPaginas)
                : base(titulo, autor, anioPublicacion)
            {
                ISBN = isbn;
                NumeroPaginas = numeroPaginas;
            }
            public override string ObtenerDescripcion()
            {
                return $"{base.ObtenerDescripcion()} ISBN: {ISBN}, Páginas: {NumeroPaginas}.";
            }
        }
    }
}
