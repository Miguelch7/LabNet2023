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
        private readonly CustomersLogic _customersLogic;
        private readonly OrdersLogic _ordersLogic;
        private readonly ProductsLogic _productsLogic;
        private readonly SuppliersLogic _suppliersLogic;

        public MenuPrincipal()
        {
            _categoriesLogic = new CategoriesLogic();
            _customersLogic = new CustomersLogic();
            _ordersLogic = new OrdersLogic();
            _productsLogic = new ProductsLogic();
            _suppliersLogic = new SuppliersLogic();
            opcionSalir = 14;
        }

        protected override void MostrarMenu()
        {
            Console.WriteLine("---------- Menú de opciones ----------");
            Console.WriteLine("1) Devolver objeto Customer.");
            Console.WriteLine("2) Devolver todos los productos sin stock.");
            Console.WriteLine("3) Devolver todos los productos que tienen stock y que cuestan más de 3 por unidad.");
            Console.WriteLine("4) Devolver todos los customer de la Región WA.");
            Console.WriteLine("5) Devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789.");
            Console.WriteLine("6) Devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
            Console.WriteLine("7) Devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
            Console.WriteLine("8) Devolver los primeros 3 Customers de la Región WA.");
            Console.WriteLine("9) Devolver lista de productos ordenados por nombre.");
            Console.WriteLine("10) Devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine("11) Devolver las distintas categorías asociadas a los productos.");
            Console.WriteLine("12) Devolver el primer elemento de una lista de productos.");
            Console.WriteLine("13) Devolver los customers con la cantidad de ordenes asociadas.");
            Console.WriteLine("14) Salir");
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
            Console.Clear();

            switch (option)
            {
                case 1:
                    DevolverObjetoCustomer();
                    Console.WriteLine();
                    break;
                case 2:
                    ProductosSinStock();
                    Console.WriteLine();
                    break;
                case 3:
                    ProductosConStockYPrecioMayorA3();
                    Console.WriteLine();
                    break;
                case 4:
                    CustomersRegionWA();
                    Console.WriteLine();
                    break;
                case 5:
                    ProductoID789ONull();
                    Console.WriteLine();
                    break;
                case 6:
                    NombresCustomers();
                    Console.WriteLine();
                    break;
                case 7:
                    OrdenesDeCustomersRegionWA();
                    Console.WriteLine();
                    break;
                case 8:
                    Primeros3CustomersRegionWA();
                    Console.WriteLine();
                    break;
                case 9:
                    ProductosOrdenadosPorNombre();
                    Console.WriteLine();
                    break;
                case 10:
                    ProductosOrdenadosPorUnidadDescending();
                    Console.WriteLine();
                    break;
                case 11:
                    CategoriasAsociadasAProductos();
                    Console.WriteLine();
                    break;
                case 12:
                    PrimerProducto();
                    Console.WriteLine();
                    break;
                case 13:
                    CantidadOrdenesPorCustomers();
                    Console.WriteLine();
                    break;
                case 14:
                    Salir();
                    break;
                default:
                    Console.WriteLine("Elija una opción válida.");
                    break;
            }
        }

        protected void DevolverObjetoCustomer()
        {
            List<Customers> customersList = _customersLogic.GetAll();

            Console.WriteLine("\n1) Query para devolver objeto Customer.");

            var customer = customersList.FirstOrDefault();

            if (customer == null)
            {
                Console.WriteLine("\nNo se ha encontrado un customer.\n");
                return;
            }

            customer.print();
        }

        protected void ProductosSinStock()
        {
            List<Products> productsList = _productsLogic.GetAll();

            Console.WriteLine("\n2. Query para devolver todos los productos sin stock\n");

            var productosSinStock = from product in productsList
                                    where product.UnitsInStock == 0
                                    select product;

            productosSinStock.printAll();
        }

        protected void ProductosConStockYPrecioMayorA3()
        {
            List<Products> productsList = _productsLogic.GetAll();

            Console.WriteLine("\n3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad.\n");

            var productos = from product in productsList
                            where product.UnitsInStock != 0 && product.UnitPrice > 3
                            select product;

            productos.printAll();
        }

        protected void CustomersRegionWA()
        {
            List<Customers> customersList = _customersLogic.GetAll();

            Console.WriteLine("\n4. Query para devolver todos los customers de la Región WA.\n");

            var customers = customersList.Where(c => c.Region == "WA");
            customers.printAll();
        }

        protected void ProductoID789ONull()
        {
            List<Products> productsList = _productsLogic.GetAll();

            Console.WriteLine("\n5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789.\n");

            var producto = productsList.FirstOrDefault(p => p.ProductID == 789);
            producto.print();
        }

        protected void NombresCustomers()
        {
            List<Customers> customersList = _customersLogic.GetAll();

            Console.WriteLine("\n6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.\n");

            IEnumerable<String> nombresCustomers = customersList.Select(c => "Mayúscula: " + c.CompanyName.ToUpper() + " - Minúsculas: " + c.CompanyName.ToLower());

            nombresCustomers.printAll();
        }

        protected void OrdenesDeCustomersRegionWA()
        {
            List<Customers> customersList = _customersLogic.GetAll();
            List<Orders> ordersList = _ordersLogic.GetAll();

            Console.WriteLine("\n7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.\n");

            var customerOrders = from customer in customersList
                                join order in ordersList
                                on customer.CustomerID equals order.CustomerID
                                where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                select new CustomerOrdersDateDTO(customer.CompanyName, customer.Region, order.OrderID, order.OrderDate);

            customerOrders.printAll();
        }

        protected void Primeros3CustomersRegionWA()
        {
            List<Customers> customersList = _customersLogic.GetAll();

            Console.WriteLine("\n8. Query para devolver los primeros 3 Customers de la  Región WA.\n");

            var customers = customersList.Where(c => c.Region == "WA").Take(3);
            customers.printAll();
        }

        protected void ProductosOrdenadosPorNombre()
        {
            List<Products> productsList = _productsLogic.GetAll();

            Console.WriteLine("\n9. Query para devolver lista de productos ordenados por nombre\n");

            var productos = productsList.OrderBy(p => p.ProductName);
            productos.printAll();
        }

        protected void ProductosOrdenadosPorUnidadDescending()
        {
            List<Products> productsList = _productsLogic.GetAll();

            Console.WriteLine("\n10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.\n");

            var productos = productsList.OrderByDescending(p => p.UnitsInStock);
            productos.printAll();
        }

        protected void CategoriasAsociadasAProductos()
        {
            List<Categories> categoriesList = _categoriesLogic.GetAll();
            List<Products> productsList = _productsLogic.GetAll();


            Console.WriteLine("\n11.Query para devolver las distintas categorías asociadas a los productos.\n");

            IEnumerable<String> nombresCategorias = from category in categoriesList
                                                    join product in productsList
                                                    on category.CategoryID equals product.CategoryID
                                                    group category by category.CategoryName into g
                                                    select g.Key;

            nombresCategorias.printAll();
        }

        protected void PrimerProducto()
        {
            List<Products> productsList = _productsLogic.GetAll();

            Console.WriteLine("\n12.Query para devolver el primer elemento de una lista de productos\n");
            
            var producto = productsList.First();
            producto.print();
        }

        protected void CantidadOrdenesPorCustomers()
        {
            List<Customers> customersList = _customersLogic.GetAll();
            List<Orders> ordersList = _ordersLogic.GetAll();

            Console.WriteLine("\n13.Query para devolver los customer con la cantidad de ordenes asociadas.\n");

            IEnumerable<OrdersByCustomerDTO> ordersByCustomerDTO = from customer in customersList
                                                                   join order in ordersList
                                                                   on customer.CustomerID equals order.CustomerID into ordersByCustomer
                                                                   select new OrdersByCustomerDTO(customer, ordersByCustomer);

            ordersByCustomerDTO.printAll();
        }
    }
}
