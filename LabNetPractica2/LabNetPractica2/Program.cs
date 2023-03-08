using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Punto 1) ==========");

            try
            {
                DividirPorCero();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("La operación finalizó");
            }
        }

        static int DividirPorCero()
        {
            Console.Write("Ingrese un valor: ");
            string valor = Console.ReadLine();
            int valorNum;

            while (!Int32.TryParse(valor, out valorNum))
            {
                Console.WriteLine("Debes ingresar un valor númerico!!!");
                Console.Write("Ingrese un valor: ");
                valor = Console.ReadLine();
            }

            return valorNum / 0;
        }        
    }
}
