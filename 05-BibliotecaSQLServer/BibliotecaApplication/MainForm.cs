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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void lectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de lectores.
            AdminLectoresForm adminLectoresForm = new AdminLectoresForm();
            adminLectoresForm.MdiParent = this;
            adminLectoresForm.Show();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            AdminLibrosForm adminLibrosForm = new AdminLibrosForm();
            adminLibrosForm.MdiParent = this;
            adminLibrosForm.Show();
        }

        private void enPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            ConsultaEnPrestamoForm enPrestamoForm = new ConsultaEnPrestamoForm();
            enPrestamoForm.MdiParent = this;
            enPrestamoForm.Show();
        }

        private void prestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            ConsultaPrestamoAgrupadoForm form = new ConsultaPrestamoAgrupadoForm();
            form.MdiParent = this;
            form.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cerrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenform in this.MdiChildren)
            {                
                childrenform.Close();                
            }
        }

        private void lectoresSinPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra la consulta de los lectores que no poseen libros.
            ConsultaLectoresSinLibrosForm form = new ConsultaLectoresSinLibrosForm();
            form.MdiParent = this;
            form.Show();
        }

        private void actualizarConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Actualizar las consultas de cada formulario.
            foreach (Form form in this.MdiChildren)
            {
                IActualizable actualizable = form as IActualizable;
                if (actualizable != null)
                {
                    actualizable.ActualizarConsulta();                   
                }
            }
        }
    }
}
