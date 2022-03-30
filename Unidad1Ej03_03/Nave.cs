using System;
namespace Unidad1Ej03_03
{
    public class Nave
    {
        private int _CoordXAnt { set; get; }
        private int _CoordYAnt { set; get; }

        public int CoordX { set; get; }
        public int CoordY { set; get; }

        public Nave(int x, int y)
        {
            this.CoordX = x;
            this.CoordY = y;

            DibujarNave();

            this._CoordXAnt = x;
            this._CoordYAnt = y;

        }

        public void Mover()
        {
            BorrarNaveAnterior();

            this._CoordXAnt = this.CoordX;
            this._CoordYAnt = this.CoordY;

            DibujarNave();
        }
        public void BorrarNaveAnterior()
        {
            Console.CursorLeft = _CoordXAnt;
            Console.CursorTop = _CoordYAnt;
            Console.Write(" ");
        }

        public void DibujarNave()
        {
            Console.CursorLeft = CoordX;
            Console.CursorTop = CoordY;
            Console.Write("A");
        }

        public void Explosion(Nave nave)
        {
            nave.BorrarNaveAnterior();
            int x = nave.CoordX;
            int y = nave.CoordY;
            EscribirExplosion(x - 2, y - 2, "*");
            EscribirExplosion(x - 1, y - 1, "*");
            EscribirExplosion(x, y, "*");
            EscribirExplosion(x+3, y, "JUEGO TERMINADO, PRESIONE  CUALQUIER TECLA PARA SALIR");
            EscribirExplosion(x + 2, y + 2, "*");
            EscribirExplosion(x + 1, y + 1, "*");
            EscribirExplosion(x - 2, y + 2, "*");
            EscribirExplosion(x - 1, y + 1, "*");
            EscribirExplosion(x + 2, y - 2, "*");
            EscribirExplosion(x + 1, y - 1, "*");
            
        }

        public void EscribirExplosion(int x, int y, string texto)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(texto);
        }
    }
}
