using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica1
{
    public abstract class TransportePublico
    {
        public int Pasajeros { get; set; }

        public TransportePublico(int pasajeros) 
        {
            this.Pasajeros = pasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
