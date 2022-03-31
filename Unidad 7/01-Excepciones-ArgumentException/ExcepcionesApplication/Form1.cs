using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcepcionesApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEjecutarPruebas_Click(object sender, EventArgs e)
        {
            EjecutarPruebaA();
            EjecutarPruebaB();
            EjecutarPruebaC();
            EjecutarPruebaD();
        }

        private void EjecutarPruebaA()
        {
            int resultado = Divisor.DividirPorDos(6);
            if (resultado == 3)
                labelPruebaA.ForeColor = Color.Green;
            else
                labelPruebaA.ForeColor = Color.Red;
        }

        private void EjecutarPruebaB()
        {
            try
            {
                int resultado = Divisor.DividirPorDos(15);
                labelPruebaB.ForeColor = Color.Red;
            }
            catch (ArgumentException)
            {
                labelPruebaB.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                labelPruebaB.ForeColor = Color.Red;
            }
        }

        private void EjecutarPruebaC()
        {
            try
            {
                int resultado = Divisor.DividirPorDos(15);
                labelPruebaC.ForeColor = Color.Red;
            }
            catch (ArgumentException argumentException)
            {
                if (argumentException.Message.Contains("El número debe cumplir como precondición que sea par."))
                    labelPruebaC.ForeColor = Color.Green;
                else
                    labelPruebaC.ForeColor = Color.Red;
            }
        }

        private void EjecutarPruebaD()
        {
            try
            {
                int resultado = Divisor.DividirPorDos(15);
                labelPruebaD.ForeColor = Color.Red;
            }
            catch (ArgumentException argumentException)
            {
                if (argumentException.Message.Contains("numeroPar"))
                    labelPruebaD.ForeColor = Color.Green;
                else
                    labelPruebaD.ForeColor = Color.Red;
            }
        }
    }
}
