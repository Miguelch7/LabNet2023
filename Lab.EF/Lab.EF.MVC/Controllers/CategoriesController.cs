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

        public ActionResult Delete(int id)
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            categoriesLogic.Delete(id);

            return RedirectToAction("Index");
        }
    }
}