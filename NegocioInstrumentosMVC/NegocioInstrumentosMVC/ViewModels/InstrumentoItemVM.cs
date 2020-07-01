using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.ViewModels
{
    public class InstrumentoItemVM
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int stock;
        private float precio;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public float Precio { get => precio; set => precio = value; }
    }
}