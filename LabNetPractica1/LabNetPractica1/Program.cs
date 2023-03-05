using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> ListadoTransportesPublicos = new List<TransportePublico>();
            int CantidadTransportes = 10;
            string TipoDeTransporte = "Omnibus";
            

            for (int i = 0; i < CantidadTransportes; i++)
            {
                if (i == 5)
                {
                    TipoDeTransporte = "Taxi";
                }

                CargarTransportePublico(ListadoTransportesPublicos, TipoDeTransporte, i + 1);
            }

            Console.WriteLine($"\n\n===== Transportes Públicos: {ListadoTransportesPublicos.Count} =====");

            foreach (TransportePublico Transporte in ListadoTransportesPublicos)
            {
                Console.WriteLine(Transporte.Avanzar());
            }

            Console.ReadKey();
        }

        public static void CargarTransportePublico(List<TransportePublico> transportePublicos, string tipoTransporte, int numeroTransporte)
        {
            bool isValid = false;
            int cantidadPasajeros = -1;
            int min = 0;
            int max = (tipoTransporte == "Omnibus") ? 40 : 4;

            while (!isValid && (cantidadPasajeros < min || cantidadPasajeros > max))
            {
                try
                {
                    Console.WriteLine($"La capacidad del {tipoTransporte} es de entre {min} y {max} pasajeros");
                    Console.Write($"{numeroTransporte})Ingrese el número de pasajeros del {tipoTransporte}: ");

                    cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"\n¡FORMATO INCORRECTO!: Debes ingresar un número entre {min} y {max}");
                }

                if (cantidadPasajeros >= min && cantidadPasajeros <= max)
                {
                    isValid = true;
                    if (tipoTransporte == "Omnibus")
                    {
                        transportePublicos.Add(new Omnibus(cantidadPasajeros));
                    }
                    else
                    {
                        transportePublicos.Add(new Taxi(cantidadPasajeros));
                    }
                }
            }

            isValid = false;
        }
    }
}
