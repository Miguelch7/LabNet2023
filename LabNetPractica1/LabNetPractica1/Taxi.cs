using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica1
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
            this.Pasajeros = pasajeros;
        }

        public override string Avanzar()
        {
            return $"El taxi avanzó con { this.Pasajeros } pasajeros.";
        }

        public override string Detenerse()
        {
            return $"El taxi se detuvo con { this.Pasajeros } pasajeros.";
        }
    }
}
