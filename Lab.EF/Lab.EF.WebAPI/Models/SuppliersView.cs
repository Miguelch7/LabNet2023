using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models
{
    public class SuppliersView
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El nombre de la compañia es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de la compañia debe contener al menos 3 caracteres")]
        public string companyName { get; set; }

        [Required(ErrorMessage = "El nombre del contacto es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del contacto debe contener al menos 3 caracteres")]
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}