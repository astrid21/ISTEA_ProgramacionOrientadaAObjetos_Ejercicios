using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppErrores
{
    class Program
    {
        static void Main(string[] args)
        {
            Total = 5; //Total de latas en stock

            try
            {                
                for(int i=0; i<10; i++)
                {
                    VenderLataDeTomates();
                }                
            }
            catch (SinLataDeTomatesException error)
            {
                //maneja o atrapa el error
                //Hacer un log 
                //Sacar de la pagina web la venta de latas
                //Enviar un mail al area de repocitorio

                Console.WriteLine("Sacar de la pagina web la venta de latas");
                Console.WriteLine(error.Message);
                Console.ReadLine();
            }
            catch (MemberAccessException)
            {
                //Agun codigo
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();                
            }
            finally
            {
                IntentoDeVenta++;
            }
        }

        private static void EnviarMail(SinLataDeTomatesException error)
        {
           
        }

        private static int IntentoDeVenta { set; get; }

        private static int Total { set; get; }

        public static void VenderLataDeTomates()
        {
            try
            {
                Total--;
                if (Total == 0)
                    throw new SinLataDeTomatesException("Quedan: " + Total.ToString());
            }
            catch(SinLataDeTomatesException error)
            {
                EnviarMail(error);
                throw; //Relanza el ultimo error
            }
        }

        public static int Sumar(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
