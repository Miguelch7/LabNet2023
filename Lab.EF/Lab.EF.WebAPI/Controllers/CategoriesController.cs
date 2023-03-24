using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WebAPI.Models;

namespace Lab.EF.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly CategoriesLogic _categoriesLogic;

        public CategoriesController()
        {
            _categoriesLogic = new CategoriesLogic();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<CategoriesView> categories = _categoriesLogic.GetAll().Select(c => new CategoriesView
            {
                Id = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return Ok(categories);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Categories category = _categoriesLogic.GetById(id);

            if (category == null) return NotFound();

            CategoriesView categoryView = new CategoriesView()
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            return Ok(categoryView);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}