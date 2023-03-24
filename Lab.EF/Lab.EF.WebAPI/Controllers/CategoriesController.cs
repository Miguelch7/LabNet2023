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
        public IHttpActionResult Post([FromBody] CategoriesView categoryView)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Categories category = new Categories()
                {
                    CategoryName = categoryView.CategoryName,
                    Description = categoryView.Description
                };

                _categoriesLogic.Add(category);

                categoryView.Id = category.CategoryID;

                return Ok(categoryView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] CategoriesView categoryView)
        {
            Categories category = _categoriesLogic.GetById(id);

            if (category == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                category.CategoryName = categoryView.CategoryName;
                category.Description = categoryView.Description;

                _categoriesLogic.Update(category);

                return Ok(categoryView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}