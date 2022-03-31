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
    public partial class ConsultaEnPrestamoForm : Form, IActualizable
    {
        public ConsultaEnPrestamoForm()
        {
            InitializeComponent();
        }

        private void EnPrestamoForm_Load(object sender, EventArgs e)
        {
            this.ActualizarConsulta();
        }

        private void buttonRefrescar_Click(object sender, EventArgs e)
        {
            this.ActualizarConsulta();
        }

        /// <summary>
        /// Actualiza el listado de libros en préstamo.
        /// </summary>
        public void ActualizarConsulta()
        {
            LibroPersistidor libroPersistidor = new LibroPersistidor();
            DataTable liblosEnPrestamo = libroPersistidor.GetEnPrestamo();
            dataGridViewEnPrestamo.DataSource = liblosEnPrestamo;
            dataGridViewEnPrestamo.Columns["id_libro"].Visible = false; //Se oculta la clave primaria del registro.
        }
    }
}
