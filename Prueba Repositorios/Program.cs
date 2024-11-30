using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Repositorios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Digite un numero");
            a= int.Parse(Console.ReadLine());
            if (a % 2 == 0)
            {
                Console.WriteLine("es par");
            }
            else
            {
                Console.WriteLine("no es par");
            }

        }
    }
}
