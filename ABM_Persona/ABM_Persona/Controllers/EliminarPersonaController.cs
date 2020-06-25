using ABM_Persona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABM_Persona.AccesoDeDatos;

namespace ABM_Persona.Controllers
{
    public class EliminarPersonaController : Controller
    {
        // GET: EliminarPersona
        public ActionResult EliminarPersona(int idPersona)
        {
            Persona resultado = AccesoDatos_EliminarPersona.ObtenerPersona(idPersona);
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AccesoDatos_EliminarPersona.EliminarPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "ListadoPersona");
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