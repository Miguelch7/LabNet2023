using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WebAPI.Models;

namespace Lab.EF.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                id = c.CategoryID,
                categoryName = c.CategoryName,
                description = c.Description
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
                id = category.CategoryID,
                categoryName = category.CategoryName,
                description = category.Description
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
                    CategoryName = categoryView.categoryName,
                    Description = categoryView.description
                };

                _categoriesLogic.Add(category);

                categoryView.id = category.CategoryID;

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
                category.CategoryName = categoryView.categoryName;
                category.Description = categoryView.description;

                _categoriesLogic.Update(category);

                return Ok(categoryView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            Categories category = _categoriesLogic.GetById(id);

            if (category == null) return NotFound();

            try
            {
                _categoriesLogic.Delete(id);
                return Ok($"La categoría con id {id} se ha eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}