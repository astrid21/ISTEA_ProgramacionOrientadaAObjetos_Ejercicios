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
    public partial class AdminLectoresForm : Form
    {
        public AdminLectoresForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        /// <summary>
        /// Valor del campo Lector.id_lector que está siendo editado he identifica a un registro activo.
        /// </summary>
        private int? Id { set; get; }

        private void dataGridViewLectores_CellClick(object sender, DataGridViewCellEventArgs e)
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
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("No se puede eliminar el lector ya que posee libros en préstamo.");
            }
            catch (Exception)
            {
                throw;
            }
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
        /// Inicializa la ficha de un lector.
        /// </summary>
        private void CleanUI()
        {
            this.Id = null;
            textBoxDNI.Text = "";
            textBoxApellido.Text = "";          
        }

        /// <summary>
        /// Borra un lector de la base de datos.
        /// </summary>
        private void Delete()
        {
            Lector lector = this.LoadFromUI();

            LectorPersistidor libroPersistidor = new LectorPersistidor();
            libroPersistidor.Delete(lector.Id.Value);
        }

        /// <summary>
        /// Carga un objeto del tipo libro desde la interfaz de usuario.
        /// </summary>
        /// <returns></returns>
        private Lector LoadFromUI()
        {
            Lector letor = new Lector();
            letor.Id = this.Id;
            letor.DNI = int.Parse(textBoxDNI.Text);
            letor.Apellido = textBoxApellido.Text;            
            return letor;
        }

        /// <summary>
        /// Carga la ficha de un lector, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewLectores.Rows[rowIndex].Cells["Id"].Value;
            textBoxDNI.Text = dataGridViewLectores.Rows[rowIndex].Cells["DNI"].Value.ToString();
            textBoxApellido.Text = dataGridViewLectores.Rows[rowIndex].Cells["Apellido"].Value.ToString();            
        }

        /// <summary>
        /// Persiste (graba) un lector en la base de datos.
        /// </summary>
        private void Save()
        {
            Lector lector = this.LoadFromUI();

            LectorPersistidor libroPersistidor = new LectorPersistidor();
            libroPersistidor.Save(lector);           
        }

        /// <summary>
        /// Refresca la lista de lectores leyéndolos desde la base de datos.
        /// </summary>
        private void ReLoadGrid()
        {
            LectorPersistidor lectorPersistidor = new LectorPersistidor();
            dataGridViewLectores.DataSource = lectorPersistidor.GetAll();
            dataGridViewLectores.Columns["id"].Visible = false; //Se oculta la clave primaria del registro.
        }
    }
}
