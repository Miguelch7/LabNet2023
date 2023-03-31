using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.WebAPI.Models
{
    public class CategoriesView
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de la categoría debe contener al menos 3 caracteres")]
        public string categoryName { get; set; }
        public string description { get; set; }
    }
}