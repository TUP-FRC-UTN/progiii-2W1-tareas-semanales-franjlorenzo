using ABM_Persona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABM_Persona.AccesoDeDatos;

namespace ABM_Persona.Controllers
{
    public class ListadoPersonaController : Controller
    {
        // GET: ListadoPersona
        public ActionResult ListadoPersona()
        {
            List<Persona> listaPersona = AccesoDatos_PersonaListado.ListadoPersonas();
            return View(listaPersona);
        }
    }
}