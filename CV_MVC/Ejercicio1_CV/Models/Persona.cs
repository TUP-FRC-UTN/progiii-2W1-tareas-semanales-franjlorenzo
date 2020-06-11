using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Ejercicio1_CV.Models
{
    public class Persona
    {
        [Display(Name = "Jack")]
        public string nombre { get => nombre; set => nombre = value; }
        [Display(Name = "Daniels")]
        public string apellido { get => apellido; set => apellido = value; }
        [Display(Name = "Puesto: Programador Senior")]
        public string puesto { get => puesto; set => puesto = value; }
        [Display(Name = "35156005")]
        public long telefono { get => telefono; set => telefono = value; }
        [Display(Name = "SI")]
        public bool estadoCivil { get => estadoCivil; set => estadoCivil = value; }

        public Persona(string nombre, string apellido, string puesto, long telefono, bool estadoCivil)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.puesto = puesto;
            this.telefono = telefono;
            this.estadoCivil = estadoCivil;
        }

        

        
       


    }
}