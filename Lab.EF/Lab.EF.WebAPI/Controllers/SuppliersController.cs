using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using Lab.EF.WebAPI.Models;

namespace Lab.EF.WebAPI.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly SuppliersLogic _suppliersLogic;

        public SuppliersController()
        {
            _suppliersLogic = new SuppliersLogic();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<SuppliersView> suppliers = _suppliersLogic.GetAll().Select(s => new SuppliersView
            {
                Id = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Address = s.Address,
                City = s.City,
                Country = s.Country
            }).ToList();

            return Ok(suppliers);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Suppliers supplier = _suppliersLogic.GetById(id);

            if (supplier == null) return NotFound();

            SuppliersView supplierView = new SuppliersView()
            {
                Id = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country
            };

            return Ok(supplierView);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] SuppliersView supplierView)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Suppliers supplier = new Suppliers()
                {
                    CompanyName = supplierView.CompanyName,
                    ContactName = supplierView.ContactName,
                    ContactTitle = supplierView.ContactTitle,
                    Address = supplierView.Address,
                    City = supplierView.City,
                    Country = supplierView.Country
                };

                _suppliersLogic.Add(supplier);

                supplierView.Id = supplier.SupplierID;

                return Ok(supplierView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] SuppliersView supplierView)
        {
            Suppliers supplier = _suppliersLogic.GetById(id);

            if (supplier == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                supplier.CompanyName = supplierView.CompanyName;
                supplier.ContactName = supplierView.ContactName;
                supplier.ContactTitle = supplierView.ContactTitle;
                supplier.Address = supplierView.Address;
                supplier.City = supplierView.City;
                supplier.Country = supplierView.Country;

                _suppliersLogic.Update(supplier);

                return Ok(supplierView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            Suppliers supplier = _suppliersLogic.GetById(id);

            if (supplier == null) return NotFound();

            try
            {
                _suppliersLogic.Delete(id);
                return Ok($"El proveedor con id {id} se ha eliminado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}