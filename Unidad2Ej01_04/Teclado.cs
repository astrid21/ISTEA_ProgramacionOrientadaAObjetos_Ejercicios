using System;
namespace Unidad2Ej01_04
{
    public class Teclado
    {
        public void Leer(out int valor)
        {
            valor = int.Parse(Console.ReadLine());
        }

        public void Leer(out float valor)
        {
            valor = float.Parse(Console.ReadLine());
        }

        public void Leer(out char valor)
        {
            valor = char.Parse(Console.ReadLine()) ;
        }

        public void Leer(out bool valor)
        {
            valor = bool.Parse(Console.ReadLine());
        }
    }
}
