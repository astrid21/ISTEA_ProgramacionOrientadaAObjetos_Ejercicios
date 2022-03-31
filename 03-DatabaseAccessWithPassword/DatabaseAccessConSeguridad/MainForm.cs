using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;

namespace DatabaseAccessConSeguridad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonEjecutorPersistencia_Click(object sender, EventArgs e)
        {
            Libro libro = this.PersistirLibro();

            this.ValidarPersistencia(libro);
        }

        /// <summary>
        /// Persiste un libro en una base de datos con clave.
        /// </summary>
        /// <returns></returns>
        private Libro PersistirLibro()
        {
            Libro libro = new Libro();
            libro.Titulo = "La gran bonanza de las Antillas";
            libro.ISBN = "9788472236790";
            ///Genera un CodigoIdentificacionUnico en forma aleatoria.
            libro.CodigoIdentificacionUnico = Guid.NewGuid().ToString();
            libro.Lector = "";

            LibroPersistidor persistidor = new LibroPersistidor();
            persistidor.Save(libro);

            return libro;
        }

        private void ValidarPersistencia(Libro libro)
        {
            LibroPersistidor persistidor = new LibroPersistidor();
            Libro libroAux = persistidor.GetByid(libro.Id.Value);

            if (libro.CodigoIdentificacionUnico == libroAux.CodigoIdentificacionUnico)
            {
                string mensaje = string.Format("El libro con Id = {0} se ha persistido correctamente.", libro.Id);
                MessageBox.Show(mensaje);
                persistidor.Delete(libro.Id.Value);
            }
            else
            {
                throw new Exception("EL libro no se ha persistido en la base de datos.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.labelConnectionStringCodificado.Text = ConnectionString.ReadEncode();
            this.labelConnectionStringSinCodificar.Text = ConnectionString.ReadDecode();
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
