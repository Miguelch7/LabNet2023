using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public abstract class Menu
    {
        protected int opcionSeleccionada;
        protected int opcionSalir = 0;

        public Menu() { }

        public void Iniciar()
        {
            while (opcionSeleccionada != opcionSalir)
            {
                MostrarMenu();
                opcionSeleccionada = SolicitarOpcion();
                EjecutarAccion(opcionSeleccionada);
            }
        }

        public void Salir()
        {
            Console.WriteLine("Hasta pronto!");
            this.opcionSeleccionada = opcionSalir;
        }

        protected virtual void MostrarMenu() { }
        protected virtual int SolicitarOpcion() { return 0; }
        protected virtual void EjecutarAccion(int option) { }
    }
}
