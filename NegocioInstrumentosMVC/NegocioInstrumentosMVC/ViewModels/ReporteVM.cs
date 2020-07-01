using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.ViewModels
{
    public class ReporteVM
    {
        private List<InstrumentoItemVM> listaInstrumentos;

        public List<InstrumentoItemVM> ListaInstrumentos { get => listaInstrumentos; set => listaInstrumentos = value; }

        public ReporteVM()
        {
            listaInstrumentos = new List<InstrumentoItemVM>();
            cargarVariables();
        }

        private void cargarVariables()
        {
            ListaInstrumentos = AccesoDeDatos.AD_Reporte.obtenerReporteInstrumentos();
        }
    }
}