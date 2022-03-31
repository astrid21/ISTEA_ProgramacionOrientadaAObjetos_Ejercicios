using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;

namespace WindowsFormApplication
{
    public partial class AdminLibrosForm : Form
    {
        public AdminLibrosForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
            this.InicializarComboLectores();
        }

        /// <summary>
        /// Valor del campo Libro.id_libro que está siendo editado he identifica a un registro activo.
        /// </summary>
        private int? Id { set; get; }

        private void InicializarComboLectores()
        {
            #region Se crea un lector inexistente, para el libro que no posee lector asignado.
            Lector lectorNulo = new Lector();
            lectorNulo.Apellido = "<Sin lector asignado>";
            lectorNulo.Id = null;
            comboBoxLectores.Items.Add(lectorNulo);
            comboBoxLectores.SelectedItem = comboBoxLectores.Items[0];
            #endregion

            LectorPersistidor lectorPersistidor = new LectorPersistidor();
            List<Lector> lectores = lectorPersistidor.GetAll();
            foreach (Lector lector in lectores)
            {
                comboBoxLectores.Items.Add(lector);
            }

            comboBoxLectores.DisplayMember = "Apellido";
            comboBoxLectores.ValueMember = "Id";            
        }

        private void dataGridViewLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LoadUIFromGrid(e.RowIndex);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {            
            this.Save();
            this.ReLoadGrid();
        }
        
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Delete();
                this.ReLoadGrid();
                this.CleanUI();
            }
            catch (LibroPersistidor.EliminarLibroPrestadoException exception)
            {
                this.MostrarMensaje(exception);
            }
        }

        /// <summary>
        /// Muestra un mensaje al usuario indicándole que el libro no puede ser eliminado.
        /// </summary>
        /// <param name="exception"></param>
        private void MostrarMensaje(LibroPersistidor.EliminarLibroPrestadoException exception)
        {
            LectorPersistidor lectorPersistidor = new LectorPersistidor();
            Lector lector = lectorPersistidor.GetByid(exception.Libro.IdLector.Value);
            string mensaje = "No puede eliminar el libro ya que ha sido prestado al lector: {0} DNI: {1}.";
            mensaje = string.Format(mensaje, lector.Apellido, lector.DNI);
            MessageBox.Show(mensaje);
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            CleanUI();
        }

        /// <summary>
        /// Inicializa la ficha del libro.
        /// </summary>
        private void CleanUI()
        {
            this.Id = null;
            textBoxCodigoIdentificacionUnico.Text = "";
            textBoxTitulo.Text = "";
            textBoxISBN.Text = "";

            //Sin lector asignado.
            comboBoxLectores.SelectedItem = comboBoxLectores.Items[0];
        }

        /// <summary>
        /// Borra un libro de la base de datos.
        /// </summary>
        private void Delete()
        {
            Libro libro = this.LoadFromUI();

            LibroPersistidor libroPersistidor = new LibroPersistidor();
            libroPersistidor.Delete(libro.Id.Value);
        }

        /// <summary>
        /// Carga un objeto del tipo libro desde la interfaz de usuario.
        /// </summary>
        /// <returns></returns>
        private Libro LoadFromUI()
        {
            Lector lector = (Lector)comboBoxLectores.SelectedItem;

            Libro libro = new Libro();
            libro.CodigoIdentificacionUnico = textBoxCodigoIdentificacionUnico.Text;
            libro.Id = this.Id;
            libro.Titulo = textBoxTitulo.Text;
            libro.ISBN = textBoxISBN.Text;
            libro.IdLector = lector.Id;
            return libro;
        }

        /// <summary>
        /// Carga la ficha de un libro, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewLibros.Rows[rowIndex].Cells["Id"].Value;
            LibroPersistidor persistidor = new LibroPersistidor();
            Libro libro = persistidor.GetByid(this.Id.Value);
            textBoxCodigoIdentificacionUnico.Text = libro.CodigoIdentificacionUnico;
            textBoxTitulo.Text = libro.Titulo;
            textBoxISBN.Text = libro.ISBN;
            this.SetLectorInComboBoxLectores(libro.IdLector);
        }

        private void SetLectorInComboBoxLectores(int? idLector)
        {
            foreach (object item in comboBoxLectores.Items)
            {
                Lector lector = (Lector)item;
                if (lector.Id == idLector)
                {
                    comboBoxLectores.SelectedItem = item;
                }
            }        
        }

        /// <summary>
        /// Persiste (graba) un libro en la base de datos.
        /// </summary>
        private void Save()
        {
            Libro libro = this.LoadFromUI();

            LibroPersistidor libroPersistidor = new LibroPersistidor();
            
            this.EstandarizaElTituloPorIsbn(libro);
            
            libroPersistidor.Save(libro);
            textBoxTitulo.Text = libro.Titulo;
        }

        /// <summary>
        /// Estandariza el titulo buscando por “isbn” para que todos 
        /// los libros con el mismo isbn posean el mismo título.
        /// </summary>
        /// <param name="libro"></param>
        private void EstandarizaElTituloPorIsbn(Libro libro)
        {
            bool esNuevo = !libro.Id.HasValue;
            if (esNuevo)
            {
                LibroPersistidor libroPersistidor = new LibroPersistidor();
                Libro libroExistente = libroPersistidor.GetByIsbn(libro.ISBN);
                if (libroExistente != null)
                    libro.Titulo = libroExistente.Titulo;
            }
        }

        /// <summary>
        /// Refresca la lista de libros leyéndolos desde la base de datos.
        /// </summary>
        private void ReLoadGrid()
        {
            LibroPersistidor libroPersistidor = new LibroPersistidor();
            dataGridViewLibros.DataSource = libroPersistidor.GetAll();
            dataGridViewLibros.Columns["id"].Visible = false; //Se oculta la clave primaria del registro.
            dataGridViewLibros.Columns["IdLector"].Visible = false;
        }
    }
}
