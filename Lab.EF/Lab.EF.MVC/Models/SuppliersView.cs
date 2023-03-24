using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models
{
    public class SuppliersView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la compañia es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de la compañia debe contener al menos 3 caracteres")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "El nombre del contacto es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del contacto debe contener al menos 3 caracteres")]
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}