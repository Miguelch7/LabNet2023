using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;
using Lab.EF.Logic;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            SuppliersLogic suppliersLogic = new SuppliersLogic();

            List<Categories> ListadoCategorias = categoriesLogic.GetAll();
            List<Suppliers> ListadoSuppliers = suppliersLogic.GetAll();

            Console.WriteLine("========== Listado de categorías ==========\n");

            foreach (Categories c in ListadoCategorias)
            {
                Console.WriteLine($"Categoría: {c.CategoryName}");
                Console.WriteLine($"Descripción: {c.Description}\n");
            }

            Console.ReadKey();

            Console.WriteLine("========== Listado de proveedores ==========\n");

            foreach (Suppliers s in ListadoSuppliers)
            {
                Console.WriteLine($"{s.CompanyName} - {s.City}, {s.Country}.");
            }

            Console.ReadKey();

        }
    }
}
