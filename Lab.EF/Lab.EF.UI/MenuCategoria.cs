﻿using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class MenuCategoria : Menu, IABMMenu
    {
        private readonly CategoriesLogic _categoriesLogic;

        public MenuCategoria()
        {
            _categoriesLogic = new CategoriesLogic();
            opcionSalir = 6;
        }

        protected override void MostrarMenu()
        {
            Console.WriteLine("---------- Menú de opciones Categoría ----------");
            Console.WriteLine("1) Listar todas las categorías");
            Console.WriteLine("2) Mostrar categoría por id");
            Console.WriteLine("3) Insertar categoría");
            Console.WriteLine("4) Actualizar categoría");
            Console.WriteLine("5) Eliminar categoría");
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
            List<Categories> listadoCategorias = _categoriesLogic.GetAll();

            Console.WriteLine("========== Listado de categorías ==========\n");

            foreach (Categories c in listadoCategorias)
            {
                Console.WriteLine($"Categoría: {c.CategoryID}) {c.CategoryName}");
                Console.WriteLine($"Descripción: {c.Description}\n");
            }

            Console.WriteLine("\n");
        }

        public void MostrarPorId()
        {
            Console.Write("Ingrese el id de la categoría: ");
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

            Categories category = _categoriesLogic.GetById(id);

            if (category == null)
            {
                Console.WriteLine($"\nNo se ha encontrado una categoría con ese id.\n");
                return;
            }

            Console.WriteLine($"\nID: { category.CategoryID }");
            Console.WriteLine($"Nombre de la categoría: { category.CategoryName }");
            Console.WriteLine($"Descripción: { category.Description }\n");
        }

        public void Insertar()
        {
            string categoryName, description;

            Console.Write("Ingrese el nombre de la categoría: ");
            categoryName = Console.ReadLine();

            if (categoryName.Length < 1)
            {
                Console.WriteLine("El nombre de la categoria no puede ir vacío.\n");
                return;
            }

            Console.Write("Ingrese la description de la categoría: ");
            description = Console.ReadLine();

            Categories category = new Categories()
            {
                CategoryName = categoryName,
                Description = description
            };

            try
            {
                _categoriesLogic.Add(category);
                Console.WriteLine("\nLa categoría se ha añadido correctamente.\n");
            }
            catch(Exception ex) 
            {
                Console.WriteLine("ERROR! Ha ocurrido un error.");
                Console.WriteLine(ex.Message);
            }
        }

        public void Actualizar()
        {
            int id = 0;
            string categoryName, description;
            Console.Write("Ingrese el id de la categoría a actualizar: ");

            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return;
            }

            Console.Write("Ingrese el nombre de la categoría: ");
            categoryName = Console.ReadLine();

            if (categoryName.Length < 1)
            {
                Console.WriteLine("El nombre de la categoria no puede ir vacío.");
                return;
            }

            Console.Write("Ingrese la description de la categoría: ");
            description = Console.ReadLine();

            Categories category = new Categories()
            {
                CategoryID = id,
                CategoryName = categoryName,
                Description = description
            };

            try
            {
                _categoriesLogic.Update(category);
                Console.WriteLine("\nLa categoria se ha actualizado correctamente.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Ha ocurrido un error.");
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public void Eliminar()
        {
            Console.Write("Ingrese el id de la categoría a eliminar: ");
            int id;

            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                _categoriesLogic.Delete(id);
                Console.WriteLine($"La categoria con el id { id } se ha eliminado correctamente.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n" + ex.Message + "\n");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"\nNo se ha encontrado una categoría con ese id.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Ha ocurrido un error.");
                Console.WriteLine(ex.Message + "\n");
            }
        }
    }
}
