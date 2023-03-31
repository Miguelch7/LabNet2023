using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using Lab.EF.WebAPI.Models;

namespace Lab.EF.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                id = s.SupplierID,
                companyName = s.CompanyName,
                contactName = s.ContactName,
                contactTitle = s.ContactTitle,
                address = s.Address,
                city = s.City,
                country = s.Country
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
                id = supplier.SupplierID,
                companyName = supplier.CompanyName,
                contactName = supplier.ContactName,
                contactTitle = supplier.ContactTitle,
                address = supplier.Address,
                city = supplier.City,
                country = supplier.Country
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
                    CompanyName = supplierView.companyName,
                    ContactName = supplierView.contactName,
                    ContactTitle = supplierView.contactTitle,
                    Address = supplierView.address,
                    City = supplierView.city,
                    Country = supplierView.country
                };

                _suppliersLogic.Add(supplier);

                supplierView.id = supplier.SupplierID;

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
                supplier.CompanyName = supplierView.companyName;
                supplier.ContactName = supplierView.contactName;
                supplier.ContactTitle = supplierView.contactTitle;
                supplier.Address = supplierView.address;
                supplier.City = supplierView.city;
                supplier.Country = supplierView.country;

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