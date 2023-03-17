using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Data;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, IBaseLogic<Customers>
    {
        public CustomersLogic() : base() { }
        public CustomersLogic(NorthwindContext context) : base(context) { }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customers GetById(int id)
        {
            return _context.Customers.Find(id);
        }
        public void Add(Customers customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();
        }

        public void Update(Customers customer)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            Customers customerDB = _context.Customers.Find(id);

            _context.Customers.Remove(customerDB);

            _context.SaveChanges();
        }
    }
}
