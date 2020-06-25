using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABM_Persona.Models
{
    public class Persona
    {
        private int id;
        [Required]
        private string nombre;
        [Required]
        private string apellido;
        [Required]
        private string telefono;
        [Required]
        private int edad;

        private int idSexo;


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Edad { get => edad; set => edad = value; }
        public int IdSexo { get => idSexo; set => idSexo = value; }
    }
}