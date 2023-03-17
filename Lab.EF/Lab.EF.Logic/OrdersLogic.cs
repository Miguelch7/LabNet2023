using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Data;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class OrdersLogic : BaseLogic, IBaseLogic<Orders>
    {
        public OrdersLogic(): base() { }
        public OrdersLogic(NorthwindContext context): base(context) { }

        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Orders GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void Add(Orders order)
        {
            _context.Orders.Add(order);

            _context.SaveChanges();
        }

        public void Update(Orders entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            Orders orderDB = _context.Orders.Find(id);

            _context.Orders.Remove(orderDB);

            _context.SaveChanges();
        }
    }
}
