using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class MenuProveedor : Menu, IABMMenu
    {
        private readonly SuppliersLogic _suppliersLogic;

        public MenuProveedor()
        {
            _suppliersLogic = new SuppliersLogic();
            opcionSalir = 6;
        }

        protected override void MostrarMenu()
        {
            Console.WriteLine("---------- Menú de opciones Proveedor ----------");
            Console.WriteLine("1) Listar todos los proveedores");
            Console.WriteLine("2) Mostrar proveedor por id");
            Console.WriteLine("3) Insertar proveedor");
            Console.WriteLine("4) Actualizar proveedor");
            Console.WriteLine("5) Eliminar proveedor");
            Console.WriteLine("6) Volver al menú principal");
        }

        protected override int SolicitarOpcion()
        {
            Console.Write("Elija una opción: ");
            int option = 0;

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            return option;
        }

        protected override void EjecutarAccion(int option)
        {
            switch (option)
            {
                case 1:
                    MostrarTodos();
                    break;
                case 2:
                    MostrarPorId();
                    break;
                case 3:
                    Insertar();
                    break;
                case 4:
                    Actualizar();
                    break;
                case 5:
                    Eliminar();
                    break;
                case 6:
                    Salir();
                    break;
                default:
                    Console.WriteLine("Elija una opción válida.");
                    break;
            }
        }

        public void MostrarTodos()
        {
            List<Suppliers> listadoProveedores = _suppliersLogic.GetAll();

            Console.WriteLine("========== Listado de proveedores ==========\n");

            foreach (Suppliers s in listadoProveedores)
            {
                Console.WriteLine($"Proveedor: {s.SupplierID}) {s.CompanyName}");
                Console.WriteLine($"Ubicación: {s.City}, {s.Country}.\n");
            }

            Console.WriteLine("\n");
        }

        public void MostrarPorId()
        {
            Console.Write("Ingrese el id del proveedor: ");
            int id;

            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Suppliers supplier = _suppliersLogic.GetById(id);

            if (supplier == null)
            {
                Console.WriteLine($"\nNo se ha encontrado un proveedor con ese id.\n");
                return;
            }

            Console.WriteLine($"\nID: {supplier.SupplierID}");
            Console.WriteLine($"Nombre del proveedor: {supplier.CompanyName}");
            Console.WriteLine($"Ubicación: {supplier.City}, {supplier.Country}\n");
        }

        public void Insertar()
        {
            string companyName, city, country;

            Console.Write("Ingrese el nombre de la compañia del proveedor: ");
            companyName = Console.ReadLine();

            if (companyName.Length < 1)
            {
                Console.WriteLine("El nombre de la compañia no puede ir vacío.\n");
                return;
            }

            Console.Write("Ingrese la ciudad del proveedor: ");
            city = Console.ReadLine();

            Console.Write("Ingrese el país del proveedor: ");
            country = Console.ReadLine();

            Suppliers supplier = new Suppliers()
            {
                CompanyName = companyName,
                City = city,
                Country = country
            };

            try
            {
                _suppliersLogic.Add(supplier);
                Console.WriteLine("\nLa categoría se ha añadido correctamente.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Ha ocurrido un error.");
                Console.WriteLine(ex.Message);
            }
        }

        public void Actualizar()
        {
            int id = 0;
            string companyName, city, country;

            Console.Write("Ingrese el id del proveedor a actualizar: ");

            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return;
            }

            Console.Write("Ingrese el nombre de la compañia del proveedor: ");
            companyName = Console.ReadLine();

            if (companyName.Length < 1)
            {
                Console.WriteLine("El nombre de la compañia no puede ir vacío.\n");
                return;
            }

            Console.Write("Ingrese la ciudad del proveedor: ");
            city = Console.ReadLine();

            Console.Write("Ingrese el país del proveedor: ");
            country = Console.ReadLine();

            Suppliers supplier = new Suppliers()
            {
                SupplierID = id,
                CompanyName = companyName,
                City = city,
                Country = country
            };

            try
            {
                _suppliersLogic.Update(supplier);
                Console.WriteLine($"\nEl proveedor con id {id} se ha actualizado correctamente.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Ha ocurrido un error.");
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public void Eliminar()
        {
            Console.Write("Ingrese el id del proveedor a eliminar: ");
            int id;

            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                _suppliersLogic.Delete(id);
                Console.WriteLine($"El proveedor con el id {id} se ha eliminado correctamente.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n" + ex.Message + "\n");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"\nNo se ha encontrado un proveedor con ese id.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Ha ocurrido un error.");
                Console.WriteLine(ex.Message + "\n");
            }
        }
    }
}
