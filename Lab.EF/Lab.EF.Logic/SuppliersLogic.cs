using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class SuppliersLogic
    {
        protected readonly NorthwindContext _context;

        public SuppliersLogic()
        {
            _context = new NorthwindContext();
        }

        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }
    }
}
