using EjemploMVC.AccesoDeDatos;
using EjemploMVC.Models;
using EjemploMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona

        public ActionResult EliminarPersona(int idPersona)
        {
            Persona resultado = AD_Persona.ObtenerPersona(idPersona);
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.EliminarDatosPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult DatosPersona(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Persona.ObtenerListaSexos();
            List<SelectListItem> itemsCombo = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });

            Persona resultado = AD_Persona.ObtenerPersona(idPersona);

            foreach (var item in itemsCombo)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.items = itemsCombo;

            ViewBag.nombre = resultado.nombre + " " + resultado.apellido;
            return View(resultado);
        }

        [HttpPost]
        public ActionResult DatosPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.ActualizarDatosPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
            
        }

        public ActionResult AltaPersona()
        {
            List<SexoItemVM> listaSexos = AD_Persona.ObtenerListaSexos();
            List<SelectListItem> items = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        public ActionResult AltaPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.InsertarNuevaPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ListadoPersonas()
        {
            List<Persona> listaPersona = AD_Persona.ObtenerListaPersona();
            return View(listaPersona);
        }
    }
}