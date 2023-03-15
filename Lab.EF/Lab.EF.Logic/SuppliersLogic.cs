using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class SuppliersLogic : BaseLogic, IBaseLogic<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Suppliers GetById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public void Add(Suppliers supplier)
        {
            _context.Suppliers.Add(supplier);

            _context.SaveChanges();
        }

        public void Update(Suppliers supplier)
        {
            Suppliers supplierDB = _context.Suppliers.Find(supplier.SupplierID);

            supplierDB.CompanyName = supplier.CompanyName;
            supplierDB.City = supplier.City;
            supplierDB.Country = supplier.Country;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Suppliers supplier = _context.Suppliers.Find(id);

            _context.Suppliers.Remove(supplier);

            _context.SaveChanges();
        }
    }
}
