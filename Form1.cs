using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Biblioteca_Gestion2
{
    public partial class FrmUsuarios : Form
    {
        List<UsuarioBiblioteca> usuarios = new List<UsuarioBiblioteca>();
        List<MaterialBiblioteca> materiales = new List<MaterialBiblioteca>();

        public class UsuarioBiblioteca
        {
            public string Nombre { get; set; }
            public string Carnet { get; set; }

            public UsuarioBiblioteca(string nombre, string carnet)
            {
                Nombre = nombre;
                Carnet = carnet;
            }

            // Para mostrar correctamente en el ComboBox
            public override string ToString()
            {
                return $"{Nombre} ({Carnet})";
            }
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
           
            public UsuarioBiblioteca UsuarioPrestamo { get; private set; }
            public MaterialBiblioteca(string titulo, string autor, int anioPublicacion)
            {
                Titulo = titulo;
                Autor = autor;
                AnioPublicacion = anioPublicacion;
                Prestado = false;
                UsuarioPrestamo = null;
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

            // Para mostrar correctamente en el ComboBox
            public override string ToString()
            {
                return $"{Titulo} - {Autor} ({AnioPublicacion})";
            }
        }
        public FrmUsuarios()
        {
            InitializeComponent();
            InicializarColumnasUsuarios();
            InicializarColumnasPrestamos();
            CargarMaterialesIniciales(); //Simulación de inventario
            ActualizarMateriales();//Actualiza ComboBox y dataGridView*/
            ActualizarUsuarios(); //Si tienes usuarios precargados
            ActualizarPrestamos(); //Muestra estado inicial

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

        private void InicializarColumnasUsuarios()
        {
            DgvUsuarios.Columns.Clear();
            DgvUsuarios.Columns.Add("Nombre", "Nombre");
            DgvUsuarios.Columns.Add("Carnet", "Carnet");
            DgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InicializarColumnasPrestamos()
        {
            DgvPrestamos.Columns.Clear();
            DgvPrestamos.Columns.Add("Titulo", "Titulo");
            DgvPrestamos.Columns.Add("Autor", "Autor");
            DgvPrestamos.Columns.Add("Año", "Año");
            DgvPrestamos.Columns.Add("Estado", "Estado");
         //   DgvPrestamos.Columns..Add("Usuario", "Usuario con Prestamo");
            DgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void BtnPrestar_Click(object sender, EventArgs e)
        {

            if (cmbMaterial.SelectedItem is MaterialBiblioteca material &&
                CmbUsuario.SelectedItem is UsuarioBiblioteca usuario)
            {
                if (!material.Prestado)
                {
                    material.AsignarPrestamo(usuario);
                    ActualizarMateriales();
                    ActualizarPrestamos();
                    MessageBox.Show("Préstamo realizado con éxito");
                }
                else
                {
                    MessageBox.Show("El material ya está prestado");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un material y un usuario");
            }
        }

        private void ActualizarPrestamos()
        {
            // Actualizar el DataGridView de préstamos
            DgvPrestamos.Rows.Clear();

            foreach (var material in materiales)
            {
                DgvPrestamos.Rows.Add(
                    material.Titulo,
                    material.Autor,
                    material.AnioPublicacion,
                    material.Prestado ? "Prestado" : "Disponible",
                    material.Prestado ? material.UsuarioPrestamo.Nombre : "N/A"
                );
            }
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtNombreUsuario.Text) &&
                !string.IsNullOrEmpty(TxtCarnetUsuario.Text))
            {
                var usuario = new UsuarioBiblioteca(TxtNombreUsuario.Text, TxtCarnetUsuario.Text);
                usuarios.Add(usuario);
                ActualizarUsuarios();

                // Limpiar campos
                TxtNombreUsuario.Text = "";
                TxtCarnetUsuario.Text = "";
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedItem is MaterialBiblioteca material)
            {
                if (material.Prestado)
                {
                    material.DevolverPrestamo();
                    ActualizarMateriales();
                    ActualizarPrestamos();
                    MessageBox.Show("Devolución realizada con éxito");
                }
                else
                {
                    MessageBox.Show("Este material no está prestado");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un material");
            }
        }

        private void CargarMaterialesIniciales()
        {
            materiales.Add(new Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "978-3-16-148410-0", 417));
            materiales.Add(new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605, "978-1-56619-909-4", 863));
            materiales.Add(new Libro("1984", "George Orwell", 1949, "978-0-452-28423-4", 328));
            materiales.Add(new Libro("El Principito", "Antoine de Saint-Exupéry", 1943, "978-0-15-601219-5", 96));

        }

        private void ActualizarMateriales()
        {

            cmbMaterial.Items.Clear();
            foreach (var material in materiales)
            {
                // Mostrar solo materiales disponibles
                if (!material.Prestado)
                {
                    cmbMaterial.Items.Add(material);
                }
            }

        }

        private void ActualizarUsuarios()
        {
           DgvUsuarios.Rows.Clear();
            CmbUsuario.Items.Clear();
            foreach(var usuario in usuarios)
            {
                DgvUsuarios.Rows.Add(usuario.Nombre, usuario.Carnet);
                CmbUsuario.Items.Add(usuario);
            }
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
