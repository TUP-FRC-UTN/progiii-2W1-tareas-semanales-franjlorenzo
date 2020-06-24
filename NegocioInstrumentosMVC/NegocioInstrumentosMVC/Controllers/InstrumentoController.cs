using NegocioInstrumentosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentosMVC.Controllers
{
    public class InstrumentoController : Controller
    {
        // GET: Instrumento
        public ActionResult ListadoInstrumentos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListadoDeInstrumentos()
        {
            List<Instrumento> listaInstrumentos = AccesoDeDatos.AD_Instrumento.ObtenerListadoInstrumentos();
            return View(listaInstrumentos);
        }
    }
}