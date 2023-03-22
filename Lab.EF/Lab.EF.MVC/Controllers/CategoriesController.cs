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
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            List<CategoriesView> categories = categoriesLogic.GetAll().Select(c => new CategoriesView {
                Id = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return View(categories);
        }

        public ActionResult Add()
        {
            ViewData["Action"] = "Add";
            ViewData["BtnText"] = "Crear categoría";

            return View("FormCategory", new CategoriesView() );
        }

        [HttpPost]
        public ActionResult Add(CategoriesView categoryView)
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            Categories category = new Categories()
            {
                CategoryName = categoryView.CategoryName, 
                Description = categoryView.Description
            };

            categoriesLogic.Add(category);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            Categories category = categoriesLogic.GetById(id);

            CategoriesView categoryView = new CategoriesView
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            ViewData["Action"] = "Update";
            ViewData["BtnText"] = "Guardar Cambios";

            return View("FormCategory", categoryView);
        }

        [HttpPost]
        public ActionResult Update(CategoriesView categoryView)
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            Categories category = new Categories()
            {
                CategoryID = categoryView.Id,
                CategoryName = categoryView.CategoryName,
                Description = categoryView.Description
            };

            categoriesLogic.Update(category);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            categoriesLogic.Delete(id);

            return RedirectToAction("Index");
        }
    }
}