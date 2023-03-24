using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;

namespace Lab.EF.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SuppliersLogic _suppliersLogic;

        public SuppliersController()
        {
            _suppliersLogic = new SuppliersLogic();
        }

        // GET: Suppliers
        public ActionResult Index()
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

            return View(suppliers);
        }

        public ActionResult Add()
        {
            ViewData["Action"] = "Add";
            ViewData["BtnText"] = "Crear proveedor";

            return View("FormSupplier", new SuppliersView());
        }

        [HttpPost]
        public ActionResult Add(SuppliersView supplierView)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Action"] = "Add";
                ViewData["BtnText"] = "Crear proveedor";

                return View("FormSupplier", supplierView);
            }

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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { message = ex.Message });
            }
        }

        public ActionResult Update(int id)
        {
            Suppliers supplier = _suppliersLogic.GetById(id);

            if (supplier == null) return RedirectToAction("Error", new { message = $"El proveedor con el id {id} no existe." });

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

            ViewData["Action"] = "Update";
            ViewData["BtnText"] = "Actualizar proveedor";

            return View("FormSupplier", supplierView);
        }

        [HttpPost]
        public ActionResult Update(SuppliersView supplierView)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Action"] = "Update";
                ViewData["BtnText"] = "Actualizar proveedor";

                return View("FormSupplier", supplierView);
            }

            try
            {
                Suppliers supplier = new Suppliers()
                {
                    SupplierID = supplierView.Id,
                    CompanyName = supplierView.CompanyName,
                    ContactName = supplierView.ContactName,
                    ContactTitle = supplierView.ContactTitle,
                    Address = supplierView.Address,
                    City = supplierView.City,
                    Country = supplierView.Country
                };


                _suppliersLogic.Update(supplier);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { message = ex.Message });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _suppliersLogic.Delete(id);

                return RedirectToAction("Index");
            }
            catch (ArgumentNullException ex)
            {
                return RedirectToAction("Error", new { message = $"El proveedor con el id {id} no existe." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { message = ex.Message });
            }
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}