using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploMVC.Models
{
    public class Persona
    {
        public int id { set; get; }
        [Required]
        public string nombre { set; get; }
        [Required]
        public string apellido { set; get; }
        [Required]
        public string telefono { set; get; }
        [Required]      
        public int edad { set; get; }

        public int IdSexo { set; get; }
    }
}