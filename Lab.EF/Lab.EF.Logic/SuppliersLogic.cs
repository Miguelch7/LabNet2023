using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class SuppliersLogic : BaseLogic
    {
        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }
    }
}
