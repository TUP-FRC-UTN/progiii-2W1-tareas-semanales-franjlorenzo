using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.ViewModels
{
    public class TipoItemVM
    {
        private int idTipo;
        private string nombreTipo;

        public int IdTipo { get => idTipo; set => idTipo = value; }
        public string NombreTipo { get => nombreTipo; set => nombreTipo = value; }
    }
}