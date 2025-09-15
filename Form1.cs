using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Biblioteca_Gestion2
{
    public partial class FrmUsuarios : Form
    {
        // Listas para almacenar usuarios y materiales
        List<UsuarioBiblioteca> usuarios = new List<UsuarioBiblioteca>();
        List<MaterialBiblioteca> materiales = new List<MaterialBiblioteca>();

        // Variable para llevar el control del usuario que se está editando
        private UsuarioBiblioteca usuarioEditando = null;

        // Clase UsuarioBiblioteca
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

        // Clase abstracta MaterialBiblioteca
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

        // Constructor
        public FrmUsuarios()
        {
            InitializeComponent();
            InicializarColumnasUsuarios();
            InicializarColumnasPrestamos();
            InicializarColumnasLibrosPrestados();
            CargarMaterialesIniciales();
            ActualizarMateriales();
            ActualizarUsuarios();
            ActualizarPrestamos();
            ActualizarComboUsuariosPrestados();

            // Suscribir al evento CellClick para la edición
            DgvUsuarios.CellClick += DgvUsuarios_CellClick;

            // Suscribir al evento SelectedIndexChanged del ComboBox
            BtnUsuarioPrestado.SelectedIndexChanged += BtnUsuarioPrestado_SelectedIndexChanged;
        }

        // Clase Libro que hereda de MaterialBiblioteca
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

        // Método para inicializar columnas de usuarios
        private void InicializarColumnasUsuarios()
        {
            DgvUsuarios.Columns.Clear();
            DgvUsuarios.Columns.Add("Nombre", "Nombre");
            DgvUsuarios.Columns.Add("Carnet", "Carnet");
            DgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Método para inicializar columnas de préstamos
        private void InicializarColumnasPrestamos()
        {
            DgvPrestamos.Columns.Clear();
            DgvPrestamos.Columns.Add("Titulo", "Título");
            DgvPrestamos.Columns.Add("Autor", "Autor");
            DgvPrestamos.Columns.Add("Año", "Año Publicación");
            DgvPrestamos.Columns.Add("Estado", "Estado");
            DgvPrestamos.Columns.Add("Usuario", "Usuario con Préstamo");
            DgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Método para inicializar columnas de libros prestados
        private void InicializarColumnasLibrosPrestados()
        {
            DgvLibrosPrestados.Columns.Clear();
            DgvLibrosPrestados.Columns.Add("Titulo", "Título");
            DgvLibrosPrestados.Columns.Add("Autor", "Autor");
            DgvLibrosPrestados.Columns.Add("Año", "Año Publicación");
            DgvLibrosPrestados.Columns.Add("Estado", "Estado");
            DgvLibrosPrestados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Evento para prestar materiales
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
                    // Actualizar la lista de libros prestados si el usuario seleccionado es el mismo
                    if (BtnUsuarioPrestado.SelectedItem == usuario)
                    {
                        MostrarLibrosPrestadosPorUsuario(usuario);
                    }
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

        // Método para actualizar la lista de préstamos
        private void ActualizarPrestamos()
        {
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

        // Evento para agregar o actualizar usuarios
        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNombreUsuario.Text) &&
                !string.IsNullOrEmpty(TxtCarnetUsuario.Text))
            {
                if (BtnAgregarUsuario.Text == "Agregar")
                {
                    // Modo agregar nuevo usuario
                    var usuario = new UsuarioBiblioteca(TxtNombreUsuario.Text, TxtCarnetUsuario.Text);
                    usuarios.Add(usuario);
                    MessageBox.Show("Usuario agregado correctamente");
                }
                else
                {
                    // Modo actualizar usuario existente
                    if (usuarioEditando != null)
                    {
                        usuarioEditando.Nombre = TxtNombreUsuario.Text;
                        usuarioEditando.Carnet = TxtCarnetUsuario.Text;
                        MessageBox.Show("Usuario actualizado correctamente");

                        // Restablecer el modo a "Agregar"
                        BtnAgregarUsuario.Text = "Agregar";
                        usuarioEditando = null;
                    }
                }

                ActualizarUsuarios();
                ActualizarComboUsuariosPrestados();

                // Limpiar campos
                TxtNombreUsuario.Text = "";
                TxtCarnetUsuario.Text = "";
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        // Evento para devolver materiales
        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            if (DgvPrestamos.SelectedRows.Count > 0)
            {
                int selectedIndex = DgvPrestamos.SelectedRows[0].Index;
                MaterialBiblioteca material = materiales[selectedIndex];

                if (material.Prestado)
                {
                    // Guardar el usuario que tenía el préstamo para actualizar la vista después
                    UsuarioBiblioteca usuarioConPrestamo = material.UsuarioPrestamo;

                    material.DevolverPrestamo();
                    ActualizarMateriales();
                    ActualizarPrestamos();

                    // Actualizar la lista de libros prestados si el usuario afectado está seleccionado
                    if (BtnUsuarioPrestado.SelectedItem == usuarioConPrestamo)
                    {
                        MostrarLibrosPrestadosPorUsuario(usuarioConPrestamo);
                    }

                    MessageBox.Show("Devolución realizada con éxito");
                }
                else
                {
                    MessageBox.Show("Este material no está prestado");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un material de la lista de préstamos");
            }
        }

        // Método para cargar materiales iniciales
        private void CargarMaterialesIniciales()
        {
            materiales.Add(new Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "978-3-16-148410-0", 417));
            materiales.Add(new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605, "978-1-56619-909-4", 863));
            materiales.Add(new Libro("1984", "George Orwell", 1949, "978-0-452-28423-4", 328));
            materiales.Add(new Libro("El Principito", "Antoine de Saint-Exupéry", 1943, "978-0-15-601219-5", 96));
        }

        // Método para actualizar la lista de materiales disponibles
        private void ActualizarMateriales()
        {
            cmbMaterial.Items.Clear();
            foreach (var material in materiales)
            {
                if (!material.Prestado)
                {
                    cmbMaterial.Items.Add(material);
                }
            }
        }

        // Método para actualizar la lista de usuarios
        private void ActualizarUsuarios()
        {
            DgvUsuarios.Rows.Clear();
            CmbUsuario.Items.Clear();

            foreach (var usuario in usuarios)
            {
                DgvUsuarios.Rows.Add(usuario.Nombre, usuario.Carnet);
                CmbUsuario.Items.Add(usuario);
            }
        }

        // Método para actualizar el ComboBox de usuarios prestados
        private void ActualizarComboUsuariosPrestados()
        {
            BtnUsuarioPrestado.Items.Clear();
            foreach (var usuario in usuarios)
            {
                BtnUsuarioPrestado.Items.Add(usuario);
            }
        }

        // Evento para seleccionar un usuario para editar
        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que no se hizo clic en el encabezado
            {
                // Obtener el usuario seleccionado
                usuarioEditando = usuarios[e.RowIndex];

                // Llenar los TextBox con los datos del usuario
                TxtNombreUsuario.Text = usuarioEditando.Nombre;
                TxtCarnetUsuario.Text = usuarioEditando.Carnet;

                // Cambiar el texto del botón a "Actualizar"
                BtnAgregarUsuario.Text = "Actualizar";
            }
        }

        // Evento para eliminar usuarios
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvUsuarios.SelectedRows.Count > 0)
            {
                int rowIndex = DgvUsuarios.CurrentRow.Index;
                UsuarioBiblioteca usuarioAEliminar = usuarios[rowIndex];

                // Verificar si el usuario tiene materiales prestados
                bool tienePrestamos = false;
                foreach (var material in materiales)
                {
                    if (material.Prestado && material.UsuarioPrestamo == usuarioAEliminar)
                    {
                        tienePrestamos = true;
                        break;
                    }
                }

                if (tienePrestamos)
                {
                    MessageBox.Show("No se puede eliminar el usuario porque tiene materiales prestados.");
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar al usuario: {usuarioAEliminar.Nombre}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    usuarios.RemoveAt(rowIndex);
                    ActualizarUsuarios();
                    ActualizarComboUsuariosPrestados();

                    if (usuarioEditando == usuarioAEliminar)
                    {
                        usuarioEditando = null;
                        TxtNombreUsuario.Text = "";
                        TxtCarnetUsuario.Text = "";
                        BtnAgregarUsuario.Text = "Agregar";
                    }

                    MessageBox.Show("Usuario eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
            }
        }

        // Evento cuando se selecciona un usuario en el ComboBox de libros prestados
        private void BtnUsuarioPrestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BtnUsuarioPrestado.SelectedItem is UsuarioBiblioteca usuarioSeleccionado)
            {
                MostrarLibrosPrestadosPorUsuario(usuarioSeleccionado);
            }
        }

        // Método para mostrar los libros prestados por un usuario específico
        private void MostrarLibrosPrestadosPorUsuario(UsuarioBiblioteca usuario)
        {
            DgvLibrosPrestados.Rows.Clear();

            foreach (var material in materiales)
            {
                if (material.Prestado && material.UsuarioPrestamo == usuario)
                {
                    DgvLibrosPrestados.Rows.Add(
                        material.Titulo,
                        material.Autor,
                        material.AnioPublicacion,
                        "Prestado"
                    );
                }
            }
        }

        // Eventos sin implementación
        private void FrmUsuarios_Load(object sender, EventArgs e) { }
        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void BtnEditar_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}
