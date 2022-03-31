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
    public partial class Main : Form
    {
        public Main()
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
            this.Save();
            this.ReLoadGrid();
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

            return producto;
        }

        /// <summary>
        /// Carga la ficha de un producto, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadUIFromGrid(int rowIndex)
        {
            textBoxId.Text = dataGridViewProductos.Rows[rowIndex].Cells["Id"].Value.ToString();
            textBoxMarca.Text = dataGridViewProductos.Rows[rowIndex].Cells["Marca"].Value.ToString();
            textBoxPrecio.Text = dataGridViewProductos.Rows[rowIndex].Cells["Precio"].Value.ToString();
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
