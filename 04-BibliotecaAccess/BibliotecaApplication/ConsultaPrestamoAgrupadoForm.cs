using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormApplication
{
    public partial class ConsultaPrestamoAgrupadoForm : Form, IActualizable
    {
        public ConsultaPrestamoAgrupadoForm()
        {
            InitializeComponent();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            this.ActualizarConsulta();
        }
        
        private void PrestamoAgrupadoForm_Load(object sender, EventArgs e)
        {
            this.ActualizarConsulta();
        }

        /// <summary>
        /// Actualiza el listado de libros en préstamo.
        /// </summary>
        public void ActualizarConsulta()
        {
            LibroPersistidor libroPersistidor = new LibroPersistidor();
            DataTable liblosEnPrestamo = libroPersistidor.GetEnPrestamoAgrupado();
            dataGridViewAgrupado.DataSource = liblosEnPrestamo;
            dataGridViewAgrupado.Columns["id_lector"].Visible = false; //Se oculta la clave primaria del registro.
        }       
    }
}
