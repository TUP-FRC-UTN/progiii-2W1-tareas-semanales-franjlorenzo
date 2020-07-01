using NegocioInstrumentosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentosMVC.Controllers
{
    public class EliminarInstrumentoController : Controller
    {
        // GET: EliminarInstrumento
        public ActionResult EliminarInstrumento(int idInstrumento)
        {
            Instrumento resultado = AccesoDeDatos.AD_EliminarInstrumento.ObtenerInstrumento(idInstrumento);
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarInstrumento(Instrumento model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AccesoDeDatos.AD_EliminarInstrumento.EliminarPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoInstrumentos", "Instrumento");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }
    }
}