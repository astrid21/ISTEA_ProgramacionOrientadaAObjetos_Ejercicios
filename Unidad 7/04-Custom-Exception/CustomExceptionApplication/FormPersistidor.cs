using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomExceptionApplication
{
    public partial class FormPersistidor : Form
    {
        public FormPersistidor()
        {
            InitializeComponent();
        }

        private Persistidor _Persistidor = new Persistidor();

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            CientificoArgentino cientifico = new CientificoArgentino(textBoxApellido.Text, textBoxNombre.Text);
            try
            {
                _Persistidor.Adicionar(cientifico);
            }
            catch (Persistidor.ApellidoCientificoRequeridoException)
            {
                MessageBox.Show("El apellido es de ingreso obligatorio");
            }
            catch (Persistidor.CientificoYaExisteException yaExisteException)
            {
                string mensaje = string.Format("El científico {0}, {1} ya existe.", 
                    yaExisteException.Cientifico.Apellido, yaExisteException.Cientifico.Nombre);
                MessageBox.Show(mensaje);
            }
            catch (Persistidor.PersistidorException)
            {
                MessageBox.Show("Se ha generado un error genérico del persistidor.");
            }
            catch (Exception exception)
            {
                string mensaje = string.Format("Se ha producido un error inesperado con la siguiente descripción: {0}", exception.Message);
                MessageBox.Show(mensaje, exception.Message);
            }
        }

        private void linkLabelListar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string lista = "";
            foreach (CientificoArgentino cientifico in _Persistidor.Cientificos)
            {
                lista += cientifico.Apellido + "," + cientifico.Nombre + "\r\n";
            }

            MessageBox.Show(lista);
        }       
    }
}
