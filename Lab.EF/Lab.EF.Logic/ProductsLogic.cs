using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ProductsLogic : BaseLogic, IBaseLogic<Products>
    {
        public ProductsLogic() : base() { }
        public ProductsLogic(NorthwindContext context) : base(context) { }

        public List<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public Products GetById(int id)
        {
            return _context.Products.Find(id);
        }
        public void Add(Products product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();
        }

        public void Update(Products product)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            Products productDB = _context.Products.Find(id);

            _context.Products.Remove(productDB);

            _context.SaveChanges();
        }
    }
}
