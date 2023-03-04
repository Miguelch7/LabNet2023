using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica1
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros) 
        {
            this.Pasajeros = pasajeros;
        }

        public override string Avanzar()
        {
            return $"El omnibus avanzó con { this.Pasajeros } pasajeros.";
        }

        public override string Detenerse()
        {
            return $"El omnibus se detuvo con { this.Pasajeros } pasajeros.";
        }
    }
}
