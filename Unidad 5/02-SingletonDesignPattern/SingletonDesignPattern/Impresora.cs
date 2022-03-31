using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonDesignPattern
{
    /// <summary>
    /// Implementa el patrón Singleton, ya que solo puede existir una impresora para toda la aplicación.
    /// </summary>
    public sealed class Impresora
    {
        private static Impresora _Instance;

        public static Impresora Instance
        {
            get 
            {
                if (_Instance == null) 
                    _Instance = new Impresora();
                return _Instance; 
            }
        }

        private Impresora() { } //Constructor privado

        public string Documento { get; set; }   //Documento a imprimir
        public void Imprimir() { Console.WriteLine(this.Documento); }   //Imprime un documento
    }
}
