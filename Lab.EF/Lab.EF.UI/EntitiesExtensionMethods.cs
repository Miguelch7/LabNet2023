using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public static class EntitiesExtensionMethods
    {
        public static void print(this String text)
        {
            Console.WriteLine(text);
        }
        public static void print(this Customers customer)
        {
            if (customer == null)
            {
                Console.WriteLine("No existe el customer");
                return;
            }

            Console.WriteLine($"\nID: {customer.CustomerID}");
            Console.WriteLine($"Nombre de la compañia: {customer.CompanyName}");
            Console.WriteLine($"Contacto: {customer.ContactName}, {customer.ContactTitle}");
            Console.WriteLine($"Dirección: {customer.Address}");
            Console.WriteLine($"Ciudad: {customer.City}");
            Console.WriteLine($"Región: {customer.Region}");
            Console.WriteLine($"País: {customer.Country}\n");
        }

        public static void print(this Products product)
        {
            if (product == null)
            {
                Console.WriteLine("No existe el producto");
                return;
            }

            Console.WriteLine($"\nID: {product.ProductID}");
            Console.WriteLine($"Nombre del producto: {product.ProductName}");
            Console.WriteLine($"Categoria: {product.CategoryID}");
            Console.WriteLine($"Precio por unidad: ${product.UnitPrice}");
            Console.WriteLine($"Cantidad por Unidad: {product.QuantityPerUnit}");
            Console.WriteLine($"Stock: {product.UnitsInStock}");
        }

        public static void print(this CustomerOrdersDateDTO customerOrdersDateDTO)
        {
            Console.WriteLine($"\nCustomer: {customerOrdersDateDTO.CompanyName}");
            Console.WriteLine($"Region customer: {customerOrdersDateDTO.Region}");
            Console.WriteLine($"ID orden: {customerOrdersDateDTO.OrderID}");
            Console.WriteLine($"Fecha orden: {customerOrdersDateDTO.OrderDate}\n");
        }

        public static void print(this OrdersByCustomerDTO co)
        {
            Console.WriteLine($"Cantidad de ordenes de {co.Customer.CompanyName}: {co.ObtenerCantidadOrdenes()}");
        }

        public static void printAll(this IEnumerable<String> texts)
        {
            foreach (String text in texts) text.print();
        }

        public static void printAll(this IEnumerable<Customers> customers)
        {
            foreach (Customers customer in customers) customer.print();
        }

        public static void printAll(this IEnumerable<Products> products)
        {
            foreach (Products product in products) product.print();
        }

        public static void printAll(this IEnumerable<OrdersByCustomerDTO> ordersByCustomer)
        {
            foreach (OrdersByCustomerDTO co in ordersByCustomer) co.print();
        }

        public static void printAll(this IEnumerable<CustomerOrdersDateDTO> customerOrdersDate)
        {
            foreach (CustomerOrdersDateDTO co in customerOrdersDate) co.print();
        }
    }
}
