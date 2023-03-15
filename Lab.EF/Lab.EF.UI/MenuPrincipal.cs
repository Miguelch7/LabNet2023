using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;
using Lab.EF.Logic;

namespace Lab.EF.UI
{
    public class MenuPrincipal : Menu
    {
        private readonly CategoriesLogic _categoriesLogic;
        private readonly SuppliersLogic _suppliersLogic;
        
        public MenuPrincipal()
        {
            _categoriesLogic = new CategoriesLogic();
            _suppliersLogic = new SuppliersLogic();
            opcionSalir = 5;
        }

        protected override void MostrarMenu()
        {
            Console.WriteLine("---------- Menú de opciones ----------");
            Console.WriteLine("1) Listar Categorías");
            Console.WriteLine("2) Listar Proveedores");
            Console.WriteLine("3) Ver más opciones Categorías");
            Console.WriteLine("4) Ver más opciones Proveedores");
            Console.WriteLine("5) Salir");
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
                    ListarCategorias();
                    break;
                case 2:
                    ListarProveedores();
                    break;
                case 3:
                    IniciarMenuCategoria();
                    break;
                case 4:
                    IniciarMenuProveedor();
                    break;
                case 5:
                    Salir();
                    break;
                default:
                    Console.WriteLine("Elija una opción válida.");
                    break;
            }
        }

        protected void ListarCategorias()
        {
            List<Categories> listadoCategorias = _categoriesLogic.GetAll();

            Console.WriteLine("========== Listado de categorías ==========\n");

            foreach (Categories c in listadoCategorias)
            {
                Console.WriteLine($"Categoría: {c.CategoryName}");
                Console.WriteLine($"Descripción: {c.Description}\n");
            }

            Console.WriteLine("\n");
        }

        private void ListarProveedores()
        {
            List<Suppliers> listadoProveedores = _suppliersLogic.GetAll();

            Console.WriteLine("========== Listado de proveedores ==========\n");

            foreach (Suppliers s in listadoProveedores)
            {
                Console.WriteLine($"{s.CompanyName} - {s.City}, {s.Country}.");
            }

            Console.WriteLine("\n");
        }

        private void IniciarMenuCategoria()
        {
            MenuCategoria menuCategoria = new MenuCategoria();
            menuCategoria.Iniciar();
        }

        private void IniciarMenuProveedor()
        {
            MenuProveedor menuProveedor = new MenuProveedor();
            menuProveedor.Iniciar();
        }
    }
}
