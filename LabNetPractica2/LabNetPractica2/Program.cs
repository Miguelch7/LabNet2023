﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string dividendoString, divisorString;

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

            Console.WriteLine("\nPresione una tecla para continuar al siguiente punto.");
            Console.ReadKey();


            Console.WriteLine("\n========== Punto 2) ==========");

            Console.Write("Ingrese el dividendo: ");
            dividendoString = Console.ReadLine();

            Console.Write("Ingrese el divisor: ");
            divisorString = Console.ReadLine();

            try
            {
                Console.WriteLine($"El resultado de la división es: { Dividir(dividendoString, divisorString) }");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPresione una tecla para continuar al siguiente punto.");
            Console.ReadKey();

            Console.WriteLine("\n===== Punto 3) =====");

            try
            {
                Logic.Method();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"El tipo de excepción es: {ex.GetType()}");
            }

            Console.WriteLine("\nPresione una tecla para continuar al siguiente punto.");
            Console.ReadKey();

            Console.WriteLine("\n===== Punto 3) =====");

            try
            {
                Logic.CustomMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"El tipo de excepción es: {ex.GetType()}");
            }

            Console.Write("\nFin del programa. Presione una tecla para salir...");
            Console.ReadKey();
        }

        public static int DividirPorCero()
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

        public static int Dividir(string dividendoString, string divisorString)
        {
            int dividendo, divisor;

            if (!Int32.TryParse(dividendoString, out dividendo) || !Int32.TryParse(divisorString, out divisor))
            {
                throw new FormatException("Seguro ingresó una letra o no ingresó nada!");
            }

            if (divisor == 0) throw new DivideByZeroException("Sólo Chuck Norris divide por cero!");

            return dividendo / divisor;
        }
    }
}
