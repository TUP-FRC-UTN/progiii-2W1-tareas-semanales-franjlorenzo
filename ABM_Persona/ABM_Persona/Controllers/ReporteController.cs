using ABM_Persona.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABM_Persona.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult ReportePersona()
        {
            ReporteVM resultado = new ReporteVM();
            return View(resultado);
        }
    }
}