using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
