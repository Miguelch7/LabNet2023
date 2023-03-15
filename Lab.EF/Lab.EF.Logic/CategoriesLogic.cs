using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IBaseLogic<Categories>
    {
        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Categories category)
        {
            _context.Categories.Add(category);

            _context.SaveChanges();
        }

        public void Update(Categories category)
        {
            Categories categoryDB = _context.Categories.Find(category.CategoryID);

            categoryDB.CategoryName = category.CategoryName;
            categoryDB.Description = category.Description;
            categoryDB.Picture = category.Picture;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Categories categoryDB = _context.Categories.Find(id);
            
            _context.Categories.Remove(categoryDB);

            _context.SaveChanges();
        }
    }
}
