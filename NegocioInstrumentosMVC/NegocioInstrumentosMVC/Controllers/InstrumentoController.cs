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
            List<Instrumento> listaInstrumentos = AccesoDeDatos.AD_ListadoInstrumento.ObtenerListadoInstrumentos();
            return View(listaInstrumentos);
        }
    }
}