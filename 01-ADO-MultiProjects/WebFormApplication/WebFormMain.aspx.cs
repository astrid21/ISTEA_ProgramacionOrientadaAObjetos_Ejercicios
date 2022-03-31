using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace WebFormApplication
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InicializacionGeneral();
            if (!IsPostBack)
            {
                this.InicializarFichaProducto();
                this.Listar();                
            }
        }

        /// <summary>
        /// Establece los valores iniciales del formulario.
        /// </summary>
        protected void InicializacionGeneral()
        {           
            LabelMensaje.Visible = false;
            LabelMensaje.Text = "";
        }

        /// <summary>
        /// Genera la lista de productos existentes en la base de datos.
        /// </summary>
        protected void Listar()
        {
            Persistidor persistidor = new Persistidor();
            List<Producto> productos = persistidor.GetAll();
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();        
        }

        /// <summary>
        /// Rutina de atención al evento OnRowCommand sobre la grilla.
        /// </summary>
        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            //Lectura del Id desde la fila seleccionada por el usuario en la grilla.
            string cellId = GridViewProductos.Rows[index].Cells[0].Text;
            //Id del producto seleccionado por el usuario.
            int idProducto = int.Parse(cellId);
            switch (e.CommandName)
            { 
                case "Editar":
                    this.EditarProducto(idProducto);    //Modifica un producto existente.
                    break;
                case "Eliminar":
                    this.EliminarProducto(idProducto);  //Borra un producto existente.
                    break;
                default:
                    throw new Exception("No esiste el comando" + e.CommandName);  //Error por comando inexistente.                  
            }
        }

        /// <summary>
        /// Borra un producto de la base de datos.
        /// </summary>
        /// <param name="idProducto">
        /// Id del producto a borrar.
        /// </param>
        protected void EliminarProducto(int idProducto)
        {
            Persistidor persistidor = new Persistidor();
            persistidor.Delete(idProducto);
            this.Listar();
        }

        /// <summary>
        /// Inicializa los campos de la ficha de un producto en la interfaz de usuario.
        /// </summary>
        protected void InicializarFichaProducto()
        {
            TextBoxId.Text = "";
            TextBoxMarca.Text = "";
            TextBoxPrecio.Text = "0";
        }

        /// <summary>
        /// Carga la ficha de un producto.
        /// </summary>
        /// <param name="idProducto">
        /// Identifica inequívocamente a un producto.
        /// </param>
        protected void EditarProducto(int idProducto)
        {
            Persistidor persistidor = new Persistidor();
            Producto producto = persistidor.GetByid(idProducto);
            
            TextBoxId.Text = producto.Id.ToString();
            TextBoxMarca.Text = producto.Marca;
            TextBoxPrecio.Text = producto.Precio.ToString();
        }

        /// <summary>
        /// Rutina de atención al evento OnClick para un alta de producto.
        /// </summary>
        protected void LinkButtonAltaProducto_Click(object sender, EventArgs e)
        {
            this.Alta();
        }

        /// <summary>
        /// Persiste un nuevo producto en la base de datos.
        /// </summary>
        protected void Alta()
        {
            this.InicializarFichaProducto();           
        }

        /// <summary>
        /// Carga un producto desde la interfaz de usuario (UI)
        /// </summary>
        /// <returns></returns>
        protected Producto GetProductoFromUi()
        {
            Producto producto = new Producto();
            if (TextBoxId.Text.Trim() != "")
            {
                producto.Id = int.Parse(TextBoxId.Text.Trim());
            }
            producto.Marca = TextBoxMarca.Text;
            producto.Precio = double.Parse(TextBoxPrecio.Text);
            return producto;
        }

        /// <summary>
        /// Persiste un producto en la base de datos, 
        /// realizando una inserción o una modificación según corresponda.
        /// </summary>
        protected void Save()
        {
            Persistidor persistidor = new Persistidor();
            Producto producto = this.GetProductoFromUi();
            bool exito = persistidor.Save(producto);
            TextBoxId.Text = producto.Id.ToString();
            if (!exito)
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = "El producto no se ha persistido exitosamente.";
            }
            this.Listar();        
        }

        /// <summary>
        /// Rutina de atención al evento OnClick que persiste un producto.
        /// </summary>        
        protected void LinkButtonGuardar_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// Rutina de atención al evento OnClick que recarga la grilla de productos.
        /// </summary>
        protected void LinkButtonRefrescarListado_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}