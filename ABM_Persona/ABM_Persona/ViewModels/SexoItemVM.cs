using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABM_Persona.ViewModels
{
    public class SexoItemVM
    {
        private int idSexo;
        private string nombre;

        public int IdSexo { get => idSexo; set => idSexo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}