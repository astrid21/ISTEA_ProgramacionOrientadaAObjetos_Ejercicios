using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApplicationArgumentNullException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ejecuta el conjunto de todas las pruebas.
        /// </summary>
        private void buttonEjecutarPruebas_Click(object sender, EventArgs e)
        {
            //Cada una de las pruebas lanzará una excepción en caso de ser fallidas.
            this.PruebaA();
            this.PruebaB();
            this.PruebaC();
            this.PruebaD();
            this.PruebaE();

            MessageBox.Show("Las pruebas fueron exitosas.");
        }

        /// <summary>
        /// Verifica que el conteo de los espacios sea correcto.
        /// </summary>
        private void PruebaA()
        {
            Documento documento = new Documento();
            documento.Texto = "Desde que me case ya no soy uno soy la mitad de dos.";

            Contador contador = new Contador();
            int cantEspacios = contador.ContarEspacios(documento);

            if (cantEspacios != 12) throw new Exception("La cantidad de espacios debería haber sido de 12.");
        }

        /// <summary>
        /// Verifica que se dispare la excepción ArgumentNullException, 
        /// al enviarse como parámetro un documento nulo.
        /// </summary>
        private void PruebaB()
        {            
            Documento documento = null;           
            Contador contador = new Contador();
            try
            {
                contador.ContarEspacios(documento);
                throw new Exception("Prueba fallida, se esperaba una excepción");
            }
            catch (ArgumentNullException)
            {
                //La prueba fue exitosa ya que el resultado esperado era una excepción
            }            
        }

        /// <summary>
        /// Se envía como parámetro un texto del documento nulo, 
        /// esperando que el método lance una excepción del tipo InvalidOperationException.
        /// </summary>
        private void PruebaC()
        {
            Documento documento = new Documento();
            documento.Texto = null;
            Contador contador = new Contador();
            try
            {
                contador.ContarEspacios(documento);
                throw new Exception("Prueba fallida, se esperaba una excepción");
            }
            catch (InvalidOperationException)
            {
                //La prueba fue exitosa ya que el resultado esperado era una excepción
            }
        }

        /// <summary>
        /// Verifica que el mensaje de la excepción sea el esperado.
        /// </summary>
        private void PruebaD()
        {
            Documento documento = new Documento();
            documento.Texto = null;
            Contador contador = new Contador();
            try
            {
                contador.ContarEspacios(documento);
                throw new Exception("Prueba fallida, se esperaba una excepción");
            }
            catch (InvalidOperationException exception)
            {
                //La prueba fue exitosa ya que el resultado esperado era una excepción
                if(exception.Message != "El texto del documento no existe")
                    throw new Exception("Prueba fallida, el mensaje esperado con coincide con el actual.");
            }
        }

        /// <summary>
        /// Verifica que la cantidad de espacios de un texto de 
        /// cero caracteres de largo sea cero.
        /// </summary>
        private void PruebaE()
        {
            Documento documento = new Documento();
            documento.Texto = "";

            Contador contador = new Contador();
            int cantEspacios = contador.ContarEspacios(documento);

            if (cantEspacios != 0) throw new Exception("La cantidad de espacios debería haber sido de 0 (cero).");
        }
    }
}
