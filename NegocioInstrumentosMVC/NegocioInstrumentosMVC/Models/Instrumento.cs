using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.Models
{
    public class Instrumento
    {
        private int idInstrumento;
        [Required]
        private string Nombre;
        [Required]
        private string Descripcion;
        [Required]
        private int Stock;
        [Required]
        private float Precio;

        private int idTipo;

        public int IdInstrumento { get => idInstrumento; set => idInstrumento = value; }
        public string pNombre { get => Nombre; set => Nombre = value; }
        public string pDescripcion { get => Descripcion; set => Descripcion = value; }
        public int pStock { get => Stock; set => Stock = value; }
        public float pPrecio { get => Precio; set => Precio = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
    }
}