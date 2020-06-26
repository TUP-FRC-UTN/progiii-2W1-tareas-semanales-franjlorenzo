using ABM_Persona.AccesoDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABM_Persona.ViewModels.Reportes
{
    public class ReporteVM
    {
        private List<SexoItemVM> listaSexos;
        private List<PersonaItemVM> listaPersonas;

        public ReporteVM()
        {
            listaSexos = new List<SexoItemVM>();
            listaPersonas = new List<PersonaItemVM>();
            cargarVariables();
        }

        public List<SexoItemVM> ListaSexos { get => listaSexos; set => listaSexos = value; }
        public List<PersonaItemVM> ListaPersonas { get => listaPersonas; set => listaPersonas = value; }

        private void cargarVariables()
        {
            ListaSexos = AccesoDatos_Reportes.cantidadPersonasPorSexo();
            ListaPersonas = AccesoDatos_Reportes.obtenerReportePersonas();
        }
    }
}