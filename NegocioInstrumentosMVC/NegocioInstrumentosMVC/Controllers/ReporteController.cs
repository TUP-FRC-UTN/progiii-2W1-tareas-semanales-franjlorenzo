using NegocioInstrumentosMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentosMVC.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult ReporteInstrumento()
        {
            ReporteVM resultado = new ReporteVM();
            return View(resultado);
        }
    }
}