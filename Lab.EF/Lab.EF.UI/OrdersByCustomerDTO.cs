using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class OrdersByCustomerDTO
    {
        public Customers Customer { get; set; }
        public IEnumerable<Orders> Orders { get; set; }

        public OrdersByCustomerDTO(Customers customer, IEnumerable<Orders> orders) 
        {
            Customer = customer;
            Orders = orders;
        }

        public int ObtenerCantidadOrdenes()
        {
            return Orders.Count();
        }
    }
}
