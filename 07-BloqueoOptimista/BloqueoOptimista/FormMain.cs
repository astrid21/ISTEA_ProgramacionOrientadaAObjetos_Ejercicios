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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LoadUIFromGrid(e.RowIndex);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Save();               
            }
            catch (Persistidor.BloqueoException)
            {
                string message = "La información no se ha persistido ya que fue modificada por otro usuario.";
                MessageBox.Show(message);
            }
            finally
            {
                this.ReLoadGrid();
            }
        }
        
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
            this.ReLoadGrid();
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
        /// Inicializa la ficha del producto.
        /// </summary>
        private void CleanUI()
        {
            textBoxId.Text = "";
            textBoxMarca.Text = "";
            textBoxPrecio.Text = "0";
            textBoxBloqueo.Text = "";
        }

        /// <summary>
        /// Borra un producto de la base de datos.
        /// </summary>
        private void Delete()
        {
            Producto producto = this.LoadFromUI();

            Persistidor persistidor = new Persistidor();
            persistidor.Delete(producto.Id.Value);
        }

        /// <summary>
        /// Carga un objeto del tipo producto desde la interfaz de usuario.
        /// </summary>
        /// <returns></returns>
        private Producto LoadFromUI()
        {
            Producto producto = new Producto();
            producto.Id = (textBoxId.Text == "") ? new Nullable<int>() : int.Parse(textBoxId.Text);
            producto.Marca = textBoxMarca.Text;
            producto.Precio = double.Parse(textBoxPrecio.Text);
            producto.Bloqueo = textBoxBloqueo.Text;

            return producto;
        }

        /// <summary>
        /// Carga la ficha de un producto, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadUIFromGrid(int rowIndex)
        {
            //Lee el valor del idProducto desde la grilla.
            int idProducto = (int)dataGridViewProductos.Rows[rowIndex].Cells["Id"].Value;
            Persistidor persistidor = new Persistidor();
            Producto producto = persistidor.GetByid(idProducto);
            
            textBoxId.Text = producto.Id.ToString();
            textBoxMarca.Text = producto.Marca;
            textBoxPrecio.Text = producto.Precio.ToString();
            textBoxBloqueo.Text = producto.Bloqueo;
        }

        /// <summary>
        /// Persiste (graba) un producto en la base de datos.
        /// </summary>
        private void Save()
        {
            Producto producto = this.LoadFromUI();

            Persistidor persistidor = new Persistidor();
            persistidor.Save(producto);
            textBoxId.Text = producto.Id.ToString();
            textBoxBloqueo.Text = producto.Bloqueo;
        }

        /// <summary>
        /// Refresca la lista de productos leyéndolos desde la base de datos.
        /// </summary>
        private void ReLoadGrid()
        {
            Persistidor persistidor = new Persistidor();
            dataGridViewProductos.DataSource = persistidor.GetAll();
        }
    }
}
