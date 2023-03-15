using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public interface IABMMenu
    {
        void MostrarTodos();
        void MostrarPorId();
        void Insertar();
        void Actualizar();
        void Eliminar();
    }
}
