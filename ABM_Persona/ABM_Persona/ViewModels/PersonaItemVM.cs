using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABM_Persona.ViewModels
{
    public class PersonaItemVM
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private int edad;
        private string sexoNombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Edad { get => edad; set => edad = value; }
        public string SexoNombre { get => sexoNombre; set => sexoNombre = value; }
    }
}