using System;
namespace MostrarTablaDeMultiplicar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int Numero = 0;
                Console.WriteLine("Escribe un número");
                int Numero = Convert.ToInt32(Console.ReadLine());

            } while ((Numero > 0)) ;

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i, "*", Numero, "=", Numero * i);
            }

        }

        private static void MostrarTablaDeMultiplicar()
        {
            
            //Console.ReadKey();
        
        
            }
    }
}
